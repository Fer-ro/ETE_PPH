<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ETE_PPH.ETE.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="BTN_Exportar" OnClick="BTN_Exportar_Click" runat="server" Text="Exportar a Excel" />
</asp:Content>
