using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Produtos
{
    public class ProdutoService
    {
        private List<Produto> produtos;

        public ProdutoService() {
            produtos = new();

            produtos.Add(new Produto
            {
                Id = 1,
                Nome = "Primeiro produto",
                Descricao = "Descrição do primeiro produto",
                Quantidade = 15
            });
            produtos.Add(new Produto
            {
                Id = 1,
                Nome = "Segundo produto",
                Descricao = "Descrição do segundo produto",
                Quantidade = 18
            });
            produtos.Add(new Produto
            {
                Id = 1,
                Nome = "Terceiro produto",
                Descricao = "Descrição do terceiro produto",
                Quantidade = 9
            });
            produtos.Add(new Produto
            {
                Id = 1,
                Nome = "Quarto produto",
                Descricao = "Descrição do quarto produto",
                Quantidade = 50
            });
        }

        public ICollection<Produto> Listar()
        {
            return produtos;
        }

        public Produto? Buscar(int id)
        {
            return produtos.Find(p => p.Id.Equals(id));
        }

        public Produto Inserir(Produto produto)
        {
            produto.Id = produtos.Count > 0 ? produtos.Last().Id + 1 : 1;
            
            produtos.Add(produto);

            return produto;
        }

        public Produto? Editar(Produto produto)
        {
            var local = produtos.Find(p => p.Id.Equals(produto.Id));
            
            if (local != null)
            {
                int index = produtos.IndexOf(local);
                local.Nome = produto.Nome;
                local.Descricao = produto.Descricao;
                local.Preco = produto.Preco;
                local.Quantidade = produto.Quantidade;
                local.Ativo = produto.Ativo;

                produtos[index] = local;

                return produtos[index];
            }

            return null;
        }

        public bool Delete(int id)
        {
            var local = produtos.Find(p => p.Id.Equals(id));
            if (local == null) return false;

            return produtos.Remove(local);
        }
    }
}
