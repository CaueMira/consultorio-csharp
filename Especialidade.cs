using System;
using Models;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class EspecialidadeController
    {
        // Criando uma nova especialidade.
        public static Especialidade CriarEspecialidade(
		string Descricao, 
		string Detalhes
		)
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descricao inválida.");
            }

            if (String.IsNullOrEmpty(Detalhes))
            {
                throw new Exception("Detalhes inválidos");
            }

            return new Especialidade(Descricao, Detalhes);
        }

        // Alterando uma especialidade que já existe.
        public static Especialidade UpdateEspecialidade(
            int Id,
            string Descricao,
            string Detalhes
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                especialidade.Descricao = Descricao;
            }
            
            if (!String.IsNullOrEmpty(Detalhes))
            {
                especialidade.Detalhe = Detalhes;
            }

            return especialidade;
        }

        // Deletando especialidade por ID.
        public static Especialidade DeleteEspecialidade(int Id)
        {
            try
            {
                Especialidade especialidade = GetEspecialidade(Id);
                Especialidade.RemoveEspecialidade(especialidade);
                return especialidade;
            }
            catch
            {
                throw new Exception("Ocorreu algum erro.");
            }
        }

        // Get todas especialidades.
        public static List<Especialidade> GetAllEspecialidades()
        {
            return Especialidade.GetEspecialidades();
        }

        // Get Especialidade por ID.
        public static Especialidade GetEspecialidade(int Id)
        {
            Especialidade especialidade = (
                from Especialidade in Especialidade.GetEspecialidades()
                    where Especialidade.Id == Id
                    select Especialidade
            ).First();

            if (especialidade == null)
            {
                throw new Exception("Especialidade não encontrada.");
            }

            return especialidade;
        } 
    }
}