using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using LojaDoSeuManoel.Infrastruture.Persistense;
using LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastruture.Repositories
{
    public class BoxRepository : IBoxRepository
    {

        private readonly LojaDoSeuManoelDbContext _dbContext;

        public BoxRepository(LojaDoSeuManoelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseModel<List<BoxEntity>?>> GetAllBoxesAdminAsync()
        {
            ResponseModel<List<BoxEntity>?> response = new ResponseModel<List<BoxEntity>?>();
            try
            {
                var boxes = await _dbContext.Box.ToListAsync();
                if (boxes is null || !boxes.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhuma caixa encontrada.";
                    return response;
                }

                response.Content = boxes;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<BoxEntity>?> GetBoxByTypeAdminAsync(BoxTypeEnum Type)
        {
           
            ResponseModel<BoxEntity?> response = new ResponseModel<BoxEntity?>();
            try
            {
                var box = await _dbContext.Box.FirstOrDefaultAsync(x => x.BoxType == Type);

                if (box is null)
                {
                    response.Status = false;
                    response.Message = "Nenhuma caixa encontrada com o tipo especificado.";
                    return response;
                }

                response.Content = box;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }
    }
}
