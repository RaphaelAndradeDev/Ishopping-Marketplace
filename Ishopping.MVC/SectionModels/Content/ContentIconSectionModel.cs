using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.SectionModels.Content
{
    public class ContentIconSectionModel
    {
        private readonly IContentIconAppService _contentIcon;
        public List<string> ListVectorIcon { get; private set; }

        private int _siteNumber;
        private AdminViewData _viewData;

        public ContentIconSectionModel(int siteNumber, IContentIconAppService contentIcon, AdminViewData adminViewData)
        {
            this._siteNumber = siteNumber;
            this._viewData = adminViewData;
            _contentIcon = contentIcon;
            this.ListVectorIcon = listIcon();
        }

        private List<string> listIcon()
        {
            List<string> list = new List<string>();

            int sr = _viewData.ViewCod;
            string[] seqIcon = _viewData.ListVectorIcon.Split(new Char[] { ',' });

            int[] tipoIcon = Array.ConvertAll(seqIcon, int.Parse);
            int maxPosition = tipoIcon.Length;

            string[] icon = new string[maxPosition];

            var listIcon = _contentIcon.GetAllBySiteNumber(_siteNumber, maxPosition, _viewData.ViewCod).ToList();

            for (int i = 0; i < maxPosition; i++)
            {

                if (tipoIcon[i] == 1)
                {
                    icon[i] = listIcon.Where(x => x.Position == i + 1).Select(x => x.Icon).FirstOrDefault();
                    if (icon[i] != null) { list.Add(icon[i]); } else { list.Add(Resource.FontAwesome); }
                }

                else if (tipoIcon[i] == 2)
                {
                    icon[i] = listIcon.Where(x => x.Position == i + 1).Select(x => x.Icon).FirstOrDefault();
                    if (icon[i] != null) { list.Add(icon[i]); } else { list.Add(Resource.Glyphicons); }
                }

                else if (tipoIcon[i] == 3)
                {
                    icon[i] = listIcon.Where(x => x.Position == i + 1).Select(x => x.Icon).FirstOrDefault();
                    if (icon[i] != null) { list.Add(icon[i]); } else { list.Add(Resource.ElusiveIcons); }
                }
            }
            return list;
        }
    }
}