using Ishopping.Mvc.Serialization.Option;
using Ishopping.Mvc.Serialization.User;
using System;
using System.Collections.Generic;

namespace Ishopping.Mvc.Serialization.Component
{
    public class ComponentPostSerialization
    {
        public Guid Id { get; set; }
        public string Autor { get;  set; }
        public string Categoria { get;  set; }
        public string Titulo { get;  set; }        
        public string SubTitulo1 { get;  set; }
        public string Paragrafo1 { get;  set; }     
        public string Video { get;  set; }
        public int Views { get; set; }
        public DateTime DataCadastro { get;  set; }

        public string IdStr { get { return this.Id.ToString(); } }
        public string DatePartDay { get { return DataCadastro.ToString("dd"); } }
        public string DatePartMonth { get { return DataCadastro.ToString("MMMM"); } }
        public string DatePartYear { get { return DataCadastro.ToString("yyyy"); } }
  
        //Relacionamentos
        public virtual ICollection<UserImageGallerySerialization> UserImageGallery { get;  set; }
        public virtual ComponentPostOptionSerialization ComponentPostOption { get;  set; }        
    }
}
