<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="NuevoRequerimiento.aspx.cs" Inherits="ETE_PPH.GesistionTickets.NuevoRequerimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       
            function Reload() {
                window.location.reload("Refresh")
            }
        //Lanzamiento de modal de Eliminar OT
        function Modal_ConfirmarEliminar() {
            $('#Modal_Aviso_ELiminar_OT').modal('show');
        }
        //Lanzamiento de modal de Editar OT
        function Modal_Editar() {
            $('#Modal_Registro').modal('show');
        }
    </script>

     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <style>
        .update
{
position: fixed;
top: 0px;
left: 0px;
min-height: 100%;
min-width: 100%;
background-image: url("../Imagenes/ES_121355.gif");
background-position:center center;
background-repeat:no-repeat;
background-color: #e4e4e6;
z-index: 500 !important;
opacity: 0.8;
overflow: hidden;
}
    </style>
   
    <h4>Requerimientos</h4>
    <hr />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

     <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="UP_Princial" DisplayAfter="20" DynamicLayout="true">
        <ProgressTemplate>
            
            <div class="update">
            </div>
                    
        </ProgressTemplate>
    </asp:UpdateProgress>


     <div class="card">
        <h5 class="card-header text-white bg-info">Crear requerimiento</h5>
         <div class="card-body">

             <div class="row">
                                 
             </div>
             <asp:UpdatePanel ID="UP_Princial" runat="server">
                 <ContentTemplate>
                    
                     <h6>Datos de la celda</h6>                   
                     <div class="row">
                         <div class="col-3">
                             <div class="input-group mb-3">
                                 <div class="input-group-prepend">
                                     <span class="input-group-text" id="SPAN_Linea">Linea</span>
                                 </div>
                                 <asp:DropDownList ID="DDL_Linea" AutoPostBack="true" OnSelectedIndexChanged="DDL_Linea_SelectedIndexChanged" aria-describedby="SPAN_Linea" class="form-control" runat="server"></asp:DropDownList>
                             </div>
                         </div>
                         <div class="col-4">
                             <div class="input-group mb-3">
                                 <div class="input-group-prepend">
                                     <span class="input-group-text" id="SPAN_Celda">Estacion</span>
                                 </div>
                                 <asp:DropDownList ID="DDL_Celda" AutoPostBack="true" aria-describedby="SPAN_Celda" class="form-control" runat="server"></asp:DropDownList>
                             </div>
                         </div>
                         <div class="col-4">
                             
                             <div class="input-group mb-3">
                                 <div class="input-group-prepend">
                                     <span class="input-group-text" id="SPAN_Robot">Robot</span>
                                 </div>
                                 <asp:DropDownList ID="DDL_Robot" AutoPostBack="true" aria-describedby="SPAN_Robot" class="form-control" runat="server"></asp:DropDownList>
                             </div>
                         
                         </div>
                     </div>
                     <div class="row">
                         <div class="col-4">
                              <div class="input-group mb-3">
                                 <div class="input-group-prepend">
                                     <span class="input-group-text" id="SPAN_impacto">Tipo impacto</span>
                                 </div>
                                 <asp:DropDownList ID="DDL_TipoImpacto" aria-describedby="SPAN_impacto" class="form-control" runat="server"></asp:DropDownList>
                             </div>
                         </div>
                     </div>
                     <br />
                     <hr />
                      <h6>Falla</h6>
                     
                       <div class="row">
                         <div class="col-6">
                             <div class="input-group mb-2">
                                 <div class="input-group-prepend">
                                     <span class="input-group-text" id="SPAN_TipoFallabusqueda">Busqueda por nombre</span>
                                 </div>
                                 <asp:TextBox ID="TXT_Buscar_Falla" OnTextChanged="TXT_Buscar_Falla_TextChanged" class="form-control" aria-describedby="SPAN_TipoFallabusqueda" runat="server"></asp:TextBox><asp:Button ID="BTN_RealizarBsuquedaFallas" OnClick="BTN_RealizarBsuquedaFallas_Click" runat="server" Text="Buscar" />
                             </div>
                         </div>                        
                     </div> 
                     
                        <div class="row">
                         <div class="col-6">
                             <div class="input-group mb-12">
                                 <div class="input-group-prepend">
                                     <span class="input-group-text" id="SPAN_TipoRequerimiento">Seleccion de falla: </span>
                                 </div>
                                  <asp:DropDownList ID="DDL_ResultadoDeBusqueda" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDL_ResultadoDeBusqueda_SelectedIndexChanged" aria-describedby="SPAN_TipoRequerimiento" runat="server"></asp:DropDownList>
                             </div>
                         </div>

                        

                        </div> 
                     <br />
                      <br />
                     <hr />
                      <h6>Hora que inicio la falla</h6>
                           
                               
                                <div class="row">
                                    <div class="col-6">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-4">
                                                        Dia inicio falla: 
                                                    </div>
                                                    <div class="col-4">
                                                        Hora inicio falla: 
                                                    </div>
                                                    <div class="col-4">
                                                        Minutos inicio falla:
                                                    </div>
                                                </div>
                                                <div class="row">                                                   
                                                    <div class="col-4">
                                                       
                                    <asp:DropDownList ID="DDL_Dia_Inicio" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-4">
                                                       
                                    <asp:DropDownList ID="DDL_Hora_Inicio" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-4">
                                                        
                                    <asp:DropDownList ID="DDL_Minutos_Inicio" runat="server"></asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                 
                                </div>
                      <br />
                        <br />
                     
                     Descripcion breve del trabajo o falla: <b>(Opcional)</b>
                     <asp:TextBox ID="TXT_Comentarios" class="form-control" runat="server" Width="600" Height="50" TextMode="MultiLine"></asp:TextBox>
                     <br />
                   

                     <asp:Button ID="BTN_GenerarOT" runat="server" OnClick="BTN_GenerarOT_Click" class="btn btn-success" Text="Generar orden de trabajo" />
                     <!-- Modal -->                   
                     <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                         <div class="modal-dialog" role="document">
                             <div class="modal-content">
                                 <div class="modal-header">
                                     <h5 class="modal-title" id="exampleModalLabel">OK</h5>
                                     <button type="button" class="close" data-dismiss="modal"  onclick="Reload(this);" aria-label="Close">
                                         <span aria-hidden="true">&times;</span>
                                     </button>
                                 </div>
                                 <div class="modal-body">
                                <h3>Se genero la nueva OT numero <b><asp:Label ID="LBL_ID_LastOT" runat="server" Text="-"></asp:Label></b> satisfactoriamente!</h3>
                                 </div>
                                 <div class="modal-footer">
                                    
                                     <button type="button" class="btn btn-secondary" onclick="Reload(this);" data-dismiss="modal">Cerrar</button>
                                 </div>
                             </div>
                         </div>
                     </div>
                 </ContentTemplate>
             </asp:UpdatePanel>
             <br />


         </div>
    </div>
     <br />
   <br />
    <h4>Mis OT´s</h4>
    <hr />
    <div class="card ">
        <h5 class="card-header text-white bg-info">Estatus de mis OT´s</h5>
        <div class="card-body">

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text " id="SPAN_Linea_Misot">Linea</span>
                                </div>
                                <asp:DropDownList ID="DDL_Filtro_Linea_MisOT" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-6">
                            <asp:Button ID="BTN_AplicarFiltro_MisOT" OnClick="BTN_AplicarFiltro_MisOT_Click" runat="server" Text="Aplicar filtro" />
                            <asp:Button ID="BTN_Limpiar_Filtro_MisOT" OnClick="BTN_Limpiar_Filtro_MisOT_Click" runat="server" Text="Limpiar filtro" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <hr />

            <div class="table-responsive">
                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="always" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GV_Mis_OT" AllowPaging="true" OnPageIndexChanging="GV_OT_Abiertas_PageIndexChanging" OnSelectedIndexChanged="GV_Mis_OT_SelectedIndexChanged" AutoGenerateSelectButton="true" class="table table-striped table-responsive" runat="server"></asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
    </div>
    <br />
    <br />
     <h4>OT´s Generales</h4>
    <hr />
    <div class="card ">
        <h5 class="card-header text-white bg-info">OT's</h5>
        <div class="card-body">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text " id="SPAN_Linea_">Linea</span>
                                </div>
                                <asp:DropDownList ID="DDL_Filtro_Linea" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-6">
                            <asp:Button ID="BTN_AplicarFiltro" OnClick="BTN_AplicarFiltro_Click" runat="server" Text="Aplicar filtro" />
                            <asp:Button ID="BTN_LimpiarFiltro_Abiertas" OnClick="BTN_LimpiarFiltro_Abiertas_Click" runat="server" Text="Limpiar filtro" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <hr />

            <div class="table-responsive">
                <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="always" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GV_OT_Abiertas" OnRowDataBound="GV_OT_Abiertas_RowDataBound" AllowPaging="true" OnPageIndexChanging="GV_OT_Abiertas_PageIndexChanging1"  AutoGenerateSelectButton="true" class="table table-striped table-responsive" OnPageIndexChanged="GV_OT_Abiertas_PageIndexChanged" runat="server"></asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
    </div>
    <br />

     <!-- The Modal Editar OT-->
    <div class="modal fade" id="Modal_Registro">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Editar OT</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="always">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-4">
                                    <div class="input-group input-group-sm mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="ID_OT">ID OT</span>
                                        </div>
                                        <asp:TextBox ID="TXT_ID_OT" class="form-control form-control-sm" runat="server" aria-describedby="ID_OT" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="input-group input-group-sm mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="Solicitante">Solicito</span>
                                        </div>
                                        <asp:TextBox ID="TXT_Solicito" class="form-control form-control-sm" aria-describedby="Solicitnte" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="input-group input-group-sm mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="Impato">Impacto</span>
                                        </div>
                                        <asp:TextBox ID="TXT_Impacto" class="form-control form-control-sm" aria-describedby="Impacto" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-4">
                                    <div class="input-group input-group-sm mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="Estacion">Estacion</span>
                                        </div>
                                        <asp:TextBox ID="TXT_Celda" class="form-control form-control-sm" aria-describedby="Estacion" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="input-group input-group-sm mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="Linea">Linea</span>
                                        </div>
                                        <asp:TextBox ID="TXT_Linea" class="form-control form-control-sm" aria-describedby="Linea" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="input-group input-group-sm mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="Tipo_paro">Tipo de paro</span>
                                        </div>
                                        <asp:TextBox ID="TXT_TipoParo" class="form-control form-control-sm" aria-describedby="Tipo_paro" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-4">
                                    <div class="input-group input-group-sm mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="FechaCreo">Robot</span>
                                        </div>
                                        <asp:TextBox ID="TXT_FechaRegistro" aria-describedby="FechaCreo" class="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="input-group input-group-sm mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="FechaRequerida">Fecha inicio falla</span>
                                        </div>
                                        <asp:TextBox ID="TXT_FechaRequerida" class="form-control form-control-sm" aria-describedby="FechaRequerida" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-4">
                                        <asp:TextBox ID="TXT_Cordones_o_Sensores" class="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                           
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                     <ContentTemplate>
                           <button type="button" class="btn btn-danger" onclick=" Modal_ConfirmarEliminar();" data-dismiss="modal">Eliminar OT</button>
                          
                     </ContentTemplate>
                 </asp:UpdatePanel>                   
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>

            </div>
        </div>
    </div>
 
       <!-- Modal aviso de ELiminar OT -->
    <div class="modal fade" id="Modal_Aviso_ELiminar_OT">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Eliminar OT</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel14">
                        <ContentTemplate>
                            <h3> Esta usted seguro que desea eliminar la OT: <asp:Label ID="LBL_OT_A_ELIMINAR" runat="server" Text="-"></asp:Label></h3>
                            <br />
                            <asp:Button ID="BTN_EliminarOT" runat="server" OnClick="BTN_EliminarOT_Click" class="btn btn-danger" Text="Si, Eliminar OT" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                                
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">                                    
                     <button type="button"class="btn btn-secondary" data-dismiss="modal">Close</button>                   
                </div>

            </div>
        </div>
    </div>
       

</asp:Content>
