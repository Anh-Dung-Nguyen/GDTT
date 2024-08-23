using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using static Azure.Core.HttpHeader;

namespace WebApplication1.Repository
{
    public class Repo_Gara
    {
        private readonly GdttContext _context;
        public Repo_Gara(GdttContext context)
        {
            _context = context;
        }

        public PagedList<DmGaRaDTO> GetAll_Gara(QueryStringParameters queryStringParameters)
        {
            var query = (from DmGaRa in _context.DmGaRas
                        select new DmGaRaDTO
                        {
                            MaGara = DmGaRa.MaGara,
                            TenGara = DmGaRa.TenGara,
                            TenTat = DmGaRa.TenTat,
                            DiaChi = DmGaRa.DiaChi,
                            DiaChiXuong = DmGaRa.DiaChiXuong,
                            TenTinh = DmGaRa.TenTinh,
                            QuanHuyen = DmGaRa.QuanHuyen,
                            TyLeGGSC = DmGaRa.TyleggSuachua,
                            TyLeGGPT = DmGaRa.TyleggPhutung,
                            EmailGara = DmGaRa.EmailGara,
                            DienThoaiGara = DmGaRa.DienThoaiGara
                        });
            var result = PagedList<DmGaRaDTO>.ToPagedList(query, queryStringParameters.PageNumber, queryStringParameters.PageSize);
            return result;
        }

        public async Task<string> updateGara(DmGaRaDTO dmGaRaDTO)
        {
            try
            {
                var query = _context.DmGaRas.Where(x => x.MaGara == dmGaRaDTO.MaGara).FirstOrDefaultAsync().GetAwaiter().GetResult();
            

            if (query != null)
            {
                query.TyleggPhutung = dmGaRaDTO.TyLeGGPT;
                query.TyleggSuachua = dmGaRaDTO.TyLeGGSC;
                query.EmailGara = dmGaRaDTO.EmailGara;
                query.DienThoaiGara = dmGaRaDTO.DienThoaiGara;
                query.DiaChiXuong = dmGaRaDTO.DiaChiXuong;
                query.TenTat = dmGaRaDTO.TenTat;
            }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            var result = _context.SaveChangesAsync();
            return "Success";
        }
    }
}
