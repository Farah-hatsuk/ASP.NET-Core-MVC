using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Manager { get; set; } = null!;

    public int EmployeesCount { get; set; }
}
