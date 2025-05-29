using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.Admin;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Admin
{
    public interface IAdminBoxInterface
    {

        //Querys
        Task<ResponseModel<List<BoxAdminDTO>?>> GetBoxesAdmin();
        Task<ResponseModel<BoxAdminDTO>?> GetBoxByTypeAdmin(BoxTypeEnum Type);

        //Commands
        Task<SimpleResponseModel> UpdateDataBoxAdmin(UpdateBoxModel model);
    }
}
