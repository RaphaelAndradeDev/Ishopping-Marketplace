using System;

namespace Ishopping.MVC.ViewModels.ECommerce
{
    public class ECommerceProductSoldViewModel
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
        public string ECommerceShoppingListId { get; set; }
        public virtual ECommerceShoppingListViewModel ECommerceShoppingList { get; set; }
    }
}
