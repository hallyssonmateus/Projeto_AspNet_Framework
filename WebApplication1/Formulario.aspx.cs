using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Garante que a mensagem de erro não apareça no carregamento inicial
                LabelError.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Exemplo de depuração
            System.Diagnostics.Debug.WriteLine("Botão clicado");

            string nome = TextBox1.Text.Trim();
            string dataNascimentoStr = TextBox2.Text.Trim();
            string cpf = TextBox3.Text.Trim();
            string tiposeguroSelecionado = DropDownList1.SelectedValue;

            // Validação de campos obrigatórios
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(dataNascimentoStr) || string.IsNullOrEmpty(cpf))
            {
                LabelError.Text = "Todos os campos são obrigatórios!";
                LabelError.Visible = true; // Certifique-se de que o rótulo de erro é visível
                return;
            }

            // Validação de CPF
            if (!ValidarCPF(cpf))
            {
                LabelError.Text = "CPF inválido!";
                LabelError.Visible = true; // Certifique-se de que o rótulo de erro é visível
                return;
            }

            // Validação da data de nascimento (maior de 18 anos)
            if (!ValidarDataDeNascimento(dataNascimentoStr))
            {
                LabelError.Text = "Você deve ter mais de 18 anos.";
                LabelError.Visible = true; // Certifique-se de que o rótulo de erro é visível
                return;
            }

            // Se todas as validações passarem, redireciona para a página de resultados
            Response.Redirect("Resultado.aspx?nome=" + Server.UrlEncode(nome) +
    "&cpf=" + Server.UrlEncode(cpf) +
    "&datanascimento=" + Server.UrlEncode(dataNascimentoStr) +
    "&tiposeguro=" + Server.UrlEncode(tiposeguroSelecionado));
        }

        private static bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            bool todosDigitosIguais = true;
            for (int i = 1; i < 11 && todosDigitosIguais; i++)
                if (cpf[i] != cpf[0])
                    todosDigitosIguais = false;

            if (todosDigitosIguais || cpf == "12345678909")
                return false;

            int[] multiplicadores1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }

        private bool ValidarDataDeNascimento(string dataNascimentoStr)
        {
            DateTime dataNascimento;
            if (DateTime.TryParse(dataNascimentoStr, out dataNascimento))
            {
                int idade = DateTime.Now.Year - dataNascimento.Year;

                if (dataNascimento > DateTime.Now.AddYears(-idade)) idade--;

                return idade >= 18;
            }
            return false;
        }
    }
}