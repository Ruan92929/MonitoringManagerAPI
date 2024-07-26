using MonitoringManagerAPI.Domain.DTOs;
using System.Net.Mail;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MonitoringManagerAPI.Extensions.Validate
{
    public static class UserValidationService
    {
        public static void ValidateUser(UserDTO user)
        {
            // Verificação de nome de usuário
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new ArgumentException("O nome de usuário não pode ser vazio ou nulo.");
            }
            if (user.Username.Length < 3 || user.Username.Length > 20)
            {
                throw new ArgumentException("O nome de usuário deve ter entre 3 e 20 caracteres.");
            }

            // Verificação de senha
            if (string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                throw new ArgumentException("A senha não pode ser vazia ou nula.");
            }
            if (user.PasswordHash.Length < 6)
            {
                throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");
            }
            if (!Regex.IsMatch(user.PasswordHash, @"[A-Z]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos uma letra maiúscula.");
            }
            if (!Regex.IsMatch(user.PasswordHash, @"[a-z]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos uma letra minúscula.");
            }
            if (!Regex.IsMatch(user.PasswordHash, @"[0-9]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos um número.");
            }
            if (!Regex.IsMatch(user.PasswordHash, @"[\W_]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos um caractere especial.");
            }

            // Verificação de Email
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("O Email é obrigatório.");

            if (!Regex.IsMatch(user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email inválido.");
        }
    }
}

