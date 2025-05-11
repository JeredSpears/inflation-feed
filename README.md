# inflation-feed
tracking pricing information for grocery stores

## Table of Contents

## Getting Started

### Prerequisites
- .NET 8.0
- Docker
- Node

1. Clone the repository
```bash
git clone git@github.com:JeredSpears/inflation-feed.git
cd inflation-feed
```

2. Initalize everything
```bash
./setup.sh --all
```

3. Check your docker to confirm everything is running
```bash
docker ps
```

4. Go to the web app and confirm you can see the data
[https://localhost:3000](https://localhost:3000)



run: (for now) docker-compose up --build (seriously I think this might not be worth, a bash script is probably better)