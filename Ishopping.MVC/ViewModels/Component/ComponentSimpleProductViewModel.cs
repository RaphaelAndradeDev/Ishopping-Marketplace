using Ishopping.Domain.ApplicationClass;
using Ishopping.MVC.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentSimpleProductViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public bool DisplayOnPage { get; set; }
        public bool DisplayOnlyPage { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Tags { get; set; }

        // Get IsTags
        public string _Tags { get; set; }
        public string _Name { get; set; }
        public string _Brand { get; set; }
        public string _Model { get; set; }
        public string _Description { get; set; }

        // Relacionamentos         
        public virtual ICollection<UserImageGalleryViewModel> UserImageGallery { get; set; }

        public Guid ComponentSimpleProductOptionId { get; set; }
        public virtual ComponentSimpleProductOptionModel ComponentSimpleProductOption { get; set; }

        public CategoryList CategoryList = new CategoryList(); 
        public string _Category { get { return GetCategory(); } }
        public string _SubCategory { get { return GetSubCategory(); } }
        public IEnumerable<SubCategory> _SubCategoryList { get { return GetSubCategoryList(); } }

        private string GetCategory()
        {
            string str = CategoryList.Category.FirstOrDefault(x => x.Id == Category).Name;
            return string.IsNullOrEmpty(str) ? "Selecione uma Categoria" : str;
        }

        private string GetSubCategory()
        {
            string str = CategoryList.Category.FirstOrDefault(x => x.Id == Category).SubCategory.FirstOrDefault(y => y.Id == SubCategory).Name;
            return string.IsNullOrEmpty(str) ? "Selecione uma SubCategoria" : str;
        }

        private IEnumerable<SubCategory> GetSubCategoryList()
        {
            return CategoryList.Category.FirstOrDefault(x => x.Id == Category).SubCategory;  
        }
    }

    public class ComponentSimpleProductOptionModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public bool Default { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }    
}