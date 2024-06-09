using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table(nameof(Orders))]
public class Orders
{
    [Key]
    public int OrderId { get; set; }

    public DateTime AcceptedAt { get; set; }
    public DateTime FulfilledAt { get; set; }
    [MaxLength(300)]
    public string Comments { get; set; }


    public int ClientId { get; set; }
    [ForeignKey(nameof(ClientId))] 
    public Clients Client { get; set; } = null!;

    public int EmployeeId { get; set; }
    [ForeignKey(nameof(EmployeeId))] 
    public Employees Employee { get; set; } = null!;

    public ICollection<Order_pastry> OrderPastries { get; set; } 
        = new HashSet<Order_pastry>();


}