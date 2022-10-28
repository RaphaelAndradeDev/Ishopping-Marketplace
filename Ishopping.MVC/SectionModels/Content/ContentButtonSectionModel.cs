using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.SectionModels.Content
{
    public class ContentButtonSectionModel
    {
        private readonly IContentButtonAppService _contentButton;
        public List<ButtonModels> ListButton { get; private set; }

        private int _siteNumber;
        private AdminViewData _viewData;

        public ContentButtonSectionModel(int siteNumber, IContentButtonAppService contentButton, AdminViewData adminViewData)
        {
            this._siteNumber = siteNumber;
            this._viewData = adminViewData;
            _contentButton = contentButton;
            this.ListButton = listButton();
        }

        public List<ButtonModels> listButton()
        {
            List<ButtonModels> list = new List<ButtonModels>();

            int sr = _viewData.ViewCod;
            int maxPosition = _viewData.NumBtn;

            ButtonModels[] Button = new ButtonModels[maxPosition];           

            var listBtn = _contentButton.GetAllBySiteNumber(_siteNumber, maxPosition, _viewData.ViewCod).ToList();

            for (int i = 0; i < maxPosition; i++)
            {
                Button[i] = listBtn.Where(x => x.Position == i + 1).Select(x => new ButtonModels { TextButton = x.TextBtn, UrlButton = x.TextURL, StButton = x.ContentButtonOption.TextBtn}).FirstOrDefault();
           
                if (Button[i] != null)
                {
                    ButtonModels comBtn = new ButtonModels();
                    comBtn.TextButton = Button[i].TextButton;
                    comBtn.UrlButton = Button[i].UrlButton;
                    comBtn.StButton = Button[i].StButton;
                    list.Add(comBtn);
                }
                else
                {
                    ButtonModels comBtn = new ButtonModels();
                    comBtn.TextButton = Resource.Button + " " + (i + 1);
                    comBtn.UrlButton = "#";
                    comBtn.StButton = "SemEstilo";
                    list.Add(comBtn);
                }
            }
            return list;
        }
    }
}