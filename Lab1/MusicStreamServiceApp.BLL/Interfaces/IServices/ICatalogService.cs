using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MusicStreamServiceApp.BLL.DTOs;

namespace MusicStreamServiceApp.BLL.Interfaces.IServices
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogDTO>> GetAllCatalogsAsync();

        Task<CatalogDTO> GetCatalogAsync(int Id);

        Task AddCatalogAsync(CatalogDTO catalogDTO);

        Task UpdateCatalogAsync(CatalogDTO catalogDTO);

        Task DeleteCatalogAsync(int Id);

        Task<CatalogDTO> GetCatalogAsync(string Name, string Author);

        Task<IEnumerable<CatalogDTO>> GetAuthorCatalogsAsync(string Author);

        Task<bool> IsAnyCatalogDefinedAsync(int Id);
    }
}
