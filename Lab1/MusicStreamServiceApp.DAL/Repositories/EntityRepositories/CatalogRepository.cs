using MusicStreamServiceApp.DAL.EFCoreContexts;
using MusicStreamServiceApp.DAL.Entities;
using MusicStreamServiceApp.DAL.Interfaces.IEntityRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamServiceApp.DAL.Repositories.EntityRepositories
{
    public class CatalogRepository : GenericRepository<Catalog, int>, ICatalogRepository
    {
        public CatalogRepository(MusicDBContext db)
            : base(db)
        {
        }

        public async Task<Catalog> Get(string Name, string Author)
        {
            return await db.Set<Catalog>().FirstOrDefaultAsync(e => e.Name == Name && e.Author == Author);
        }

        public async Task<IEnumerable<Catalog>> GetAuthorCatalogs(string Author)
        {
            return await db.Catalogs.Where(e => e.Author == Author).ToListAsync();
        }
    }
}
