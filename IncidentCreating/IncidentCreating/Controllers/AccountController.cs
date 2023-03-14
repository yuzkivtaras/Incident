using DataService.IConfiguration;
using Entities.DbSet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentCreating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("AddAccount")]
        public async Task<IActionResult> AddAccounts([FromBody] Account account)
        {
            var accountExist = await _unitOfWork.Accounts.GetByName(account.AccountName);
            if (accountExist != null)
            {
                return BadRequest("Not Found");
            }

            var _account = new Account();
            _account.AccountName = account.AccountName;

            await _unitOfWork.Accounts.Add(account);
            await _unitOfWork.CompleteAsync();

            return Ok();


        }
    }
}
