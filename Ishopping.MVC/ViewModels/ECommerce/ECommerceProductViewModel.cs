
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.ECommerce
{
    public class ECommerceProductViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public int Exibicao { get; set; }
        public string Nome { get; set; } 
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor1 { get; set; }
        public string Cor2 { get; set; }    
        public string Cor3 { get; set; }    
        public string Cor4 { get; set; }     
        public string Tamanho1 { get; set; } 
        public string Tamanho2 { get; set; } 
        public string Tamanho3 { get; set; }
        public string Tamanho4 { get; set; }
        public string Material { get; set; }
        public int Peso { get; set; }    
        public decimal Preco { get; set; }
        public decimal PrecoOff { get; set; }
        public int Desconto { get; set; }
        public int Quantidade { get; set; }
        public bool RelPorCat { get; set; }     
        public int Vendas { get; set; }
        public int Favorito { get; set; }    
        public DateTime DataCadastro { get; set; }
        public string VideoRelacionado { get; set; } 

        // Relacionamentos
        public string ECommerceProductCategoryId { get; set; }
        public virtual ECommerceProductCategory ECommerceProductCategory { get; set; }

        public string ECommerceProductGroupId { get; set; }
        public virtual ECommerceProductGroup ECommerceProductGroup { get; set; }

        public virtual ICollection<UserImageGallery> UserImageGallery { get; set; } 
    }
}
