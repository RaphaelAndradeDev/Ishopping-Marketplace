using Ishopping.Common.Resources;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Application.SectionModels.Content
{
    public class ContentButtonSectionModel
    {
        private readonly IContentButtonService _contentButton;
        public List<ButtonModels> ListButton { get; private set; }

        private int _siteNumber;
        private int _viewCod;
        private int _numBtn;

        public ContentButtonSectionModel(int siteNumber, IContentButtonService contentButton, AdminViewData adminViewData)
        {
            _contentButton = contentButton;
            _siteNumber = siteNumber;
            _viewCod = adminViewData.ViewCod;
            _numBtn = adminViewData.NumBtn;
            ListButton = listButton();
        }

        public ContentButtonSectionModel(int siteNumber, IContentButtonService contentButton, int viewCod, int numButton)
        {
            _contentButton = contentButton;
            _siteNumber = siteNumber;
            _viewCod = viewCod;
            _numBtn = numButton;                  
            ListButton = listButton();
        }

        public List<ButtonModels> listButton()
        {
            List<ButtonModels> list = new List<ButtonModels>();

            int sr = _viewCod;
            int maxPosition = _numBtn;

            ButtonModels[] Button = new ButtonModels[maxPosition];

            var listBtn = _contentButton.GetAllBySiteNumber(_siteNumber, maxPosition, _viewCod).ToList();

            for (int i = 0; i < maxPosition; i++)
            {
                Button[i] = listBtn.Where(x => x.Position == i + 1).Select(x => new ButtonModels { TextButton = x.TextBtn, UrlButton = x.TextURL, StButton = x.ContentButtonOption.TextBtn }).FirstOrDefault();

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
