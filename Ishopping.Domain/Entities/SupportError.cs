using System;

namespace Ishopping.Domain.Entities
{
    public class SupportError
    {
        public int Id { get; private set; }
        public DateTime ErroDate { get; private set; }
        public string ErroDescription { get; private set; }
        public string Exception { get; private set; }

        // Ctor
        protected SupportError() { }

        public SupportError(DateTime erroDate, string erroDescription, string exception)
        {
            this.ErroDate = erroDate;
            this.ErroDescription = erroDescription;
            this.Exception = exception;
        }
    
    }
}
