namespace WebApplication1.Models
{
    public class DmPquyenKyhsDTO
    {
        public string? TenUser { get; set; }
        public string? Mail { get; set; }
        public string MaUserPias { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public decimal SoTien { get; set; }
        public string TenDonvi { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime? NgayCnhat { get; set; }
    }
}
