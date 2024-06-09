using System.Runtime.InteropServices.JavaScript;

namespace WebApplication1.Models.DTOs;

public class GetOrderInfoDTO
{
    public int OrderID { get; set; }

    public DateTime AcceptedAt { get; set; }
    
    public DateTime FulfilleddAt { get; set; }

    public IEnumerable<PastryDTO> Pastries { get; set; }
}

public class PastryDTO
{
    public string Name { get; set; }

    public double Price { get; set; }
    public int Amount { get; set; }
}