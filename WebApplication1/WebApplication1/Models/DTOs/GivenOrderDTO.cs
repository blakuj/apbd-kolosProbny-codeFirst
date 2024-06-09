namespace WebApplication1.Models.DTOs;

public class GivenOrderDTO
{
    public int EmployeeId { get; set; }
    public DateTime AcceptedAt { get; set; }
    public string Comments { get; set; }
    public IEnumerable<PastriesDTO> PastriesDtos { get; set; }
    
}

public class PastriesDTO
{
    public string Name { get; set; }
    public int Amount { get; set; }
    public string? Comments { get; set; }
    
}
