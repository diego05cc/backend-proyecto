﻿using backend_proyecto.DTOs;
using backend_proyecto.model;

namespace backend_proyecto.services
{
    public interface IRegisteroftimeService
    {
        Task<IEnumerable<Registeroftime>> GetAllRegisteroftimesAsync();
        Task<Registeroftime> GetRegisteroftimeByIdAsync(int id);
        Task CreateRegisteroftimeAsync(Registeroftime registeroftime);
        Task UpdateRegisteroftimeAsync(Registeroftime registeroftime);
        Task SoftDeleteRegisteroftimeAsync(int id);
        Task CreateRegisteroftimeAsync(DTORegisteroftime registeroftime);
        Task UpdateRegisteroftimeAsync(DTORegisteroftime registeroftime);
    }
}