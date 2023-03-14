using DataService.IConfiguration;
using Entities.DbSet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentCreating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public IncidentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("AddIncident")]
        public async Task<IActionResult> AddIncidents([FromBody] Incident incident, [FromQuery] Account account, [FromQuery] Contact contact)
        {
            var accountExist = await _unitOfWork.Accounts.GetByName(account.AccountName);
            if (accountExist == null)
            {
                return NotFound();
            }

            var contactExist = await _unitOfWork.Contacts.GetByEmail(contact.Email);
            if (contactExist != null)
            {
                contactExist.FirstName = contact.FirstName;
                contactExist.LastName = contact.LastName;

                await _unitOfWork.Contacts.UpdateContact(contact);
            }   

            await _unitOfWork.Contacts.Add(contact);
            await _unitOfWork.CompleteAsync();

            var incidents = await _unitOfWork.Incidents.GetById(incident.Id);
            if (incidents == null)
            {
                incidents = new Incident
                {
                    Description = incident.Description
                };
            }
            else
            {
                return BadRequest("Incident already in use");
            }

            await _unitOfWork.Incidents.Add(incidents);
            await _unitOfWork.CompleteAsync();

            return Ok(incidents);
        }
    }
}
