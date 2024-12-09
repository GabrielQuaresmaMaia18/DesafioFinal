# Desafio Final

API para gerenciamento de produtos com autenticação JWT.

## Tecnologias
- **C#** com **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server LocalDB**
- **JWT** para autenticação
- **Swagger** para documentação

## Configuração
1. Clone o repositório:
   ```bash
   git clone https://github.com/GabrielQuaresmaMaia18/DesafioFinal.git
   cd DesafioFinal
2. Configure o Banco de Dados
   No arquivo appsettings.json, configure a string de conexão para o SQL Server LocalDB ou outro banco de dados:
   "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DesafioFinalDb;Trusted_Connection=True;MultipleActiveResultSets=True;"
         }
3. Execute as Migrações
   No terminal ou no Package Manager Console do Visual Studio, execute os comandos abaixo para criar o banco de dados:
    dotnet ef database update
4. Inicie o projeto:
   dotnet run
## Autenticação
1. Geração de Token:
   POST /api/Auth/Login
   Body: { "userName": "gerente", "password": "123456" }
2. Use o token nos endpoints protegidos:
   Authorization: Bearer <seu_token_jwt>
## EndPoints
GET /api/Produto: Lista produtos (filtragem opcional por status).
POST /api/Produto: Cria produto.
PUT /api/Produto/{id}/AtualizaEstoque: Atualiza estoque (JWT).
DELETE /api/Produto/{id}: Exclui produto (JWT).

## Testes
 Acesse o Swagger em: https://localhost:5001/swagger.

## Exemplo de JSON para inserir produto:

 {
    "nome": "Maça",
    "descricao": "Fruta",
    "preco": 2.5,
    "quantidadeEstoque": 1
  }

## Exemplo de JSON para atualizar produto: 
 
 {
    "quantidadeEstoque": 1
  }
   
