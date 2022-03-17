using System;
using Models;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class DentistaController
    {
        // Criando um novo dentista.
        public static Dentista CriarDentista(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            string Registro,
            double Salario,
            int IdEspecialidade
        )
        {
            EspecialidadeController.GetEspecialidade(IdEspecialidade);
            
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido.");
            }

            Regex rxCpf = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (String.IsNullOrEmpty(Cpf) || !rxCpf.IsMatch(Cpf))
            {
                throw new Exception("Cpf inválido");
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
                // Armazenando a senha
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            if (String.IsNullOrEmpty(Registro))
            {
                throw new Exception("Registro inválido.");
            }

            Regex rxSalario = new Regex("(?!0$)[0-9]+(?:\\.[0-9]+)?");
            if (!rxSalario.IsMatch(Convert.ToString(Salario)))
            {
                throw new Exception("Salário inválido.");
            }

            return new Dentista(Nome, Cpf, Fone, Email, Senha, Registro, Salario, IdEspecialidade);
        }

        // Alterando um dentista, sem alterar a especialidade.
        public static Dentista UpdateDentista(
            int Id,
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            string Registro,
            double Salario
        )
        {
            Dentista dentista = GetDentista(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                dentista.Nome = Nome;
            }

            Regex rx = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (!String.IsNullOrEmpty(Cpf) || rx.IsMatch(Cpf))
            {
                dentista.Cpf = Cpf;
            }

            if (!String.IsNullOrEmpty(Fone))
            {
                dentista.Fone = Fone;
            }

            if (!String.IsNullOrEmpty(Email))
            {
                dentista.Email = Email;
            }

            if (!String.IsNullOrEmpty(Senha))
            {
                dentista.Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            Regex rxSalario = new Regex("(?!0$)[0-9]+(?:\\.[0-9]+)?");
            if (!rxSalario.IsMatch(Convert.ToString(Salario)))
            {
                throw new Exception("Salário inválido.");
            }

            return dentista;
        }

        // Deletando o dentista por ID.
        public static Dentista DeleteDentista(int Id)
        {
            try
            {
                Dentista dentista = GetDentista(Id);
                Dentista.RemoveDentista(dentista);
                return dentista;
            }
            catch
            {
                throw new Exception("Algo ocorreu de forma incorreta.");
            }
        }

        // Get todos os dentistas.
        public static List<Dentista> GetAllDentistas()
        {
            return Dentista.GetDentistas();
        }

        // Get Id Dentista.
        public static Dentista GetDentista(int Id)
        {
            Dentista dentista = (
                from Dentista in Dentista.GetDentistas()
                    where Dentista.Id == Id
                    select Dentista
            ).First();

            if (dentista == null)
            {
                throw new Exception("Não foi possível encontrar nenhum dentista.");
            }

            return dentista;
        }
    }

}