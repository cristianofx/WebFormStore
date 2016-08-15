<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebFormsStore.Admin.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <ul class="list-group">
            <li class="list-group-item">
                <asp:Label ID="Label1" runat="server" Text="Numero de Ítens Anunciados:" Font-Names="Arial Black"></asp:Label>
                &nbsp;<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                &nbsp;
            </li>
            <%--    </ul>
    
    <ul>--%>
            <li class="list-group-item">
                <asp:Label ID="Label2" runat="server" Text="Ítens Bloqueados por Término da Validade" Font-Names="Arial Black"></asp:Label>
                :
    
    <asp:Label ID="Validade" runat="server" Text="Label"></asp:Label>

            </li>

            <%--    </ul>

    <ul>--%>
            <li class="list-group-item">
                <asp:Label ID="Label3" runat="server" Text="Ítens por Desistência do Vendedor" Font-Names="Arial Black"></asp:Label>
                :
        <asp:Label ID="Desistencia" runat="server" Text="Label"></asp:Label>
            </li>
            <%--    </ul>

    <ul>--%>
            <li class="list-group-item">
                <asp:Label ID="Label4" runat="server" Text="Ítens Vendidos" Font-Names="Arial Black"></asp:Label>
                :
        <asp:Label ID="Vendidos" runat="server" Text="Label"></asp:Label>
            </li>
            <%--   </ul>
    
    <ul>--%>
            <li class="list-group-item">
                <asp:Label ID="Vendedores" runat="server" Text="Número de Vendedores:" Font-Names="Arial Black"></asp:Label>
                &nbsp;<asp:Label ID="NumVendedores" runat="server" Text="Label"></asp:Label></>
            </li>


            <li class="list-group-item">
                <asp:Label ID="Expirados" runat="server" Text="Número de produtos expirados:" Font-Names="Arial Black"></asp:Label>
                &nbsp;<asp:Label ID="ExpiradosLabel" runat="server" Text=""></asp:Label></>
            </li>

        </ul>
        <br />
        <br />
    </div>


    <section>
        <div>
            <label>Usuários: </label>
        </div>
        <div>


            <asp:DropDownList ID="Usuarios" CssClass="btn btn-primary dropdown-toggle"
                runat="server" DataTextField="Nome" DataValueField="UsuarioID"
                SelectMethod="getUsuarios" Width="141px" AppendDataBoundItems="True"
                OnSelectedIndexChanged="loadDetalhesUsuario" AutoPostBack="true">
                <asp:ListItem Text="" Selected="True"></asp:ListItem>
            </asp:DropDownList>



            <br />
            <br />



            <asp:ListView ID="ListView" runat="server"
                DataKeyNames="ProdutoID" GroupItemCount="4"
                ItemType="WebFormsStore.Models.Produto" SelectMethod="getProdutosBloqueados">
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

    <section>
        <div>


            <asp:ListView ID="ListView1" runat="server"
                DataKeyNames="ProdutoID" GroupItemCount="4"
                ItemType="WebFormsStore.Models.Produto" SelectMethod="getDesistiu">
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
                                    </div>
                                    <asp:Label ID="LabelBloqueado" runat="server" Visible="<%# Item.desistiu ? true : false %>"><h5>DESISTIU</h5></asp:Label>
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

    <section>
        <div>

            <asp:ListView ID="ListView2" runat="server"
                DataKeyNames="ProdutoID" GroupItemCount="4"
                ItemType="WebFormsStore.Models.Produto" SelectMethod="getVendidos">
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


