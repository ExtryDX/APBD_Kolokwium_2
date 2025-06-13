using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BatchesController : ControllerBase
{
    private readonly IDatabaseService _databaseServices;

    public BatchesController(IDatabaseService databaseServices)
    {
        _databaseServices = databaseServices;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BatchPostDto batchPostDto)
    {
        try
        {
            await _databaseServices.PostNurseryAsync(batchPostDto);
            return Ok("Batch posted");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
    }
}