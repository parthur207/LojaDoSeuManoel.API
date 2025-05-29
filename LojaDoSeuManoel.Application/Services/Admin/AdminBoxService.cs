using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using LojaDoSeuManoel.Infra
namespace LojaDoSeuManoel.Application.Services.Admin
{
    public class AdminBoxService : IAdminBoxInterface
    {

        private readonly LojaDoSeuManoelDbContext _adminBoxInterface;
        public Task<ResponseModel<BoxAdminDTO>?> GetBoxByTypeAdmin(BoxTypeEnum Type)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<BoxAdminDTO>?>> GetAllBoxesAdmin()
        {
            throw new NotImplementedException();
        }
    }
}
