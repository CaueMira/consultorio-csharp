using System;
using Models;
using Controllers;

namespace Views
{
    public class AgendamentoViewView
    {
        public static void CriarAgendamento()
        {
            int PacienteID;
            int DentistaID;
            int SalaID;
            int ProcedureID;
            DateTime Date = DateTime.Now;
            Console.WriteLine("Informe a ID do Paciente do Atendimento: ");
            try
            {
                PacienteID = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Id inválida.");
            }
            Console.WriteLine("Informe a id do Dentista envolvido no Atendimento: ");
            try
            {
                DentistaID = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Id inválida.");
            }
            Console.WriteLine("Informe a id da Sala para o Atendimento:: ");
            try
            {
                SalaID = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Id inválida.");
            }
            Console.WriteLine("Informe a ID do procedimento do Atendimento: ");
            try
            {
                ProcedureID = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Id inválida.");
            }

            AgendamentoController.CriarAgendamento(
                PacienteID,
                DentistaID,
                SalaID,
                Date
            );

        }

        public static void UpdateAgendamento()
        {
            int Id = 0;

            GetAllAgendamentos();
            Console.WriteLine("+-------------------------------+");
            DateTime Date = DateTime.Now;
            Console.WriteLine("Informe a id do agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }
            Console.WriteLine("Informe a data do Atendimento: ");
            try
            {
                Date = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data inválida.");
            }

            AgendamentoController.UpdateAgendamento(
                Id,
                Date
            );

        }

        public static void DeleteAgendamento()
        {
            int Id = 0;

            GetAllAgendamentos();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe a id do agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }
            
            AgendamentoController.DeleteAgendamento(Id);
        }

        public static void GetPatientAgendamento(int PacienteID)
        {
            foreach (Agendamento agendamento in AgendamentoController.GetAgendamentoByPaciente(PacienteID))
            {
                Console.WriteLine(agendamento);
            }
        }

        public static void GetAllAgendamentos()
        {
            foreach (Agendamento agendamento in AgendamentoController.GetAllAgendamentos())
            {
                Console.WriteLine(agendamento);
            }
        }

        public static void ConfirmAgendamento()
        {
            GetAllAgendamentos();

            int Id = 0;
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe a id do agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }

            Agendamento agendamento = AgendamentoController.ConfirmAgendamento(Id);

            Console.WriteLine("Confirmado: ");
            Console.WriteLine(agendamento);
        }
    }
}