using Microsoft.AspNetCore.Mvc;
using PostsApplicationBackEnd.Entities;
using PostsApplicationBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsApplicationBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _parcelService;
        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var parcels = await _parcelService.GetAllAsync();
            return Ok(parcels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var parcel = await _parcelService.GetByIdAsync(id);
            return Ok(parcel);
        }

        [HttpGet]
        [Route("ParcelssbyPost/{postId}")]
        public async Task<ActionResult> GetByPostId(int postId)
        {
            var parcelByPost = await _parcelService.GetByPostIdAsync(postId);
            return Ok(parcelByPost);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Parcel parcel)
        {
            var newparcel = await _parcelService.CreateAsync(parcel);

            return Ok(newparcel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Parcel parcel)
        {
            await _parcelService.UpdateAsync(parcel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _parcelService.DeleteAsync(id);

            return NoContent();
        }


    }
}
