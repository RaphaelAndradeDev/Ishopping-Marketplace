
namespace Ishopping.Application.Common
{
    public class JsonResponse
    {
        public bool Redirect = false;
        public bool Serialize = true;
        public string RedirectUrl = "Alter";
        public string Term = null;
        public string Response = null;        
        public string Id = "00000000-0000-0000-0000-000000000000"; 
        public string Ex = " Erro Desconhecido";
        public string Message = "Dados salvos com sucesso";
    }

    public class JsonError
    {
        public bool Redirect { get; private set; }
        public string RedirectUrl { get; private set; }
        public string Id { get; private set; }
        public string Ex { get; private set; }
        public string Message { get; private set; }

        public JsonError(string ex)
        {
            this.Redirect = false;
            this.RedirectUrl = "Alter";
            this.Id = "00000000-0000-0000-0000-000000000000"; 
            this.Ex = ex;
            this.Message = "Erro na tentativa de salvar dados";
        }

        public JsonError(string id, string ex)
        {
            this.Redirect = false;
            this.RedirectUrl = "Alter";
            this.Id = id;
            this.Ex = ex;
            this.Message = "Erro na tentativa de salvar dados";
        }
    }

    public class JsonDelete
    {
        public string Id { get; set; }
        public bool Redirect { get; set; }
        public bool Serialize { get; set; }
        public string RedirectUrl { get; set; }
        public string Term { get; set; }
        public string Response { get; set; }
        public string Message { get; set; }
         
        public JsonDelete(bool redirect = false, bool serialize = true, string term = null)
        {
            this.Id = "00000000-0000-0000-0000-000000000000";
            this.Redirect = redirect;
            this.Serialize = serialize;
            this.RedirectUrl = "Alter";
            this.Term = term;
            this.Message = "Objeto deletado com sucesso";
        }

        public JsonDelete(string id)
        {
            this.Id = id;
            this.Redirect = false;
            this.RedirectUrl = "Alter"; 
            this.Message = "O objeto não foi deletado";
        }
    }

    public class JsonPageNotFound
    {
        public bool Redirect { get; private set; }
        public string RedirectUrl { get; private set; }
        public string Id { get; private set; } 
        public string Message { get; private set; }

        public JsonPageNotFound(bool redirect = true)
        {
            this.Redirect = redirect;
            this.RedirectUrl = "Alter";
            this.Id = "00000000-0000-0000-0000-000000000000";    
            this.Message = "A página não existe ou pode estar desativada";
        }
    }

    public class JsonFileNotFound
    {      
        public string Id { get; private set; }
        public bool FileFound { get; private set; }
        public string Message { get; private set; }

        public JsonFileNotFound()
        {           
            this.Id = "00000000-0000-0000-0000-000000000000";
            this.FileFound = false;
            this.Message = "Nenhum objeto foi encontrado";
        }   
    }

}
