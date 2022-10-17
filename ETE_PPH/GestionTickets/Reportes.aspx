<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ETE_PPH.GestionTickets.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="../../jqwidgets/styles/jqx.base.css" type="text/css" />
    <link rel="stylesheet" href="../../jqwidgets/styles/jqx.classic.css" type="text/css" />

    <meta name="viewport" content="width=device-width, initial-scale=1 maximum-scale=1 minimum-scale=1" />	

   
    <script type="text/javascript" src="../JQ/jqwidgets/jqxchart.core.js"></script>
       <script type="text/javascript" src="../JQ/jqwidgets/jqxchart.js"></script>
   <link rel="stylesheet" href="../JQ/jqwidgets/styles/jqx.base.css" type="text/css"/>
    <link rel="stylesheet" href="../JQ/jqwidgets/styles/jqx.summer.css" type="text/css"/>
     <link rel="stylesheet" href="../JQ/jqwidgets/styles/jqx.energyblue.css" type="text/css"/> 
    <script type="text/javascript" src="../JQ/jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxtabs.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxdatetimeinput.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqx-all.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxcalendar.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxtextarea.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxtooltip.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/globalization/globalize.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxcore.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxbuttons.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxscrollbar.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxdata.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxdate.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxscheduler.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxscheduler.api.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxdatetimeinput.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxmenu.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxcalendar.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxtooltip.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxwindow.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxcheckbox.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxlistbox.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxdropdownlist.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxnumberinput.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxradiobutton.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/jqxinput.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/globalization/globalize.js"></script>
    <script type="text/javascript" src="../JQ/jqwidgets/globalization/globalize.culture.de-DE.js"></script>
   
    <script type="text/javascript" src="../JQ/jqwidgets/jqxdata.export.js"></script> 
    <script type="text/javascript" src="../JQ/jqwidgets/jqxgrid.export.js"></script> 

   <script type="text/javascript">
  

       function LlenarDDL_lineas() {          
           $.ajax({
               type: 'POST',
               url: 'Reportes.aspx/GetLineas',
               contentType: 'application/json; charset=utf-8',
               data: "{}",
               async: false,
               dataType: 'json', 
               success: function (data) {
                   var obj = data.d;
                   var source =
                   {                      
                      datatype: "json",
                      datafields: [
                          { name: 'Nombre', type: 'string'},
                          { name: 'ID_Linea', type: 'string' }
                       ],
                      localdata: obj
                   };
                   var dataAdapter = new $.jqx.dataAdapter(source);
                   // Create a jqxDropDownList
                   $("#jqxDDL_Linea").jqxDropDownList({
                       selectedIndex: 0, source: dataAdapter, displayMember: 'Nombre', valueMember: 'ID_Linea', width: 200, height: 30,
                   });
                   
               },
               error: function (err) {
                   alert('Error');
               }
           });         
       }

       function LlenarDDL_Celdas(Linea) {
           ////-----------------TIEMPOS--------------------------
           
           $.ajax({
               type: 'POST',
               dataType: 'json',
               async: false,
               url: 'Reportes.aspx/GetCeldas',
               data: '{ "ID_Linea":"' + Linea+ '"}',
               cache: false,
               contentType: 'application/json; charset=utf-8',
               success: function (data) {
                   var source =
                   {
                       localdata: data.d,
                       datafields: [
                           { name: 'Nom_Celda' },
                           { name: 'ID_Celda' }
                       ],
                       datatype: "json",
                       async: false
                   };
                   var dataAdapter = new $.jqx.dataAdapter(source);
                   // Create a jqxDropDownList
                   $("#jqxDDL_Celda").jqxDropDownList({
                       selectedIndex: 0, source: dataAdapter, displayMember: "Nom_Celda", valueMember: "ID_Celda", width: 200, height: 30,
                   });
               },
               error: function (err) {
                   alert(err.data);
               }
           });
         
       }

       function Top5(Linea,Celda) {
           var source = {};
           $.ajax({
               type: 'POST',
               dataType: 'json',
               async: false,
               url: 'Reportes.aspx/GetData',
               cache: false,
               data: '{ "FechaInicial":"' + $('#dateInput_Inicial').val() + '", "FechaFinal":"' + $('#dateInput_Final').val() + '", "ID_Linea":"' + Linea + '", "ID_Celda":"' + Celda +'" }',
               contentType: 'application/json; charset=utf-8',
               success: function (data) {
                   source = $.parseJSON(data.d);
               },
               error: function (err) {
                   alert('Error');
               }
           });
           // prepare jqxChart settings
           var settings = {
               title: "Top 5 Fallas",
               description: "",
               showLegend: true,
               padding: { left: 5, top: 5, right: 5, bottom: 5 },
               titlePadding: { left: 90, top: 0, right: 0, bottom: 10 },
               source: source,
               categoryAxis:
               {
                   dataField: 'FALLA',
                   unitInterval: 1,
                   showGridLines: true
               },
               colorScheme: 'scheme01',
               seriesGroups:
                   [
                       {
                           type: 'column',
                           columnsGapPercent: 50,
                           seriesGapPercent: 0,
                           valueAxis:
                           {
                               unitInterval: 10,
                               minValue: 0,
                               maxValue: 100,
                               valuesOnTicks: false,
                               displayValueAxis: true,
                               description: 'Total de fallas',
                               axisSize: 'auto',
                               tickMarksColor: '#888888'
                           },
                           series: [
                               {
                                   dataField: 'INCIDENCIAS', displayText: 'INCIDENCIAS',
                                   labelRadius: 190,
                                   radius: 170,
                                   labels: {
                                       visible: true,
                                       verticalAlignment: 'top',
                                       offset: { x: 0, y: -20 }
                                   }
                               }

                           ]
                       }
                   ]
           };
           $('#jqxChart').jqxChart(settings);
       }

       function Tiempos(Linea,Celda) {
           ////-----------------TIEMPOS--------------------------
           var source_tiempo = {};
           $.ajax({
               type: 'POST',
               dataType: 'json',
               async: false,
               url: 'Reportes.aspx/GetData_Tiempos',
               data: '{ "FechaInicial":"' + $('#dateInput_Inicial').val() + '", "FechaFinal":"' + $('#dateInput_Final').val() + '", "ID_Linea":"' + Linea + '"  , "ID_Celda":"' + Celda +'"  }',
               cache: false,
               contentType: 'application/json; charset=utf-8',
               success: function (data) {
                   source_tiempo = $.parseJSON(data.d);
               },
               error: function (err) {
                   alert(err.data);
               }
           });
           // prepare jqxChart settings
           var settings = {
               title: "Top 5 Fallas con mayor tiempo de paro de linea",
               description: "",
               showLegend: true,
               padding: { left: 5, top: 5, right: 5, bottom: 5 },
               titlePadding: { left: 90, top: 0, right: 0, bottom: 10 },
               source: source_tiempo,
               categoryAxis:
               {
                   dataField: 'FALLA',
                   unitInterval: 1,
                   showGridLines: true
               },
               colorScheme: 'scheme01',
               seriesGroups:
                   [
                       {
                           type: 'column',
                           columnsGapPercent: 50,
                           seriesGapPercent: 0,
                           valueAxis:
                           {
                               unitInterval: 10,
                               minValue: 0,
                               valuesOnTicks: false,
                               maxValue: 100,
                               displayValueAxis: true,
                               description: 'Total minutos',
                               axisSize: 'auto',
                               tickMarksColor: '#888888'
                           },
                           series: [
                               {
                                   dataField: 'MINUTOS', displayText: 'INCIDENCIAS', labels: {
                                       visible: true,
                                       labelsAngle: 90,
                                       labelRadius: 190,
                                       radius: 170,
                                       verticalAlignment: 'top',
                                       offset: { x: 0, y: -20 }
                                   }
                               }

                           ]
                       }
                   ]
           };
           $('#jqxChart_tiempos').jqxChart(settings);
       }

      

       function MinutosMensuales() {
           ////----------------MINUTOS MENSUAL---------------------------
           var source_tiempo = {};
           $.ajax({
               type: 'GET',
               dataType: 'json',
               async: false,
               url: 'Reportes_Detalle_FR.aspx/GetData_Top_Minutos_Mensual',
               cache: false,
               contentType: 'application/json; charset=utf-8',
               success: function (data) {
                   source_tiempo = $.parseJSON(data.d);
               },
               error: function (err) {
                   alert('Error');
               }
           });
           // prepare jqxChart settings
           var settings = {
               title: "TOTAL MINUTOS - PAROS MENSUAL",
               description: "",
               showLegend: true,
               padding: { left: 5, top: 5, right: 5, bottom: 5 },
               titlePadding: { left: 90, top: 0, right: 0, bottom: 10 },
               source: source_tiempo,
               categoryAxis:
               {
                   dataField: 'MES',
                   showGridLines: true
               },
               colorScheme: 'scheme01',
               seriesGroups:
                   [
                       {
                           type: 'column',
                           columnsGapPercent: 50,
                           seriesGapPercent: 0,
                           valueAxis:
                           {
                               unitInterval: 200,
                               minValue: 0,
                               maxValue: 2000,
                               displayValueAxis: true,
                               description: 'Total minutos',
                               axisSize: 'auto',
                               tickMarksColor: '#888888'
                           },
                           series: [
                               {

                                   dataField: 'MINUTOS', displayText: 'MINUTOS', labels: {
                                       visible: true,
                                       verticalAlignment: 'top',
                                       offset: { x: 0, y: -20 }
                                   }
                               }
                           ]
                       }
                   ]
           };
           $('#jqxChart_Tiempo_Mensual').jqxChart(settings);
       }

       function MinutosSemanal() {
           ////----------------MINUTOS Semanal---------------------------
           var source_tiempo = {};
           $.ajax({
               type: 'GET',
               dataType: 'json',
               async: false,
               url: 'Reportes_Detalle_FR.aspx/GetData_Top_Minutos_Semanal',
               cache: false,
               contentType: 'application/json; charset=utf-8',
               success: function (data) {
                   source_tiempo = $.parseJSON(data.d);
               },
               error: function (err) {
                   alert('Error');
               }
           });
           // prepare jqxChart settings
           var settings = {
               title: "TOTAL MINUTOS POR SEMANA - PAROS POR SEMANA",
               description: "",
               showLegend: true,
               padding: { left: 5, top: 5, right: 5, bottom: 5 },
               titlePadding: { left: 90, top: 0, right: 0, bottom: 10 },
               source: source_tiempo,
               categoryAxis:
               {
                   dataField: 'SEMANA',
                   showGridLines: true
               },
               colorScheme: 'scheme01',
               seriesGroups:
                   [
                       {
                           type: 'column',
                           columnsGapPercent: 50,
                           seriesGapPercent: 0,
                           valueAxis:
                           {
                               unitInterval: 200,
                               minValue: 0,
                               maxValue: 2000,
                               displayValueAxis: true,
                               description: 'Total minutos',
                               axisSize: 'auto',
                               tickMarksColor: '#888888'
                           },
                           series: [
                               {

                                   dataField: 'MINUTOS', displayText: 'MINUTOS', labels: {
                                       visible: true,
                                       verticalAlignment: 'top',
                                       offset: { x: 0, y: -20 }
                                   }
                               }
                           ]
                       }
                   ]
           };
           $('#jqxChart_Tiempo_Semanal').jqxChart(settings);
       }

       function Paros_Totales() {
           ////----------------Paros periodo---------------------------
           var source = {};
           $.ajax({
               type: 'POST',
               dataType: 'json',
               async: false,
               url: 'Reportes.aspx/GetParosTotales',
               cache: false,
               data: '{ "Mes":"' + 6 + '", "Periodo":"' + 2021 + '"}', 
               contentType: 'application/json; charset=utf-8',
               success: function (data) {
                   source = $.parseJSON(data.d);
               },
               error: function (err) {
                   alert('Error');
               }
           });
           // prepare jqxChart settings
           var settings = {
               title: "Paros totales por linea",
               description: "",
               showLegend: true,
               padding: { left: 5, top: 5, right: 5, bottom: 5 },
               titlePadding: { left: 90, top: 0, right: 0, bottom: 10 },
               source: source,
               categoryAxis:
               {
                   dataField: 'Linea',
                   unitInterval: 1,
                   showGridLines: true
               },
               colorScheme: 'scheme01',
               seriesGroups:
                   [
                       {
                           type: 'column',
                           columnsGapPercent: 50,
                           seriesGapPercent: 0,
                           valueAxis:
                           {
                               unitInterval: 10,
                               minValue: 0,
                               maxValue: 100,
                               valuesOnTicks: false,
                               displayValueAxis: true,
                               description: 'Total de fallas',
                               axisSize: 'auto',
                               tickMarksColor: '#888888'
                           },
                           series: [
                               {
                                   dataField: 'INCIDENCIAS', displayText: 'INCIDENCIAS',
                                   labelRadius: 190,
                                   radius: 170,
                                   labels: {
                                       visible: true,
                                       verticalAlignment: 'top',
                                       offset: { x: 0, y: -20 }
                                   }
                               }

                           ]
                       }
                   ]
           };
           $('#jqxChart_ParosTotales').jqxChart(settings);
           
       }

       $(document).ready(function () {

           // init widgets.
           var initWidgets = function (tab) {
               switch (tab) {
                   case 1:
                       
                       break;
                   case 2:
                       
                       break;
               }
           }
           $('#jqxTabs').jqxTabs({  height: '100%', initTabContent: initWidgets });
           MinutosMensuales();
           MinutosSemanal();
           Paros_Totales();
           //llenamos ddl lineas
           LlenarDDL_lineas();
           LlenarDDL_Celdas(3);
           // Create a jqxDateTimeInput
           $("#dateInput_Inicial").jqxDateTimeInput({ width: '150px', height: '25px', formatString: "yyyy-MM-dd" });
           $("#dateInput_Final").jqxDateTimeInput({ width: '150px', height: '25px', formatString: "yyyy-MM-dd" });
           //
           $("#BTN_aplicar_Filtros").click(function () {
               AplicarFiltro_Acumulado();
           });
          
           function AplicarFiltro_Acumulado() {
               var Linea = $("#jqxDDL_Linea").jqxDropDownList('val');
               var Celda = $("#jqxDDL_Celda").jqxDropDownList('val');
               Top5(Linea, Celda);
               Tiempos(Linea, Celda);
               MTTR(Linea);
                
           }

           $('#jqxDDL_Linea').on('select', function (event) {
               var args = event.args;
               if (args) {
                   // index represents the item's index.                
                   var index = args.index;
                   var item = args.item;
                   // get item's label and value.
                   var label = item.label;
                   var value = item.value;
                    LlenarDDL_Celdas(value);
                   var type = args.type; // keyboard, mouse or null depending on how the item was selected.
               }
           });
       });
   </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id='jqxWidget'>
        <div id='jqxTabs'>
            <ul>
                <li style="margin-left: 30px;">
                    <div style="height: 20px; margin-top: 5px;">
                        <div style="float: left;">
                            <img width="16" height="16" src="../JQ/images/catalogicon.png" />
                        </div>
                        <div style="margin-left: 4px; vertical-align: middle; text-align: center; float: left;">
                            Paros de Lineas
                        </div>
                    </div>
                </li>
                <li>
                    <div style="height: 20px; margin-top: 5px;">
                        <div style="float: left;">
                            <img width="16" height="16" src="../JQ/images/pieicon.png" />
                        </div>
                        <div style="margin-left: 4px; vertical-align: middle; text-align: center; float: left;">
                            Reporte por Linea
                        </div>
                    </div>
                </li>
            </ul>
            <div style="overflow: hidden; margin: 25px">
                <h2>Paros Totales por linea </h2>
                <div id="jqxChart_ParosTotales" style="width: auto; height: 400px;"></div>
                <br />
                <hr />
                  <br />
                <h2>Minutos de paro Mensuales y Semanales </h2>
                <div class="row">
                    <div class="col-6">
                        <div id="jqxChart_Tiempo_Mensual" style="width: auto; height: 400px;"></div>
                    </div>
                    <div class="col-6">
                        <div id="jqxChart_Tiempo_Semanal" style="width: auto; height: 400px;"></div>
                    </div>
                </div>
                 <br />
                  <hr />
                 <br />
                <h2>Reportes de fallas </h2>
                <br />
                <label id="lbl_LineaSeleccionada"></label>
                <div class="row">
                    <div class="col-2">
                        <label>Fecha Inicial</label>
                        <div id='dateInput_Inicial'>
                        </div>
                    </div>
                    <div class="col-2">
                        <label>Fecha Final</label>
                        <div id='dateInput_Final'>
                        </div>
                    </div>
                    <div class="col-3">
                        Linea
                        <div id='jqxDDL_Linea'></div>
                    </div>
                     <div class="col-3">
                        Celda
                        <div id='jqxDDL_Celda'></div>
                    </div>
                    <div class="col-1">
                        <label></label>
                        <input id="BTN_aplicar_Filtros" type="button" class="btn btn-primary" value="Aplicar Filtro" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-6">
                        <div id="jqxChart" style="width: auto; height: 400px;"></div>
                    </div>
                    <div class="col-6">
                        <div id="jqxChart_tiempos" style="width: auto; height: 400px;"></div>
                    </div>
                </div>
                <br />
                 <div class="row">
                    <div class="col-3">
                        <input id="BTN_Descargar_Excel_Acumulado" type="button" class="btn btn-primary" value="Aplicar Filtro" />
                    </div>
                     <div class="col-3">
                        <input id="BTN_Descargar_Excel_Acumulado" type="button" class="btn btn-primary" value="Aplicar Filtro" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                       
                    </div>

                </div>
              
            </div>
            <div style="overflow: hidden;margin: 25px">               
                
            </div>
            
        </div>
    </div>

  
   
     
      
     
</asp:Content>
