using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository
{
    public interface IBoxRepository
    {
        //Admin
        Task<ResponseModel<List<BoxAdminDTO>?>> GetAllBoxesAdminAsync();
        Task<ResponseModel<BoxAdminDTO>?> GetBoxByTypeAdminAsync(BoxTypeEnum Type);
    }
}
