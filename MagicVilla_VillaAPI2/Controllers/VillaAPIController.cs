using MagicVilla_VillaAPI2.Data;
using MagicVilla_VillaAPI2.Models;
using MagicVilla_VillaAPI2.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;

namespace MagicVilla_VillaAPI2.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase //returns data and users from controllers class
    {
       
        public VillaAPIController()
        {
           
            
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
           
            return Ok(VillaStore.villaList);

        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok();

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if(VillaStore.villaList.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomerError", "Villa already exists");
                return BadRequest();
            }
            if(villaDTO == null)
            {
                return BadRequest();
            }    
            if(villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1; //go to villa store, then retrieve highest id. add one to the highest id and then you have your new id. 
            VillaStore.villaList.Add(villaDTO); //add villaDTO to villaStore
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);

        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public IActionResult DeleteVilla(int id) //with IActionREsult do not have to include return type 
        {
            if(id == 0) { return BadRequest();  }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (id == null) { return NotFound(); }
            VillaStore.villaList.Remove(villa);
            return NoContent();
            
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if(villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            villa.Name = villaDTO.Name;
            villa.Sqft = villaDTO.Sqft;
            villa.Occupancy = villaDTO.Occupancy;

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO) //we need operation, patch and a value according to JSON documents
        {
            if(patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return BadRequest();

            }
            patchDTO.ApplyTo(villa, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}