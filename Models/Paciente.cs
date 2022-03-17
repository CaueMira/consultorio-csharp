using System;
using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Paciente : Pessoa
    {
        // Atributos para paciente.
        private static List<Paciente> Pacientes = new List<Paciente>();
        public DateTime DtNasc { set; get; }

        // Criando o construtor do Paciente.
        public Paciente() { }

        public Paciente(
            string Name,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DtNasc
        ) : base(Name, Cpf, Fone, Email, Senha)
        {
            this.DtNasc = DtNasc;

            //Adicionando Paciente no Banco de Dados
            Context db = new Context();
            db.Pacientes.Add(this);
            db.SaveChanges();
        }

        // ToString - Pacientes
        public override string ToString()
        {
            return base.ToString()
                + $"\n + Data de nascimento: {this.DtNasc}";
        }

        // Equals - Paciente
        public override bool Equals(object obj)
        {
            if (obj == null || !Paciente.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Paciente iterable = (Paciente) obj;
            return iterable.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Retornando todos pacientes.
        public static List<Paciente> GetPacientes()
        {
            Context db = new Context();
            return (from Paciente in db.Pacientes select Paciente).ToList();
        }

        // Removendo o objeto paciente de pacientes.
        public static void RemovePaciente(Paciente paciente)
        {
            Context db = new Context();
            db.Pacientes.Remove(paciente);
        }
    }
}