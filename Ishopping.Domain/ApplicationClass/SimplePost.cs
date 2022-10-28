using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ishopping.Domain.ApplicationClass
{
    public class SimplePost
    {
        public Guid Id { get; set; }
        public int SiteNumber { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo1 { get; set; }
        public string Paragrafo1 { get; set; }
        public int Views { get; set; }
        public DateTime DataCadastro { get; set; }

        public string DateRegisterMonth { get { return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DataCadastro.Month); } }
                
        //Relacionamentos
        public virtual ICollection<UserImageGallery> UserImageGallery { get; set; }
                
    }
}
