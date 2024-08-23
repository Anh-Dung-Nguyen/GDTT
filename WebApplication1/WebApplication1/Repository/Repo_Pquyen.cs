using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class Repo_Pquyen
    {
        private readonly GdttContext _context;
        public Repo_Pquyen(GdttContext context)
        {
            _context = context;
        }
        public PagedList<DmPquyenKyhsDTO> GetDmPquyenKyhs(QueryStringParameters queryStringParameters)
        {
            var query = from DmPquyenKyh in _context.DmPquyenKyhs
                        join DmUser in _context.DmUsers on DmPquyenKyh.MaUser equals DmUser.MaUser
                        join DmDonvi in _context.DmDonvis on DmUser.MaDonvi equals DmDonvi.MaDonvi

                        select new DmPquyenKyhsDTO
                        {
                            TenUser = DmUser.TenUser,
                            Mail = DmUser.Mail,
                            MaUserPias = DmUser.MaUserPias,
                            MaSp = DmPquyenKyh.MaSp,
                            SoTien = DmPquyenKyh.SoTien,
                            TenDonvi = DmDonvi.TenDonvi,
                            IsActive = DmPquyenKyh.IsActive,
                            NgayCnhat = DmPquyenKyh.NgayCnhat
                        };
            var result = PagedList<DmPquyenKyhsDTO>.ToPagedList(query, queryStringParameters.PageNumber, queryStringParameters.PageSize);
            return result;
        }
        public PagedList<DmUserGDDK> GetUser(QueryStringParameters queryStringParameters)
        {
            var query = from DmPquyenKyh in _context.DmPquyenKyhs
                        join DmUser in _context.DmUsers on DmPquyenKyh.MaUser equals DmUser.MaUser

                        select new DmUserGDDK
                        {
                            TenUser = DmUser.TenUser,
                            MaUser = DmUser.MaUser,
                            Dienthoai = DmUser.Dienthoai
                        };
            var result = PagedList<DmUserGDDK>.ToPagedList(query, queryStringParameters.PageNumber, queryStringParameters.PageSize);
            return result;
        }
        public async Task<string> updateDigitalSign(DmPquyenKyhsDTO dmPquyenKyhsDTO)
        {
            //try
            //{
            //    var query = _context.DmPquyenKyhs.Where(x => x.MaUser == dmPquyenKyhsDTO.MaUser).FirstOrDefaultAsync().GetAwaiter().GetResult();

            //    if (query != null)
            //    {
            //        query.MaUser = dmPquyenKyhsDTO.MaUser;
            //        query.TyleggSuachua = dmPquyenKyhsDTO.TyLeGGSC;
            //        query.EmailGara = dmPquyenKyhsDTO.EmailGara;
            //        query.DienThoaiGara = dmPquyenKyhsDTO.DienThoaiGara;
            //        query.DiaChiXuong = dmPquyenKyhsDTO.DiaChiXuong;
            //        query.TenTat = dmPquyenKyhsDTO.TenTat;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //var result = _context.SaveChangesAsync();
            return "Success";
        }
    }
}
