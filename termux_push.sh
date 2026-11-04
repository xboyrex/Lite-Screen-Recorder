#!/data/data/com.termux/files/usr/bin/bash
# Lite Screen Recorder — robust Termux GitHub deploy script
# Safe sync/rebase + normal push. Never force-pushes or overwrites remote tags.

set -Eeuo pipefail
IFS=$'\n\t'

readonly REPO_NAME="Lite-Screen-Recorder"
readonly DESCRIPTION="Lite Screen Recorder v2.0 Pro — Windows desktop screen and audio recorder."
readonly DEFAULT_RELEASE_TAG="v2.0.0"
readonly EXPECTED_OWNER="xboyrex"

PROJECT_DIR="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
cd "$PROJECT_DIR"

RED='\033[1;31m'; GREEN='\033[1;32m'; YELLOW='\033[1;33m'; CYAN='\033[1;36m'; RESET='\033[0m'
info(){ printf "${CYAN}[INFO]${RESET} %s\n" "$*"; }
ok(){ printf "${GREEN}[OK]${RESET} %s\n" "$*"; }
warn(){ printf "${YELLOW}[WARN]${RESET} %s\n" "$*"; }
die(){ printf "${RED}[ERROR]${RESET} %s\n" "$*" >&2; exit 1; }

on_error() {
  local code=$?
  printf "\n${RED}[FAILED]${RESET} Command failed (exit %s). No force-push was performed.\n" "$code" >&2
  exit "$code"
}
trap on_error ERR

# Validate project root.
[[ -f "Lite-Screen-Recorder.sln" ]] || die "Lite-Screen-Recorder.sln not found. Run from the extracted project root."
[[ -f "quick-screen-recorder/quick-screen-recorder.csproj" ]] || die "C# project file missing."
[[ -f ".github/workflows/build.yml" ]] || die "GitHub Actions workflow missing."

