using System;
using Models;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class ProcedimentoController
    {
        // Criando um novo procedimento.
        public static Procedimento CriarProcedimento(
		string Descricao, 
		double Preco, 
		int AgendamentoId
		)
        {
            if(string.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição inválida.");
            }

            Regex rxPreco = new Regex("(?!0$)[0-9]+(?:\\.[0-9]+)?");
            if (!rxPreco.IsMatch(Convert.ToString(Preco)))
            {
                throw new Exception("Preço inválido.");
            }
            
            AgendamentoController.GetAgendamento(AgendamentoId);

            return new Procedimento(Descricao, Preco, AgendamentoId);
        }

        // Alterando um procedimento existente.
        public static Procedimento UpdateProcedimento(
            int Id,
            string Descricao,
            double Preco
        )
        {
            Procedimento procedimento = GetProcedimento(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                procedimento.Descricao = Descricao;
            }

            Regex rxPreco = new Regex("(?!0$)[0-9]+(?:\\.[0-9]+)?");
            if (!rxPreco.IsMatch(Convert.ToString(Preco)))
            {
                throw new Exception("Preço inválido.");
            }

            return procedimento;
        }

        // Deletando um procedimento pela ID.
        public static Procedimento DeleteProcedimento(int Id)
        {
            try
            {
                Procedimento procedimento = GetProcedimento(Id);
                Procedimento.RemoveProcedimento(procedimento);
                return procedimento;
            }
            catch
            {
                throw new Exception("Ocorreu um erro.");
            }
        }

        // Get todos os procedimentos.
        public static List<Procedimento> GetAllProcedimentos()
        {
            return Procedimento.GetProcedimentos();
        }

        // Get Procedimento por ID.
        public static Procedimento GetProcedimento(int Id)
        {
            Procedimento procedimento = (
                from Procedimento in Procedimento.GetProcedimentos()
                    where Procedimento.Id == Id
                    select Procedimento
            ).First();

            if (procedimento == null)
            {
                throw new Exception("Procedimento não encontrado.");
            }

            return procedimento;
        }
    }
}