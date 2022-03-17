using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Procedimento
    {
        public int Id { set; get; }
        [Required]
        public string Descricao { set; get; }
        [Required]
        public double Preco { set; get; }
        public int AgendamentoID { set; get; }
        public Agendamento Agendamento { get; }

        // The public constructor, will be call when Procedimento will instantiated.
        public Procedimento() { }
        public Procedimento(
            string Descricao,
            double Preco,
            int AgendamentoID
        ) 
        {
            this.Descricao = Descricao;
            this.Preco = Preco;

            this.AgendamentoID = AgendamentoID;
                        
            // Adicionando os procedimentos no Banco de Dados.
            Context db = new Context();
            db.Procedimentos.Add(this);
            db.SaveChanges();
            // Add Procedimento in a list of associate Agendamentos.
            Agendamento.AddProcedimento(this);
        }

        // ToString - Procedimento
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Descricao: {this.Descricao}."
                + $"\n - Preco: ${this.Preco}"
                + $"\n - ID do agendamento: {this.Agendamento.Id}"
                + $"\n - Data do agendamento: {this.Agendamento.Date}";
        }

        // Equals - Procedimento
        public override bool Equals(object obj)
        {
            if (obj == null || !Procedimento.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Procedimento iterable = (Procedimento) obj;
            return iterable.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Retorna todos os procedimentos.
        public static List<Procedimento> GetProcedimentos()
        {
            Context db = new Context();
            return (from Procedimento in db.Procedimentos select Procedimento).ToList();
        }

        // Metodo pra remover o objeto Procedimento da lista de Procedimentos.
        public static void RemoveProcedimento(Procedimento procedimento)
        {
            Context db = new Context();
            db.Procedimentos.Remove(procedimento);
        }
    }
}