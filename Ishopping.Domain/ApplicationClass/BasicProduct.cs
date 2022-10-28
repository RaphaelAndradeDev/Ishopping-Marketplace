namespace Ishopping.Domain.ApplicationClass
{
    public class BasicProduct
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string ImgFolder { get; set; }
        public string ImgFile { get; set; }
          
        public BasicProduct(int category)
        {
            Title = "Talvez você goste";
            Category = BasicCategoryList.getCategoryByKey(category);
            ImgFolder = "1101";
            ImgFile = BasicCategoryList.getImgCategoryByKey(category);
        }
    }
}
