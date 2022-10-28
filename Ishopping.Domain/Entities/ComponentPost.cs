using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentPost : _Component
    {
        public bool IsBlock { get; private set; }
        public bool DisplayOnPage { get; private set; }
        public bool DisplayOnlyPage { get; private set; }
        public string Model { get; private set; }
        public string Autor { get; private set; }
        public string Categoria { get; private set; }
        public string Titulo { get; private set; }   
        public string SubTitulo1 { get; private set; }
        public string Paragrafo1 { get; private set; }
        public string SubTitulo2 { get; private set; }
        public string Paragrafo2 { get; private set; }
        public string SubTitulo3 { get; private set; }
        public string Paragrafo3 { get; private set; }
        public string Video { get; private set; }
        public string Tags { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int Views { get; private set; }

        // Get IsTags
        public string _Titulo { get { return IsHtmlTags.GetTags(Titulo); } }
        public string _SubTitulo1 { get { return IsHtmlTags.GetTags(SubTitulo1); } }
        public string _Paragrafo1 { get { return IsHtmlTags.GetTags(Paragrafo1); } }
        public string _SubTitulo2 { get { return IsHtmlTags.GetTags(SubTitulo2); } }
        public string _Paragrafo2 { get { return IsHtmlTags.GetTags(Paragrafo2); } }
        public string _SubTitulo3 { get { return IsHtmlTags.GetTags(SubTitulo3); } }
        public string _Paragrafo3 { get { return IsHtmlTags.GetTags(Paragrafo3); } }
  

        //Relacionamentos
        public virtual ICollection<UserImageGallery> UserImageGallery { get; private set; }

        public Guid ComponentPostOptionId { get; private set; }
        public virtual ComponentPostOption ComponentPostOption { get; private set; }

        // Ctor
        protected ComponentPost() { }

        public ComponentPost(string userId, int siteNumber, bool isBlock, ICollection<UserImageGallery> userImageGallery, Guid componentPostOptionId, bool displayOnPage, bool displayOnlyPage, string model, string titulo, string paragrafo1, string autor = "",
             string categoria = "", string subTitulo1 = "", string subTitulo2 = "", string paragrafo2 = "", string subTitulo3 = "", string paragrafo3 = "", string video = "", string tags = "")
        {
            CommonValidate.Validate(userId, siteNumber);  
            Validate(model, titulo, paragrafo1, autor, categoria, subTitulo1, subTitulo2, paragrafo2, subTitulo3, paragrafo3, video, tags);

            IdUser = userId;
            SiteNumber = siteNumber;
            Model = model;
            IsBlock = isBlock;
            DisplayOnPage = displayOnPage;
            DisplayOnlyPage = displayOnlyPage;
            UserImageGallery = userImageGallery;
            ComponentPostOptionId = componentPostOptionId;
            Autor = autor;
            Categoria = categoria;
            Video = video;
            Tags = IsTags.Join(tags);
            DataCadastro = DateTime.Now;
            LastChange = DateTime.Now;

            Titulo = IsHtmlTags.SetTags(titulo);
            Search = IsHtmlTags.RemoveTags(titulo);
            Paragrafo1 = IsHtmlTags.SetTags(paragrafo1);
            SubTitulo1 = IsHtmlTags.SetTags(subTitulo1);
            SubTitulo2 = IsHtmlTags.SetTags(subTitulo2);
            Paragrafo2 = IsHtmlTags.SetTags(paragrafo2);
            SubTitulo3 = IsHtmlTags.SetTags(subTitulo3);
            Paragrafo3 = IsHtmlTags.SetTags(paragrafo3);                       
        }

        public ComponentPost(string userId, int siteNumber, bool isBlock, ICollection<UserImageGallery> userImageGallery, ComponentPostOption componentPostOption, bool displayOnPage, bool displayOnlyPage, string model, string titulo, string paragrafo1, string autor = "",
             string categoria = "", string subTitulo1 = "", string subTitulo2 = "", string paragrafo2 = "", string subTitulo3 = "", string paragrafo3 = "", string video = "", string tags = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(model, titulo, paragrafo1, autor, categoria, subTitulo1, subTitulo2, paragrafo2, subTitulo3, paragrafo3, video, tags);

            IdUser = userId;
            SiteNumber = siteNumber;
            Model = model;
            IsBlock = isBlock;
            DisplayOnPage = displayOnPage;
            DisplayOnlyPage = displayOnlyPage;
            UserImageGallery = userImageGallery;
            ComponentPostOption = componentPostOption;
            Autor = autor;
            Categoria = categoria;
            Video = video;
            Tags = IsTags.Join(tags);
            DataCadastro = DateTime.Now;

            Titulo = IsHtmlTags.SetTags(titulo);
            Search = IsHtmlTags.RemoveTags(titulo);
            Paragrafo1 = IsHtmlTags.SetTags(paragrafo1);
            SubTitulo1 = IsHtmlTags.SetTags(subTitulo1);
            SubTitulo2 = IsHtmlTags.SetTags(subTitulo2);
            Paragrafo2 = IsHtmlTags.SetTags(paragrafo2);
            SubTitulo3 = IsHtmlTags.SetTags(subTitulo3);
            Paragrafo3 = IsHtmlTags.SetTags(paragrafo3);
        }        
        
        // Methods
        public void AddComponentPostOption(ComponentPostOption componentPostOption)
        {
            ComponentPostOption = componentPostOption;
        }

        public void ChangeComponentPostOption(Guid componentPostOptionId)
        {
            ComponentPostOptionId = componentPostOptionId;
        }

        public void AddListUserImageGallery(ICollection<UserImageGallery> userImageGallery)
        {
            UserImageGallery = userImageGallery;                     
        } 

        public void AddView()
        {
            Views++;
        }

        public void SetIsBlock(bool isBlock)
        {
            IsBlock = isBlock;
        }

        public void Change(ICollection<UserImageGallery> userImageGallery, bool displayOnPage, bool displayOnlyPage, string model, string titulo, string paragrafo1, string autor = "", string categoria = "",
              string subTitulo1 = "", string subTitulo2 = "", string paragrafo2 = "", string subTitulo3 = "", string paragrafo3 = "", string video = "", string tags = "")
        {
            Validate(model, titulo, paragrafo1, autor, categoria, subTitulo1, subTitulo2, paragrafo2, subTitulo3, paragrafo3, video, tags);

            UserImageGallery = userImageGallery;
            DisplayOnPage = displayOnPage;
            DisplayOnlyPage = displayOnlyPage;
            Model = model;
            Autor = autor;
            Categoria = categoria;
            Video = video;
            Tags = IsTags.Join(tags);
            DataCadastro = DateTime.Now;

            Titulo = IsHtmlTags.SetTags(titulo);
            Search = IsHtmlTags.RemoveTags(titulo);
            Paragrafo1 = IsHtmlTags.SetTags(paragrafo1);
            SubTitulo1 = IsHtmlTags.SetTags(subTitulo1);
            SubTitulo2 = IsHtmlTags.SetTags(subTitulo2);
            Paragrafo2 = IsHtmlTags.SetTags(paragrafo2);
            SubTitulo3 = IsHtmlTags.SetTags(subTitulo3);
            Paragrafo3 = IsHtmlTags.SetTags(paragrafo3); 
        }

        private void Validate(string model, string titulo, string paragrafo1, string autor, string categoria, 
            string subTitulo1, string subTitulo2, string paragrafo2, string subTitulo3, string paragrafo3, string video, string tags)
        {
            AssertionConcern.AssertArgumentNotEmpty(model, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(model, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(titulo, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(titulo, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(paragrafo1, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(paragrafo1, 5120, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(autor, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(categoria, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(subTitulo1, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(subTitulo2, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(subTitulo3, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(paragrafo2, 5120, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(paragrafo3, 5120, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(video, 256, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(tags, 320, Errors.MaxLength);
        }
    }
}
