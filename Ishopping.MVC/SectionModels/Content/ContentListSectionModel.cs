using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.SectionModels.Content
{
    public class ContentListSectionModel
    {
        private readonly IContentListAppService _contentList;
        public List<string> ListOfList { get; private set; }

        private int _siteNumber;
        private AdminViewData _viewData;

        public ContentListSectionModel(int siteNumber, IContentListAppService contentList, AdminViewData adminViewData)
        {
            this._siteNumber = siteNumber;
            this._viewData = adminViewData;
            _contentList = contentList;
            this.ListOfList = listList();
        }

        private List<string> listList()
        {
            List<string> listas = new List<string>();
            int maxPosition = _viewData.ListList;

            string[] list = new string[maxPosition];

            var listList = _contentList.GetAllBySiteNumber(_siteNumber, maxPosition, _viewData.ViewCod).ToList();

            for (int i = 0; i < maxPosition; i++)
            {
                string item = "";
                list[i] = listList.Where(x => x.Position == i).Select(x => x.Lista).FirstOrDefault();
                if (list[i] != null) { item = (list[i]); } else { item = Resource.Lista; }
                item = "<li>" + item.Replace(";", "<li></li>") + "</li>";
                listas.Add(item);
            }
            return listas;
        }
    }
}