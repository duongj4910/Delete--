using MagicVilla_Villa.API2.Models;

namespace MagicVilla_VillaAPI2.Models.Dto
{
    public class LoginResponseDTO
    {

        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
