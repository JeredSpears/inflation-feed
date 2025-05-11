#!/bin/bash

source ./scripts/helpers/EchoColors.sh

# Check if Node.js is installed
if ! command -v node &> /dev/null; then
  print_warn "Node.js is not installed. Please install it to proceed."
  exit 1
else
  print_success "Node.js is installed."
fi

# Check if Docker is running
if ! docker info > /dev/null 2>&1; then
  print_warn "Docker is not running. Please start Docker to proceed."
  exit 1
else
  print_success "Docker is running."
fi

# Check if .NET 8 is installed
if ! dotnet --list-sdks | grep -q '^8\.'; then
  print_warn ".NET 8 is not installed. Please install it to proceed."
  exit 1
else
  print_success ".NET 8 is installed."
fi

print_success "All compatibility checks passed. You are all ready!"