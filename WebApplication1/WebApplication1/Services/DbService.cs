using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public class DbService
{
    private readonly ApplicationContext _context;

    public DbService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<ICollection<GetOrderInfoDTO>> GetOrderInfo(string clientLastName )
    {
        var info = await _context.OrdersEnumerable
            .Where(o => o.Client.LastName == clientLastName)
            .Select(o => new GetOrderInfoDTO()
            {
               OrderID = o.OrderId,
               AcceptedAt = o.AcceptedAt,
               FulfilleddAt = o.FulfilledAt,
               Pastries = o.OrderPastries
                   .Select(op => new PastryDTO()
                   {
                       Name = op.Pastry.Name,
                       Price = op.Pastry.Price,
                       Amount = op.Amount
                       
                   }).ToList()
            }).ToListAsync();

        return info;

    }
    public async Task<ICollection<GetOrderInfoDTO>> GetOrderInfoWithNullLastName()
    {
        var info = await _context.OrdersEnumerable
            .Select(o => new GetOrderInfoDTO()
            {
                OrderID = o.OrderId,
                AcceptedAt = o.AcceptedAt,
                FulfilleddAt = o.FulfilledAt,
                Pastries = o.OrderPastries
                    .Select(op => new PastryDTO()
                    {
                        Name = op.Pastry.Name,
                        Price = op.Pastry.Price,
                        Amount = op.Amount
                       
                    }).ToList()
            }).ToListAsync();

        return info;

    }

    public async Task AddOrder(GivenOrderDTO givenOrderDto)
    {
        using (var transaction =  await _context.Database.BeginTransactionAsync())
            try
            {
                var order = new Orders()
                {
                    EmployeeId = givenOrderDto.EmployeeId,
                    AcceptedAt = givenOrderDto.AcceptedAt,
                    Comments = givenOrderDto.Comments
                };
                await _context.OrdersEnumerable.AddAsync(order);
                await _context.SaveChangesAsync();


                
                var orderPastry = new List<Order_pastry>();

                foreach (var pastryDto in givenOrderDto.PastriesDtos)
                {
                    var pastry = new Pastry()
                    {
                        Name = pastryDto.Name
                    };
            
                    orderPastry.Add(new Order_pastry()
                    {
                        OrderId = order.OrderId,
                        PastryId = pastry.PastryID,
                        Amount = pastryDto.Amount,
                        Comment = pastryDto.Comments
                    });

                    await _context.Pastries.AddAsync(pastry);
                    await _context.SaveChangesAsync();
                }


                await _context.OrderPastries.AddRangeAsync(orderPastry);
                await _context.SaveChangesAsync();
                
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

    }

    public async Task<bool> DoesPastryExist(GivenOrderDTO givenOrderDto)
    {
        foreach (var pastryDto in givenOrderDto.PastriesDtos)
        {
            var pastry = await _context.Pastries.Where(p=> p.Name == pastryDto.Name).FirstOrDefaultAsync();

            if (pastry == null)
            {
                return false;
            }
        }

        return true;

    }

    public async Task<bool> DoesClientExist(int id)
    {
        var clientExists = await _context.ClientsEnumerable.AnyAsync(c => c.ClientID == id);
        return clientExists;
    }
    public async Task<bool> DoesEmployeeExist(GivenOrderDTO givenOrderDto)
    {
        var employeeExist = await _context.EmployeesEnumerable.AnyAsync(e => e.EmployeeID == givenOrderDto.EmployeeId);
        return employeeExist;
    }
}