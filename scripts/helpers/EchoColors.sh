# Colors
RED='\033[0;31m'
YELLOW='\033[1;33m'
GREEN='\033[0;32m'
BLUE='\033[0;34m'
BOLD='\033[1m'
NC='\033[0m' # No Color (reset)

print_error() {
  echo -e "${RED}❌ Error: $1${NC}"
}

print_warn() {
  echo -e "${YELLOW}⚠️ Warning: $1${NC}"
}

print_attempt() {
  echo -e "${BOLD}🔄 Attempting: $1${NC}"
}

print_success() {
  echo -e "${GREEN}✅ Success: $1${NC}"
}

print_info() {
  echo -e "${BLUE}🔎 Info: $1${NC}"
}

print() {
  echo -e "$1${NC}"
}