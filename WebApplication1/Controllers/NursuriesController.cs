using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NursuriesController : ControllerBase
{
    private readonly IDatabaseService _databaseServices;

    public NursuriesController(IDatabaseService databaseServices)
    {
        _databaseServices = databaseServices;
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetNursuriesByIdAsync(int id)
    {
        try
        {
            var nurseBatch = await _databaseServices.GetNurseryBatchAsync(id);
            return Ok(nurseBatch);
        }
        catch (NotFoundException e)
        {
            Console.WriteLine(e);
            return NotFound("Nurse not found");
        }
    }
}