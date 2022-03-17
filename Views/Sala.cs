using System;
using Controllers;
using Models;

namespace Views
{
    public class View
    {
        public static void CriarSala()
        {
            Console.WriteLine("Informe o identificador da sala: ");
            string Numero = Console.ReadLine();
            Console.WriteLine("Informe os equipamentos da sala: ");
            string Equipamentos = Console.ReadLine();

            RoomController.CriarSala(
                Numero,
                Equipamentos
            );
        }

        public static void UpdateSala()
        {
            int Id = 0;

            GetAllSalas();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe o ID da Sala: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }

            Console.WriteLine("Informe o identificador da sala: ");
            string Numero = Console.ReadLine();
            Console.WriteLine("Informe os equipamentos da sala: ");
            string Equipamentos = Console.ReadLine();

            SalaController.UpdateSala(
                Id,
                Numero,
                Equipamentos
            );
        }

        public static void DeleteSala()
        {
            int Id = 0;

            GetAllSalas();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Informe o ID da Sala: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválida.");
            }
            
            SalaController.DeleteSala(Id);
        }

        public static void GetAllSalas()
        {
            foreach (Sala sala in SalaController.GetAllSalas())
            {
                Console.WriteLine(sala);
            }
        }
    }
}