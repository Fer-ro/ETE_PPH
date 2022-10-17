<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Reportes_Detalle_FR.aspx.cs" Inherits="ETE_PPH.GestionTickets.Reportes_Detalle_FR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="../../jqwidgets/styles/jqx.base.css" type="text/css" />
    <link rel="stylesheet" href="../../jqwidgets/styles/jqx.classic.css" type="text/css" />

    <meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />	
    <script type="text/javascript" src="../JQ/scripts/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxdraw.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxchart.core.js"></script>
       <script type="text/javascript" src="../JQ/jqwidgets/jqxchart.js"></script>
    <script type="text/javascript" src="../JQ/scripts/demos.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxdata.js"></script>

   <script type="text/javascript">
       $(document).ready(function () {
         
         

       });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h2>Reportes - Resumen</h2>
    <br />   
    <div class="row">
        <div class="col-6">
            <div id="jqxChart_Tiempo_Mensual" style="width: auto; height: 400px;"></div>
        </div>
        <div class="col-6">
            <div id="jqxChart_Tiempo_Semanal" style="width: auto; height: 400px;"></div>
        </div>
    </div>
     <div class="row">
        <div class="col-12">
            
        </div>       
    </div>
 

</asp:Content>
