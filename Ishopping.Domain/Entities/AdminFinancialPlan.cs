using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class AdminFinancialPlan
    {
        public int Id { get; private set; }
        public int Cod { get; private set; }                    // Identificação única
        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public int Month { get; private set; }

        // Configurações do plano
        public int Group { get; private set; }
        public int Exhibition { get; private set; }
        public int Gallery { get; private set; }
        public int Products { get; private set; }
        public int DataBase { get; private set; }
        public int Email { get; private set; }

        // Relacionamentos
        public virtual ICollection<UserFinancialHistory> UserFinancialHistory { get; private set; }

        // Ctor
        protected AdminFinancialPlan() { }

        public AdminFinancialPlan(int cod, string name, decimal value, int month, int group, int exhibition, int gallery, int products, int dataBase, int email)
        {
            this.Cod = cod;
            this.Name = name;
            this.Value = value;
            this.Month = month;
            this.Group = group;
            this.Exhibition = exhibition;
            this.Gallery = gallery;
            this.Products = products;
            this.DataBase = dataBase;
            this.Email = email;
        }        
    }
}
