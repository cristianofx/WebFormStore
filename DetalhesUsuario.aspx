<%@ Page Title="Detalhes do Usuário" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalhesUsuario.aspx.cs" Inherits="WebFormsStore.DetalhesUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="painel" runat="server" visible="false" style="text-align:center">

        <div class="row" style="text-align: center">
            <h1><%: Title %></h1>
        </div>

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


        <asp:FormView ID="Endereco" runat="server" style="text-align:center" ItemType="WebFormsStore.Models.Endereco" SelectMethod="getEndereco" RenderOuterTable="false">
            <ItemTemplate>
                <br />
                <table>
                    <tr>
                        <td>&nbsp;</td>
                        <td style="vertical-align: top; text-align: left;">
                            <b>Rua: </b>
                            <%# Item.Rua %>
                            <br />
                            <b>Número:</b>
                            <%#:Item.Numero %>
                            <br />
                            <b>Complemento: </b>
                            <%# Item.Complemento %>
                            <br />
                            <b>CEP: </b>
                            <%# Item.Cep %>
                            <br />
                            <b>Bairro: </b>
                            <%# Item.Bairro %>
                            <br />
                            <b>Cidade: </b>
                            <%# Item.Cidade %>
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
        </asp:FormView>

        <hr />

        <div class="row">
            <div style="text-align: center">
                <h3>Detalhes de venda do usuário</h3>
            </div>
            <div class="row" style="text-align:center">
                <asp:Label ID="Label1" runat="server" Text="Quantidade de Produtos a venda deste usuário: "></asp:Label>
                <asp:Label ID="quantidadeProdutos" runat="server" Text=""></asp:Label>
            </div>

            <div class="row" style="text-align:center">
                <asp:Label ID="Label2" runat="server" Text="Valor total de produtos a venda: R$ "></asp:Label>
                <asp:Label ID="TotalOfertado" runat="server" Text=""></asp:Label>
            </div>

        </div>
        <hr />

        <div class="row">

            <br />
            <asp:GridView ID="GridView1"
                
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
                    <asp:BoundField DataField="ProdutoNome" HeaderText="Produto" ReadOnly="True">
                        <ItemStyle Width="400px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PerguntaFeita" HeaderText="Pergunta" ReadOnly="True">
                        <ItemStyle Width="400px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Resposta" HeaderText="Resposta" ReadOnly="True">
                        <ItemStyle Width="400px"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>

        </div>
    </div>

</asp:Content>
