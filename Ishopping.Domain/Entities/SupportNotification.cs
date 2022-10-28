using System;

namespace Ishopping.Domain.Entities
{
    public class SupportNotification
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public int Destination { get; private set; }            // Destino da notificação. Ishopping. Cliente ou outros

        // Relacionamentos
        public int SupportInfoId { get; private set; }
        public virtual SupportInfo SupportInfo { get; private set; }          // Informação prestada

        // Ctor
        protected SupportNotification() { }

        public SupportNotification(DateTime date, int destination, SupportInfo supportInfo)
        {
            this.Date = date;
            this.Destination = destination;
            this.SupportInfo = supportInfo;
        }       
    }
}
