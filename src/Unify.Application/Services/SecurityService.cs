using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Unify.Application.DTOs;
using Unify.Application.Interfaces;

namespace Unify.Application.Services
{
    public class SecurityService : ISecurityService
    {
        public SenhaDTO CriarSenha(string senha)
        {
            var result = new SenhaDTO()
            {
                Salt = new byte[128]
            };

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(result.Salt);
            }

            using (var hmac = new HMACSHA512(result.Salt))
            {
                result.Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            }

            return result;
        }

        public bool ValidarSenha(string senha, byte[] hashBanco, byte[] saltBanco)
        {
            using (var hmac = new HMACSHA512(saltBanco))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
                return hash.SequenceEqual(hashBanco);
            }
        }

        public string GerarCodigoValidacao()
        {
            byte[] buffer = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }

            int value = BitConverter.ToInt32(buffer, 0);
            value = Math.Abs(value % 100000);

            return value.ToString("D5");
        }
    }
}
