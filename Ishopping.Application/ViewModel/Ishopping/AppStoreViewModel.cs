using Ishopping.Domain.ApplicationClass;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Application.ViewModel.Ishopping
{
    public class AppStoreViewModel // ao carregar a página pela primeira vez
    {
        public string Term { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
        public CategoryList CategoryList { get; set; }

        public AppStoreViewModel()
        {
            CategoryList = new CategoryList();       
        }

        public AppStoreViewModel(string term, int? category, int? subCategory)
        {
            Term = term;
            Category = category.HasValue ? category.Value : 0;
            SubCategory = subCategory.HasValue ? subCategory.Value : 0;
            CategoryList = new CategoryList();
        }
    }

    public class AppStoreProductListT1ViewModel
    {
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }        
        public IEnumerable<SimpleProduct> SimpleProduct { get; set; }

        public AppStoreProductListT1ViewModel()
        {
            PageCount = 1;
            CurrentPage = 1;
            SimpleProduct = new List<SimpleProduct>();
        }

        public AppStoreProductListT1ViewModel(IEnumerable<SimpleProduct> simpleProduct, int currentPage, int productCount)
        {
            PageCount = productCount % 16 != 0 ? productCount / 16 + 1 : productCount / 16;
            CurrentPage = currentPage;
            SimpleProduct = simpleProduct;
        }
    }

    public class AppStoreProductListT2ViewModel
    {
        public IEnumerable<SimpleProduct> SimpleProduct { get; set; }

        public AppStoreProductListT2ViewModel()
        {
            SimpleProduct = new List<SimpleProduct>();
        }

        public AppStoreProductListT2ViewModel(IEnumerable<SimpleProduct> simpleProduct)
        {
            SimpleProduct = simpleProduct;
        }
    }

    public class AppStoreProductListT3ViewModel
    {
        public string SortBy { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<SimpleProduct> SimpleProduct { get; set; }

        public AppStoreProductListT3ViewModel()
        {
            SortBy = "Mais Próximo";
            PageCount = 1;
            CurrentPage = 1;
            SimpleProduct = new List<SimpleProduct>();
        }

        public AppStoreProductListT3ViewModel(IEnumerable<SimpleProduct> simpleProduct)
        {
            SortBy = "Mais Próximo";
            int productCount = simpleProduct.Count();
            PageCount = productCount % 12 != 0 ? productCount / 12 + 1 : productCount / 12;
            CurrentPage = 1;
            SimpleProduct = simpleProduct;
        }

        public AppStoreProductListT3ViewModel(IEnumerable<SimpleProduct> simpleProduct, int currentPage, int productCount, int sortBy)
        {       
            PageCount = productCount % 12 != 0 ? productCount / 12 + 1 : productCount / 12;
            CurrentPage = currentPage;
            SimpleProduct = Sort(simpleProduct, sortBy);
        }

        private IEnumerable<SimpleProduct> Sort(IEnumerable<SimpleProduct> simpleProduct, int sortBy)
        {
            switch (sortBy)
            {
                case 1:
                    SortBy = "Menor Preço";
                    return simpleProduct.OrderBy(x => x.Price);
                case 2:
                    SortBy = "Maior Preço";
                    return simpleProduct.OrderByDescending(x => x.Price);
                case 3:
                    SortBy = "Mais Próximo";
                    return simpleProduct;              
                case 4:
                    SortBy = "Mais Distante";
                    return simpleProduct;            
                default:
                    return simpleProduct;
            }
        }
    }

    public class AppStoreProductListT4ViewModel
    {
        public List<BasicProduct> BasicProduct { get; set; }

        public AppStoreProductListT4ViewModel(IEnumerable<int> category)
        {
            BasicProduct = GetBasicProduct(category);
        }    
        
        private List<BasicProduct> GetBasicProduct(IEnumerable<int> category)
        {
            var basicProductList = new List<BasicProduct>();
            foreach (var item in category)
            {
                basicProductList.Add(new BasicProduct(item));
            }
            return basicProductList;
        }
    }

    public class AppStorePartialPageFilterViewModel
    {
        public IEnumerable<ProductDataPage> ProductDataFilter { get; set; }

        public AppStorePartialPageFilterViewModel(IEnumerable<ProductDataPage> productDataFilter)
        {
            ProductDataFilter = productDataFilter;
        }        
    }

    // AppStore users
    public class AppStoreMainViewModel
    {
        public CategoryList CategoryList { get; set; }
        public ProfileContact ProfileContact { get; set; }

        public AppStoreMainViewModel(ProfileContact profileContact)
        {
            CategoryList = new CategoryList();  
            ProfileContact = profileContact;
        }
    }

    public class AppStoreItemViewModel
    {
        public CategoryList CategoryList { get; set; }
        public SimpleProduct SimpleProduct { get; set; }
        public ProfileContact ProfileContact { get; set; }

        public AppStoreItemViewModel(SimpleProduct simpleProduct, ProfileContact profileContact)
        {
            CategoryList = new CategoryList();
            SimpleProduct = simpleProduct;
            ProfileContact = profileContact;
        }
    }

    
}
