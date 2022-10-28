
namespace Ishopping.Domain.ApplicationClass
{
    public class ProfileContact
    {
        public int ViewStart { get; set; }
        public int SiteNumber { get; set; }
        public string SiteName { get; set; }
        public string Controller { get; set; }
        public string Empresa { get; set; }
        public string Rua { get; set; }
        public string NumRua { get; set; }
        public string Distrito { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string _Latitude { get { return Latitude.ToString().Replace(",", "."); }}
        public string _Longitude { get { return Longitude.ToString().Replace(",", "."); }}

        public string Adress
        {
            get { return Rua + " nº " + NumRua + ", " + Cidade + " " + Estado; }
        }

        public string StreetAdress
        {
            get { return Rua + " nº " + NumRua; }
        }

        public string CityAdress
        {
            get { return Cidade + " " + Estado; }
        }

        public string Phone
        {
            get { return Telefone + ", " + Telefone2; }
        }
    }
}
