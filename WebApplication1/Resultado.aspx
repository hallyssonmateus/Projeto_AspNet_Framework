<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Resultado.aspx.cs" Inherits="WebApplication1.Resultado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="description" content="Apresentação dos preços do valor do seguro escolhido!"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box-seguro">
        <h2>Resultado do Formulário</h2>
        <asp:Label ID="LabelNome" class="LabelNome" runat="server" Text=""></asp:Label><br/>
        <asp:Label ID="LabelCPF" class="LabelCPF" runat="server" Text=""></asp:Label><br/>
        <asp:Label ID="LabelDataNascimento" class="LabelDataNascimento" runat="server" Text=""></asp:Label><br/>
        <asp:Label ID="LabelTipoSeguro" class="LabelTipoSeguro" runat="server" Text=""></asp:Label><br/>
        <asp:Button ID="btnVoltar" class="btn-voltar" runat="server" Text="Voltar ao Formulário" PostBackUrl="~/Formulario.aspx" />
        <button type="button" onclick="window.print();">Imprimir Resultado</button>
    </div>
    
</asp:Content>
