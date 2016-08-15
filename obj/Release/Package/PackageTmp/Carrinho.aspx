<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrinho.aspx.cs" Inherits="WebFormsStore.Carrinho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="TituloCarrinho" runat="server" class="ContentHead">
        <h1>Seu Carrinho</h1>
    </div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="WebFormsStore.Models.ItemCarrinho" SelectMethod="GetShoppingCartItems"
        CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="ProdutoID" HeaderText="ID" SortExpression="ProdutoID" />
            <asp:BoundField DataField="Produto.ProdutoNome" HeaderText="Nome" />
            <asp:BoundField DataField="Produto.PrecoUnitario" HeaderText="Preço" DataFormatString="{0:c}" />
            <asp:TemplateField HeaderText="Quantidade">
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantidade %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total do Item">
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantidade)) *  Convert.ToDouble(Item.Produto.PrecoUnitario)))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remover">
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <div>


            <div>
                <p></p>
                                <strong>
                                    <asp:Label ID="LabelTotalText" runat="server" Text="Total: "></asp:Label>
                                    <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
                                </strong>
                <br /><p></p>
                <table>
                    <tr>
                        <td>
                            <div style="float: right">

                                


                                <asp:LinkButton ID="UpdateBtn" CssClass="btn btn-primary" runat="server" Text="Atualizar" OnClick="UpdateBtn_Click"></asp:LinkButton>&nbsp;&nbsp;
                                <%--<asp:Button ID="UpdateBtn" runat="server" Text="Atualizar" OnClick="UpdateBtn_Click" />--%>
                            </div>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" Text="Finalizar Compra" OnClick="FinalizarCompra"></asp:LinkButton>
                            <asp:Label ID="labelConectar" runat="server" Visible="false" Text="Entre ou registre-se para finalizar a compra."></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <br />
    <div id="CarrinhoVazio" runat="server"></div>


</asp:Content>
