<%@ Page Title="Registrar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebFormsStore.Account.Register" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <h2><%: Title %></h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <div class="col-md-6">
            <div class="form-horizontal">
                <h4>Criar uma nova conta</h4>
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
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                            CssClass="text-danger" ErrorMessage="Por favor, insira seu email" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Senha</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="Por favor, insira uma senha." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirmar senha</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="É necessário confirmar sua senha." />
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="As senhas não são iguais." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrar" CssClass="btn btn-primary" />
                    </div>
                </div>

            </div>
        </div>
        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>

</asp:Content>
