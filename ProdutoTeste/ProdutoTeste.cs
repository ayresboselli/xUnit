using Produtos;

namespace ProdutoTeste
{
    public class ProdutoTeste
    {
        private ProdutoService produtoService;

        public ProdutoTeste()
        {
            produtoService = new ();
        }

        [Fact]
        public void ListarTest()
        {
            var result = produtoService.Listar();
            Assert.IsType<List<Produto>>(result);
        }

        [Fact]
        public void BuscarTest()
        {
            var produto = produtoService.Buscar(1);
            Assert.Equal(1, produto.Id);
        }

        [Fact]
        public void InserirTest()
        {
            string nome = "Produto teste";

            var novo = new Produto { 
                Nome = nome
            };

            var produto = produtoService.Inserir(novo);

            Assert.Equal(nome, produto.Nome);
        }

        [Fact]
        public void EdotarTest()
        {
            string nome = "Produto teste 2";

            var produto = produtoService.Buscar(1);
            produto.Nome = nome;
            var produto_editado = produtoService.Editar(produto);

            Assert.Equal(nome, produto_editado.Nome);
        }

        [Fact]
        public void ExcluirTest()
        {
            Assert.True(produtoService.Delete(1));
        }
    }
}