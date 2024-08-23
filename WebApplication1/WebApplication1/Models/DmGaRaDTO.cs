using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DmGaRaDTO
    {
        [Key]
        public string MaGara { get; set; } // mã gara
        public string TenGara { get; set; } // tên gara
        public string TenTat { get; set; } // tên tắt
        public string DiaChi { get; set; } // địa chỉ
        public string DiaChiXuong { get; set; } // địa chỉ xưởng
        public string TenTinh { get; set; } // tên tỉnh 
        public string QuanHuyen { get; set; } // quận huyện 
        public decimal? TyLeGGSC { get; set; } // tỷ lệ ggsc 
        public decimal? TyLeGGPT { get; set; } // tỷ lệ ggpt 
        public string EmailGara { get; set; } // email 
        public string DienThoaiGara { get; set; } // điện thoại 
    }
}
