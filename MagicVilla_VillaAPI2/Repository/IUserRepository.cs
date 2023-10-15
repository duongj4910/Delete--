using MagicVilla_Villa.API2.Models;
using MagicVilla_VillaAPI2.Models.Dto;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI2.Repository
{
    public interface IUserRepository //where T : class
    {

        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}