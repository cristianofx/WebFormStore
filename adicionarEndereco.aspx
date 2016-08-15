<%@ Page Title="Adicionar um Endereço" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adicionarEndereco.aspx.cs" Inherits="WebFormsStore.adicionarEndereco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="tudo" runat="server">
        <div class="row">
            <div style="text-align: center">
                <h1><%: Title %></h1>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal" style="text-align: center">

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RuaBox" CssClass="col-md-1 control-label">Rua</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="RuaBox" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="RuaBox"
                            CssClass="text-danger" ErrorMessage="Por favor, insira sua rua." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="NumeroBox" CssClass="col-md-1 control-label">Número</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="NumeroBox" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NumeroBox"
                            CssClass="text-danger" ErrorMessage="Campo não pode ficar vazio." />
                        <br />
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="NumeroBox" ValidationExpression="^\d+$"
                            CssClass="text-danger" ErrorMessage="Digite apenas números" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ComplementoBox" CssClass="col-md-1 control-label">Complemento</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="ComplementoBox" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="CepBox" CssClass="col-md-1 control-label">CEP</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="CepBox" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CepBox"
                            CssClass="text-danger" ErrorMessage="Campo não pode ficar vazio." />
                        <br />
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="CepBox" ValidationExpression="\d{5}\-\d{3}$"
                            CssClass="text-danger" ErrorMessage="CEP deve ter formato XXXXX-XXX" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="CidadeBox" CssClass="col-md-1 control-label">Cidade</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="CidadeBox" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CidadeBox"
                            CssClass="text-danger" ErrorMessage="Por favor, insira sua cidade." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="BairroBox" CssClass="col-md-1 control-label">Bairro</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="BairroBox" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="BairroBox"
                            CssClass="text-danger" ErrorMessage="Por favor, insira seu Bairro." />
                    </div>
                </div>

            </div>

            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="salvarEndereco" Text="Salvar" CssClass="btn btn-primary" />
            </div>

        </div>
    </div>


</asp:Content>
