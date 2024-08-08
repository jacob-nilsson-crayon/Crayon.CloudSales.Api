using Crayon.CloudSales.Core.Interfaces.Services;
using Crayon.CloudSales.Infrastructure.Database.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Crayon.CloudSales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAccountsAsync(string customerId)
        {
            var entities = await _accountService.GetAccounts(customerId);
            var dtos = entities.Select(AccountMapper.ToAccountDto);

            return Ok(dtos);
        }
    }
}
