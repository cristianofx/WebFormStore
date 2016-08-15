<%@ Page Title="AdicionarProduto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AdicionarProduto.aspx.cs" Inherits="WebFormsStore.AdicionarProduto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/jquery.price_format.2.0.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.preco2').priceFormat({
                prefix: 'R$ ',
                centsSeparator: ',',
                thousandsSeparator: '.',
                limit: 10
            });
        });
    </script>

    <div>
        <div style="text-align: center">
            <h1>Adicione um novo produto</h1>
        </div>
        <br />

        <div class="row">
            <div class="col-md-4" style="width: auto; margin-top: -5px">
                <h4>Nome do Produto: </h4>
            </div>
            <div class="col-md-4" style="width: auto">
                <div class="form-group">
                    <asp:TextBox ID="NomeProduto" Width="250px" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NomeProduto"
                        CssClass="text-danger" ErrorMessage="Por favor, digite o nome do produto." />
                </div>

            </div>



            <div class="col-md-1" style="width: auto; margin-top: -5px">
                <h4>Preço: </h4>
            </div>
            <div style="float: left">

                <asp:TextBox ID="preco" class="preco2" Width="150px" runat="server" Style="text-align: right"></asp:TextBox><br />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="preco"
                    CssClass="text-danger" ErrorMessage="Digite o preço do produto." /><br />
            </div>


            <div class="col-md-4" style="width: auto; margin-top: -15px">
                <h4>Categoria 

            <asp:DropDownList ID="DropDownList1" CssClass="btn btn-primary dropdown-toggle" runat="server" DataTextField="CategoriaNome" DataValueField="CategoriaID" SelectMethod="GetCategories">
            </asp:DropDownList>

                </h4>
            </div>

            <br />
        </div>




        <div class="row">
            <div style="float: left; width: auto; margin-top: -5px">
                <h4>Descrição do Produto: </h4>
            </div>
            <div style="float: left; padding: 5px">
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="descricao" Width="550px" runat="server" Height="150px" TextMode="MultiLine" Style="resize: none"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="descricao"
                    CssClass="text-danger" ErrorMessage="Por favor, digite uma descrição do produto." />
            </div>
        </div>

        <div>
            <div style="float: left; padding: 5px">
                &nbsp;&nbsp;&nbsp;
               
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-md-3" style="width: auto">
            <h4>Data Limite: </h4>
            &nbsp;&nbsp;&nbsp;
        </div>

<%--        <asp:CustomValidator ID="Validator" runat="server" ErrorMessage="Necessário escolher uma data limite."
            ClientValidationFunction="Validate" />--%>
                &nbsp;&nbsp;&nbsp;
        <div style="float: left; width: auto">
            <asp:Calendar ID="Calendar1" runat="server" Font-Size="Small"></asp:Calendar>
            <br />
            <asp:CustomValidator ID="cvCaltest" runat="server" ErrorMessage="Por favor, escolha uma data válida."
                ValidationGroup="vgCaltest"></asp:CustomValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3" style="width: auto">
            <h4>Adicionar Imagem: </h4>
        </div>
        <div class="col-md-5" style="margin-top: -17px">
            <b style="font-size: large; float: left; font-style: normal">&nbsp;
            <asp:FileUpload ID="FileUploadControl" runat="server" />
                <%--<asp:Button runat="server" id="UploadButton" class="btn btn-primary" Text="Enviar Imagem" onclick="UploadButton_Click" />--%>
            &nbsp;<asp:Label runat="server" ID="StatusLabel" Text="" />
            </b>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2" style="margin-top: 10px">
            <asp:Button runat="server" ID="UploadButton" class="btn btn-primary" Text="Cadastrar" OnClick="enviar" />
        </div>
    </div>

</asp:Content>
