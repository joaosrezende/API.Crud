namespace Application.DTOs
{
    public class AddProdutoDto
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}