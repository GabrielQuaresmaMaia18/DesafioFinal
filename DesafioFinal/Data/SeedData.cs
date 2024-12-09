using Microsoft.AspNetCore.Identity;
using DesafioFinal.Models;
using System.Linq;

namespace DesafioFinal.Data
{
    public class SeedData
    {
        public static void Initialize (AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "gerente",
                    Password = "123456",
                    Role = "Gerente"
                });

                context.Users.Add(new User
                {
                    Username = "funcionario",
                    Password = "123456",
                    Role = "Funcionario"
                });

                context.SaveChanges();
            }

            if (!context.Produtos.Any())
            {
                context.Produtos.Add(new Produto
                {
                    Nome = "Maça",
                    Descricao = "Fruta",
                    Preco = 2.5,
                    QuantidadeEstoque = 0
                });

                context.Produtos.Add(new Produto
                {
                    Nome = "Morango",
                    Descricao = "Fruta",
                    Preco = 1.5,
                    QuantidadeEstoque = 0
                });

                context.Produtos.Add(new Produto
                {
                    Nome = "Pera",
                    Descricao = "Fruta",
                    Preco = 3,
                    QuantidadeEstoque = 0
                });

                context.SaveChanges();
            }

        }
    }
}
