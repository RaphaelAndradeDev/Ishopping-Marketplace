using Ishopping.Common.Resources;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Application.SectionModels.Content
{
    public class ContentTextSectionModel
    {
        private readonly IContentTextService _contentTextService;
        public List<TextModels> ListText { get; private set; }

        private int _siteNumber;
        private int _viewCod;
        private string _textType;
        

        public ContentTextSectionModel(int siteNumber, IContentTextService contentText, AdminViewData adminViewData)
        {
            _siteNumber = siteNumber;
            _viewCod = adminViewData.ViewCod;
            _textType = adminViewData.ListText;
            _contentTextService = contentText;
            ListText = listText();
        }

        public ContentTextSectionModel(int siteNumber, IContentTextService contentTextService, int viewCod, string textType)
        {
            _siteNumber = siteNumber;
            _contentTextService = contentTextService;
            _viewCod = viewCod;
            _textType = textType;            
            ListText = listText();
        }

        private List<TextModels> listText()
        {
            List<TextModels> list = new List<TextModels>();

            string[] seqText = _textType.Split(new Char[] { ',' });

            int[] tamText = Array.ConvertAll(seqText, int.Parse);
            int maxPosition = tamText.Length;

            TextModels[] texto = new TextModels[maxPosition];

            var listText = _contentTextService.GetAllBySiteNumber(_siteNumber, maxPosition, _viewCod).ToList();

            for (int i = 0; i < maxPosition; i++)
            {

                if (tamText[i] == 1)
                {
                    texto[i] = listText.Where(x => x.Position == i + 1).Select(x => new TextModels { Text = x.Text32, StText = x.ContentTextOption.Text32 }).FirstOrDefault();
                    if (texto[i] != null) { list.Add(texto[i]); } else { list.Add(new TextModels { Text = Resource.TextoPequeno + " " + (i + 1), StText = "SemEstilo" }); }
                }

                else if (tamText[i] == 2)
                {
                    texto[i] = listText.Where(x => x.Position == i + 1).Select(x => new TextModels { Text = x.Text512, StText = x.ContentTextOption.Text512 }).FirstOrDefault();
                    if (texto[i] != null) { list.Add(texto[i]); } else { list.Add(new TextModels { Text = Resource.TextoMedio + " " + (i + 1), StText = "SemEstilo" }); }
                }

                else if (tamText[i] == 3)
                {
                    texto[i] = listText.Where(x => x.Position == i + 1).Select(x => new TextModels { Text = x.Text5120, StText = x.ContentTextOption.Text5120 }).FirstOrDefault();
                    if (texto[i] != null) { list.Add(texto[i]); } else { list.Add(new TextModels { Text = Resource.TextoGrande + " " + (i + 1) + Resource.TextoAdicional + Resource.LoremLipsum_1, StText = "SemEstilo" }); }
                }
            }
            return list;
        }
    }
}
