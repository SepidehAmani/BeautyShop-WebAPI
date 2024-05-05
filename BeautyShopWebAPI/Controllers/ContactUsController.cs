using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.Entities.ContactUs;
using BeautyShopDomain.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopWebAPI.Controllers
{
    //This Controller is just for Practicing

    //[Route("api/ContactUs")]
    //[ApiController]
    //[Authorize]
    //public class ContactUsController : ControllerBase
    //{
    //    private readonly IContactUsService _contactUsService;
    //    private readonly IContactUsRepository _contactUsRepository;
    //    public ContactUsController(IContactUsService contactUsService , IContactUsRepository contactUsRepository)
    //    {
    //        _contactUsService = contactUsService;
    //        _contactUsRepository = contactUsRepository;
    //    }


    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<ContactUs>>> GetListOfContactUs(CancellationToken cancellation=default)
    //    {
    //        var model = await _contactUsService.GetListOfContactUs(cancellation);
    //        return Ok(model);
    //    }


    //    [HttpGet("{id}",Name ="GetContactUs")]
    //    public async Task<ActionResult<ContactUs>> GetContactUs(int id,CancellationToken cancellation=default)
    //    {
    //        var model = await _contactUsService.GetContactUsById(id, cancellation);
    //        return Ok(model);
    //    }


    //    [HttpPost]
    //    public async Task<ActionResult> CreateContactUs(ContactUs contactUs,CancellationToken cancellation=default)
    //    {
    //        if(!ModelState.IsValid) return BadRequest(ModelState);

    //        contactUs.Id = 0;
    //        _contactUsRepository.AddContactUs(contactUs);
    //        await _contactUsRepository.SaveChangesAsync(cancellation);

    //        return CreatedAtAction("GetContactUs", new { id = contactUs.Id }, contactUs);

    //    }


    //    [HttpPatch("{id}")]
    //    public async Task<ActionResult> PatchContactUs(int id, JsonPatchDocument<ContactUs> document , CancellationToken cancellation=default)
    //    {
    //        if (!ModelState.IsValid) return BadRequest(ModelState);

    //        var contactUs = await _contactUsService.GetContactUsById(id, cancellation);
    //        if (contactUs == null) return NotFound();

    //        document.ApplyTo(contactUs,ModelState);
    //        if (!TryValidateModel(contactUs)) return BadRequest();

    //        _contactUsRepository.UpdateContactUs(contactUs);
    //        await _contactUsRepository.SaveChangesAsync(cancellation);

    //        return NoContent();
    //    }
    //}
}
