using System;
using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Agendamento
    {
        public int Id { set; get; }
        public int PacienteId { set; get; }
        public Paciente Paciente { get; }
        public int DentistaId { set; get; }
        public Dentista Dentista { set; get; }
        public int SalaId { set; get; }
        public Sala Sala { get; }
        public static List<Procedimento> Procedimentos = new List<Procedimento>();
        public DateTime Data { set; get; }
        public bool Confirm { set; get; }

        // Criando construtor de Agendamento
        public Agendamento() { }
        public Agendamento(
            int PacienteId,
            int DentistaaId,
            int SalaId,
            DateTime Data
        ) 
        {
            this.Id = Id;
            this.PacienteId = PacienteId;
            this.DentistaId = DentistaaId;
            this.SalaId = SalaId;

            this.Data = Data;

            // Adicionando Agendamento no Banco de Dados.
            Context db = new Context();
            db.Agendamentos.Add(this);
            db.SaveChanges();
        }

        // ToString - Agendamento
        public override string ToString()
        {
            // Calculando o preço a pagar.
            double totalPrice = 0;

            string printAgendamento = $"ID: {this.Id}"
                + $"\n - Paciente: {this.Paciente.Nome}"
                + $"\n - Dentista: {this.Dentista.Nome}"
                + $"\n - Sala: {this.Sala.Numero}"
                + $"\n - Data: {this.Data}"
                + $"\n - Agendamento: {(this.Confirm ? "Confirm agendamento." : "Don't scheduleded.")}";

                foreach (Procedimento item in Procedimentos)
                {
                    printAgendamento += $"\nID Procedimento: {item.Id}"
                            + $"\n - Descrição: {item.Descricao}."
                            + $"\n - Preco: ${item.Preco}";
                    
                    totalPrice += item.Preco;
                }

                printAgendamento += $"\n^ Total: ${totalPrice}";

                return printAgendamento;
        }

        // Equals - Agendamento
        public override bool Equals(object obj)
        {
            if (obj == null || !Agendamento.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Agendamento iterable = (Agendamento) obj;
            return iterable.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Retornando todos os Agendamentos.
        public static List<Agendamento> GetAgendamentos()
        {
            Context db = new Context();
            return (from Agendamento in db.Agendamentos select Agendamento).ToList();
        }

        // Metodo para remover o objeto Agenddamento da lista Agendamentos
        public static void RemoveAgendamento(Agendamento agendamento)
        {
            Context db = new Context();
            db.Agendamentos.Remove(agendamento);
        }

        // Metodo para adicionar o procedimento no agendamento
        public static void AddProcedimento(Procedimento procedimento)
        {
            Procedimentos.Add(procedimento);
        }
    }
}