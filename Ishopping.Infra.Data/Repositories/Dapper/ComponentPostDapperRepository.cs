using Dapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ComponentPostDapperRepository : Repository, IComponentPostDapperRepository
    {
        public IEnumerable<ComponentPost> GetAllBySiteNumber(int siteNumber)
        {
            throw new System.Exception();
        }         
               
        // Async Methods
        public async Task<IEnumerable<ComponentPost>> GetAllBySiteNumberAsync(int siteNumber)
        {
            string str = "SELECT TOP 36 cm.Id As PostId, cm.IdUser, cm.SiteNumber, cm.Autor, cm.Categoria, cm.Titulo, cm.SubTitulo1, SUBSTRING(cm.Paragrafo1, 0, 64), cm.Video, cm.DataCadastro, cm.Views," +
                " st.Id As OptionId, st.Autor, st.Categoria, st.Titulo, st.SubTitulo, st.Paragrafo" +
                " img.Id As ImageId, img.Folder, img.FileName" +
                " FROM ComponentPost cm" +
                " INNER JOIN ComponentPostUserImageGallery pi ON pi.ComponentPost_Id = cm.Id" +
                " INNER JOIN UserImageGallery img ON pi.UserImageGallery_Id = img.Id" +
                " INNER JOIN ComponentPostOption st ON cm.ComponentPostOptionId = st.Id" +                
                " WHERE cm.SiteNumber = @SiteNumber AND cm.DisplayOnPage = @DisplayOnPage" +
                " ORDER BY cm.DataCadastro";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<ComponentPost> list = await cn.QueryAsync<ComponentPost, ComponentPostOption, UserImageGallery, ComponentPost >(str, (cm, st, img) => { cm.AddComponentPostOption(st); return cm; }, new { SiteNumber = siteNumber, DisplayOnPage = true }, splitOn: "PostId,OptionId,ImageId");
                cn.Close();
                return list;
            }
        }


        // Async Methods for SinglePost
        public async Task<SinglePost> GetSinglePostByIdAsync(Guid id)
        {
            var listSinglePost = await GetSinglePost(SinglePostQuery("cm.Id = @Id"), new { Id = id });
            return listSinglePost.FirstOrDefault();
        }

        // Async Methods for SimplePost
        public async Task<IEnumerable<SimplePost>> GetAllBySiteNumberAsync(int siteNumber, int take)
        {
            return await GetSimplePost(SimplePostQuery("cm.SiteNumber = @SiteNumber", "cm.Views"), new { SiteNumber = siteNumber});
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int take)
        {
            return await GetSimplePost(SimplePostQuery("", "cm.DataCadastro"), new { });
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int siteNumber, int take)
        {
            return await GetSimplePost(SimplePostQuery("cm.SiteNumber = @SiteNumber", "cm.DataCadastro"), new { SiteNumber = siteNumber });
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(string category, int take)
        {
            return await GetSimplePost(SimplePostQuery("cm.Categoria = @Categoria", "cm.DataCadastro"), new { Categoria = category });
        }

        public async Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int take)
        {
            return await GetSimplePost(SimplePostQuery("cm.Categoria = @Categoria"), new { Categoria = category });
        }

        public async Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int siteNumber, int take)
        {
            return await GetSimplePost(SimplePostQuery("cm.Categoria = @Categoria AND cm.SiteNumber = @SiteNumber"), new { Categoria = category, SiteNumber = siteNumber });
        }

        public async Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int take)
        {
            return await GetSimplePost(SimplePostQuery("", "cm.Views"), new { });
        }

        public async Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int siteNumber, int take)
        {
            return await GetSimplePost(SimplePostQuery("cm.SiteNumber = @SiteNumber"), new { SiteNumber = siteNumber });
        }

        public async Task<IEnumerable<SimplePost>> GetAllByTermAsync(string term)
        {
            return await GetSimplePost(SimplePostQuery("cm.Search = @Term"), new { Term = term });
        }


        // Private Methods
        private string SimplePostQuery(string where)
        {
            where = where == "" ? "" : " AND " + where;
            var str = new StringBuilder();
            str.Append("SELECT TOP 36 cm.Id, cm.SiteNumber, cm.Autor, cm.Categoria, cm.Titulo, cm.SubTitulo1, SUBSTRING(cm.Paragrafo1, 0, 64) AS Paragrafo1, cm.DataCadastro, cm.Views,");
            str.Append(" img.Id, img.Folder, img.FileName");
            str.Append(" FROM ComponentPost cm");
            str.Append(" INNER JOIN ComponentPostUserImageGallery pi ON pi.ComponentPost_Id = cm.Id");
            str.Append(" INNER JOIN UserImageGallery img ON pi.UserImageGallery_Id = img.Id");
            str.Append(" WHERE cm.DisplayOnlyPage = 'False' AND cm.IsBlock = 'False'" + where);     
            return str.ToString();
        }

        private string SimplePostQuery(string where, string orderBy)
        {
            var str = new StringBuilder();
            str.Append(SimplePostQuery(where));
            str.Append(" ORDER BY " + orderBy);
            return str.ToString();
        }              
      
        private async Task<IEnumerable<SimplePost>> GetSimplePost(string query, object param)
        {
            using (var cn = IshoppingConnection)
            {                
                var k = await cn
                .QueryAsync<SimplePost, UserImageGallery, SimplePost>(
                    query.ToString(),
                    (cm, img) =>
                    {
                        cm.UserImageGallery = cm.UserImageGallery ?? new List<UserImageGallery>();
                        cm.UserImageGallery.Add(img);
                        return cm;
                    },
                    param,
                    splitOn: "Id"
                );

                return k.GroupBy(o => o.Id)
                .Select(group =>
                {
                    var combinedOwner = group.First();
                    combinedOwner.UserImageGallery = group.Select(owner => owner.UserImageGallery.Single()).ToList();
                    return combinedOwner;
                });
            }
        }

        private string SinglePostQuery(string where)
        {
            where = where == "" ? "" : " AND " + where;
            var str = new StringBuilder();
            str.Append("SELECT TOP 36 cm.Id, cm.SiteNumber, cm.Model, cm.Autor, cm.Categoria, cm.Titulo, cm.SubTitulo1, cm.Paragrafo1, cm.SubTitulo2, cm.Paragrafo2, cm.SubTitulo3, cm.Paragrafo3, cm.Video, cm.Tags, cm.DataCadastro, cm.Views,");
            str.Append(" img.Id, img.Folder, img.FileName");
            str.Append(" FROM ComponentPost cm");
            str.Append(" INNER JOIN ComponentPostUserImageGallery pi ON pi.ComponentPost_Id = cm.Id");
            str.Append(" INNER JOIN UserImageGallery img ON pi.UserImageGallery_Id = img.Id");
            str.Append(" WHERE cm.IsBlock = 'False'" + where);
            return str.ToString();
        }        

        private async Task<IEnumerable<SinglePost>> GetSinglePost(string query, object param)
        {
            using (var cn = IshoppingConnection)
            {
                var k = await cn
                .QueryAsync<SinglePost, UserImageGallery, SinglePost>(
                    query.ToString(),
                    (cm, img) =>
                    {
                        cm.UserImageGallery = cm.UserImageGallery ?? new List<UserImageGallery>();
                        cm.UserImageGallery.Add(img);
                        return cm;
                    },
                    param,
                    splitOn: "Id"
                );

                return k.GroupBy(o => o.Id)
                .Select(group =>
                {
                    var combinedOwner = group.First();
                    combinedOwner.UserImageGallery = group.Select(owner => owner.UserImageGallery.Single()).ToList();
                    return combinedOwner;
                });
            }
        }
    }
}
