using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Application.Mappers;
using LojaDoSeuManoel.Application.Repositories;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
namespace LojaDoSeuManoel.Application.Services.Admin
{
    public class AdminBoxService : IAdminBoxInterface
    {

        private readonly IBoxRepository _boxRepository;

        public AdminBoxService(IBoxRepository boxRepository)
        {
            _boxRepository = boxRepository;
        }

        public async Task<ResponseModel<BoxAdminDTO>?> GetBoxByTypeAdmin(BoxTypeEnum Type)
        {
            ResponseModel<BoxAdminDTO>? response = new ResponseModel<BoxAdminDTO>();

            if(!Enum.IsDefined(typeof(BoxTypeEnum), Type))
            {
                response.Status = false;
                response.Message = "Tipo de caixa inválido.";
                return response;
            }

            var boxResponse = await _boxRepository.GetBoxByTypeAdminAsync(Type);

            var BoxDTO= BoxMapper.ToBoxDTO(boxResponse.Content);

            response.Status = true;
            response.Content = BoxDTO;
            return response;
        }

        public async Task<ResponseModel<List<BoxAdminDTO>?>> GetAllBoxesAdmin()
        {
            ResponseModel<List<BoxAdminDTO>?> response = new ResponseModel<List<BoxAdminDTO>?>();

            var boxesResponse = await _boxRepository.GetAllBoxesAdminAsync();

            if (boxesResponse.Content is null || !boxesResponse.Content.Any())
            {
                response.Status = false;
                response.Message = "Nenhuma caixa encontrada.";
                return response;
            }

            foreach (var b in boxesResponse.Content) 
            {
                response.Content.Add(BoxMapper.ToBoxDTO(b));
            }

            response.Status = true;
            return response;
        }
    }
}
