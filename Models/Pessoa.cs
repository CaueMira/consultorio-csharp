namespace Models
{
    public class Pessoa
    {
        //Atributos classe pessoa
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        // Public Method Constructor for the Class Pessoa.
        public Pessoa() { }
        public Pessoa(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha
        )
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Email = Email;
            this.Senha = Senha;
        }

        // ToString - Pessoa
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Nome: {this.Nome}"
                + $"\n - CPF: {this.Cpf}"
                + $"\n - Fone: {this.Fone}"
                + $"\n - Email: {this.Email}";
        }

        // Equals - Pessoa
        public override bool Equals(object obj)
        {
            if (obj == null || !Pessoa.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Pessoa iterable = (Pessoa) obj;
            return iterable.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}