# DigitalCircleCRUD

Teste técnico para DigitalCircle envolvendo backend em ASP.NET Core e frontend em Angular.

## Estrutura do Projeto

- **Backend**: Localizado na pasta `backend/DigitalCircle.Backend`.
- **Frontend**: Localizado na pasta `frontend/digitalcircle-frontend`.

---

## Pré-requisitos

Ferramentas necessárias:

- **.NET SDK** (versão compatível com o projeto, ex.: `.NET 8.0`)
- **Node.js** (recomendado: versão 18 ou superior)

---

## Configuração do ambiente

### Frontend

No arquivo frontend/digitalcircle-frontend `frontend/digitalcircle-frontend/src/environments/environment.ts`, o valor da URL da API está configurado como
apiUrl: 'https://localhost:7228', que é onde o back vai rodar, caso não é só ajustar
o valor da url.

## Execução

### Backend

1. Navegar até a pasta do backend: `cd backend/DigitalCircle.Backend` executar:

- dotnet restore
- dotnet ef database update (caso não tenha o arquivo database.db)
- dotnet run

O backend estará disponível em: https://localhost:7228

### Frontend

1. Navegar até a pasta do frontend: `cd frontend/digitalcircle-frontend` executar:

- npm install
- npx ng serve

O frontend estará disponível em: http://localhost:4200

## Detalhes do Banco de Dados

O banco de dados SQLite é utilizado, com o arquivo database.db incluído no repositório. A base de dados a tabela e os campos são são criada por meio de migrations do Entity Framework Core.

A tabela TB01 é definida da seguinte forma:
public class TB01:

```csharp
{
[Column("id")]
public int Id { get; set; }

    [Column("col_texto")]
    public string ColText { get; set; } = string.Empty;

    [Column("col_dt")]
    public DateTime ColDt { get; set; } = DateTime.Now;

}
```

onde os compos serão id, col_texto, col_dt respectivamente.

Depois foi criado o contexto para o ef core:

```csharp
public class AppDbContext : DbContext
{
    public DbSet<TB01> TB01 { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
```

é injetado container de injecão de dependencias com o nome do arquivo a ser criado:

```csharp
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=database.db"));
```

para assim ser criada usando sqlLite e gerada a partir das migrations, utilizando o comando:

- dotnet ef migrations add InitialMigration
- dotnet ef database update
