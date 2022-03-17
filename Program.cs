using System;
using Visualizars;
using Controllers;
using Models;

namespace ConsultorioOdontologico
{
    public class Program
    {
        public static string ReadSenha()
        {
            string senha = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    senha += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(senha))
                    {
                        // remover um caractere da lista de caracteres de senha
                        senha = senha.Substring(0, senha.Length - 1);
                        // obter a localização do cursor
                        int pos = Console.CursorLeft;
                        // mover o cursor para a esquerda em um caractere
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // substituindo por espaço
                        Console.Write(" ");
                        // mover o cursor para a esquerda em um caractere novamente
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            // adicionando uma nova linha porque o usuário pressionou "enter" no final de sua senha
            Console.WriteLine();
            return senha;
        }

        public static void Main(string[] args)
        {
            //EspecialidadeController.CriarEspecialidade("Clinico Geral", "O Dentistaa clínico geral é geralmente o primeiro profissional odontológico a entrar em contato com o paciente");
            //DentistaaController.CriarDentistaa("Caue Mira", "111.111.111-11", "47 99999-9999", "caue.mira@Dentistaa.com", "123456", "12345/SC", 15000, 1);
            //PacienteController.CriarPaciente("Jose Carlos", "111.111.111-11", "47 88888-8888", "jose.carlos@paciente.com", "123456", Convert.ToDateTime("1990-01-01"));
            //SalaController.CriarSala("B135", "RaioX");
            //AgendamentoController.Cr1, 1, 1, Convert.ToDateTime("2022-04-05"));
            //ProcedimentoController.CriarProcedimento("General diagnosis", 300, 1);
            // MenuPrincipal();

            do
            {
                Console.WriteLine("Usuário: ");
                string Email = Console.ReadLine();
                Console.WriteLine("Senha: ");
                string Senha = ReadSenha();
                
                try
                {
                    Autenticacao.DentistaaLogin(Email, Senha);
                    if (Autenticacao.Dentista != null)
                    {
                        PrincipalMenu();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
                try
                {
                    Autenticacao.PacienteLogin(Email, Senha);
                    if (Autenticacao.Paciente != null) {
                        PacienteMenu();
                    }
                    Autenticacao.Logout();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            } while (!Autenticacao.IsLogeed);
        }

        public static void PacienteMenu()
        {
            Console.WriteLine($" ============= BEM VINDO Paciente {Autenticacao.Paciente.Nome} ============ ");
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("| Operação  | Descricao               |");
            Console.WriteLine("|-----------|-------------------------|");
            Console.WriteLine("|     0     | Sair                    |");
            Console.WriteLine("|     1     | Ver agendamentos        |");
            Console.WriteLine("|     2     | Confirmar Agendamentos  |");
            Console.WriteLine("+-------------------------------------+");
            int opt = 0;

            do
            {
                Console.WriteLine("Informe sua operação: ");
                try
                {
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }
                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Volte sempre!");
                        break;
                    case 1:
                        AgendamentoVisualizar.GetPacienteAgendamento(Autenticacao.Paciente.Id);
                        break;
                    case 2:
                        AgendamentoVisualizar.ConfirmAgendamento();
                        break;
                    default:
                        Console.WriteLine("Operação inválida");
                        break;
                }  
            } while (opt != 0);
        }

        public static void PrincipalMenu()
        {
            Console.WriteLine($" ============= BEM VINDO {Autenticacao.Dentista.Nome} ============ ");
            Console.WriteLine("+----------------------------------------------+");
            Console.WriteLine("| Operação  |  			Descrição   		  |");
            Console.WriteLine("|-----------|----------------------------------|");
            Console.WriteLine("|  0        |  Sair                   		  |");
            Console.WriteLine("|  1        |  Criar Dentista         		  |");
            Console.WriteLine("|  2        |  Criar Paciente         		  |");
            Console.WriteLine("|  3        |  Criar Sala            		  |");
            Console.WriteLine("|  4        |  Criar Agendamento       		  |");
            Console.WriteLine("|  5        |  Criar Procedimento       		  |");
            Console.WriteLine("|  6        |  Criar Especialidade      		  |");
            Console.WriteLine("|  7        |  Atualizar Dentista         	  |");
            Console.WriteLine("|  8        |  Atualizar Paciente         	  |");
            Console.WriteLine("|  9        |  Atualizar Sala            	  |");
            Console.WriteLine("|  10       |  Atualizar Agendamento       	  |");
            Console.WriteLine("|  11       |  Atualizar Procedimento          |");
            Console.WriteLine("|  12       |  Atualizar Especialidade      	  |");
            Console.WriteLine("|  13       |  Remover Dentista         		  |");
            Console.WriteLine("|  14       |  Remover Paciente                |");
            Console.WriteLine("|  15       |  Remover Sala                    |");
            Console.WriteLine("|  16       |  Remover Agendamento             |");
            Console.WriteLine("|  17       |  Remover Procedimento            |");
            Console.WriteLine("|  18       |  Remover Especialidade           |");
            Console.WriteLine("|  19       |  Visualizar Dentistas            |");
            Console.WriteLine("|  20       |  Visualizar Pacientes            |");
            Console.WriteLine("|  21       |  Visualizar Salas                |");
            Console.WriteLine("|  22       |  Visualizar Agendamentos         |");
            Console.WriteLine("|  23       |  Visualizar Procedimentos        |");
            Console.WriteLine("|  24       |  Visualizar Specialities      	  |");
            Console.WriteLine("+----------------------------------------------+");

            int opt = 0;

            do
            {
                try
                {
                    Console.WriteLine("Informe sua operação: ");
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }
                try{
                    switch (opt)
                    {
                        case 0:
                        {
                            Console.WriteLine("Valeu pela visita.");
                            break;
                        }
                        case 1:
                        {
                            DentistaVisualizar.CriarDentista();
                            break;
                        }
                        case 2:
                        {
                            PacienteVisualizar.CriarPaciente();
                            break;
                        }
                        case 3:
                        {
                            SalaVisualizar.CriarSala();
                            break;
                        }
                        case 4:
                        {
                            AgendamentoVisualizar.CriarAgendamento();
                            break;
                        }
                        case 5:
                        {
                            ProcedimentoVisualizar.CriarProcedimento();
                            break;
                        }
                        case 6:
                        {
                            EspecialidadeVisualizar.CriarEspecialidade();
                            break;
                        }
                        case 7:
                        {
                            DentistaVisualizar.AtualizarDentista();
                            break;
                        }
                        case 8:
                        {
                            PacienteVisualizar.AtualizarPaciente();
                            break;
                        }
                        case 9:
                        {
                            SalaVisualizar.AtualizarSala();
                            break;
                        }
                        case 10:
                        {
                            AgendamentoVisualizar.AtualizarAgendamento();
                            break;
                        }
                        case 11:
                        {
                            ProcedimentoVisualizar.AtualizarProcedimento();
                            break;
                        }
                        case 12:
                        {
                            EspecialidadeVisualizar.AtualizarEspecialidade();
                            break;
                        }
                        case 13:
                        {
                            DentistaVisualizar.RemoverDentista();
                            break;
                        }
                        case 14:
                        {
                            PacienteVisualizar.RemoverPatiet();
                            break;
                        }
                        case 15:
                        {
                            SalaVisualizar.RemoverSala();
                            break;
                        }
                        case 16:
                        {
                            AgendamentoVisualizar.RemoverAgendamento();
                            break;
                        }
                        case 17:
                        {
                            ProcedimentoVisualizar.RemoverProcedimento();
                            break;
                        }
                        case 18:
                        {
                            EspecialidadeVisualizar.RemoverSpeciliaty();
                            break;
                        }
                        case 19:
                        {
                            DentistaVisualizar.GetAllDentistas();
                            break;
                        }
                        case 20:
                        {
                            PacienteVisualizar.GetAllPacientes();
                            break;
                        }
                        case 21:
                        {
                            SalaVisualizar.GetAllSalas();
                            break;
                        }
                        case 22:
                        {
                            AgendamentoVisualizar.GetAllAgendamentos();
                            break;
                        }
                        case 23:
                        {
                            ProcedimentoVisualizar.GetAllProcedimentos();
                            break;
                        }
                        case 24:
                        {
                            EspecialidadeVisualizar.GetAllSpecialities();
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Operação inválida.");
                            break;
                        }
                    }
                } 
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    opt = 99;
                }
            } while (opt != 0);
        }
    }
}