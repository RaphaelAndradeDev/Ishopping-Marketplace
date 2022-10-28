using Ishopping.MVC.ViewModels.User;
using System;
using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentPostViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public bool DisplayOnPage { get; set; }
        public bool DisplayOnlyPage { get; set; }
        public string Model { get; set; }
        public string Autor { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Categoria { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo1 { get; set; }
        public string Paragrafo1 { get; set; }
        public string SubTitulo2 { get; set; }
        public string Paragrafo2 { get; set; }
        public string SubTitulo3 { get; set; }
        public string Paragrafo3 { get; set; }
        public string Video { get; set; }
        public string Tags { get; set; }

        // Get IsTags
        public string _Titulo { get; set; }
        public string _SubTitulo1 { get; set; }
        public string _Paragrafo1 { get; set; }
        public string _SubTitulo2 { get; set; }
        public string _Paragrafo2 { get; set; }
        public string _SubTitulo3 { get; set; }
        public string _Paragrafo3 { get; set; }

        // Relacionamentos
        public virtual ICollection<UserImageGalleryViewModel> UserImageGallery { get; set; }

        public Guid ComponentPostOptionId { get; set; }
        public virtual ComponentPostOptionModel ComponentPostOption { get; set; }
    }

    public class ComponentPostOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Paragrafo { get; set; }
    }
}
