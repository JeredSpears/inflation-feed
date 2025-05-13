#!/bin/bash
# This script automates the setup and build process for a web application using Docker Compose.

source ./scripts/helpers/LineBreak.sh
source ./scripts/helpers/EchoColors.sh

# Run compatibility checks
if ! ./scripts/CompatibilityChecks.sh; then
  print_error "Compatibility checks failed. Please resolve the issues and try again."
  exit 1
fi

show_help() {
  print_info "Usage: $0 [options]"
  print_info "Options:"
  print_info "  -h, --help       Show this help message"
  print_info "  -a, --all        Build all components (backend, frontend, database)"
  print_info "  -b, --backend    Build the backend"
  print_info "  -f, --frontend   Build the frontend"
  print_info "  -d, --database   Reset and initialize the database"
  print_info "  -s, --stop       Stop all running containers"
}

build_backend() {
  print_attempt "Cleaning and restoring the backend solution..."
  dotnet clean ./backend/Inflationfeed.Api
  dotnet restore ./backend/Inflationfeed.Api

  print_attempt "Building backend in Docker..."
  docker-compose up --build -d api --force-recreate
}

build_frontend() {
  print_attempt "Building frontend..."
  docker-compose up -d  frontend --force-recreate
}

reset_database() {
  print_attempt "Resetting database..."
  docker-compose down -v && docker-compose up -d database --force-recreate
}

build_all() {
  reset_database
  build_backend
  build_frontend
}

stop_all() {
  print_attempt "Stopping all running containers..."
  docker-compose down
}

# Parse arguments
while [[ "$#" -gt 0 ]]; do
  case $1 in
    -h|--help) show_help; exit 0 ;;
    -a|--all) build_all; exit 0 ;;
    -b|--backend) build_backend; exit 0 ;;
    -f|--frontend) build_frontend; exit 0 ;;
    -d|--database) reset_database; exit 0 ;;
    -s|--stop) stop_all; exit 0 ;;
    *) print_warn "Unknown option: $1"; show_help; exit 1 ;;
  esac
  shift
done

# Default action if no arguments are provided
show_help