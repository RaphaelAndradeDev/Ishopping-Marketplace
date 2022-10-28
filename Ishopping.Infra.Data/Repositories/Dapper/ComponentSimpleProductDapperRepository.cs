using Dapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentSimpleProductDapperRepository : Commun.Repository, IComponentSimpleProductDapperRepository
    {
        public IEnumerable<ComponentSimpleProduct> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As SimpleProductId, cm.IdUser, cm.SiteNumber, cm.Name, cm.Category, cm.Brand, cm.Model, cm.Description, cm.Price," +
                " st.Id As OptionId, st.Name, st.Category, st.Brand, st.Model, st.Description, st.Price," +
                " FROM ComponentSimpleProduct cm" +
                " INNER JOIN ComponentSimpleProductOption st ON cm.ComponentSimpleProductOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber AND cm.DisplayOnPage = @DisplayOnPage";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentSimpleProduct> list = cn.Query<ComponentSimpleProduct, ComponentSimpleProductOption, ComponentSimpleProduct>(str, (cm, st) => { cm.AddComponentSimpleProductOption(st); return cm; }, new { SiteNumber = siteNumber, DisplayOnPage = true }, splitOn: "SimpleProductId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentSimpleProduct>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As SimpleProductId, cm.IdUser, cm.SiteNumber, cm.Name, cm.Category, cm.Brand, cm.Model, cm.Description, cm.Price," +
                " st.Id As OptionId, st.Name, st.Category, st.Brand, st.Model, st.Description, st.Price," +
                " FROM ComponentSimpleProduct cm" +
                " INNER JOIN ComponentSimpleProductOption st ON cm.ComponentSimpleProductOptionId = st.Id" +
                " WHERE cm.SiteNumber = @SiteNumber AND cm.DisplayOnPage = @DisplayOnPage";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentSimpleProduct> list = await cn.QueryAsync<ComponentSimpleProduct, ComponentSimpleProductOption, ComponentSimpleProduct>(str, (cm, st) => { cm.AddComponentSimpleProductOption(st); return cm; }, new { SiteNumber = siteNumber, DisplayOnPage = true }, splitOn: "SimpleProductId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }


        // Async Methods for AppStore 
        public async Task<IEnumerable<SimpleProduct>> GetByIdAsync(int siteNumber, Guid id, int take)
        {
            return await GetSimpleProduct(SimpleProductQuery("cm.SiteNumber = @SiteNumber AND cm.Id = @Id", take));
        }

        public async Task<IEnumerable<SimpleProduct>> GetBySiteNumberAsync(int siteNumber, int take)
        {
            return await GetSimpleProduct(SimpleProductQuery("cm.SiteNumber = @SiteNumber", take));
        }

        public async Task<IEnumerable<SimpleProduct>> GetByTitleAsync(int siteNumber, string name, int take)
        {
            return await GetSimpleProduct(SimpleProductQuery("cm.SiteNumber = @SiteNumber AND cm.Name = @Name", take));
        }

        public async Task<IEnumerable<SimpleProduct>> GetByCategoryAsync(int siteNumber, int category, int take)
        {
            return await GetSimpleProduct(SimpleProductQuery("cm.SiteNumber = @SiteNumber AND cm.Category = @Category", take));
        }

        public async Task<IEnumerable<SimpleProduct>> GetBySubCategoryAsync(int siteNumber, int subCategory, int take)
        {
            return await GetSimpleProduct(SimpleProductQuery("cm.SiteNumber = @SiteNumber AND cm.SubCategory = @SubCategory", take));
        }

        public Task<IEnumerable<SimpleProduct>> GetByTagsAsync(int siteNumber, string tags, int take)
        {
            //var tag = TagSplit(tags);
            //var simpleProducts = new List<SimpleProduct>();

            //simpleProducts.AddRange(await GetSimpleProducts1(null, siteNumber, tag));

            //if (simpleProducts.Count() < 200)
            //{
            //    simpleProducts.AddRange(await GetSimpleProducts2(null, siteNumber, tag));
            //}

            //if (simpleProducts.Count() < 200)
            //{
            //    simpleProducts.AddRange(await GetSimpleProducts3(null, siteNumber, tag));
            //}
            throw new Exception();
        }

        public Task<IEnumerable<SimpleProduct>> GetByParametersAsync(int siteNumber, string tags, int category, int subCategory, decimal priceMin, decimal priceMax, int take)
        {
            throw new NotImplementedException();
        }


        // multiplos usuários
        public async Task<IEnumerable<string>> SearchAsync(IEnumerable<int> siteNumber, string term, int take)
        {
            string str = "SELECT TOP 5 cm.Name" +
               " FROM ComponentSimpleProduct cm" +
               " WHERE" +
               " cm.SiteNumber IN @SiteNumber AND" +
               " cm.Name LIKE '%" + term.Trim() + "%'" +    
               " ORDER BY NEWID()";

            using (var cn = IshoppingConnection)
            {              
                var result = await cn.QueryAsync<string>(str, new { SiteNumber = siteNumber });          
                return result.Distinct();              
            }
        }

        public async Task<StoreDataPage> GetStoreDataPageAsync(List<BasicDisplay> basicDisplay, StoreFilter storeFilter, int take)
        {
            int step = take / basicDisplay.Count();
            List<SimpleProduct> simpleProductList = new List<SimpleProduct>();

            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            string connetionString = ConfigurationManager.ConnectionStrings["IShoppingProject"].ConnectionString;

            var str = new StringBuilder();
            str.Append("WITH SimpleProduct AS");
            str.Append("(");
            str.Append(" SELECT");
            str.Append(" ROW_NUMBER() OVER(PARTITION BY cm.SiteNumber ORDER BY cm.SiteNumber DESC, cm.LastChange DESC) AS RowNum,");
            str.Append(" cm.Id, cm.SiteNumber, cm.Category, cm.SubCategory, cm.Brand, cm.Price");
            str.Append(" FROM ComponentSimpleProduct cm");
            str.Append(" WHERE cm.DisplayOnlyPage = 'False' AND cm.SiteNumber IN ({0}) {1}");
            str.Append(")");
            str.Append(" SELECT * FROM SimpleProduct WHERE RowNum <= {2}");

            String sql = string.Format(str.ToString(), String.Join(", ", basicDisplay.Select(x => x.SiteNumber).ToArray()), WhereBuild(storeFilter), step.ToString());

            using (connection = new SqlConnection(connetionString))
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                string id = string.Empty;
                while (dataReader.Read())
                {
                    if (id != dataReader["Id"].ToString())
                    {
                        simpleProductList.Add(
                          new SimpleProduct(
                              Guid.Parse(dataReader["Id"].ToString()),
                              Convert.ToInt32(dataReader["SiteNumber"]),
                              Convert.ToInt32(dataReader["Category"]),
                              Convert.ToInt32(dataReader["SubCategory"]),
                              dataReader["Brand"].ToString(),
                              Convert.ToInt32(dataReader["Price"])
                      ));
                    }
                    id = dataReader["Id"].ToString();
                }
                connection.Close();
            }

            basicDisplay.ForEach(x => x.AddProductDataPage(simpleProductList.Where(y => y.SiteNumber == x.SiteNumber).Select(y => new ProductDataPage(y.Id, y.Category, y.SubCategory, y.Brand, y.Price)), storeFilter));
            return new StoreDataPage(basicDisplay);
        }

        public async Task<IEnumerable<SimpleProduct>> GetAllByIdAsync(IEnumerable<Guid> id, int take)
        {           
            return await GetSimpleProduct(SimpleProductQuery("cm.Id IN ('" + String.Join("','", id.ToArray()) + "')", take));
        }            

        public async Task<IEnumerable<SimpleProduct>> GetAllByCategoryAsync(IEnumerable<int> siteNumber, IEnumerable<int> category, int take)
        {
            return await SimpleProductQuery(siteNumber, "cm.Category IN (" + String.Join(", ", category.ToArray()) + ")", take);
        }

 


        // Private Methods       
        private string WhereBuild(StoreFilter storeFilter)
        {
            var str = new StringBuilder();
            
            if (storeFilter.Term != "")
                str.Append(" AND cm.Name LIKE '%" + storeFilter.Term.Trim() + "%'");

            if (storeFilter.GetAll)
                return str.ToString();

            if (storeFilter.CategoryIsValid())
                str.Append(" AND cm.Category IN (" + String.Join(", ", storeFilter.Category.ToArray()) + ")");
            if (storeFilter.SubCategoryIsValid() && storeFilter.Category.ElementAt(0) == 0)
                str.Append(" AND cm.SubCategory IN (" + String.Join(", ", storeFilter.SubCategory.ToArray()) + ")");
            if (storeFilter.BrandIsValid() && storeFilter.Category.ElementAt(0) == 0)
                str.Append(" AND cm.Brand IN (" + String.Join(", ", storeFilter.Brand.ToArray()) + ")");
            if (storeFilter.PriceMin != 0)
                str.Append(" AND cm.PriceMin = " + storeFilter.PriceMin);
            if (storeFilter.PriceMax != 99999)
                str.Append(" AND cm.PriceMax = " + storeFilter.PriceMax);

            return str.ToString();
        }          
        
        public async Task<IEnumerable<SimpleProduct>> SimpleProductQuery(IEnumerable<int> siteNumber, string where, int take)
        {
            int step = take / siteNumber.Count();
            List<SimpleProduct> simpleProductList = new List<SimpleProduct>();

            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            string connetionString = ConfigurationManager.ConnectionStrings["IShoppingProject"].ConnectionString;

            var str = new StringBuilder();
            str.Append("WITH SimpleProduct AS");
            str.Append("(");
            str.Append(" SELECT");
            str.Append(" ROW_NUMBER() OVER(PARTITION BY cm.SiteNumber ORDER BY cm.SiteNumber DESC, cm.LastChange DESC) AS RowNum,");
            str.Append(" cm.Id, cm.SiteNumber, cm.Category, cm.SubCategory, cm.Name, cm.Brand, cm.Model, cm.Description, cm.Price, cm.Tags, cm.LastChange,");
            str.Append(" img.Folder, img.FileName");
            str.Append(" FROM ComponentSimpleProduct cm");
            str.Append(" INNER JOIN ComponentSimpleProductUserImageGallery pi ON pi.ComponentSimpleProduct_Id = cm.Id");
            str.Append(" INNER JOIN UserImageGallery img ON pi.UserImageGallery_Id = img.Id");
            str.Append(" WHERE cm.DisplayOnlyPage = 'False' AND cm.SiteNumber IN ({0}) AND {1}");
            str.Append(")");
            str.Append(" SELECT * FROM SimpleProduct WHERE RowNum <= {2}");

            String sql = string.Format(str.ToString(), String.Join(", ", siteNumber.ToArray()), where.ToString(), step.ToString());

            using (connection = new SqlConnection(connetionString))
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                string id = string.Empty;
                while (dataReader.Read())
                {
                    if(id != dataReader["Id"].ToString())
                    {
                        simpleProductList.Add(
                          new SimpleProduct(
                              Guid.Parse(dataReader["Id"].ToString()),
                              Convert.ToInt32(dataReader["SiteNumber"]),
                              Convert.ToInt32(dataReader["Category"]),
                              Convert.ToInt32(dataReader["SubCategory"]),
                              dataReader["Name"].ToString(),
                              dataReader["Brand"].ToString(),
                              dataReader["Model"].ToString(),
                              dataReader["Description"].ToString(),
                              Convert.ToInt32(dataReader["Price"]),
                              dataReader["Tags"].ToString(),
                                  new List<UserImageGallery>(){
                                            new UserImageGallery(
                                            new Guid().ToString(),
                                            Convert.ToInt32(dataReader["SiteNumber"]),
                                            0,
                                            dataReader["FileName"].ToString(),
                                            1,
                                            Convert.ToInt32(dataReader["Folder"]),
                                            0
                                        )}
                      ));
                    }
                    else
                    {
                        simpleProductList.Last().AddUserImageGallery(
                            new UserImageGallery(
                                new Guid().ToString(),
                                Convert.ToInt32(dataReader["SiteNumber"]),
                                0,
                                dataReader["FileName"].ToString(),
                                1,
                                Convert.ToInt32(dataReader["Folder"]),
                                0
                            ));
                    }

                    id = dataReader["Id"].ToString();
                }
                connection.Close();
            }
            return simpleProductList;
        }

        private string SimpleProductQuery(string where, int take)
        {
            where = where == "" ? "" : " AND " + where;
            var str = new StringBuilder();
            str.Append("SELECT TOP {0} cm.Id, cm.SiteNumber, cm.Category, cm.SubCategory, cm.Name, cm.Brand, cm.Model, cm.Description, cm.Price, cm.Tags,");
            str.Append(" img.Id, img.Folder, img.FileName");
            str.Append(" FROM ComponentSimpleProduct cm");
            str.Append(" INNER JOIN ComponentSimpleProductUserImageGallery pi ON pi.ComponentSimpleProduct_Id = cm.Id");
            str.Append(" INNER JOIN UserImageGallery img ON pi.UserImageGallery_Id = img.Id");
            str.Append(" WHERE cm.DisplayOnlyPage = 'False' {1}");

            return string.Format(str.ToString(), take.ToString(), where);           
        }

        private string SimpleProductQuery(string where, int take, string orderBy)
        {
            var str = new StringBuilder();
            str.Append(SimpleProductQuery(where, take));
            str.Append(" ORDER BY " + orderBy);
            return str.ToString();
        }

        private async Task<IEnumerable<SimpleProduct>> GetSimpleProduct(string query)
        {           
            List<SimpleProduct> simpleProductList = new List<SimpleProduct>();

            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            string connetionString = ConfigurationManager.ConnectionStrings["IShoppingProject"].ConnectionString;    
                    
            using (connection = new SqlConnection(connetionString))
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                dataReader = command.ExecuteReader();

                string id = string.Empty;
                while (dataReader.Read())
                {
                    if (id != dataReader["Id"].ToString())
                    {
                        simpleProductList.Add(
                          new SimpleProduct(
                              Guid.Parse(dataReader["Id"].ToString()),
                              Convert.ToInt32(dataReader["SiteNumber"]),
                              Convert.ToInt32(dataReader["Category"]),
                              Convert.ToInt32(dataReader["SubCategory"]),
                              dataReader["Name"].ToString(),
                              dataReader["Brand"].ToString(),
                              dataReader["Model"].ToString(),
                              dataReader["Description"].ToString(),
                              Convert.ToInt32(dataReader["Price"]),
                              dataReader["Tags"].ToString(),
                                  new List<UserImageGallery>(){
                                            new UserImageGallery(
                                            new Guid().ToString(),
                                            Convert.ToInt32(dataReader["SiteNumber"]),
                                            0,
                                            dataReader["FileName"].ToString(),
                                            1,
                                            Convert.ToInt32(dataReader["Folder"]),
                                            0
                                        )}
                      ));
                    }
                    else
                    {
                        simpleProductList.Last().AddUserImageGallery(
                            new UserImageGallery(
                                new Guid().ToString(),
                                Convert.ToInt32(dataReader["SiteNumber"]),
                                0,
                                dataReader["FileName"].ToString(),
                                1,
                                Convert.ToInt32(dataReader["Folder"]),
                                0
                            ));
                    }

                    id = dataReader["Id"].ToString();
                }
                connection.Close();
            }
            return simpleProductList;
        }

        private IEnumerable<string> TagSplit(string tags)
        {
            return tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length > 2);                                  
        }

        //private async Task<IEnumerable<SimpleProduct>> GetSimpleProducts1(IEnumerable<int> siteNumberList, int? siteNumber,  IEnumerable<string> tags)
        //{           
        //    string query = string.Empty;
        //    object param;

        //    string where = siteNumberList != null ? "cm.SiteNumber IN @SiteNumber AND " : "cm.SiteNumber = @SiteNumber AND ";

        //    if (tags.Count() == 1)
        //    {
        //        query = where + "[Tags] LIKE '%,@Tag1,%'";
        //        param = new { SiteNumber = siteNumberList, Tag1 = tags.ElementAt(0) };
        //    }
        //    else if(tags.Count() == 2)
        //    {
        //        query = where + "[Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%'";
        //        param = new { SiteNumber = siteNumberList, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1) };
        //    }
        //    else if (tags.Count() >= 2)
        //    {
        //        query = where + "[Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%' AND [Tags] LIKE '%,@Tag3,%'";
        //        param = new { SiteNumber = siteNumberList, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1), Tag3 = tags.ElementAt(2) };
        //    }
        //    else
        //    {
        //        return new List<SimpleProduct>();
        //    }
       
        //    return await GetSimpleProduct(SimpleProductQuery(query), param);
        //}

        //private async Task<IEnumerable<SimpleProduct>> GetSimpleProducts2(IEnumerable<int> siteNumberList, int? siteNumber, IEnumerable<string> tags)
        //{           
        //    string query = string.Empty;
        //    object param;

        //    string where = siteNumberList != null ? "cm.SiteNumber IN @SiteNumber AND " : "cm.SiteNumber = @SiteNumber AND ";

        //    if (tags.Count() == 1)
        //    {
        //        query = where + "[Tags] LIKE '%,@Tag1,%'";
        //        param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0) };
        //    }
        //    else if (tags.Count() == 2)
        //    {
        //        query = where + "[Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%'";
        //        param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1) };
        //    }
        //    else if (tags.Count() >= 2)
        //    {
        //        query = where + "([Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%') OR ([Tags] LIKE '%,@Tag1,%' AND[Tags] LIKE '%,@Tag3,%') OR ([Tags] LIKE '%,@Tag2,%' AND[Tags] LIKE '%,@Tag3,%')";
        //        param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1), Tag3 = tags.ElementAt(2) };
        //    }
        //    else
        //    {
        //        return new List<SimpleProduct>();
        //    }

        //    return await GetSimpleProduct(SimpleProductQuery(query), param);
        //}

        //private async Task<IEnumerable<SimpleProduct>> GetSimpleProducts3(IEnumerable<int> siteNumberList, int? siteNumber, IEnumerable<string> tags)
        //{           
        //    string query = string.Empty;
        //    object param;

        //    string where = siteNumberList != null ? "cm.SiteNumber IN @SiteNumber AND " : "cm.SiteNumber = @SiteNumber AND ";

        //    if (tags.Count() == 1)
        //    {
        //        query = where + "[Tags] LIKE '%,@Tag1,%'";
        //        param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0) };
        //    }
        //    else if (tags.Count() == 2)
        //    {
        //        query = where + "[Tags] LIKE '%,@Tag1,%' OR [Tags] LIKE '%,@Tag2,%'";
        //        param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1) };
        //    }
        //    else if (tags.Count() >= 2)
        //    {
        //        query = where + "[Tags] LIKE '%,@Tag1,%' OR [Tags] LIKE '%,@Tag2,%' OR [Tags] LIKE '%,@Tag3,%'";
        //        param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1), Tag3 = tags.ElementAt(2) };
        //    }
        //    else
        //    {
        //        return new List<SimpleProduct>();
        //    }

        //    return await GetSimpleProduct(SimpleProductQuery(query), param);
        //}

        
    }
}
