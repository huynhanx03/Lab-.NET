using System;
using System.Collections.Generic;

namespace MyLibrabry.Models;

public partial class JobTitle
{
    public string JobTitleId { get; set; }

    public string JobTitleName { get; set; }

    public string JobTitleDescription { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
