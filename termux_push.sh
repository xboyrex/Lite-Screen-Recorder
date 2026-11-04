#!/data/data/com.termux/files/usr/bin/bash
# Lite Screen Recorder — safe GitHub bootstrap for Termux
# Creates/pushes the project to the authenticated GitHub account.
# No force-push. No token embedded in Git remote URLs.

set -Eeuo pipefail
IFS=$'\n\t'

readonly REPO_NAME="Lite-Screen-Recorder"
readonly DESCRIPTION="Lite Screen Recorder v2.0 Pro — Windows desktop screen and audio recorder."
readonly RELEASE_TAG="v2.0.0"
readonly EXPECTED_OWNER="xboyrex"

PROJECT_DIR="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
cd "$PROJECT_DIR"

RED='\033[1;31m'
GREEN='\033[1;32m'
YELLOW='\033[1;33m'
CYAN='\033[1;36m'
RESET='\033[0m'

info() { printf "${CYAN}[INFO]${RESET} %s\n" "$*"; }
ok()   { printf "${GREEN}[OK]${RESET} %s\n" "$*"; }
warn() { printf "${YELLOW}[WARN]${RESET} %s\n" "$*"; }
die()  { printf "${RED}[ERROR]${RESET} %s\n" "$*" >&2; exit 1; }

on_error() {
    local code=$?
    printf "\n${RED}[FAILED]${RESET} Script stopped at line %s (exit %s). No force-push was performed.\n" \
        "${BASH_LINENO[0]:-unknown}" "$code" >&2
    exit "$code"
}
trap on_error ERR

# 1. Validate that this script is running from the extracted project root.
[[ -f "Lite-Screen-Recorder.sln" ]] ||
    die "Lite-Screen-Recorder.sln not found. Run this script from ~/projects/Lite-Screen-Recorder."
[[ -f "quick-screen-recorder/quick-screen-recorder.csproj" ]] ||
    die "C# project file not found; this does not look like the project root."
[[ -f "termux_push.sh" ]] ||
    die "termux_push.sh not found in the current project directory."

