<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Captura.aspx.cs" Inherits="ETE_PPH.ETE.Captura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <script type="text/javascript">
        $(document).ready(function () {
          
            $("#dateInput").jqxDateTimeInput({ width: '150px', height: '25px' });           
            $("#timeInput").jqxDateTimeInput({ formatString: "T", showTimeButton: true, showCalendarButton: false, width: '150px', height: '25px' });
            $("#timeInput2").jqxDateTimeInput({ formatString: "T", showTimeButton: true, showCalendarButton: false, width: '150px', height: '25px' });

            //Eventos
            $('#dateInput').on('change', function (event) {
                var jsDate = $('#dateInput').jqxDateTimeInput('getText');
                var type = event.args.type; // keyboard, mouse or null depending on how the date was selected.
                $.ajax({
                    type: 'POST',
                    url: '<%= ResolveUrl("~/ETE/Captura.aspx/GetSelecicon_Fecha") %>',
                    data: '{"fecha":"'+jsDate+'"}',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (msg) {
                        
                    }
                });
            }); 
            //Eventos  -->horai
            $('#timeInput').on('change', function (event) {
                var jsDate = $('#timeInput').jqxDateTimeInput('getText');
                var type = event.args.type; // keyboard, mouse or null depending on how the date was selected.
                $.ajax({
                    type: 'POST',
                    url: '<%= ResolveUrl("~/ETE/Captura.aspx/GetSelecicon_HoraI") %>',
                    data: '{"HoraI":"' + jsDate + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (msg) {
                        
                    }
                });
            }); 
            //Eventos  -->horaf
            $('#timeInput2').on('change', function (event) {
                var jsDate = $('#timeInput2').jqxDateTimeInput('getText');
                var type = event.args.type; // keyboard, mouse or null depending on how the date was selected.
                $.ajax({
                    type: 'POST',
                    url: '<%= ResolveUrl("~/ETE/Captura.aspx/GetSelecicon_HoraF") %>',
                    data: '{"HoraF":"' + jsDate + '" }',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (msg) {
                        
                    }
                });
            }); 
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
    <h4>Captura de paros</h4>
    <hr />

    <div class="card">
        <h5 class="card-header">Captura paros</h5>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="row"> 
                        <div class="col-4">
                            Linea:
            <asp:DropDownList ID="DDL_Linea" OnSelectedIndexChanged="DDL_Linea_SelectedIndexChanged" class="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-3">
                            Celda:
            <asp:DropDownList ID="DDL_Celda" class="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-5">                           
                            Folio OP:
            <asp:TextBox ID="TXT_OrdenDeTrabajo" class="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-7">
                            <br />
                            Causa:
            <asp:DropDownList ID="DDL_CausaParo" class="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-5">
                            <br />
                            Atendio:
            <asp:DropDownList ID="DDL_AtendidoPor" class="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                   
                </ContentTemplate>
            </asp:UpdatePanel>

          
            <br />
            <div class="row">
                <div class="col-2">
                    <label>Fecha paro</label>
                    <div id='dateInput'>
                    </div>
                    <br />

                </div>
                <div class="col-2">
                    <label>Hora que inicio el paro</label>
                    <div id='timeInput'>
                    </div>
                </div>
                <div class="col-3">
                    <label>Hora que termino el paro</label>
                    <div id='timeInput2'>
                    </div>
                </div>
            </div>

            <br />
            Comentarios:
            <br />
            <asp:UpdatePanel ID="UpdatePanel3"  runat="server" UpdateMode="Always">
                <ContentTemplate>
                       <asp:TextBox ID="TXT_Comentarios" class="form-control" runat="server" Width="600" Height="150" TextMode="MultiLine"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
         
           
             <br />
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
           <asp:Button ID="BNT_GuardarRegistro" OnClick="BNT_GuardarRegistro_Click" class="btn btn-success" runat="server" Text="Guardar registro" />
                </ContentTemplate>
              </asp:UpdatePanel>

        </div>
    </div>
    
    <br />

     

</asp:Content>
