using System;
using Models;
using Controllers;

namespace Views
{
    public class ProcedimentoView
    {
        public static void CriarProcedimento()
        {
            Console.WriteLine("Informe a descrição do procedimento: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Informe o preco do procedimento: ");
            double Preco = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Informe a ID do agendamento associado com esse Procedimento: ");
            int AgendamentoID = Convert.ToInt32(Console.ReadLine());

            ProcedureController.CriarProcedimento(Descricao, Preco, AgendamentoID);
        }

        public static void UpdateProcedimento()
        {
            int Id = 0;

            GetAllProcedimentos();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe o ID do Procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            Console.WriteLine("Informe a descrição do procedimento: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Informe o preço do procedimento: ");
            double Preco = Convert.ToSingle(Console.ReadLine());

            ProcedimentoController.UpdateProcedimento(Id, Descricao, Preco);
        }

        public static void DeleteProcedimento()
        {
            int Id = 0;

            GetAllProcedimentos();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe o ID do Procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            ProcedimentoController.DeleteProcedimento(Id);
        }

        public static void GetAllProcedimentos()
        {
            foreach (Procedimento procedimento in ProcedimentoController.GetAllProcedimentos())
            {
                Console.WriteLine(procedimento);
            }
        }
    }
}