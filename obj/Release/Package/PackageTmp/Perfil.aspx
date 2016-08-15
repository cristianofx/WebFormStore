<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="WebFormsStore.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .myCenter {
            margin-left: auto;
            margin-right: auto;
        }
    </style>


    <div >
        <asp:FormView ID="DetalheUsuario" runat="server" ItemType="WebFormsStore.Models.Usuario" SelectMethod="getUser" RenderOuterTable="false">
            <ItemTemplate>
                <div>
                    <h1><%#:Item.Nome %>&nbsp;<%#:Item.Sobrenome %></h1>
                </div>
                <br />
                <table>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="vertical-align: top; text-align: left;">
                            <b>Email: </b>
                            <%# Item.Email %>
                            <br />
                            <b>Data de Nascimento:</b>
                            <%#:Item.DataNascimento.ToShortDateString() %>
                            <br />

                        </td>
                    </tr>
                </table>
                <br />

            </ItemTemplate>


        </asp:FormView>

        <div class="row">

            <div class="col-md-1">
                <a id="addEndLink" class="btn btn-primary" href="~/adicionarEndereco.aspx" runat="server">Adicionar um Endereço</a>
            </div>
            <asp:FormView ID="mostraEndereço" runat="server" ItemType="WebFormsStore.Models.Endereco" SelectMethod="getEndereco" RenderOuterTable="false">
                <ItemTemplate>
                    <div>
                        <h1>Endereço</h1>
                    </div>
                    <br />
                    <table>
                        <tr>
                            <td>&nbsp;</td>
                            <td style="vertical-align: top; text-align: left;">
                                <b>Rua: </b>
                                <%# Item.Rua %>
                                <br />
                                <b>Número: </b>
                                <%#:Item.Numero %>
                                <br />
                                <b>Complemento: </b>
                                <%#:Item.Complemento %>
                                <br />
                                <b>CEP: </b>
                                <%#:Item.Cep %>
                                <br />
                                <b>Bairro: </b>
                                <%#:Item.Bairro %>
                                <br />
                                <b>Cidade: </b>
                                <%#:Item.Cidade %>
                            </td>
                        </tr>
                    </table>
                    <br />

                </ItemTemplate>
            </asp:FormView>

        </div>

        <div>
            <section>
                <div>
                    <hgroup>
                        <h2>Meus Produtos Comprados:</h2>
                    </hgroup>

                    <asp:ListView ID="productList" runat="server"
                        DataKeyNames="ProdutoID" GroupItemCount="4"
                        ItemType="WebFormsStore.Models.Produto" SelectMethod="GetProducts">
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td>Sem produtos.</td>
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
                                            <a href="DetalhesProduto.aspx?productID=<%#:Item.ProdutoID%>">
                                                <img src="<%#:Item.ImagePath%>"
                                                    width="100" height="75" style="border: solid" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="ProductDetails.aspx?productID=<%#:Item.ProdutoID%>">
                                                <span>
                                                    <%#:Item.ProdutoNome%>
                                                </span>
                                            </a>
                                            <br />
                                            <span>
                                                <b>Preço: </b><%#:String.Format("{0:c}", Item.PrecoUnitario)%>
                                            </span>
                                            <br />
                                            <div runat="server" visible="<%# !Item.vendido && !Item.bloqueado ? true : false %>">
                                                <a href="/EditarProduto.aspx?productID=<%#:Item.ProdutoID %>">
                                                    <span class="ProductListItem">
                                                        <b>Editar Produto<b>
                                                    </span>
                                                </a>
                                            </div>
                                            <asp:Label ID="LabelVendido" runat="server" Visible="<%# Item.vendido ? true : false %>"><h5>VENDIDO</h5></asp:Label>
                                            <asp:Label ID="LabelBloqueado" runat="server" Visible="<%# Item.bloqueado ? true : false %>"><h5>BLOQUEADO</h5></asp:Label>
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
            </section>
        </div>

    </div>

</asp:Content>
