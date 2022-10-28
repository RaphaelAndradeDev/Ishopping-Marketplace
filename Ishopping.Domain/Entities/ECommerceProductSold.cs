using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Entities
{
    public class ECommerceProductSold
    {
        public Guid Id { get; set; }
        public int ProdutoId { get; set; }          // id original do produto
        public string Nome { get; set; }
        public string Img1FileName { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Desconto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get { return Preco * Quantidade; } }
        public DateTime DataCadastro { get; set; }
        public Guid ECommerceShoppingListId { get; set; }
        public virtual ECommerceShoppingList ECommerceShoppingList { get; set; }
    }
}
