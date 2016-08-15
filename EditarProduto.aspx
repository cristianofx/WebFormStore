<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarProduto.aspx.cs" Inherits="WebFormsStore.EditarProduto" ResponseEncoding="utf-8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="Scripts/jquery.price_format.2.0.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.precoBox').priceFormat({
                prefix: 'R$ ',
                centsSeparator: ',',
                thousandsSeparator: '.',
                limit: 10
            });
        });
    </script>

    <br />

    <div class="row">
        <div class="col-md-1" style="margin-top: 13px">
            <img src="#" id="imagemUrl" style="border: solid; height: 170px; width: 170px" alt="" runat="server" />
            <b style="font-size: medium; float: left; font-style: normal">&nbsp;
                        <asp:FileUpload ID="FileUploadControl" runat="server" />

                <asp:Label runat="server" ID="StatusLabel" Text="" />
            </b>
            <div class="col-md-4" style="width: auto; margin-top: -15px">
            </div>
        </div>
        <div class="col-md-offset-1 col-md-3" style="margin-left: 100px">
            <h4>Editar nome do produto</h4>
            <asp:TextBox ID="nome" runat="server" Text=""></asp:TextBox>
            <%--<%#:Item.ProdutoNome.ToString() %>--%>
            <br />
            <h4>Editar Descrição</h4>

            <asp:TextBox ID="descricao" Text="" Width="450px" runat="server" Height="100px" TextMode="MultiLine" Style="resize: none"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="descricao"
                CssClass="text-danger" ErrorMessage="Por favor, digite uma descrição do produto." />

        </div>
        <div class="col-md-offset-2" style="margin-top: -18px">
            <br />
            <h4>Categoria</h4>
            <asp:DropDownList ID="DropDownList1" CssClass="btn btn-primary dropdown-toggle" runat="server" DataTextField="CategoriaNome" DataValueField="CategoriaID" SelectMethod="GetCategories">
            </asp:DropDownList>
        </div>

        <div class="col-md-offset-2 col-md-5">
            <asp:Panel ID="panel" runat="server">
                <h4>Responder perguntas:</h4>


            </asp:Panel>


        </div>

    </div>

    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-offset-1 col-md-4">
            <span><b>Editar Preço:</b>&nbsp;
                            <asp:TextBox ID="preco" CssClass="precoBox" runat="server" Text="" AutoPostBack="true"></asp:TextBox></span><br />
            <span><b>Data Expiração:</b>&nbsp;<asp:Label ID="dataExpiracao" runat="server" Text=""></asp:Label></span><br />
            <br />

            <div runat="server" id="vendidoOuBloqueadoBotaoEditar" visible="true">
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="editarProduto" Text="Salvar" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
            <div runat="server" id="vendidoOuBloqueadoBotaoCancelar" visible="true">
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10" style="margin-top: 15px">
                        <asp:Button ID="botao_cancelar" runat="server" OnClick="cancelarProduto" Text="Bloquear venda" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <table>
        <tr>
            <td>&nbsp;</td>
            <td style="vertical-align: top; text-align: center;">
                <asp:Label ID="LabelVendido" runat="server" Visible="false"><div class="alert alert-dismissible alert-danger"><h4>VENDIDO</h4></div></asp:Label>
                <asp:Label ID="LabelBloqueado" runat="server" Visible="false"><div class="alert alert-dismissible alert-danger"><h4>BLOQUEADO</h4></div></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

</asp:Content>
