using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ishopping.SectionModels.Content
{
    public class ContentVideoSectionModel
    {
        private readonly IContentVideoAppService _contentVideo;
        public List<string> ListVideo { get; private set; }

        private int _siteNumber;
        private AdminViewData _viewData;
        public ContentVideoSectionModel(int siteNumber, IContentVideoAppService contentVideo, AdminViewData adminViewData)
        {
            this._siteNumber = siteNumber;
            this._viewData = adminViewData;
            _contentVideo = contentVideo;
            this.ListVideo = listVideo();
        }

        private List<string> listVideo()
        {
            List<string> listas = new List<string>();
            int maxPosition = _viewData.NumVideo;

            string[] list = new string[maxPosition];

            var listVideo = _contentVideo.GetAllBySiteNumber(_siteNumber, maxPosition, _viewData.ViewCod).ToList();

            for (int i = 0; i < maxPosition; i++)
            {
                string item = "";
                list[i] = listVideo.Where(x => x.Position == i + 1).Select(x=> x.Url).FirstOrDefault();
                if (list[i] != null) { item = (list[i]); } else { item = Resource.Video; }               
                listas.Add(item);
            }
            return listas;
        }
    }
}