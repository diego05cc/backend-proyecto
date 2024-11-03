using backend_proyecto.DTOs;
using backend_proyecto.model;
using backend_proyecto.Repositories;


namespace backend_proyecto.Services
{
    public class Registeroftimeservices : IRegisteroftimeservices
    {
        private readonly IRegisteroftimeRepository _registeroftimeRepository;

        public Registeroftimeservices(IRegisteroftimeRepository registeroftimeRepository)
        {
            _registeroftimeRepository = registeroftimeRepository;
        }

        public async Task CreateRegisteroftimeAsync(Registeroftime registeroftime)
        {
            await _registeroftimeRepository.CreateRegisteroftimeAsync(registeroftime);
        }

        public Task CreateRegisteroftimeAsync(DTORegisteroftime registeroftime)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Registeroftime>> GetAllRegisteroftimesAsync()
        {
            return await _registeroftimeRepository.GetAllRegisteroftimesAsync();
        }

        public async Task<Registeroftime> GetRegisteroftimeByIdAsync(int id)
        {
            return await _registeroftimeRepository.GetRegisteroftimeByIdAsync(id);
        }

        public async Task SoftDeleteRegisteroftimeAsync(int id)
        {
            await _registeroftimeRepository.SoftDeleteRegisteroftimeAsync(id);
        }

        public async Task UpdateRegisteroftimeAsync(Registeroftime registeroftime)
        {
            await _registeroftimeRepository.UpdateRegisteroftimeAsync(registeroftime);
        }

        public Task UpdateRegisteroftimeAsync(DTORegisteroftime registeroftime)
        {
            throw new NotImplementedException();
        }
    }
}