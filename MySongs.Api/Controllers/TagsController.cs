using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySongs.Common.DTOs;
using MySongs.Services.Interfaces;

namespace MySongs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_tagService.GetAll());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] TagDto tag)
        {
            _tagService.Add(tag);
            return Ok("התגית נוספה");
        }

       
        
    }
}