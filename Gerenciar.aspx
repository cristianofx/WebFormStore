<%@ Page MaintainScrollPositionOnPostback="true" Title="Gerência do Site" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerenciar.aspx.cs" Inherits="WebFormsStore.Gerenciar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="painel" runat="server" visible="false">

        <div class="row">
            <div style="text-align: center">
                <h1><%: Title %></h1>
            </div>
        </div>


        <div class="row">
            <div style="text-align: left">
                <h3>Adicionar Categoria:</h3>
            </div>
            <div class="form-horizontal" style="text-align: center">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="NomeCategoria" CssClass="col-md-2 control-label">Nome da Categoria</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="NomeCategoria" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="DescricaoCategoria" CssClass="col-md-2 control-label">Descrição da Categoria</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="DescricaoCategoria" CssClass="form-control" TextMode="MultiLine" Height="140px" Style="resize: none" />
                    </div>
                </div>
                <div class="form-group" style="text-align: left; margin-left: 5px">
                    <div class="col-md-2"></div>
                    <asp:Button ID="AdicionaCategoriaBtn" runat="server" CssClass="btn btn-primary" Text="Adicionar" OnClick="adicionaCategoria" />
                    <asp:Label ID="resultado" runat="server" Visible="false" Text="" CssClass=""></asp:Label>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">

            <div class="col-md-2" style="width: auto">
                <h3>Editar Categoria 

            <asp:DropDownList ID="DropDownList1" CssClass="btn btn-primary dropdown-toggle" runat="server"
                DataTextField="CategoriaNome" DataValueField="CategoriaID" SelectMethod="GetCategories"
                OnSelectedIndexChanged="loadCategoria" AutoPostBack="True" AppendDataBoundItems="True">
                <asp:ListItem Text="" Selected="True"></asp:ListItem>
            </asp:DropDownList>

                </h3>
            </div>
        </div>
        <div class="row">
            <div class="form-horizontal" style="text-align: center">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="NomeCategoriaMudar" CssClass="col-md-2 control-label">Nome da Categoria</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="NomeCategoriaMudar" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="DescricaoCategoriaMudar" CssClass="col-md-2 control-label">Descrição da Categoria</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="DescricaoCategoriaMudar" CssClass="form-control" TextMode="MultiLine" Height="140px" Style="resize: none" />
                    </div>
                </div>
                <div class="form-group" style="text-align: left; margin-left: 5px">
                    <div class="col-md-2"></div>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Salvar" OnClick="modificaCategoria" />
                    <asp:Label ID="ResultadoSalvar" runat="server" Visible="false" Text="" CssClass=""></asp:Label>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">

            <div style="text-align: left">
                <h3>Procurar informações de um usuário:</h3>
            </div>

            <div style="width: 100%; text-align: center">
                <input type="text" name="textoSearch" size="15" />
                <input type="button" class="btn btn-primary btn-sm" value="Procurar Usuário"
                    onclick="window.location = 'Gerenciar.aspx?search=' + this.form.textoSearch.value">
            </div>

            <asp:ListView ID="UserList" runat="server"
                DataKeyNames="UsuarioID" GroupItemCount="4"
                ItemType="WebFormsStore.Models.Usuario" SelectMethod="GetSearch">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>Nenhum usuário encontrado</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <br />
                                    <a href="DetalhesUsuario.aspx?userID=<%#:Item.UsuarioID%>">
                                        <span>
                                            <%#:Item.Nome%>&nbsp;<%#:Item.Sobrenome %>
                                        </span>
                                    </a>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>

        </div>
    </div>
    <br />
</asp:Content>
