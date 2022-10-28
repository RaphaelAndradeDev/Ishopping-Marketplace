using System;
using System.Linq;
using System.Collections.Generic;

namespace Ishopping.Domain.ApplicationClass
{
    public class BasicDisplay
    {
        public int SiteNumber { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Usado para filtrar produtos mais próximos
        public int Radius { get; set; }

        public IEnumerable<ProductDataPage> ProductDataPage { get; private set; }
        public IEnumerable<ProductDataPage> ProductDataFilter { get; private set; }

        public void AddProductDataPage(IEnumerable<ProductDataPage> productDataPage, StoreFilter storeFilter)
        {
            productDataPage.ToList().ForEach(x => x.SetRadius(Radius));
            ProductDataFilter = productDataPage;
            ProductDataPage = storeFilter.GetAll ? productDataPage : FilterDataPage(productDataPage, storeFilter);
        }   

        public void RemoveProductDataPage()
        {
            ProductDataPage = null;
            ProductDataFilter = null;
        }

        private IEnumerable<ProductDataPage> SetProductDataPage(IEnumerable<ProductDataPage> productDataPage)
        {
            foreach (var item in productDataPage)
            {
                item.Radius = Radius;
                yield return item;
            }
        }

        private IEnumerable<ProductDataPage> FilterDataPage(IEnumerable<ProductDataPage> productDataPage, StoreFilter storeFilter)
        {
            List<ProductDataPage> productDataPageList = new List<ProductDataPage>();

            Func<ProductDataPage, bool> predicate1 = x => true;
            Func<ProductDataPage, bool> predicate2 = x => true;
            Func<ProductDataPage, bool> predicate3 = x => true;

            if (storeFilter.CategoryIsValid())
            {
                predicate1 = x => storeFilter.Category.Contains(x.CategoryId);
            }

            if (storeFilter.SubCategoryIsValid())
            {
                predicate2 = x => storeFilter.SubCategory.Contains(x.SubCategoryId);
            }

            if (storeFilter.BrandIsValid())
            {
                predicate3 = x => storeFilter.Brand.Contains(x.Brand);
            }

            productDataPageList.AddRange(productDataPage.Where(x => predicate1(x) && predicate2(x) && predicate3(x)));

            return productDataPageList;
        }
    }

    public class ProductDataPage
    {
        public Guid Id { get; set; }        
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

        // Usado para filtrar produtos mais próximos
        public int Radius { get; set; }

        public BasicCategory _Category { get { return new BasicCategory(CategoryId, BasicCategoryList.getCategoryByKey(CategoryId)); } }
        public BasicCategory _SubCategory { get { return new BasicCategory(SubCategoryId, BasicCategoryList.getSubCategoryByKey(SubCategoryId)); } }

        public ProductDataPage()
        {

        }

        public ProductDataPage(Guid id, int categoryId, int subCategoryId, string brand, decimal price)
        {
            Id = id;            
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            Brand = brand;
            Price = price;   
        }

        public void SetRadius(int radius)
        {
            Radius = radius;
        }
    }

    public class StoreFilter
    {       
        public bool GetAll { get; set; }
        public int SortBy { get; set; }
        public string Term { get; set; }
        public IEnumerable<int> Category { get; set; }
        public IEnumerable<int> SubCategory { get; set; }
        public IEnumerable<string> Brand { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }

        public StoreFilter()
        {
            GetAll = true;
            SortBy = 1;
            Term = "";
            Category = null;
            SubCategory = null;
            Brand = null;
            PriceMin = 0;
            PriceMax = 99999;
        }

        public StoreFilter(string term, IEnumerable<int> category, IEnumerable<int> subCategory, IEnumerable<string> brand = null, decimal priceMin = 0, decimal priceMax = 99999, bool getAll = true, int sortBy = 1)
        {
            GetAll = getAll;
            SortBy = sortBy;
            Term = term;
            Category = category;
            SubCategory = subCategory;
            Brand = brand;
            PriceMin = priceMin;
            PriceMax = priceMax;
        }

        public bool CategoryIsValid()
        {
            return !(Category == null || Category.ElementAt(0) == 0);
        }

        public bool SubCategoryIsValid()
        {
            return !(SubCategory == null || SubCategory.ElementAt(0) == 0);
        }

        public bool BrandIsValid()
        {
            return !(Brand == null || Brand.ElementAt(0) == "");
        }
    }
}
