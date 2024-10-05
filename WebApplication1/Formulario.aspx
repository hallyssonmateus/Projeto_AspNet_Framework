<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="description" content="Formulário para calculo de preços de seguros da empresa Télos!"/>
    <meta name="keywords" content="simulador de seguros, Telos Seguros, cotação de seguros, seguro de vida, seguro de acidentes, seguro patrimonial, seguro de automóvel, orçamento de seguro, calcular seguro online, CPF, cotação de seguros personalizada, seguro residencial, seguro empresarial, seguro de saúde"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formulario">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Campo Nome é obrigatório" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <asp:Label ID="Label1" class="Label1" CssClass="Label1" runat="server" Text="Nome:"></asp:Label>
        <asp:TextBox ID="TextBox1" class="TextBox1" placeholder="Digite seu nome" runat="server"></asp:TextBox>
       
        <asp:Label ID="Label2" class="Label2" runat="server" Text="Data de Nascimento:"></asp:Label>
        <asp:TextBox ID="TextBox2" class="TextBox2" runat="server" placeholder="Digite sua data de nascimento (dd/mm/aaaa)"></asp:TextBox>
        
        <asp:Label ID="Label3" class="Label3" runat="server" Text="CPF:"></asp:Label>
        <asp:TextBox ID="TextBox3" class="TextBox3" runat="server" placeholder="Digite seu CPF (000.000.000-00)"></asp:TextBox>
        <asp:Label ID="Label4" class="Label4" runat="server" Text="Selecione o modelo de seguro:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" class="DropDownList1" runat="server">
            <asp:ListItem Text="Seguro de Vida" Value="segurodevida"></asp:ListItem>
            <asp:ListItem Text="Seguro de Morte Acidental" Value="segurodemorteacidental"></asp:ListItem>
            <asp:ListItem Text="Seguro Contra Acidentes Pessoais" Value="segurocontraacidentespessoais"></asp:ListItem>
            <asp:ListItem Text="Seguro de Saúde" Value="segurodesaúde"></asp:ListItem>
            <asp:ListItem Text="Seguro de Automóvel" Value="segurodeautomóvel"></asp:ListItem>
            <asp:ListItem Text="Seguro Residencial" Value="seguroresidencial"></asp:ListItem>
            <asp:ListItem Text="Seguro Patrimonial" Value="seguropatrimonial"></asp:ListItem>
            <asp:ListItem Text="Seguro Empresarial" Value="seguroempresarial"></asp:ListItem>
        </asp:DropDownList><br/><br/>
        <div class="btn-container">
            <asp:Button ID="Button2" class="btn-resultado" runat="server" Text="Mostrar Orçamento" OnClick="Button2_Click"/>
            <asp:Label ID="LabelError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        
    </div>
</asp:Content>
