using Ishopping.Mvc.Serialization.User;
using System;
using System.Collections.Generic;

namespace Ishopping.ViewModels.Ishopping
{
    public class BlogViewModel
    {
        public Guid Id { get; set; }      
        public int SiteNumber { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo1 { get; set; }
        public string Paragrafo1 { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Views { get; set; }

        // Format
        public string _Id { get { return Id.ToString(); } }
        public string _Titulo { get { return FormatTitle(Titulo); } }
        public string _SubTitulo { get { return FormatSubTitle(SubTitulo1); } }
        public string _Paragrafo { get { return FormatParagraph(Paragrafo1); } }
               
        // Relacionamentos
        public virtual ICollection<UserImageGallerySerialization> UserImageGallery { get; set; }


        // Private Methods
        private string FormatTitle(string titulo)
        {
            if (titulo.Length > 65)
                return titulo.Substring(0, 64) + " ...";
            return titulo;
        }

        private string FormatSubTitle(string subTitulo)
        {
            if (subTitulo.Length > 128)
                return subTitulo.Substring(0, 127) + " ...";
            return subTitulo;
        }

        private string FormatParagraph(string paragraph)
        {
            if (paragraph.Length > 350)
                return paragraph.Substring(0, 349) + " ...";
            return paragraph;
        }
    }
}