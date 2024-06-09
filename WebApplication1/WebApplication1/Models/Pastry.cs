using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WebApplication1.Models;
[Table(nameof(Pastry))]
public class Pastry
{
    [Key]
    public int PastryID { get; set; }
    [MaxLength(150)]
    public string Name { get; set; }
    
    public double Price { get; set; }
    [MaxLength(40)]
    public string Type { get; set; }
    
    
       
    public ICollection<Order_pastry> OrderPastries { get; set; } 
        = new HashSet<Order_pastry>();
    
}