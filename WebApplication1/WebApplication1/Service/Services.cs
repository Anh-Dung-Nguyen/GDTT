using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Service
{
    public interface IServices
    {
        List<DmGaRaDTO> GetAll_Gara(QueryStringParameters queryStringParameters);
        Task<string> updateGara(DmGaRaDTO dmGaRaDTO);
        List<DmPquyenKyhsDTO> GetDmPquyenKyhs(QueryStringParameters queryStringParameters);
        //comment due to the lack of dm_sanpham table
        //IQueryable<DmSpham> GetAll_sp()
    }
    public class Services : IServices
    {
        private readonly Repo_Gara _repogara;
        private readonly Repo_Pquyen _repopquyen;
        //comment due to the lack of dm_sanpham table
        //private readonly Repo_sp _reposp;
        public Services(Repo_Gara repogara, Repo_Pquyen repo_Pquyen /*, Repo_sp reposp*/)
        { 
            _repogara = repogara;
            _repopquyen = repo_Pquyen;
            //comment due to the lack of dm_sanpham table
            //_reposp = reposp
        }
        public List<DmGaRaDTO> GetAll_Gara(QueryStringParameters queryStringParameters)
        {
            return _repogara.GetAll_Gara(queryStringParameters);
        }
        public Task<string> updateGara(DmGaRaDTO dmGaRaDTO)
        {
            return _repogara.updateGara(dmGaRaDTO);
        }
        public List<DmPquyenKyhsDTO> GetDmPquyenKyhs(QueryStringParameters queryStringParameters)
        {
            return _repopquyen.GetDmPquyenKyhs(queryStringParameters);
        }
        //comment due to the lack of dm_sanpham table
        // public IQueryable<DmSpham> GetAll_sp()
        //{
        //    return_reposp.GetAll_sp();
        //}
    }
}