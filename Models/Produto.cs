using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafioIbid.Models;

    //modelo que representa a tabela produto no banco de dados,
    //utilizando data annotations para definir o nome das colunas e o tipo de dado
    public class Produto
    {
        [Display(Name = "Código")]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("nome")]
        public required string Nome { get; set; }

        [Display(Name = "Tipo")]
        [Column("tipo")]

        public required string Tipo { get; set; }

        [Display(Name = "Preço")]
        [Column("preco", TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        

        
    }
