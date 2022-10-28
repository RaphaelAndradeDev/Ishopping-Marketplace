using System;

namespace Ishopping.Domain.ApplicationClass
{
    public class VideoModels
    {
        string[] stringSeparators = new string[] { "/embed/" };

        public string VideoUrl { get; set; }
        public string VideoCod { get { return VideoUrl.Split(stringSeparators, StringSplitOptions.None)[1]; } }        
    }
}
