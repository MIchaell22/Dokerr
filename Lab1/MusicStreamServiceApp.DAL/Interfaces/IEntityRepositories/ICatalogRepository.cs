using MusicStreamServiceApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamServiceApp.DAL.Interfaces.IEntityRepositories
{
    public interface ICatalogRepository : IGenericRepository<Catalog, int>
    {
        Task<Catalog> Get(string Name, string Author);

        Task<IEnumerable<Catalog>> GetAuthorCatalogs(string Author);
    }
}
