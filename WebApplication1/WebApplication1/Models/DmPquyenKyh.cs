using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class DmPquyenKyh
{
    public Guid PrKey { get; set; }

    public string MaUser { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public decimal SoTien { get; set; }

    public bool IsActive { get; set; }

    public DateTime? NgayCnhat { get; set; }

    public string MaUserCapnhat { get; set; } = null!;
}
