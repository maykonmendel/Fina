# Fina

Projeto desenvolvido na Jornada Fullstack do balta.io


## Stack utilizada

**Front-end:** 
- Blazor WebAssembly
- MudBlazor

**Back-end:** 
- ASP.NET Minimal API
- Entity Framework Core 8
- SQL Server

## Rodando localmente

- Clone o projeto:

```bash
  git clone https://github.com/maykonmendel/Fina.git
```

- Entre no diretório principal e instale as dependências:

```bash
  dotnet clean  
  dotnet restore
```

- Entre no diretório do projeto Fina.API e inicie o servidor

```bash
  cd Fina/Fina.API
  dotnet watch run
```

- Entre no diretório do projeto Fina.Client e inicie o cliente

```bash
  cd Fina/Fina.Client
  dotnet watch run
```

