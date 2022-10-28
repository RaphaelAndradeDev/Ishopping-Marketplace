using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.ApplicationClass
{
    public class SinglePost
    {
        public Guid Id { get; set; }
        public int SiteNumber { get; set; }
        public string Model { get; set; }
        public string Autor { get; set; }
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
        public DateTime DataCadastro { get; set; }
        public int Views { get; set; }

        // Get IsTags
        public string _Titulo { get { return IsHtmlTags.GetTags(Titulo); } }
        public string _SubTitulo1 { get { return IsHtmlTags.GetTags(SubTitulo1); } }
        public string _Paragrafo1 { get { return IsHtmlTags.GetTags(Paragrafo1); } }
        public string _SubTitulo2 { get { return IsHtmlTags.GetTags(SubTitulo2); } }
        public string _Paragrafo2 { get { return IsHtmlTags.GetTags(Paragrafo2); } }
        public string _SubTitulo3 { get { return IsHtmlTags.GetTags(SubTitulo3); } }
        public string _Paragrafo3 { get { return IsHtmlTags.GetTags(Paragrafo3); } }


        //Relacionamentos
        public virtual ICollection<UserImageGallery> UserImageGallery { get; set; }
    }
}
