using System;
using Models;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class AgendamentoController
    {
        // Criando um novo agendamento.
        public static Agendamento CriarAgendamento(
            int PacienteId,
            int DentistaId,
            int SalaId,
            DateTime Data
        )
        {
            PacienteController.GetPaciente(PacienteId);
            DentistaController.GetDentista(DentistaId);
            SalaController.GetSala(SalaId);

            if(Data == null || Data <= DateTime.Now)
            {
                throw new Exception("A data não pode estar no passado.");
            }

            if(GetAgendamentoConflict(0, DentistaId, SalaId, Data))
            {
                throw new Exception("Já existe um agendamento nesse horário.");
            }

            return new Agendamento(PacienteId, DentistaId, SalaId, Data);
        }

        // Conferindo se já existe algum agendamento na sala com o horário.
        private static bool GetAgendamentoConflict(
            int AtualId,
            int DentistaId,
            int SalaId,
            DateTime Data
        )
        {
            // Definindo uma coleção chamando os agendamentos
            IEnumerable<Agendamento> agendamentos =
                from Agendamento in Agendamento.GetAgendamentos()
                    where Agendamento.Data == Data
                        && Agendamento.DentistaId == DentistaId
                        && Agendamento.SalaId == SalaId
                        && Agendamento.Id != AtualId
                    select Agendamento;
                return agendamentos.Count() > 0; 
        }

        // Alterando um agendamento existente
        public static Agendamento UpdateAgendamento(
            int Id,
            DateTime Data
        )
        {
            Agendamento agendamento = GetAgendamento(Id);

            if (Data == null | Data < DateTime.Now)
            {
                throw new Exception("Data inválida.");
            }

            // Conferindo se existe conflito de agendamentos.
            if (GetAgendamentoConflict(
                agendamento.Id,
                agendamento.DentistaId,
                agendamento.SalaId,
                Data
            ))
            {
                throw new Exception("Já existe um agendamento nesse horário.");
            }

            agendamento.Data = Data;
            
            return agendamento;
        }

        // Deletando um agendamento
        public static Agendamento DeleteAgendamento(int Id)
        {
            try
            {
                Agendamento agendamento = GetAgendamento(Id);
                Agendamento.RemoveAgendamento(agendamento);
                return agendamento;
            }
            catch
            {
                throw new Exception("Ocorreu um erro.");
            }
        }

        // Get todos os agendamentos.
        public static List<Agendamento> GetAllAgendamentos()
        {
            return Agendamento.GetAgendamentos();
        }  

        // Retornando o agendamento por Id.
        public static Agendamento GetAgendamento(int Id)
        {
            Agendamento agendamento = (
                from Agendamento in Agendamento.GetAgendamentos()
                    where Agendamento.Id == Id
                    select Agendamento
            ).First();

            if (agendamento == null)
            {
                throw new Exception("Agendamento não encontrado.");
            }

            return agendamento;
        }

        // Retornando o agendamento pela id do Paciente
        public static IEnumerable<Agendamento> GetAgendamentoByPaciente(int PacienteId)
        {
            try
            {
                return Agendamento.GetAgendamentos().Where(Agendamento => Agendamento.PacienteId == PacienteId);
            }
            catch
            {
                throw new Exception("Paciente sem horário marcado.");
            }
        }

        // Confirmando agendamento.
        public static Agendamento ConfirmAgendamento(int Id)
        {
            Agendamento agendamento = GetAgendamento(Id);

            if (agendamento.PacienteId != Autenticacao.Paciente.Id)
            {
                throw new Exception("Agendamento não confirmado.");
            }

            agendamento.Confirm = true;

            return agendamento;
        }
    }
}