using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ClienteProduto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public ClienteProduto(Guid clienteId, int produtoId)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
        }

        public ClienteProduto()
        {
        }
    }
}
