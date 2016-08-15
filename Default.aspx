<%@ Page Title="Bem Vindo ao Torpedo - Venda e Compre" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsStore._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="tex">
        <div class="jumbotron text-center" style="background-color: #2fa4e7">
            <h1>Bem-vindo ao Torpedo</h1>
            <p class="lead">Venda seus produtos e ganhe dinheiro</p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4 text-center" style="margin: 0 auto;">
            <img class="img-center center-block" style="height: 60px; margin-top: 0px;" src="Images/dollars25.png">
            <h2>Cadastre e venda</h2>
            <p>
                Você tem algum produto que não está mais usando?
            Cadastre seu produto, anuncie a venda e ganhe dinheiro.
            </p>
            <p>
                <a id="botao1" class="btn btn-primary" href="/account/register" runat="server">Cadastre-se &raquo;</a>
                <a id="botao2" class="btn btn-primary" href="/AdicionarProduto" runat="server" visible="false">Adicione um Produto &raquo;</a>
            </p>
        </div>
        <div class="col-md-4 text-center">
            <img class="img-center center-block" style="height: 60px; margin-top: 0px;" src="Images/full22.png">
            <h2>Compre facilmente</h2>
            <p>
                Procure seu produto desejado e realize seu sonho
            </p>
            <p>
                <a class="btn btn-primary" href="/ListaProdutos">Veja os produtos &raquo;</a>
            </p>
        </div>
        <div class="col-md-4 text-center">
            <img class="img-center center-block" style="height: 60px; margin-top: 0px;" src="Images/bill7.png">
            <h2>Fale Conosco</h2>
            <p>
                Mande uma mensagem para nós em caso e dúvidas.
            </p>
            <p>
                <a class="btn btn-primary" href="/Contact">Contato &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
