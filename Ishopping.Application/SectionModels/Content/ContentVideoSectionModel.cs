using Ishopping.Application.Interface;
using Ishopping.Common.Resources;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Application.SectionModels.Content
{
    public class ContentVideoSectionModel
    {
        private readonly IContentVideoService _contentVideo;
        public List<VideoModels> ListVideo { get; private set; }

        private int _siteNumber;
        private int _viewCod;
        private int _numVideo;

        public ContentVideoSectionModel(int siteNumber, IContentVideoService contentVideo, AdminViewData adminViewData)
        {
            _contentVideo = contentVideo;
            _siteNumber = siteNumber;
            _viewCod = adminViewData.ViewCod;
            _numVideo = adminViewData.NumVideo;            
            ListVideo = listVideo();
        }

        public ContentVideoSectionModel(int siteNumber, IContentVideoService contentVideo, int viewCod, int numVideo)
        {
            _contentVideo = contentVideo;
            _siteNumber = siteNumber;
            _viewCod = viewCod;
            _numVideo = numVideo;            
            ListVideo = listVideo();
        }

        private List<VideoModels> listVideo()
        {
            List<VideoModels> listas = new List<VideoModels>();
            int maxPosition = _numVideo;

            string[] list = new string[maxPosition];

            var listVideo = _contentVideo.GetAllBySiteNumber(_siteNumber, maxPosition, _viewCod).ToList();

            for (int i = 0; i < maxPosition; i++)
            {
                VideoModels item = new VideoModels();
                list[i] = listVideo.Where(x => x.Position == i + 1).Select(x => x.Url).FirstOrDefault();
                if (list[i] != null) { item.VideoUrl = (list[i]); } else { item.VideoUrl = Resource.Video; }
                listas.Add(item);
            }
            return listas;
        }
    }
}
