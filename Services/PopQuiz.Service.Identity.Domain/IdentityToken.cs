using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PopQuiz.Service.Identity.Domain
{
    public class IdentityToken
    {
        // TODO: regenerate and move to external secure storage.
        private static readonly string secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";
        private string _token;

        public static IdentityToken Empty = new IdentityToken("");

        public IdentityToken(string userId)
        {
            GenerateToken(userId);
        }

        public string Token => _token;

        public override string ToString()
        {
            return _token;
        }

        private void GenerateToken(string userId)
        {
            // 64 bit encode secret.
            byte[] key = Convert.FromBase64String(secret);
            // create symmetric key for encryption.
            var securityKey = new SymmetricSecurityKey(key);
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userId)}),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                    SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            _token = handler.WriteToken(token);
        }
    }
}