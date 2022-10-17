<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Captura_Scrap.aspx.cs" Inherits="ETE_PPH.ETE.Captura_Scrap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
          
            $("#dateInput").jqxDateTimeInput({ width: '150px', height: '25px' });           
            $("#timeInput").jqxDateTimeInput({ formatString: "T", showTimeButton: true, showCalendarButton: false, width: '150px', height: '25px' });
          

            //Eventos
            $('#dateInput').on('change', function (event) {
                var jsDate = $('#dateInput').jqxDateTimeInput('getText');
                var type = event.args.type; // keyboard, mouse or null depending on how the date was selected.
                $.ajax({
                    type: 'POST',
                    url: '<%= ResolveUrl("~/ETE/Captura_Scrap.aspx/GetSelecicon_Fecha") %>',
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
                    url: '<%= ResolveUrl("~/ETE/Captura_Scrap.aspx/GetSelecicon_HoraI") %>',
                    data: '{"HoraI":"' + jsDate + '" }',
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
    <div class="card">
        <h5 class="card-header">Captura scrap</h5>
         
        <div class="card-body">
            <div class="row">
                 <div class="col-3">
                    Linea
                    <asp:DropDownList ID="DDL_Linea" AutoPostBack="false" OnSelectedIndexChanged="DDL_Linea_SelectedIndexChanged" class="form-control" runat="server"></asp:DropDownList>
                </div>
                
                <div class="col-3">
                    Cantidad de scrap:
                    <asp:TextBox ID="TXT_Scrap"  type="number"   class="form-control" runat="server"></asp:TextBox>                                        
                </div>
                <div class="col-3">
                    Codigo Scrap
                    <asp:DropDownList ID="DDL_CatalogoScrap" class="form-control" runat="server"></asp:DropDownList>
                </div>
                 <div class="col-3">
                    Lado
                    <asp:DropDownList ID="DDL_Lado" class="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-3">
                    <label>Fecha ocurrencia</label>
                    <div id='dateInput'>
                    </div>
                    <br />

                </div>
                <div class="col-2">
                    <label>Hora</label>
                    <div id='timeInput'>
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
            <asp:Button ID="BTN_GuardarRegistroScrap" OnClick="BTN_GuardarRegistroScrap_Click" class="btn btn-success" runat="server" Text="Guardar registro" />
        </div>
    </div>
</asp:Content>
