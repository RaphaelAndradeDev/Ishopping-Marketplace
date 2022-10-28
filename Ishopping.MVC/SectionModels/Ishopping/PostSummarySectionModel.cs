using Ishopping.Mvc.Serialization.User;
using System;
using System.Collections.Generic;

namespace Ishopping.SectionModels.Ishopping
{
    public class PostSummarySectionModel
    {
        public string Id { get; set; }
        public string Autor { get; set; }
        public string Titulo { get;  set; }
        public string SubTitulo1 { get;  set; }

        // Format
        public string _Titulo { get { return FormatTitle(Titulo); } }
        public string _SubTitulo { get { return FormatSubTitle(SubTitulo1); } }

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
    }
}