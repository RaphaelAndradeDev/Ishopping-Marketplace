using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ishopping.MVC.Models
{
    

    public class AppDictionary
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class StrDictionary
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class CompoCategoria
    {
        public int CatId { get; set; }
        public string Categoria { get; set; }
        public int NumProdutos { get; set; }
    }

    public class Retorno
    {
        public bool ErroCliente { get; set; }               // O erro é retornado ao cliente
        public bool ErroIshopping { get; set; }             // O erro é retornado ao Ishopping
        public string RetornoCliente { get; set; }
        public string RetornoIshopping { get; set; }        
    }

    public class IshoppingSavedError
    {
        public IshoppingSavedError(string erroDescription)
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            //Erro erro = new Erro();
            //erro.ErroDate = DateTime.Now;
            //erro.ErroDescription = erroDescription;
            //db.Erro.Add(erro);
            //db.SaveChanges();
        }      
    }
}