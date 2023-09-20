using Microsoft.EntityFrameworkCore;
using desafioIbid.Models;

namespace desafioIbid.Data;
public class Contexto : DbContext
{
    //o contexto é uma classe que representa o banco de dados, e é injetado no construtor do controller
    //aqui é feita a configuração do banco de dados, e é passado o nome da string de conexão
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
}
