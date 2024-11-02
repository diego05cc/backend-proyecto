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

        public async Task CreateRegisteroftimeAsync(DTORegisteroftime registeroftime)
        {
            await _registeroftimeRepository.CreateRegisteroftimeAsync(registeroftime);
        }

        public async Task<IEnumerable<DTORegisteroftime>> GetAllRegisteroftimesAsync()
        {
            return await _registeroftimeRepository.GetAllRegisteroftimesAsync();
        }

        public async Task<DTORegisteroftime> GetRegisteroftimeByIdAsync(int id)
        {
            return await _registeroftimeRepository.GetRegisteroftimeByIdAsync(id);
        }

        public async Task SoftDeleteRegisteroftimeAsync(int id)
        {
            await _registeroftimeRepository.SoftDeleteRegisteroftimeAsync(id);
        }

        public async Task UpdateRegisteroftimeAsync(DTORegisteroftime registeroftime)
        {
            await _registeroftimeRepository.UpdateRegisteroftimeAsync(registeroftime);
        }
    }
}