using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Especialidade
    {
        public int Id { set; get; }
        public string Descricao { set; get; }
        public string Detalhe { set; get; }

        // Criando o construtor de especialidade.
        public Especialidade() { }
        public Especialidade(
            string Descricao,
            string Detalhe
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Detalhe = Detalhe;

            // Adicionando especialidade no Banco de Dados
            Context db = new Context();
            db.Especialidades.Add(this);
            db.SaveChanges();
        }

        // ToString - Especialidade
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Descrição: {this.Descricao}."
                + $"\n - Detalhe: {this.Detalhe}.";
        }

        // Equals - Especialidade
        public override bool Equals(object obj)
        {
            if (obj == null || !Especialidade.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Especialidade iterable = (Especialidade) obj;
            return iterable.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Retornando todas as especialidades
        public static List<Especialidade> GetEspecialidades()
        {
            Context db = new Context();
            return (from Especialidade in db.Especialidades select Especialidade).ToList();
        }

        // Removendo o objeto Especialidade da lista de Especialidades.
        public static void RemoveEspecialidade(Especialidade especialidade)
        {
            Context db = new Context();
            db.Especialidades.Remove(especialidade);
        }
    }
}