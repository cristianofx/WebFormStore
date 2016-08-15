<%@ Page Title="Detalhes do Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DetalhesProduto.aspx.cs" Inherits="WebFormsStore.DetalhesProduto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div>
        <div style="width: 100%; text-align: center">
            <input type="text" name="textoSearch" size="15" runat="server" />
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

    <div  class="row" runat="server" visible="true">
        <asp:Button ID="Apagar" Visible="false" class="btn btn-primary btn-sm" runat="server" Text="Apagar produto" OnClick="apagarProduto" OnClientClick="return confirm('Você quer apagar permanentemente este produto?')"  />

    </div>

    <asp:FormView ID="productDetail" runat="server" ItemType="WebFormsStore.Models.Produto" SelectMethod="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ProdutoNome %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="<%#:Item.ImagePath %>" style="border: solid; height: 300px" alt="<%#:Item.ProdutoNome %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <b>Vendedor: <%# Item.emailUser %> </b><br />
                        <asp:Label ID="nomeVendedor" runat="server" Text=""></asp:Label>
                        <br />
                        <b>Descrição:</b><br />
                        <%#:Item.Descricao %>
                        <br />
                        <span><b>Preço:</b>&nbsp;<%#: String.Format("{0:c}", Item.PrecoUnitario) %></span><br />
                        <span><b>Número do Produto:</b>&nbsp;<%#:Item.ProdutoID %></span><br />
                        <span><b>Data Expiração:</b>&nbsp;<%#:Item.DataExpiracao != null ? Item.DataExpiracao.Value.ToShortDateString() : "Sem data de expiração" %></span><br />
                        <br />
                        <div runat="server" visible="<%# !Item.vendido && !Item.bloqueado ? true : false %>">
                            <a href="/AdicionarAoCarrinho.aspx?productID=<%#:Item.ProdutoID %>">
                                <span class="ProductListItem">
                                    <b>Adicionar ao Carrinho<b>
                                </span>
                            </a>
                        </div>
                        <asp:Label ID="LabelVendido" runat="server" Visible="<%# Item.vendido ? true : false %>"><div class="alert alert-dismissible alert-danger"><h5>VENDIDO</h5></div></asp:Label>
                        <asp:Label ID="LabelBloqueado" runat="server" Visible="<%# Item.bloqueado ? true : false %>"><div class="alert alert-dismissible alert-danger"><h5>BLOQUEADO</h5></div></asp:Label>
                    </td>
                </tr>
            </table>
            <br />

        </ItemTemplate>


    </asp:FormView>



    <div style="width: 100%; text-align: center">
        <asp:LoginView ID="viewLoged" runat="server" ViewStateMode="Disabled">
            <LoggedInTemplate>
                <div>
                    <h5>Faça uma pergunta ao vendedor:</h5>
                    <asp:TextBox ID="txtPergunta" runat="server"></asp:TextBox>
                    <asp:Button ID="Button3" class="btn btn-primary btn-sm" runat="server" Text="Perguntar" OnClick="SetPergunta" />
                </div>
            </LoggedInTemplate>
        </asp:LoginView>
        <br />
        <asp:GridView ID="GridView1"
            ItemType="WebFormsStore.Models.Pergunta"
            runat="server"
            AutoGenerateColumns="False"
            SelectMethod="GetPerguntas">
            <%--                    <EmptyDataTemplate>
                        <div style="width: 100%; text-align: center">
                            <table>
                                <tr>
                                    <td>Nenhuma pergunta feita a esse vendedor.</td>
                                </tr>
                            </table>
                        </div>
                    </EmptyDataTemplate>--%>
            <Columns>
                <asp:BoundField DataField="PerguntaFeita" HeaderText="Pergunta" ReadOnly="True">
                    <ItemStyle Width="400px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Resposta" HeaderText="Resposta" ReadOnly="True">
                    <ItemStyle Width="400px"></ItemStyle>
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


