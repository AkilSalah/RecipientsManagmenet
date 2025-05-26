using Gestion_Destinataire.DTOs;
using Gestion_Destinataire.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Destinataire.Controllers
{

    [ApiController]
    [Route("api/destinataire")]
    public class DestinataireController : ControllerBase
    {
        private readonly IDestinataireService _destinataireService;
        public DestinataireController (IDestinataireService destinataireService)
        {
            _destinataireService = destinataireService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DestinataireResponse>>> GetAll (){
            var destinataires = await _destinataireService.GetAllDestinataire();
            return Ok(destinataires);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DestinataireResponse>> GetById(int id)
        {
            var destinataire = await _destinataireService.GetById(id);
            if (destinataire == null)
                return NotFound();

            return Ok(destinataire);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _destinataireService.DeleteDestinataire(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DestinataireResponse>> Create([FromBody] DestinataireRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _destinataireService.CreateDestinataire(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DestinataireResponse>> Update(int id, [FromBody] DestinataireRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _destinataireService.UpdateDestinataire(request,id);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }





    }
}
