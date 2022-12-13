using BlazorUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI.Interfaces.IServices
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogViewModel>> GetCatalogsAsync();
        Task<CatalogViewModel> GetCatalogById(int AlbumId);
    }
}