# 2. Install missing Termux tools only.
if command -v pkg >/dev/null 2>&1; then
    missing=()
    for command_name in git gh curl; do
        command -v "$command_name" >/dev/null 2>&1 || missing+=("$command_name")
    done

    if ((${#missing[@]} > 0)); then
        info "Installing missing Termux packages: ${missing[*]}"
        pkg update -y
        pkg install -y "${missing[@]}"
    fi
fi

for command_name in git gh; do
    command -v "$command_name" >/dev/null 2>&1 ||
        die "$command_name is missing. Install it with: pkg install $command_name"
done

# 3. GitHub CLI authentication.
if ! gh auth status --hostname github.com >/dev/null 2>&1; then
    printf "${YELLOW}GitHub login required.${RESET}\n"
    printf "Enter a GitHub token with repository creation and contents write permissions.\n"
    read -r -s -p "GitHub token: " GH_TOKEN
    printf "\n"
    [[ -n "${GH_TOKEN:-}" ]] || die "No GitHub token supplied."
    printf '%s' "$GH_TOKEN" |
        gh auth login --hostname github.com --git-protocol https --with-token
    unset GH_TOKEN
fi

# Ensure Git can obtain HTTPS credentials from GitHub CLI.
gh auth setup-git

OWNER="$(gh api user --jq '.login')"
[[ -n "$OWNER" ]] || die "Could not read the authenticated GitHub username."
FULL_REPO="${OWNER}/${REPO_NAME}"
REPO_URL="https://github.com/${FULL_REPO}.git"

info "Authenticated GitHub account: ${OWNER}"
info "Target repository: https://github.com/${FULL_REPO}"

# The app's updater currently expects the xboyrex repository owner.
if [[ "$OWNER" != "$EXPECTED_OWNER" ]]; then
    warn "The app updater is configured for owner '${EXPECTED_OWNER}', but you are authenticated as '${OWNER}'."
    read -r -p "Continue with this different owner? [y/N]: " answer
    [[ "${answer,,}" == "y" || "${answer,,}" == "yes" ]] ||
        die "Cancelled to avoid publishing with a mismatched updater configuration."
fi

# 4. Initialise Git BEFORE running any local git config command.
# This ordering fixes: 'fatal: not in a git directory'.
if git rev-parse --is-inside-work-tree >/dev/null 2>&1; then
    info "Existing valid Git repository detected."
else
    if [[ -e ".git" ]]; then
        backup_dir=".git.invalid-backup.$(date +%Y%m%d-%H%M%S)"
        warn "Invalid Git metadata found at .git; preserving it as ${backup_dir}"
        mv -- ".git" "$backup_dir"
    fi

    info "Initialising a fresh Git repository..."
    git init
fi

git rev-parse --is-inside-work-tree >/dev/null 2>&1 ||
    die "Git repository initialisation failed. Check directory permissions and .git metadata."

# All local Git configuration is deliberately AFTER git init.
git config --local user.name "Mayank Droid"
git config --local user.email "xboyrex496@gmail.com"
git config --local init.defaultBranch main
git branch -M main
ok "Git repository initialised and local identity configured."

# 5. Ensure build/editor outputs are not accidentally committed.
if [[ ! -f ".gitignore" ]]; then
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
    info "Created a basic .gitignore."
fi

# 6. Stage and commit project files.
git add -A

if ! git diff --cached --quiet; then
    git commit -m "feat: Lite Screen Recorder v2.0 Pro"
else
    info "No staged changes; keeping the current commit."
fi

# Refuse to push an empty repository.
git rev-parse --verify HEAD >/dev/null 2>&1 ||
    die "No commit exists. Check that the project files were staged correctly."

# 7. Create the remote repository only when it does not already exist.
if gh api "repos/${FULL_REPO}" >/dev/null 2>&1; then
    info "GitHub repository already exists; not recreating it."
else
    info "Creating public GitHub repository..."
    gh repo create "$FULL_REPO" \
        --public \
        --description "$DESCRIPTION"
    ok "GitHub repository created."
fi

# 8. Add or validate origin. Never silently replace a different remote.
if git remote get-url origin >/dev/null 2>&1; then
    CURRENT_ORIGIN="$(git remote get-url origin)"
    case "$CURRENT_ORIGIN" in
        "$REPO_URL"|"git@github.com:${FULL_REPO}.git")
            info "Existing origin is correct."
            ;;
        *)
            die "Origin already points to '${CURRENT_ORIGIN}'. Expected '${REPO_URL}'. Fix it manually; script will not overwrite it."
            ;;
    esac
else
    git remote add origin "$REPO_URL"
fi

# 9. Push main normally. A non-fast-forward error is intentionally not bypassed.
info "Pushing main branch (normal, non-force push)..."
git push --set-upstream origin main
ok "main branch pushed."

# 10. Create/push release tag only when it does not already exist remotely.
REMOTE_TAG="$(git ls-remote --tags origin "refs/tags/${RELEASE_TAG}" | head -n 1 || true)"

if [[ -n "$REMOTE_TAG" ]]; then
    warn "Remote tag ${RELEASE_TAG} already exists; leaving it unchanged."
else
    if git show-ref --verify --quiet "refs/tags/${RELEASE_TAG}"; then
        LOCAL_TAG_COMMIT="$(git rev-list -n 1 "$RELEASE_TAG")"
        HEAD_COMMIT="$(git rev-parse HEAD)"
        [[ "$LOCAL_TAG_COMMIT" == "$HEAD_COMMIT" ]] ||
            die "Local tag ${RELEASE_TAG} points to another commit. It will not be overwritten."
    else
        git tag -a "$RELEASE_TAG" -m "Lite Screen Recorder ${RELEASE_TAG}"
    fi

    info "Pushing release tag ${RELEASE_TAG}..."
    git push origin "refs/tags/${RELEASE_TAG}"
    ok "Release tag pushed."
fi

printf "\n${GREEN}============================================${RESET}\n"
printf "${GREEN}GitHub deployment commands completed.${RESET}\n"
printf "Repository: https://github.com/%s\n" "$FULL_REPO"
printf "Actions:    https://github.com/%s/actions\n" "$FULL_REPO"
printf "Releases:   https://github.com/%s/releases\n" "$FULL_REPO"
printf "${GREEN}============================================${RESET}\n"
printf "\n"
printf "Check GitHub Actions to confirm the Windows build and release succeeded.\n"
