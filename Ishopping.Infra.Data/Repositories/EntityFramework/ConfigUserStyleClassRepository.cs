using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace Ishopping.Infra.Data.Repositories
{
    public class ConfigUserStyleClassRepository : RepositoryBaseT2<ConfigUserStyleClass>, IConfigUserStyleClassRepository
    {
        public void AddRanger(IEnumerable<ConfigUserStyleClass> configUserStyleClass)
        {
            db.ConfigUserStyleClass.AddRange(configUserStyleClass);
            db.SaveChanges();
        }

        public ConfigUserStyleClass GetById(Guid id, string userId)
        {
            return db.ConfigUserStyleClass.FirstOrDefault(x => x.Id == id && x.IdUser == userId);
        }        

        public IEnumerable<ConfigUserStyleClass> GetAllByUserId(string userId)
        {
            return db.ConfigUserStyleClass.Where(x => x.IdUser == userId);
        }

        public ConfigUserStyleClass GetByClassName(string className, string userId)
        {
            return db.ConfigUserStyleClass.FirstOrDefault(x => x.ClassName == className && x.IdUser == userId);
        }

        public IEnumerable<string> GetAllClassName(string userId)
        {
            return db.ConfigUserStyleClass.Where(x => x.ClassName != "SemEstilo" && x.IdUser == userId).Select(x => x.ClassName).ToList();
        }  

        public void DeleteAll(string userId)
        {
            var obj = GetAllByUserId(userId);
            db.ConfigUserStyleClass.RemoveRange(obj);
            db.SaveChanges();
        }

        // Async Methods
        public async Task<ConfigUserStyleClass> GetByIdAsync(Guid id, string userId)
        {
            return await db.ConfigUserStyleClass.FirstOrDefaultAsync(x => x.Id == id && x.IdUser == userId);
        }

        public async Task<IEnumerable<ConfigUserStyleClass>> GetAllByUserIdAsync(string userId)
        {
            return await db.ConfigUserStyleClass.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<ConfigUserStyleClass> GetByClassNameAsync(string className, string userId)
        {
            return await db.ConfigUserStyleClass.FirstOrDefaultAsync(x => x.ClassName == className && x.IdUser == userId);
        }

        public async Task<IEnumerable<string>> GetAllClassNameAsync(string userId)
        {
            return await db.ConfigUserStyleClass.Where(x => x.ClassName != "SemEstilo" && x.IdUser == userId).Select(x => x.ClassName).ToListAsync();
        }

    }
}
