using System;
using System.Collections.Generic;

namespace MyLibrabry.Models;

public partial class Dbaccount
{
    public string AccountId { get; set; }

    public string AccountPassword { get; set; }

    public string FullName { get; set; }

    public int? AccountRole { get; set; }
}
