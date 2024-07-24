using MonitoringManagerAPI.Domain.DTOs;
using System.Text.RegularExpressions;

namespace MonitoringManagerAPI.Extensions.Validate
{
    public static class UserValidationService
    {
        public static void ValidateRegister(RegisterDTO register)
        {
            // Verificação de nome de usuário
            if (string.IsNullOrWhiteSpace(register.Username))
            {
                throw new ArgumentException("O nome de usuário não pode ser vazio ou nulo.");
            }
            if (register.Username.Length < 3 || register.Username.Length > 20)
            {
                throw new ArgumentException("O nome de usuário deve ter entre 3 e 20 caracteres.");
            }

            // Verificação de senha
            if (string.IsNullOrWhiteSpace(register.Password))
            {
                throw new ArgumentException("A senha não pode ser vazia ou nula.");
            }
            if (register.Password.Length < 6)
            {
                throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");
            }
            if (!Regex.IsMatch(register.Password, @"[A-Z]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos uma letra maiúscula.");
            }
            if (!Regex.IsMatch(register.Password, @"[a-z]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos uma letra minúscula.");
            }
            if (!Regex.IsMatch(register.Password, @"[0-9]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos um número.");
            }
            if (!Regex.IsMatch(register.Password, @"[\W_]"))
            {
                throw new ArgumentException("A senha deve conter pelo menos um caractere especial.");
            }

            // Validar o e-mail
            if (string.IsNullOrWhiteSpace(register.Email))
            {
                throw new ArgumentException("O e-mail não pode ser vazio ou nulo.");
            }
            if (!IsValidEmail(register.Email))
            {
                throw new ArgumentException("O formato do e-mail é inválido.");
            }
        }

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}

