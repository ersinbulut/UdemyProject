using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            // 256 bit uzunluğunda bir anahtar oluşturmak için daha uzun bir anahtar kullanıyoruz
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapilongkey1234567890"); // 256 bit anahtar (32 bayt)

            // Güvenli bir anahtar oluşturuluyor
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            // Signing credentials (imza doğrulama)
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // JWT token'ı oluşturuyoruz
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost",  // Geliştirme ortamında http kullanılabilir, ama https önerilir
                audience: "https://localhost", // Aynı şekilde https önerilir
                notBefore: DateTime.UtcNow,    // UTC zamanı kullanıyoruz
                expires: DateTime.UtcNow.AddMinutes(3),  // 3 dakika geçerlilik süresi
                signingCredentials: credentials
            );

            // Token handler'ı kullanarak token'ı string formatına dönüştürüyoruz
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // Token'ı string olarak döndürüyoruz
            return handler.WriteToken(token);
        }


    }
}
