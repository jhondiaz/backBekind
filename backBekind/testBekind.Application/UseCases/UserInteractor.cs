using testBekind.Application.Ports;
using testBekind.Domain;
using testBekind.Domain.Interfaces;

namespace testBekind.Application.UseCases
{
  

    public class UserInteractor : IUserPort
    {

        private IUserRepository _userRepository;

        public UserInteractor(IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }



        public async Task<IEnumerable<User>> GetAllUserAsync()
        {

            return await _userRepository.GetAllUsersAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByNameAsync(string nome)
        {
            return await _userRepository.GetUserByNameAsync(nome);
        }

        public Task<bool> UpdateUserAsync(User product)
        {
            return _userRepository.UpdateUserAsync(product);
        }

        public Task<bool> DeleteUserAsync(string id)
        {
            return _userRepository.DeleteUserAsync(id);
        }
    }
}
