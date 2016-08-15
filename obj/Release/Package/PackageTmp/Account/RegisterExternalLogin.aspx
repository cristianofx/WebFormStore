<%@ Page Title="Register an external login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="WebFormsStore.Account.RegisterExternalLogin" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Registre-se com sua conta do(a) <%: ProviderName %></h3>

    <asp:PlaceHolder runat="server">
        <div class="form-horizontal">
            <h4>Formulário para registrar-se</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="nomeUserField" CssClass="col-md-2 control-label">Nome</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="nomeUserField" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="nomeUserField"
                        CssClass="text-danger" ErrorMessage="Por favor, insira seu nome." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="SobrenomeField" CssClass="col-md-2 control-label">Sobrenome</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="SobrenomeField" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="SobrenomeField"
                        CssClass="text-danger" ErrorMessage="Por favor, insira seu  sobrenome." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="NascimentoField" CssClass="col-md-2 control-label">Data de Nascimento</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="NascimentoField" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NascimentoField"
                        CssClass="text-danger" ErrorMessage="Por favor, insira sua data de nascimento." />
                    <br />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="NascimentoField" ValidationExpression="(((0|1)[1-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                        CssClass="text-danger" ErrorMessage="Formato de data inválido, por favor digite dd/mm/aaaa" />
                </div>
            </div>
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <p class="text-info">
                Você se autenticou com <strong><%: ProviderName %></strong>. Por favor, adicione um email para ser usado neste site.
                e clique no botão de logar-se.
            </p>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="email" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Email is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="email" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Logar-se" CssClass="btn btn-default" OnClick="LogIn_Click" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
