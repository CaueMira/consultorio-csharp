namespace Models
{
    public class Autenticacao
    {
        // Atributos para classe de autenticação
        public static Paciente Paciente;
        public static Dentista Dentista;
        // Confere se ocorreu tudo certo no login
        public static bool IsLogeed;

        // Metodo para tentar realizar o login
        public static void PacienteLogin(
		string Email, 
		string Senha
		)
        {
            // Conferindo se o paciente está na lista de pacientes, e procurando o paciente com o mesmo Email e senha.
            Paciente paciente = Paciente.GetPacientes()
                .Find(Paciente => Paciente.Email == Email && BCrypt.Net.BCrypt.Verify(Senha, Paciente.Senha));
        

            if (paciente != null)
            {
                IsLogeed = true;
                Paciente = paciente;
                Dentista = null;
            }
            else
            {
                Logout();
            }
        }

        public static void DentistaLogin(string Email, string Senha)
        {
            // Conferindo se o dentista está na lista de dentistas, e procurando o dentista com o mesmo Email e senha.
            Dentista dentista = Dentista.GetDentistas()
                .Find(Dentista => Dentista.Email == Email && BCrypt.Net.BCrypt.Verify(Senha, Dentista.Senha));
        

            if (dentista != null)
            {
                IsLogeed = true;
                Dentista = dentista;
                Paciente = null;
            }
            else
            {
                Logout();
            }
        }

        // Saindo com os dados inválidos
        public static void Logout()
        {
            IsLogeed = false;
            Dentista = null;
            Paciente = null;
        }
    }
}