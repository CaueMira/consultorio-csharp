using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Dentista : Pessoa
    {
        public string Registro { set; get; }
        public double Salario { set; get; }
        public int EspecialidadeID { set; get; }
        public Especialidade Especialidade { get; }
        
        public Dentista() { }

        // Criando o construtor Dentista.
        public Dentista(
            string Name,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            string Registro,
            double Salario,
            int EspecialidadeID
        ) : base(Name, Cpf, Fone, Email, Senha)
        {
            this.Registro = Registro;
            this.Salario = Salario;
            this.EspecialidadeID = EspecialidadeID;

            // Adicionando o Dentista no Banco de Dados
            Context db = new Context();
            System.Console.WriteLine(this);
            db.Dentistas.Add(this);
            db.SaveChanges();
        }
        
        //ToString para o dentista
        public override string ToString()
        {
            return base.ToString()
                + $"\n + Registro: {this.Registro}"
                + $"\n + Salario: {this.Salario}"
                + $"\n * Descricap da Especialidade: {this.EspecialidadeID}";
                //+ $"\n * Details of Especialidade: {this.Especialidade}";
        }

        // Equals - Dentista
        public override bool Equals(object obj)
        {
            if (obj == null || !Dentista.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Dentista iterable = (Dentista) obj;
            return iterable.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Dentistas.
        public static List<Dentista> GetDentistas()
        {
            Context db = new Context();
            return (from Dentista in db.Dentistas select Dentista).ToList();
        }

        // Method remove a Object Dentista from list of Dentistas.
        public static void RemoveDentista(Dentista dentista)
        {
            Context db = new Context();
            db.Dentistas.Remove(dentista);
        }
    }
}