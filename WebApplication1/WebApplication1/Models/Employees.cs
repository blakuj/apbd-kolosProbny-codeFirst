﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table(nameof(Employees))]
public class Employees
{
    [Key]
    public int EmployeeID { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(120)]
    public string LastName { get; set; }
    
    
    public ICollection<Orders> OrdersCollection { get; set; } 
        = new HashSet<Orders>();
}