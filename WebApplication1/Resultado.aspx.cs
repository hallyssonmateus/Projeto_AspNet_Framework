using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Resultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var form = Request.Form;
            //var concat = "ContentPlaceHolder1_";
            //var nome = Request.Form[concat + "TextBox1"];
            //var datanascimento = Request.Form[concat + "TextBox2"];
            //var cpf = Request.Form[concat + "TextBox3"];
            //var tiposeguro = form[concat + "DropDownList1"];

            string nome = Request.QueryString["nome"];
            string datanascimento = Request.QueryString["datanascimento"];
            string cpf = Request.QueryString["cpf"];
            string tiposeguro = Request.QueryString["tiposeguro"];

            LabelNome.Text = "Olá " + nome;
            LabelCPF.Text = "CPF: " + cpf;
            LabelDataNascimento.Text = "Data de Nascimento: " + datanascimento;
            LabelTipoSeguro.Text = "Você escolheu a opção de seguro: " + tiposeguro;

            decimal valorSeguro = CalcularValorSeguro(tiposeguro);

            //Concatenar com a mensagem do valor do seguro
            LabelTipoSeguro.Text += $" e o valor do orçamento do seguro ficou: R${valorSeguro:F2}";
        }

        private static decimal CalcularValorSeguro(string tipoSeguro)
        {
            const decimal valorBase = 1000m; // Valor base de R$1.000,00
            decimal percentual = 0;

            // Define o percentual baseado no tipo de seguro selecionado
            switch (tipoSeguro)
            {
                case "segurodevida":
                    percentual = 0.80m; // 80%
                    break;
                case "segurodemorteacidental":
                    percentual = 0.90m; // 90%
                    break;
                case "segurocontraacidentespessoais":
                    percentual = 0.50m; // 50%
                    break;
                case "segurodesaúde":
                    percentual = 0.40m; // 40%
                    break;
                case "segurodeautomóvel":
                    percentual = 2.50m; // 250%
                    break;
                case "seguroresidencial":
                    percentual = 0.60m; // 60%
                    break;
                case "seguropatrimonial":
                    percentual = 1.20m; // 120%
                    break;
                case "seguroempresarial":
                    percentual = 1.50m; // 150%
                    break;
                default:
                    percentual = 1.00m; // Caso não haja uma opção, aplica 100%
                    break;
            }

            // Calcula o valor final do seguro
            return valorBase * percentual;
        }
    }
}