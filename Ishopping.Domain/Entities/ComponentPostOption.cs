using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentPostOption : _Option
    {   
        public string Autor { get; private set; }
        public string Categoria { get; private set; }
        public string Titulo { get; private set; }
        public string SubTitulo { get; private set; }
        public string Paragrafo { get; private set; }    

        //Relacionamentos
        public virtual ICollection<ComponentPost> ComponentPost { get; private set; }

        // Ctor
        protected ComponentPostOption() { }
 
        public ComponentPostOption(string userId, bool isDefault, string autor, string categoria, string titulo, string subTitulo, string paragrafo)
        {
            CommonValidate.Validate(userId); 
            Validate(autor, categoria, titulo, subTitulo, paragrafo);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Autor = autor;
            this.Categoria = categoria;
            this.Titulo = titulo;
            this.SubTitulo = subTitulo;
            this.Paragrafo = paragrafo;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string autor, string categoria, string titulo, string subTitulo, string paragrafo)
        {
            Validate(autor, categoria, titulo, subTitulo, paragrafo);

            this.Default = isDefault;
            this.Autor = autor;
            this.Categoria = categoria;
            this.Titulo = titulo;
            this.SubTitulo = subTitulo;
            this.Paragrafo = paragrafo;
        }

        private void Validate(string autor, string categoria, string titulo, string subTitulo, string paragrafo)
        {         
            AssertionConcern.AssertArgumentNotEmpty(autor, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(autor, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(categoria, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(categoria, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(titulo, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(titulo, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(subTitulo, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(subTitulo, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(paragrafo, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(paragrafo, 64, Errors.MaxLength);
        }
    }
}
