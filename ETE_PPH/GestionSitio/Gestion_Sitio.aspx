<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Gestion_Sitio.aspx.cs" Inherits="ETE_PPH.GestionSitio.Gestion_Sitio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <h5 class="card-header">Agregar nueva pagina</h5>
        <div class="card-body">

            <asp:GridView ID="GV_Paginas" class="table table-hover table-responsive" runat="server"></asp:GridView>

            <br />
            Nombre de pagina: <asp:TextBox ID="TXT_NombrePagina" runat="server"></asp:TextBox>
            Ruta de la pagina: <asp:TextBox ID="TXT_Direccion" runat="server"></asp:TextBox>
            Nombre en menu: <asp:TextBox ID="TXT_NivelAcceso" runat="server"></asp:TextBox>

            <asp:Button ID="BTN_GuardarPagina" OnClick="BTN_GuardarPagina_Click" runat="server" Text="Guardar pagina" />
        </div>
    </div>

</asp:Content>
