using Ishopping.Mvc.Serialization.User;
using System;
using System.Collections.Generic;

namespace Ishopping.SectionModels.Ishopping
{
    public class SinglePostSectionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public bool IsBlock { get; set; }
        public string Model { get; set; }
        public string Autor { get;  set; }
        public string Categoria { get;  set; }
        public string Titulo { get; set; }
        public string SubTitulo1 { get;  set; }
        public string Paragrafo1 { get;  set; }
        public string SubTitulo2 { get;  set; }
        public string Paragrafo2 { get;  set; }
        public string SubTitulo3 { get;  set; }
        public string Paragrafo3 { get;  set; }
        public string Video { get;  set; }
        public DateTime DataCadastro { get;  set; }
        public int Views { get;  set; }

        public string _DataCadastro { get { return DataCadastro.ToShortDateString(); } }

        // Relacionamentos
        public virtual ICollection<UserImageGallerySerialization> UserImageGallery { get; set; }      
    }
}