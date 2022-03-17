using System;
using Models;
using Controllers;

namespace Views
{
    public class PacienteView
    {
        public static void CriarPaciente()
        {
            DateTime DtNasc = DateTime.Now;
            Console.WriteLine("Informe o nome do paciente: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Informe o CPF do Paciente: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Informe o telefone do paciente: ");
            string Fone = Console.ReadLine();
            Console.WriteLine("Informe o E-mail do paciente: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Informe a senha do paciente: ");
            string Senha = Console.ReadLine();
            Console.WriteLine("Informe a data de nascimento do paciente: ");
            try
            {
                DtNasc = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data de Nascimento inválida.");
            }

            PacienteController.CriarPaciente(
                Nome,
                Cpf,
                Fone,
                Email,
                Senha,
                DtNasc
            );
        }

        public static void UpdatePaciente()
        {
            int Id = 0;
            DateTime DtNasc = DateTime.Now;

            GetAllPacientes();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe o ID do Paciente: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }

            Console.WriteLine("Informe o nome do paciente: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Informe o CPF do Paciente: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Informe o telefone do paciente: ");
            string Fone = Console.ReadLine();
            Console.WriteLine("Informe o E-mail do paciente: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Informe a senha do paciente: ");
            string Senha = Console.ReadLine();
            Console.WriteLine("Informe a data de nascimento do paciente: ");
            try
            {
                DtNasc = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data de Nascimento inválida.");
            }

            PacienteController.UpdatePaciente(
                Id,
                Nome,
                Cpf,
                Fone,
                Email,
                Senha,
                DtNasc
            );
        }

        public static void DeletePaciente()
        {
            int Id = 0;

            GetAllPacientes();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe o ID do Paciente: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            PacienteController.DeletePaciente(Id);
        }

        public static void GetAllPacientes()
        {
            foreach (Paciente paciente in PacienteController.GetAllPacientes())
            {
                Console.WriteLine(paciente);
            }
        }
    }
}