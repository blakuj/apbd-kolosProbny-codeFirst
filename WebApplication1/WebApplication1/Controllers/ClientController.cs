using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientController :ControllerBase
{
    private readonly DbService _dbService;

    public ClientController(DbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    [Route("{id:int}/orders")]
    public async Task<IActionResult> AddOrder([FromBody] GivenOrderDTO givenOrderDto,int id )
    {
        if (!await _dbService.DoesClientExist(id))
        {
            return BadRequest("Client with given id does not exist");
        }

        if (!await _dbService.DoesEmployeeExist(givenOrderDto))
        {
            return BadRequest("Employee with given id does not exist");
        }

        if (!await _dbService.DoesPastryExist(givenOrderDto))
        {
            return BadRequest("Given pastry does not exist");
        }

        await _dbService.AddOrder(givenOrderDto);
        return Ok("Dodano zamówienie");



    }

}