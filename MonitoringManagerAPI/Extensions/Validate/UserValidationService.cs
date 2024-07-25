using MonitoringManagerAPI.Domain.DTOs;
using System.Net.Mail;
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

            ValidateEmail(register.Email);
            ValidateEdit(register.Email, register.EmployeeId);
        }

        public static void ValidateEdit(string email, string employeeId)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O Email é obrigatório.");

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email inválido.");

            if (employeeId != null)
                throw new ArgumentException("ID do empregado inválido.");
        }

        public static bool ValidateEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                throw new ArgumentException("O formato de e-mail está incorreto.");
            }
        }
    }
}

