using Ishopping.Mvc.Serialization.User;
using System;
using System.Collections.Generic;

namespace Ishopping.SectionModels.Ishopping
{
    public class BlogItemSectionModel
    {
        public string Autor { get;  set; }
        public string Categoria { get;  set; }
        public string Titulo { get;  set; }
        public string SubTitulo1 { get;  set; }
        public string Paragrafo1 { get;  set; }  
        public DateTime DataCadastro { get;  set; }

        // Relacionamentos
        public virtual ICollection<UserImageGallerySerialization> UserImageGallery { get; set; }  
    }
}