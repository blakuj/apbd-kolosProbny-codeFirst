using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;
[Table(nameof(Order_pastry))]
[PrimaryKey(nameof(OrderId),nameof(PastryId))]
public class Order_pastry
{
    public int OrderId { get; set; }
    [ForeignKey(nameof(OrderId))] public Orders Order { get; set; } = null!;

    public int PastryId { get; set; }
    [ForeignKey(nameof(PastryId))] public Pastry Pastry { get; set; } = null!;


    public int Amount { get; set; }

    [MaxLength(300)]
    public string Comment { get; set; }
}