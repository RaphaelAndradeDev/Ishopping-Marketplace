using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.SectionModels.Content
{
    public class ContentTextSectionModel
    {
        private readonly IContentTextAppService _contentText;
        public List<TextModels> ListText { get; private set; }

        private int _siteNumber;   
        private AdminViewData _viewData;

        public ContentTextSectionModel(int siteNumber, IContentTextAppService contentText, AdminViewData adminViewData)
        {
            this._siteNumber = siteNumber;
            this._viewData = adminViewData;
            _contentText = contentText;
            this.ListText = listText();            
        }

        private List<TextModels> listText()
        {
            List<TextModels> list = new List<TextModels>();

            string[] seqText = _viewData.ListText.Split(new Char[] { ',' });

            int[] tamText = Array.ConvertAll(seqText, int.Parse);
            int maxPosition = tamText.Length;

            TextModels[] texto = new TextModels[maxPosition];

            var listText = _contentText.GetAllBySiteNumber(_siteNumber, maxPosition, _viewData.ViewCod).ToList();

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