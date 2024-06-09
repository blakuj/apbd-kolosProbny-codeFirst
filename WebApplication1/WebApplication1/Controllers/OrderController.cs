using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly DbService _dbService;

    public OrderController(DbService dbService)
    {
        _dbService = dbService;
    }


    [HttpGet]
    public async Task<IActionResult> GetOrderInfo(string? clientLastName)
    {
        ICollection<GetOrderInfoDTO> res;
        
        if (clientLastName == null)
        {
             res = await _dbService.GetOrderInfoWithNullLastName();
        }
        else
        {
             res = await _dbService.GetOrderInfo(clientLastName);
        }
        if (!res.Any())
        {
            return NotFound("Nie znaleziono żadnych zamówień.");
        }

        
        
        return Ok(res);


    }
}