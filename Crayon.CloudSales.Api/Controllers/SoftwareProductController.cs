using AutoMapper;
using Crayon.CloudSales.Api.Dtos;
using Crayon.CloudSales.Api.Mappers;
using Crayon.CloudSales.Core.Entities;
using Crayon.CloudSales.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crayon.CloudSales.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoftwareProductController : Controller
    {
        private readonly ISoftwareProductService _service;

        public SoftwareProductController(ISoftwareProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> ListSoftwareProductsAsync()
        {
            var entities = await _service.ListSoftwareProducts();
            var dtos = entities.Select(SoftwareProductMapper.ToSoftwareProductDto);

            return Json(dtos);
        }
    }
}
