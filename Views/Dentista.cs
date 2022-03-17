using System;
using Models;
using Controllers;

namespace Views
{
    public class DentistaView
    {
        public static void CriarDentista()
        {
            double Salario = 0;
            int IdEspecialidade = 0;
            Console.WriteLine("Informe o nome do dentista: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Informe o CPF do dentista: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Informe o telefone do dentista: ");
            string Fone = Console.ReadLine();
            Console.WriteLine("Informe o E-mail do dentista: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Informe a senha do dentista: ");
            string Senha = Console.ReadLine();
            Console.WriteLine("Informe o registro C.R.O do dentista: ");
            string Registro = Console.ReadLine();
            Console.WriteLine("Informe o salário do dentista: ");
            try
            {
                Salario = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Salário inválido.");
            }
            EspecialidadeView.GetAllEspecialidades();
            Console.WriteLine("Escolha uma especialidade existente pela ID: ");
            try
            {
                IdEspecialidade = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }

            DentistaController.CriarDentista(
                Nome,
                Cpf,
                Fone,
                Email,
                Senha,
                Registro,
                Salario,
                IdEspecialidade
            );
        }

        public static void UpdateDentista()
        {
            int Id = 0;
            double Salario = 0;

            GetAllDentistas();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe o ID do dentista: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }

            Console.WriteLine("Informe o nome do dentista: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Informe o CPF do dentista: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Informe o telefone do dentista: ");
            string Fone = Console.ReadLine();
            Console.WriteLine("Informe o E-mail do dentista: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Informe a senha do dentista: ");
            string Senha = Console.ReadLine();
            Console.WriteLine("Informe o registro C.R.O do dentista: ");
            string Registro = Console.ReadLine();
            Console.WriteLine("Informe o salário do dentista: ");
            try
            {
                Salario = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Salário inválido.");
            }

            DentistaController.UpdateDentista(
                Id,
                Nome,
                Cpf,
                Fone,
                Email,
                Senha,
                Registro,
                Salario
            );
        }

        public static void DeleteDentista()
        {
            int Id = 0;

            GetAllDentistas();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe a ID do dentista: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }

            DentistaController.DeleteDentista(Id);
        }

        public static void GetAllDentistas()
        {
            foreach (Dentista dentista in DentistaController.GetAllDentistas())
            {
                Console.WriteLine(dentista);
            }
        }
    }
}