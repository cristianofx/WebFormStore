<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Procura.aspx.cs" Inherits="WebFormsStore.Procura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>

        
        <div style="float: left">
            <b style="font-size: small; font-style: normal">Procurar por Faixa de Preço<br />
            </b>
            <asp:DropDownList ID="precos" CssClass="btn btn-primary dropdown-toggle" runat="server"
                OnSelectedIndexChanged="procuraPorFaixaDepreco" AutoPostBack="True" AppendDataBoundItems="True">
                <asp:ListItem Text="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Menos de 10 reais"></asp:ListItem>
                <asp:ListItem Text="Entre 10 e 100 reais"></asp:ListItem>
                <asp:ListItem Text="Entre 100 e 1000 reais"></asp:ListItem>
                <asp:ListItem Text="Mais de 1000 reais"></asp:ListItem>
            </asp:DropDownList>

        </div>

        <div style="width: 80%; text-align: center">
            <input type="text" name="textoSearch" size="15" />
            <input type="button" class="btn btn-primary btn-sm" value="Procurar"
                onclick="window.location = 'Procura.aspx?search=' + this.form.textoSearch.value">
        </div>
        <div>
        </div>
    </div>
    <div id="CategoryMenu" style="text-align: center">
        <br />
        <b style="font-size: large; font-style: normal">Categorias<br />
        </b>
        <br />

        <b style="font-size: large; font-style: normal">
            <a href="/ListaProdutos.aspx" class="btn btn-primary">Todos</a>
        </b>

        <asp:ListView ID="categoryList"
            ItemType="WebFormsStore.Models.Categoria"
            runat="server"
            SelectMethod="GetCategories">
            <ItemTemplate>
                <b style="font-size: large; font-style: normal">
                    <a href="/ListaProdutos.aspx?id=<%#: Item.CategoriaID %>" class="btn btn-primary">
                        <%#: Item.CategoriaNome %>
                    </a>
                </b>
            </ItemTemplate>
            <ItemSeparatorTemplate></ItemSeparatorTemplate>
        </asp:ListView>
    </div>


    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="productList" runat="server"
                DataKeyNames="ProdutoID" GroupItemCount="4"
                ItemType="WebFormsStore.Models.Produto" SelectMethod="GetSearch">
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
                                        <a href="/AdicionarAoCarrinho.aspx?productID=<%#:Item.ProdutoID %>">
                                            <span class="ProductListItem">
                                                <b>Adicionar ao Carrinho<b>
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


</asp:Content>
