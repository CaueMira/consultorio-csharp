using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Sala
    {
        public int Id { set; get; }
        [Required]
        public string Numero { set; get; }
        [Required]
        public string Equipamentos { set; get; }

        // Criando o construtor da Sala
        public Sala() { }
        public Sala(
            string Numero,
            string Equipamentos
        )
        {
            this.Id = Id;
            this.Numero = Numero;
            this.Equipamentos = Equipamentos;

            // Adicionando Sala no Banco de Dados. 
            Context db = new Context();
            db.Salas.Add(this);
            db.SaveChanges();
        }

        // ToString - Salas.
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Identificador: {this.Numero}"
                + $"\n - Equipamentos: {this.Equipamentos}";
        }

        // Equals - Salas
        public override bool Equals(object obj)
        {
            if (obj == null || !Sala.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Sala iterable = (Sala) obj;
            return iterable.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Retornando todas as listas de Salas.
        public static List<Sala> GetSalas()
        {
            Context db = new Context();
            return (from Sala in db.Salas select Sala).ToList();
        }

        // Removendo o objeto Sala da lista Salas.
        public static void RemoveSala(Sala sala)
        {
            Context db = new Context();
            db.Salas.Remove(sala);
        }
    }
}