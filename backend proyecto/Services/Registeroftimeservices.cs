using backend_proyecto.model;
using backend_proyecto.repositories;

namespace backend_proyecto.services
{
    public class RegisteroftimeService : IRegisteroftimeService
    {
        private readonly IRegisteroftimeRepository _registeroftimeRepository;

        public RegisteroftimeService(IRegisteroftimeRepository registeroftimeRepository)
        {
            _registeroftimeRepository = registeroftimeRepository;
        }

        public async Task CreateRegisteroftimeAsync(Registeroftime registeroftime)
        {
            await _registeroftimeRepository.CreateRegisteroftimeAsync(registeroftime);
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
    }
}