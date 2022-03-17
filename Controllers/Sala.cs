using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class SalaController
    {
        // Criando uma nova sala.
        public static Sala CriarSala(
		string Numero, 
		string Equipamentos
		)
        {
            if (String.IsNullOrEmpty(Numero))
            {
                throw new Exception("Identificador inválido.");
            }

            if (String.IsNullOrEmpty(Equipamentos))
            {
                throw new Exception("Equipamentos inválido.");
            }

            return new Sala(Numero, Equipamentos);
        }

        // Alterando uma sala existente.
        public static Sala UpdateSala(int Id, string Numero, string Equipamentos)
        {
            Sala sala = GetSala(Id);

            if (!String.IsNullOrEmpty(Numero))
            {
                sala.Numero = Numero;
            }

            if (!String.IsNullOrEmpty(Equipamentos))
            {
                sala.Equipamentos = Equipamentos;
            }

            return sala;
        }

        // Deletando a sala pela id.
        public static Sala DeleteSala(int Id)
        {
            try
            {
                Sala sala = GetSala(Id);
                Sala.RemoveSala(sala);
                return sala;
            }
            catch
            {
                throw new Exception("Ocorreu um erro.");
            }
        }

        // Get todas as salas
        public static List<Sala> GetAllSalas()
        {
            return Salas.GetSalas();
        }

        // Get Salas por id.
        public static Sala GetSala(int Id)
        {
            List<Sala> salasModels = Sala.GetSalas();
            IEnumerable<Sala> salas = from Sala in salasModels
                where Sala.Id == Id
                select Sala;
            Sala sala = salas.First();

            if (sala == null)
            {
                throw new Exception("Sala não encontrada");
            }

            return sala;
        }
    }
}