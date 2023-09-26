namespace Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public ICollection<ClienteProduto> ClientesProdutos { get; set; }

        public Produto()
        {
            Nome = string.Empty;
            Preco = 0;
        }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public Produto(int id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
    }
}
