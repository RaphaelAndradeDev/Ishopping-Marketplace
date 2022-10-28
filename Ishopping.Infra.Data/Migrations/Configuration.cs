namespace Ishopping.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ishopping.Infra.Data.Contexto.IshoppingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Ishopping.Infra.Data.Contexto.IshoppingContext context)
        {
        }
    }
}
