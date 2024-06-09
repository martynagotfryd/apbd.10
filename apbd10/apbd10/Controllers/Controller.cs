using apbd10.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apbd10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Controller : ControllerBase
{
    private readonly IRepository _repository;

    public Controller(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatientInfo(int idPatient)
    {
        var patient = await _repository.GetPatientInfo(idPatient);

        if (patient == null)
        {
            return NotFound();
        }

        return Ok(patient);
    }
    
}