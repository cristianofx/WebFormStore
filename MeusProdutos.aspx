<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MeusProdutos.aspx.cs" Inherits="WebFormsStore.MeusProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


        <div>
        <section>
            <div>
                <hgroup>
                    <h2>Meus Produtos:</h2>
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
                                        <div runat="server" visible="<%# !Item.desistiu && !Item.vendido && !Item.bloqueado && Item.DataExpiracao > DateTime.Now.AddDays(-1) ? true : false %>">
                                            <a href="/EditarProduto.aspx?productID=<%#:Item.ProdutoID %>">
                                                <span class="ProductListItem">
                                                    <b>Editar Produto<b>
                                                </span>
                                            </a>
                                        </div>
                                        <asp:Label ID="LabelVendido" runat="server" Visible="<%# Item.vendido ? true : false %>"><h5>VENDIDO</h5></asp:Label>
                                        <asp:Label ID="LabelBloqueado" runat="server" Visible="<%# Item.bloqueado || Item.desistiu || Item.DataExpiracao < DateTime.Now.AddDays(-1) ? true : false %>"><h5>BLOQUEADO</h5></asp:Label>
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



</asp:Content>
