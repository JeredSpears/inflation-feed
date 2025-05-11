# inflation-feed
tracking pricing information for grocery stores

## Table of Contents

- [inflation-feed](#inflation-feed)
  - [Table of Contents](#table-of-contents)
  - [Installation](#installation)
  - [Usage](#usage)
  - [Contributing](#contributing)
  - [License](#license)

## Getting Started

#### Prerequisites
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

3. Check your docker to confirm everything is running (I like to check docker desktop ui)
```bash
docker ps
```

4. Go to the web app and confirm you can see the data
[https://localhost:3000](https://localhost:3000)

To test the API, you can use Postman @ [https://localhost:5000](https://localhost:5000)