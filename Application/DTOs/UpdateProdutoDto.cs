namespace Application.DTOs
{
    public class UpdateProdutoDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required decimal Preco { get; set; }
    }
}
