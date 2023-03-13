using DataService.IConfiguration;
using Entities.DbSet;
using Microsoft.AspNetCore.Mvc;

namespace IncidentCreating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public ContactsController(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _unitOfWork.Contacts.All();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> AddContacts(Contact contact)
        {
            var _contact = new Contact();
            _contact.FirstName = contact.FirstName;
            _contact.LastName = contact.LastName;
            _contact.Email = contact.Email;

            await _unitOfWork.Contacts.Add(_contact);
            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute("GetContact", new { email = _contact.Email }, contact);
        }

        [HttpGet]
        [Route("GetContact", Name = "GetContact")]
        public IActionResult GetContact(string email)
        {
            var contact = _unitOfWork.Contacts.GetByEmail(email);
            return Ok();
        }
    }
}
