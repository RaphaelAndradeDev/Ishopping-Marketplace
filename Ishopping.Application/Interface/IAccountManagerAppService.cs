using Ishopping.Application.Common;
using Ishopping.Domain.Entities;

namespace Ishopping.Application.Interface
{
    public interface IAccountManagerAppService
    {
        void AccountCreate(string userId, int group, int templateCod, int viewStart, int siteNumber, string siteName, string semantica1, string semantica2, string semantica3, string semantica4, string empresa, string cnpj, string rua, string numero, string distrito, string cidade, string estado, string cep, string pais, string telefone, string telefone2, string whatsapp, string email, string webSite, bool googleMaps, double latitude, double longitude, string[] cssPath);
        JsonResponse AccountUpdate(string userId, int group, int templateCod, int plan, int viewStart, string[] cssPath);
        JsonResponse AccountUpdate(string userId, string configUserViewId, int viewCod, bool ativo, string textMenu);
        JsonResponse AccountUpdate(string userId, string configUserViewItemId, bool ativo, string textMenu, string textView);
    }
}
