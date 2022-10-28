
namespace Ishopping.Domain.Communs
{
    public class _Slider
    {
        public int Position { get; set; }
        public int SliderType { get; set; }                 // slider para texto, butão, video ou imagem
        public string SliderName { get; set; }              // nome do slider
        public string SliderClass { get; set; }             // nome da classe do slider

        // slide config
        public string PartialView { get; set; }
        public string ClassTarget { get; set; }
        public string Incoming { get; set; }
        public string Outgoing { get; set; }
        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public string DataX { get; set; }
        public string DataY { get; set; }       
        public string DataHoffset { get; set; }
        public string DataVoffset { get; set; }        
        public string DataSpeed { get; set; }
        public string DataEndSpeed { get; set; }
        public string DataEasing { get; set; }
        public string DataEndEasing { get; set; }
        public string DataSplitin { get; set; }
        public string DataSplitout { get; set; }
        public string DataElementdelay { get; set; }
        public string DataEndelementdelay { get; set; }
        public string DataImgWidth { get; set; }
        public string DataImgHeight { get; set; }
        public string DataImgZindex { get; set; }

        // style config        
        public string Caption { get; set; }      

        // slide data
        public string Text { get; set; }                        // texto 64 caracteres    
        public string Url { get; set; }                         // url para video ou butão
        public string ImageFileName { get; set; }                
    }
}
