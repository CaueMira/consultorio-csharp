using System;
using Models;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class PacienteController
    {
        // Criando um novo paciente.
        public static Paciente CriarPaciente(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DtNasc
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido.");
            }

            Regex rx = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (String.IsNullOrEmpty(Cpf) || !rx.IsMatch(Cpf))
            {
                throw new Exception("CPF inválido");
            }

            if (String.IsNullOrEmpty(Fone))
            {
                throw new Exception("Número de telefone inválido.");
            }

            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("E-mail inválido.");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Senha inválida.");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            if (DtNasc == null || DtNasc > DateTime.Now)
            {
                throw new Exception("Data de nascimento inválida.");
            }

            return new Paciente(Nome, Cpf, Fone, Email, Senha, DtNasc);
        }

        // Alterando um Paciente existente.
        public static Paciente UpdatePaciente(
            int Id,
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DtNasc
        )
        {
            Paciente paciente = GetPaciente(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                paciente.Nome = Nome;
            }

            Regex rx = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (!String.IsNullOrEmpty(Cpf) && rx.IsMatch(Cpf))
            {
                paciente.Cpf = Cpf;
            }

            if (!String.IsNullOrEmpty(Fone))
            {
                paciente.Fone = Fone;
            }

            if (!String.IsNullOrEmpty(Email))
            {
                paciente.Email = Email;
            }

            if (!String.IsNullOrEmpty(Senha))
            {
                paciente.Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            if (DtNasc == null || DtNasc > DateTime.Now)
            {
                throw new Exception("Data de nascimento inválida.");
            }
            else
            {
                paciente.DtNasc = DtNasc;
            }

            return paciente;
        }

        // Deletando paciente por ID.
        public static Paciente DeletePaciente(int Id)
        {
            try
            {
                Paciente paciente = GetPaciente(Id);
                Paciente.RemovePaciente(paciente);
                return paciente;
            }
            catch
            {
                throw new Exception("Ocorreu um erro.");
            }
        }

        // Get todos pacientes.
        public static List<Paciente> GetAllPacientes()
        {
            return Paciente.GetPacientes();
        }

        // Get Paciente por ID.
        public static Paciente GetPaciente(int Id)
        {
            Paciente paciente = (
                from Paciente in Paciente.GetPacientes()
                    where Paciente.Id == Id
                    select Paciente
            ).First();

            if (paciente == null)
            {
                throw new Exception("Paciente não encontrado.");
            }

            return paciente;
        }
    }

}