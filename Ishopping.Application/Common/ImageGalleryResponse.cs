using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Application.Common
{
    public class ImageGalleryResponse
    {
        public bool Validade { get; private set; }
        public string Action { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public int MaxFileSize { get; private set; }
        public int ImageQuantity { get; private set; }
        public int ImageCount { get; private set; }
        public int MaxImageQuantity { get { return ImageQuantity - ImageCount; } }
        public string FileType { get; private set; }
        public int ViewCod { get; private set; }
        public string EntityId { get; private set; }

        const string _text = "Arquivos do tipo JPEG ou PNG e com tamanho máximo de 2 Megas.  ";
        const int _fileSize = 2000000;
   
        // Ctor
        public ImageGalleryResponse()
        {
            Validade = false;
        }

        public ImageGalleryResponse(int imageCount, int plan, int fileType, int viewCod, int? imageQuantity, string text = _text, int maxFileSize = _fileSize)
        {
            SetAction(fileType);

            ImageQuantity = imageQuantity.HasValue ? imageQuantity.Value : GetImageQuantity(plan, fileType);
            ImageCount = imageCount;         
            FileType = fileType.ToString();
            ViewCod = viewCod;
            EntityId = fileType.ToString();
            Text = text;
            MaxFileSize = maxFileSize;
            Validade = true;
        }

        public ImageGalleryResponse(int imageCount, int plan, int fileType)
        {      
            ImageQuantity = GetImageQuantity(plan, fileType);
            ImageCount = imageCount;            
        }
        
        // Methods
        private int GetImageQuantity(int plan, int fileType)
        {
            const int _plan = 4;
            const int _fileType = 16;   

            int[,] imgQuantity = new int[_plan, _fileType]
            {
                {2,4,3,6,6,6,12,10,10,12,12,3,12,12,8,4},                           // Plano 1 = Basic
                {2,4,3,8,8,8,12,12,12,16,12,3,12,12,8,6},                           // Plano 2 = BasicPro
                {2,4,3,16,16,16,18,18,24,24,16,3,18,24,12,12},                      // Plano 3 = Professional
                {2,4,3,16,16,16,24,24,40,40,16,3,24,24,16,16}                       // Plano 4 = Premium
            };

            return imgQuantity[plan, fileType - 1];
        }

        private void SetAction(int fileType)
        {
            switch (fileType)
            {
                case 1:
                    Action = "Index";
                    Text = "Imagens Views";
                    break;
                case 2:
                    Action = "GetImgIcon";
                    Text = "Imagens Ícones";
                    break;
                case 3:
                    Action = "GetImgLogo";
                    Text = "Imagens Logotipo";
                    break;
                case 4:
                    Action = "GetImgClient";
                    Text = "Imagens Clientes";
                    break;
                case 5:
                    Action = "GetImgTeam";
                    Text = "Imagens Equipe";
                    break;
                case 6:
                    Action = "GetImgBrand";
                    Text = "Imagens Marcas";
                    break;
                case 7:
                    Action = "GetImgPortofolio";
                    Text = "Imagens Portfólio";
                    break;
                case 8:
                    Action = "GetImgProjects";
                    Text = "Imagens Projetos";
                    break;
                case 9:
                    Action = "GetImgProd";
                    Text = "Imagens Produtos";
                    break;
                case 10:
                    Action = "GetImgPost";
                    Text = "Imagens Post";
                    break;
                case 11:
                    Action = "GetImgService";
                    Text = "Imagens Serviços";
                    break;
                case 12:
                    Action = "GetImgCard";
                    Text = "Imagens Cartão de Visita";
                    break;
                case 13:
                    Action = "GetImgCarte";
                    Text = "Imagens Menu";
                    break;
                case 14:
                    Action = "GetImgThumbnail";
                    Text = "Imagens Thumbnail";
                    break;
                case 15:
                    Action = "GetImgPresentation";
                    Text = "Imagens Apresentação";
                    break;
                case 16:
                    Action = "GetImgSlider";
                    Text = "Imagens Sliders";
                    break;
            }            
        }

        private void SetValidate(bool validate)
        {
            Validade = validate;
        }

    }
}
