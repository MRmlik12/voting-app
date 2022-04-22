# Voting app

## Run project
Requirements:
* Docker with compose
* .NET 6
* Node.js >= 16

```bash
$ docker-compose -f docker=compose.dev.yml up -d
```

in `backend`
```bash
$ dotnet restore
$ dotnet run --project VotingApp.Api
```

in `frontend`
```bash
$ yarn
$ yarn build
$ yarn start
```


## Run release
```bash
$ docker-compose -f docker-compose.prod.yml up -d
```