# Install missing Termux packages.
if command -v pkg >/dev/null 2>&1; then
  missing=()
  for cmd in git gh; do command -v "$cmd" >/dev/null 2>&1 || missing+=("$cmd"); done
  if ((${#missing[@]})); then
    info "Installing: ${missing[*]}"
    pkg update -y
    pkg install -y "${missing[@]}"
  fi
fi
command -v git >/dev/null 2>&1 || die "git is required: pkg install git"
command -v gh >/dev/null 2>&1 || die "GitHub CLI is required: pkg install gh"

# Authenticate GitHub CLI. Token is never inserted into the remote URL.
if ! gh auth status --hostname github.com >/dev/null 2>&1; then
  printf "${YELLOW}GitHub authentication required.${RESET}\n"
  printf "Use a token with permission to create repositories and write repository contents.\n"
  read -r -s -p "GitHub token: " GH_TOKEN
  printf "\n"
  [[ -n "${GH_TOKEN:-}" ]] || die "No token supplied."
  printf '%s' "$GH_TOKEN" | gh auth login --hostname github.com --git-protocol https --with-token
  unset GH_TOKEN
fi
gh auth setup-git

OWNER="$(gh api user --jq '.login')"
[[ -n "$OWNER" ]] || die "Could not determine GitHub account."
FULL_REPO="${OWNER}/${REPO_NAME}"
REMOTE_URL="https://github.com/${FULL_REPO}.git"

info "Authenticated account: ${OWNER}"
info "Target repository: https://github.com/${FULL_REPO}"

if [[ "$OWNER" != "$EXPECTED_OWNER" ]]; then
  warn "App updater currently expects repository owner '${EXPECTED_OWNER}', but authenticated owner is '${OWNER}'."
  read -r -p "Continue anyway? [y/N]: " answer
  [[ "${answer,,}" == "y" || "${answer,,}" == "yes" ]] || die "Cancelled."
fi

# IMPORTANT: initialise Git before any git config invocation.
if git rev-parse --is-inside-work-tree >/dev/null 2>&1; then
  info "Valid local Git repository detected."
else
  if [[ -e ".git" ]]; then
    backup=".git.invalid-backup.$(date +%Y%m%d-%H%M%S)"
    warn "Invalid .git metadata preserved as ${backup}"
    mv -- ".git" "$backup"
  fi
  git init
fi
git rev-parse --is-inside-work-tree >/dev/null 2>&1 || die "git init did not create a valid repository."

git config --local user.name "Mayank Droid"
git config --local user.email "xboyrex496@gmail.com"
git config --local init.defaultBranch main
git branch -M main

# Add safe defaults only if project .gitignore is absent.
if [[ ! -f .gitignore ]]; then
  cat > .gitignore <<'GITIGNORE'
.vs/
*.suo
*.user
*.userosscache
*.sln.docstates
[Bb]in/
[Oo]bj/
[Dd]ebug/
[Rr]elease/
artifacts/
release_artifacts/
TestResults/
.DS_Store
Thumbs.db
*.swp
*.tmp
.env
.env.*
*.token
GITIGNORE
fi

# Ensure remote repository exists.
if gh api "repos/${FULL_REPO}" >/dev/null 2>&1; then
  info "GitHub repository exists."
else
  info "Creating public GitHub repository..."
  gh repo create "$FULL_REPO" --public --description "$DESCRIPTION"
  ok "Repository created."
fi

# Do not silently replace an unrelated origin.
if git remote get-url origin >/dev/null 2>&1; then
  current_origin="$(git remote get-url origin)"
  case "$current_origin" in
    "$REMOTE_URL"|"git@github.com:${FULL_REPO}.git") ;;
    *) die "origin points to '${current_origin}', expected '${REMOTE_URL}'. Fix origin manually." ;;
  esac
else
  git remote add origin "$REMOTE_URL"
fi

# Stage and commit current project changes, including this deployment script.
git add -A
if ! git diff --cached --quiet; then
  git commit -m "chore: update Lite Screen Recorder project"
else
  info "No new local changes to commit."
fi
git rev-parse --verify HEAD >/dev/null 2>&1 || die "No local commit exists."

# Fetch and reconcile local/remote history safely.
info "Fetching origin/main..."
git fetch origin main

if git show-ref --verify --quiet refs/remotes/origin/main; then
  LOCAL_HEAD="$(git rev-parse HEAD)"
  REMOTE_HEAD="$(git rev-parse origin/main)"

  if [[ "$LOCAL_HEAD" == "$REMOTE_HEAD" ]]; then
    info "Local main already matches origin/main."
  elif git merge-base --is-ancestor origin/main HEAD; then
    info "Local main is ahead of origin/main; ready to push."
  elif git merge-base --is-ancestor HEAD origin/main; then
    info "Remote main is ahead; rebasing local commits onto origin/main..."
    if ! git rebase origin/main; then
      warn "Automatic rebase hit conflicts. Aborting rebase safely; local commits remain."
      git rebase --abort || true
      printf "\nResolve manually with:\n"
      printf "  git fetch origin\n"
      printf "  git rebase origin/main\n"
      printf "  # resolve conflicts, then git add <files> && git rebase --continue\n"
      printf "  git push origin main\n"
      exit 2
    fi
    ok "Rebase completed."
  else
    info "Local and remote histories diverged; attempting safe rebase..."
    if ! git rebase origin/main; then
      warn "Rebase conflicts detected. Aborting safely; no remote changes were made."
      git rebase --abort || true
      printf "\nInspect conflicts/history and resolve manually:\n"
      printf "  git log --oneline --graph --decorate --all -20\n"
      printf "  git fetch origin\n"
      printf "  git rebase origin/main\n"
      printf "  # resolve conflicts, then git add <files> && git rebase --continue\n"
      printf "  git push origin main\n"
      exit 2
    fi
    ok "Diverged history rebased successfully."
  fi
else
  warn "Remote main does not exist yet; first push will create it."
fi

# Final normal push. If another client pushes concurrently, fetch/rebase and retry once.
info "Pushing main (normal non-force push)..."
if ! git push -u origin main; then
  warn "Push rejected, likely because remote changed during deployment. Fetching and rebasing once..."
  git fetch origin main
  if ! git rebase origin/main; then
    warn "Rebase conflict after concurrent remote update. Aborting safely."
    git rebase --abort || true
    die "Resolve remote changes manually; no force push was attempted."
  fi
  git push -u origin main
fi
ok "main branch successfully pushed."

# Optional release tag: default v2.0.0. Existing remote tags are never overwritten.
printf "\n"
read -r -p "Push release tag ${DEFAULT_RELEASE_TAG}? [y/N]: " tag_answer
if [[ "${tag_answer,,}" == "y" || "${tag_answer,,}" == "yes" ]]; then
  RELEASE_TAG="$DEFAULT_RELEASE_TAG"
  if git ls-remote --exit-code --tags origin "refs/tags/${RELEASE_TAG}" >/dev/null 2>&1; then
    warn "Remote tag ${RELEASE_TAG} already exists; leaving it untouched."
    printf "For a new release, create a new tag (for example v2.0.1) from GitHub Actions workflow_dispatch.\n"
  else
    if git show-ref --verify --quiet "refs/tags/${RELEASE_TAG}"; then
      local_tag_commit="$(git rev-list -n 1 "$RELEASE_TAG")"
      current_commit="$(git rev-parse HEAD)"
      [[ "$local_tag_commit" == "$current_commit" ]] || die "Local ${RELEASE_TAG} tag points to another commit; refusing to overwrite."
    else
      git tag -a "$RELEASE_TAG" -m "Lite Screen Recorder ${RELEASE_TAG}"
    fi
    git push origin "refs/tags/${RELEASE_TAG}"
    ok "Tag ${RELEASE_TAG} pushed."
  fi
else
  info "Release tag skipped. Push to main still triggers the CI build and Actions artifact upload."
fi

printf "\n${GREEN}============================================${RESET}\n"
printf "${GREEN}Deployment completed successfully.${RESET}\n"
printf "Repository: https://github.com/%s\n" "$FULL_REPO"
printf "Actions:    https://github.com/%s/actions\n" "$FULL_REPO"
printf "Releases:   https://github.com/%s/releases\n" "$FULL_REPO"
printf "${GREEN}============================================${RESET}\n"
printf "Check Actions for the actual Windows EXE/MSI/ZIP build result.\n"
