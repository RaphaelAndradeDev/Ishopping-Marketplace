using Ishopping.Domain.Communs;

namespace Ishopping.Domain.ApplicationClass
{
    public class BasicText
    {
        public int Position { get; private set; }
        public string Text32 { get; private set; }  
        public string Text512 { get; private set; }
        public string Text5120 { get; private set; }     

        public BasicText(int position, string text32, string text512, string text5120)
        {              
            this.Position = position;
            this.Text32 = text32;        
            this.Text512 = text512;       
            this.Text5120 = text5120;       
        }

        private string GetText(int position, string text)
        {
            return string.IsNullOrEmpty(text) ?            
                text = "Edite texto " + position:
                text = IsHtmlTags.RemoveTags(text);            
        }

        public string TextJoin()
        {
            string str = IsHtmlTags.RemoveTags(this.Text32 + this.Text512 + this.Text5120);
            return str != "" ? str : "Edite texto " + this.Position;
        }
    }
}
