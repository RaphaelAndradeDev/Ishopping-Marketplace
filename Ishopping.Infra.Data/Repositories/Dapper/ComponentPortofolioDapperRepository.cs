using Dapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentPortofolioDapperRepository : Repository, IComponentPortofolioDapperRepository
    {

        public IEnumerable<ComponentPortofolio> GetAllBySiteNumber(int siteNumber)
        {
            string str = "SELECT cm.Id As PortofolioId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Category, cm.Title, cm.Description, cm.List," +
                " st.Id As OptionId, st.Category, st.Title, st.Description, st.List," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentPortofolio cm" +
                " INNER JOIN ComponentPortofolioOption st ON cm.ComponentPortofolioOptionId = st.Id" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber AND cm.DisplayOnPage = @DisplayOnPage";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentPortofolio> list = cn.Query<ComponentPortofolio, ComponentPortofolioOption, UserImageGallery, ComponentPortofolio>(str, (cm, st, img) => { cm.AddComponentPortofolioOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber, DisplayOnPage = true }, splitOn: "PortofolioId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }

        public async Task<IEnumerable<ComponentPortofolio>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT cm.Id As PortofolioId, cm.IdUser, cm.SiteNumber, cm.Position, cm.Category, cm.Title, cm.Description, cm.List," +
                " st.Id As OptionId, st.Category, st.Title, st.Description, st.List," +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentPortofolio cm" +
                " INNER JOIN ComponentPortofolioOption st ON cm.ComponentPortofolioOptionId = st.Id" +
                " INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id" +
                " WHERE cm.SiteNumber = @SiteNumber AND cm.DisplayOnPage = @DisplayOnPage";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentPortofolio> list = await cn.QueryAsync<ComponentPortofolio, ComponentPortofolioOption, UserImageGallery, ComponentPortofolio>(str, (cm, st, img) => { cm.AddComponentPortofolioOption(st); cm.AddUserImageGallery(img); return cm; }, new { SiteNumber = siteNumber, DisplayOnPage = true }, splitOn: "PortofolioId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }


        // Async Methods for AppPortfolio
        public async Task<SimplePortfolio> GetByIdAsync(Guid id)
        {
            var str = new StringBuilder();
            str.Append("SELECT cm.Id, cm.SiteNumber, cm.PortfolioHead, cm.PortfolioChild, cm.Category, cm.SubCategory, cm.Title, cm.Description, cm.Tags,");
            str.Append(" img.Id, img.Folder, img.FileName");
            str.Append(" FROM ComponentPortofolio cm");
            str.Append(" INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id");
            str.Append(" WHERE cm.DisplayOnlyPage = 'False' AND cm.Id = @Id");

            using (var cn = IshoppingConnection)
            {
                return await cn.QueryFirstOrDefaultAsync<SimplePortfolio>(str.ToString(), new {Id = id});
            }
        }

        public async Task<IEnumerable<SimplePortfolio>> GetBySiteNumberAsync(int siteNumber, int take)
        {
            return await GetSimplePortfolio(SimplePortfolioQuery("cm.SiteNumber = @SiteNumber"), new { SiteNumber = siteNumber });
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByTitleAsync(int siteNumber, string title, int take)
        {
            return await GetSimplePortfolio(SimplePortfolioQuery("cm.SiteNumber = @SiteNumber AND cm.Title = @Title"), new { SiteNumber = siteNumber, Title = title });
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByCategoryAsync(int siteNumber, string categoy, int take)
        {
            return await GetSimplePortfolio(SimplePortfolioQuery("cm.SiteNumber = @SiteNumber AND cm.Category = @Category"), new { SiteNumber = siteNumber, Category = categoy });
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByCategoryAsync(int siteNumber, string categoy, string subCategory, int take)
        {
            return await GetSimplePortfolio(SimplePortfolioQuery("cm.SiteNumber = @SiteNumber AND cm.Category = @Category AND cm.SubCategory = @SubCategory"), new { SiteNumber = siteNumber, Category = categoy, SubCategory = subCategory });
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByTagAsync(int siteNumber, string tag, int take)
        {
            return await GetSimplePortfolio(SimplePortfolioQuery("cm.SiteNumber = @SiteNumber AND cm.Tags LIKE '%,"+ tag +",%'"), new { SiteNumber = siteNumber });
        }

        public async Task<IEnumerable<SimplePortfolio>> GetByTagsAsync(int siteNumber, string tags, int take)
        {
            var tag = TagSplit(tags);
            var simplePorfolio = new List<SimplePortfolio>();
            simplePorfolio.AddRange(await GetSimpleProducts1(siteNumber, tag));

            if (simplePorfolio.Count() < 200)
            {
                simplePorfolio.AddRange(await GetSimpleProducts2(siteNumber, tag));
            }

            if (simplePorfolio.Count() < 200)
            {
                simplePorfolio.AddRange(await GetSimpleProducts3(siteNumber, tag));
            }
            return simplePorfolio;
        }


        // Multiplos usuarios
        public async Task<IEnumerable<SimplePortfolio>> GetAllBySiteNumberAsync(IEnumerable<int> siteNumber, int take)
        {
            int step = take / siteNumber.Count();
            List<SimplePortfolio> simplePortfolioList = new List<SimplePortfolio>();

            SqlConnection connection;
            SqlCommand command;
            SqlDataReader dataReader;
            string connetionString = ConfigurationManager.ConnectionStrings["IShoppingProject"].ConnectionString;            

            var str = new StringBuilder();
            str.Append("WITH Portfolio AS");
            str.Append("(");
            str.Append(" SELECT");
            str.Append(" ROW_NUMBER() OVER(PARTITION BY cm.SiteNumber ORDER BY cm.PortfolioHead DESC, cm.LastChange DESC) AS RowNum,");
            str.Append(" cm.Id, cm.SiteNumber, cm.PortfolioHead, cm.PortfolioChild, cm.Category, cm.SubCategory, cm.Title, cm.Description, cm.Tags,");
            str.Append(" img.Folder, img.FileName");
            str.Append(" FROM ComponentPortofolio cm");
            str.Append(" INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id");
            str.Append(" WHERE cm.DisplayOnlyPage = 'False' AND cm.SiteNumber IN ({0})"); 
            str.Append(")");
            str.Append(" SELECT * FROM Portfolio WHERE RowNum <= {1}");

            String sql = string.Format(str.ToString(), String.Join(", ", siteNumber.ToArray()), step.ToString());                     
        
            using (connection = new SqlConnection(connetionString))
            {                               
                connection.Open();
                command = new SqlCommand(sql, connection);                   
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    simplePortfolioList.Add(
                        new SimplePortfolio(
                            Guid.Parse(dataReader["Id"].ToString()),
                            Convert.ToInt32(dataReader["SiteNumber"]),
                            Convert.ToBoolean(dataReader["PortfolioHead"]),
                            Convert.ToBoolean(dataReader["PortfolioChild"]),
                            dataReader["Category"].ToString(),
                            dataReader["SubCategory"].ToString(),
                            dataReader["Title"].ToString(),
                            dataReader["Category"].ToString(),
                            dataReader["Tags"].ToString(),
                            new UserImageGallery(new Guid().ToString(),
                                Convert.ToInt32(dataReader["SiteNumber"]),
                                0, 
                                dataReader["FileName"].ToString(),
                                1, 
                                Convert.ToInt32(dataReader["Folder"]), 
                                0
                            )
                    ));
                }             
                connection.Close();                               
            }
            return simplePortfolioList;
        }
        
        public async Task<IEnumerable<SimplePortfolio>> GetAllByTitleAsync(string title, int take)
        {
            return await GetSimplePortfolio(SimplePortfolioQuery("cm.Title = @Title"), new { Title = title });
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByCategoryAsync(string categoy, int take)
        {
            return await GetSimplePortfolio(SimplePortfolioQuery("cm.Category = @Category"), new { Category = categoy });
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByCategoryAsync(string categoy, string subCategory, int take)
        {
            return await GetSimplePortfolio(SimplePortfolioQuery("cm.Category = @Category AND cm.SubCategory = @SubCategory"), new { Category = categoy, SubCategory = subCategory });
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByTagAsync(string tag, int take)
        {
            return await GetSimplePortfolio(SimplePortfolioQuery("cm.Tags LIKE '%,"+ tag +",%'"), new { Tag = tag });
        }

        public async Task<IEnumerable<SimplePortfolio>> GetAllByTagsAsync(string tags, int take)
        {
            var tag = TagSplit(tags);
            var simplePorfolio = new List<SimplePortfolio>();
            simplePorfolio.AddRange(await GetSimpleProducts1(tag));

            if (simplePorfolio.Count() < 200)
            {
                simplePorfolio.AddRange(await GetSimpleProducts2(tag));
            }

            if (simplePorfolio.Count() < 200)
            {
                simplePorfolio.AddRange(await GetSimpleProducts3(tag));
            }        
            return simplePorfolio;
        }


        // Private Methods for AppPortfolio
        private string SimplePortfolioQuery(string where)
        {            
            var str = new StringBuilder();
            str.Append("SELECT TOP 36 cm.Id, cm.SiteNumber, cm.PortfolioHead, cm.PortfolioChild, cm.Category, cm.SubCategory, cm.Title, cm.Description, cm.Tags,");
            str.Append(" img.Id, img.Folder, img.FileName");
            str.Append(" FROM ComponentPortofolio cm");
            str.Append(" INNER JOIN UserImageGallery img ON cm.UserImageGalleryId = img.Id");
            str.Append(" WHERE cm.DisplayOnlyPage = 'False' AND " + where);
            return str.ToString();
        }

        private string SimplePortfolioQuery(string where, string orderBy)
        {
            var str = new StringBuilder();
            str.Append(SimplePortfolioQuery(where));
            str.Append(" ORDER BY " + orderBy);
            return str.ToString();
        }

        private async Task<IEnumerable<SimplePortfolio>> GetSimplePortfolio(string query, object param)
        {
            using (var cn = IshoppingConnection)
            {
                return await cn.QueryAsync<SimplePortfolio, UserImageGallery, SimplePortfolio>(query, (cm, img) => { cm.UserImageGallery = img; return cm; }, param, splitOn: "Id");              
            }
        }

        private IEnumerable<string> TagSplit(string tags)
        {
            return tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length > 2);
        }

        private async Task<IEnumerable<SimplePortfolio>> GetSimpleProducts1(int siteNumber, IEnumerable<string> tags)
        {
            string query = string.Empty;
            object param;          

            if (tags.Count() == 1)
            {
                query = "cm.SiteNumber = @SiteNumber AND [Tags] LIKE '%,@Tag1,%'";
                param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0) };
            }
            else if (tags.Count() == 2)
            {
                query = "cm.SiteNumber = @SiteNumber AND [Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%'";
                param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1) };
            }
            else if (tags.Count() >= 2)
            {
                query = "cm.SiteNumber = @SiteNumber AND [Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%' AND [Tags] LIKE '%,@Tag3,%'";
                param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1), Tag3 = tags.ElementAt(2) };
            }
            else
            {
                return new List<SimplePortfolio>();
            }
            return await GetSimplePortfolio(SimplePortfolioQuery(query), param);
        }

        private async Task<IEnumerable<SimplePortfolio>> GetSimpleProducts2(int siteNumber, IEnumerable<string> tags)
        {
            string query = string.Empty;
            object param;            

            if (tags.Count() == 1)
            {
                query = "cm.SiteNumber = @SiteNumber AND [Tags] LIKE '%,@Tag1,%'";
                param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0) };
            }
            else if (tags.Count() == 2)
            {
                query = "cm.SiteNumber = @SiteNumber AND [Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%'";
                param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1) };
            }
            else if (tags.Count() >= 2)
            {
                query = "cm.SiteNumber = @SiteNumber AND ([Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%') OR ([Tags] LIKE '%,@Tag1,%' AND[Tags] LIKE '%,@Tag3,%') OR ([Tags] LIKE '%,@Tag2,%' AND[Tags] LIKE '%,@Tag3,%')";
                param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1), Tag3 = tags.ElementAt(2) };
            }
            else
            {
                return new List<SimplePortfolio>();
            }
            return await GetSimplePortfolio(SimplePortfolioQuery(query), param);
        }

        private async Task<IEnumerable<SimplePortfolio>> GetSimpleProducts3(int siteNumber, IEnumerable<string> tags)
        {
            string query = string.Empty;
            object param;      

            if (tags.Count() == 1)
            {
                query = "cm.SiteNumber = @SiteNumber AND [Tags] LIKE '%,@Tag1,%'";
                param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0) };
            }
            else if (tags.Count() == 2)
            {
                query = "cm.SiteNumber = @SiteNumber AND [Tags] LIKE '%,@Tag1,%' OR [Tags] LIKE '%,@Tag2,%'";
                param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1) };
            }
            else if (tags.Count() >= 2)
            {
                query = "cm.SiteNumber = @SiteNumber AND [Tags] LIKE '%,@Tag1,%' OR [Tags] LIKE '%,@Tag2,%' OR [Tags] LIKE '%,@Tag3,%'";
                param = new { SiteNumber = siteNumber, Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1), Tag3 = tags.ElementAt(2) };
            }
            else
            {
                return new List<SimplePortfolio>();
            }
            return await GetSimplePortfolio(SimplePortfolioQuery(query), param);
        }

        private async Task<IEnumerable<SimplePortfolio>> GetSimpleProducts1(IEnumerable<string> tags)
        {
            string query = string.Empty;
            object param;

            if (tags.Count() == 1)
            {
                query = "[Tags] LIKE '%,@Tag1,%'";
                param = new { Tag1 = tags.ElementAt(0) };
            }
            else if (tags.Count() == 2)
            {
                query = "[Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%'";
                param = new { Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1) };
            }
            else if (tags.Count() >= 2)
            {
                query = "[Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%' AND [Tags] LIKE '%,@Tag3,%'";
                param = new { Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1), Tag3 = tags.ElementAt(2) };
            }
            else
            {
                return new List<SimplePortfolio>();
            }
            return await GetSimplePortfolio(SimplePortfolioQuery(query), param);
        }

        private async Task<IEnumerable<SimplePortfolio>> GetSimpleProducts2(IEnumerable<string> tags)
        {
            string query = string.Empty;
            object param;

            if (tags.Count() == 1)
            {
                query = "[Tags] LIKE '%,@Tag1,%'";
                param = new { Tag1 = tags.ElementAt(0) };
            }
            else if (tags.Count() == 2)
            {
                query = "[Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%'";
                param = new { Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1) };
            }
            else if (tags.Count() >= 2)
            {
                query = "([Tags] LIKE '%,@Tag1,%' AND [Tags] LIKE '%,@Tag2,%') OR ([Tags] LIKE '%,@Tag1,%' AND[Tags] LIKE '%,@Tag3,%') OR ([Tags] LIKE '%,@Tag2,%' AND[Tags] LIKE '%,@Tag3,%')";
                param = new { Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1), Tag3 = tags.ElementAt(2) };
            }
            else
            {
                return new List<SimplePortfolio>();
            }
            return await GetSimplePortfolio(SimplePortfolioQuery(query), param);
        }

        private async Task<IEnumerable<SimplePortfolio>> GetSimpleProducts3(IEnumerable<string> tags)
        {
            string query = string.Empty;
            object param;

            if (tags.Count() == 1)
            {
                query = "[Tags] LIKE '%,@Tag1,%'";
                param = new { Tag1 = tags.ElementAt(0) };
            }
            else if (tags.Count() == 2)
            {
                query = "[Tags] LIKE '%,@Tag1,%' OR [Tags] LIKE '%,@Tag2,%'";
                param = new { Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1) };
            }
            else if (tags.Count() >= 2)
            {
                query = "[Tags] LIKE '%,@Tag1,%' OR [Tags] LIKE '%,@Tag2,%' OR [Tags] LIKE '%,@Tag3,%'";
                param = new { Tag1 = tags.ElementAt(0), Tag2 = tags.ElementAt(1), Tag3 = tags.ElementAt(2) };
            }
            else
            {
                return new List<SimplePortfolio>();
            }
            return await GetSimplePortfolio(SimplePortfolioQuery(query), param);
        }
    }
}
