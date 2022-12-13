using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStreamServiceApp.BLL.Interfaces.IServices;
using MusicStreamServiceApp.DAL.Interfaces;
using MusicStreamServiceApp.DAL.Entities;
using MusicStreamServiceApp.BLL.DTOs;
using AutoMapper;

namespace MusicStreamServiceApp.BLL.Services
{
    public class CatalogService : SetOfFields, ICatalogService
    {
        public CatalogService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task AddCatalogAsync(CatalogDTO catalogDTO)
        {
            var catalog = mapper.Map<Catalog>(catalogDTO);

            await unitOfWork.CatalogRepository.Add(catalog);
        }

        public async Task DeleteCatalogAsync(int Id)
        {
            var catalog = await unitOfWork.CatalogRepository.Get(Id);

            await unitOfWork.CatalogRepository.Delete(catalog);
        }

        public async Task<CatalogDTO> GetCatalogAsync(int Id)
        {
            var catalog = await unitOfWork.CatalogRepository.Get(Id);

            return mapper.Map<CatalogDTO>(catalog);
        }

        public async Task<CatalogDTO> GetCatalogAsync(string Name, string Author)
        {
            var catalog = await unitOfWork.CatalogRepository.Get(Name, Author);

            return mapper.Map<CatalogDTO>(catalog);
        }

        public async Task<IEnumerable<CatalogDTO>> GetAllCatalogsAsync()
        {
            var catalogs = await unitOfWork.CatalogRepository.GetAll();

            return mapper.Map<IEnumerable<CatalogDTO>>(catalogs);
        }

        public async Task<IEnumerable<CatalogDTO>> GetAuthorCatalogsAsync(string Author)
        {
            if (Author == null)
            {
                throw new Exception("Author's name is null");
            }

            var catalog = await unitOfWork.CatalogRepository.GetAuthorCatalogs(Author);

            if (catalog == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<CatalogDTO>>(catalogs);
        }

        public async Task<bool> IsAnyCatalogDefinedAsync(int Id)
        {
            return await unitOfWork.CatalogRepository.Any(Id);
        }

        public async Task UpdateCatalogAsync(CatalogDTO catalogDTO)
        {
            var catalog = mapper.Map<Catalog>(catalogDTO);

            await unitOfWork.CatalogRepository.Update(catalog);
        }
    }
}
