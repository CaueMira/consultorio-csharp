using System;
using Models;
using Controllers;

namespace Views
{
    public class EspecialidadeView
    {
        public static void CriarEspecialidade()
        {
            Console.WriteLine("Informe a descrição da especialidade: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Informe os detalhes da Especialidade: ");
            string Detalhe = Console.ReadLine();

            EspecialidadeController.CriarEspecialidade(Descricao, Detalhe);
        }

        public static void UpdateEspecialidade()
        {
            int Id = 0;

            GetAllEspecialidades();

            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }

            Console.WriteLine("Informe a descrição da especialidade: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Informe os detalhes da Especialidade: ");
            string Detalhe = Console.ReadLine();

            EspecialidadeController.UpdateEspecialidade(Id, Descricao, Detalhe);
        }

        public static void DeleteEspecialidade()
        {
            int Id = 0;

            GetAllEspecialidades();

            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }

            EspecialidadeController.DeleteEspecialidade(Id);
        }

        public static void GetAllEspecialidades()
        {
            foreach (Especialidade especialidade in EspecialidadeController.GetAllEspecialidades())
            {
                Console.WriteLine(especialidade);
            }
        }
    }
}