using DataService.IConfiguration;
using Entities.DbSet;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.Intrinsics.X86;

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
        [Route("GetAllContacts")]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _unitOfWork.Contacts.All();
            return Ok(contacts);
        }

        [HttpPost]
        [Route("AddContact")]
        public async Task<IActionResult> AddContacts([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                var contactExist = await _unitOfWork.Contacts.GetByEmail(contact.Email);
                if (contactExist != null)
                {
                    return BadRequest("Email already in use");
                }

                var _contact = new Contact();
                _contact.FirstName = contact.FirstName;
                _contact.LastName = contact.LastName;
                _contact.Email = contact.Email;

                await _unitOfWork.Contacts.Add(_contact);
                await _unitOfWork.CompleteAsync();

                var response = new HttpResponseMessage(HttpStatusCode.Redirect);
                response.Headers.Location = new Uri("https://localhost:7116/api/Account/AddAccount");

                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid payload");
            }
        }

        [HttpGet]
        [Route("GetContact", Name = "GetContact")]
        public async Task<IActionResult> GetContact(string email)
        {
            var contact = await _unitOfWork.Contacts.GetByEmail(email);
            return Ok();
        }
    }
}
