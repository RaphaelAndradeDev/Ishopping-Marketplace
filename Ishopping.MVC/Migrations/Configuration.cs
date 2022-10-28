namespace Ishopping.MVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ishopping.MVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Ishopping.MVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;        
        }

        protected override void Seed(Ishopping.MVC.Models.ApplicationDbContext context)
        {                                 
        }
    }
}
