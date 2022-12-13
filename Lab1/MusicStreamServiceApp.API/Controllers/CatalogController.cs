using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStreamServiceApp.BLL.DTOs;
using MusicStreamServiceApp.BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MusicStreamServiceApp.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly ICatalogService catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogDTO>>> GetAll()
        {
            var catalogDTOList = await catalogService.GetAllCatalogsAsync();

            if (catalogDTOList == null)
            {
                return NotFound();
            }

            return Ok(catalogDTOList);
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<CatalogDTO>> Get(int Id)
        {
            var catalogDTO = await catalogService.GetCatalogAsync(Id);

            if (catalogDTO == null)
            {
                return NotFound();
            }

            return catalogDTO;
        }

        /// <summary>
        /// Create album
        /// </summary>
        /// <param name="catalogDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CatalogDTO>> Post([FromBody] CatalogDTO catalogDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await catalogService.AddCatalogAsync(catalogDTO);

            catalogDTO = await catalogService.GetCatalogAsync(catalogDTO.Name, catalogDTO.Author);

            return CreatedAtAction(nameof(Get), new { id = catalogDTO.Id }, catalogDTO);
        }

        /// <summary>
        /// Update by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="catalogDTO"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<ActionResult<CatalogDTO>> Put(int Id, [FromBody] CatalogDTO catalogDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await catalogService.IsAnyCatalogDefinedAsync(Id))
            {
                return NotFound();
            }

            catalogDTO.Id = Id;

            await catalogService.UpdateCatalogAsync(catalogDTO);
            return Ok(catalogDTO);
        }

        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CatalogDTO>> Delete(int Id)
        {
            if (!await catalogService.IsAnyCatalogDefinedAsync(Id))
            {
                return NotFound();
            }

            await catalogService.DeleteCatalogAsync(Id);
            return NoContent();
        }
    }
}
