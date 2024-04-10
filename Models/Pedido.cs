namespace TesteProjetoLojaAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [StringLength(100)]
        public string UsuarioId { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DataCompra { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
    }

}
