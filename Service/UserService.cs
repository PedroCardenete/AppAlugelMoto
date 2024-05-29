using TestApplication.Model;
using TestApplication.Repositories.Interfaces;

namespace TestApplication.Service;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> AddUserAsync(User user)
    {
        return await _userRepository.AddAsync(user);
    }

    public void CheckExtensionImageCnh(IFormFile file)
    {
        var extension = System.IO.Path.GetExtension(file.FileName);
        if (!extension.Contains("png") || !extension.Contains("bmp"))
        {
            throw new Exception("Extension Image not supported");
        }
        
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
        return true;
    }

    public async Task UpdateUserCnhAsync(int id, string filePath)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user != null)
        {
            user.ImageCnh = filePath;
            await _userRepository.UpdateAsync(user);
        }
    }
}