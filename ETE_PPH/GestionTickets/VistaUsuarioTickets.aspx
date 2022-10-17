<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="VistaUsuarioTickets.aspx.cs" ValidateRequest = "false" Inherits="ETE_PPH.GestionTickets.VistaUsuarioTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type='text/javascript'>

       $(document).ready(function () {
           $('#Modal_Registro').on('hidden.bs.modal', function () {
               // Load up a new modal...
               $('#Modal_Aviso_OT_Finalizada').modal('show')
           })
           $('#CerrarModalAviso_OT_Finalizado').click(function () {
               location.reload();
           });
       });
        //Lanzamiento de modal de AD
        function ModalOT() {
            $('#Modal_Registro').modal('show');
       }
       //Cerrar de modal de AD
       function ModalOT_Hide() {
           $('#Modal_Registro').modal('hide');
       }
       //Lanzamiento de modal de Aprobacion de OT
       function Modal_Aprobar() {
           $('#Modal_Aprobar').modal('show');
       }
       //Lanzamiento de modal de Aprobacion de OT calidad
       function Modal_Aprobar_Calidad() {
           $('#Modal_Aprobar_Calidad').modal('show');
       }
       //Lanzamiento de modal aviso Aprobacion de OT
       function Modal_Aviso_Aprobar() {
           $('#Modal_Aviso_OT_Finalizada').modal('show');
       }
       function Modal_Aviso_Aprobar_Fin() {
           $('#Modal_Aviso_OT_Finalizada').modal('hide');
       }
       //Lanzamiento de modal de Aprobacion de OT
       function Modal_ConfirmarDesaprobar() {
           $('#Modal_ConfirmacionDesapruebo').modal('show');
       }
       //Lanzamiento de modal de Eliminar OT
       function Modal_ConfirmarEliminar() {
           $('#Modal_Aviso_ELiminar_OT').modal('show');
       }
       //Lanzamiento de modal de OT aprobada satisfactoriamente
       function Modal_AprobadoOK() {
           $('#Modal_aprobada_satisfactoriamente').modal('show');
       }
       function Modal_AprobadoOK_hide() {
             $('#Modal_Aprobar').modal('hide');
       }
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style>
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../Imagenes/ES_121355.gif");
            background-position: center center;
            background-repeat: no-repeat;
            background-color: #e4e4e6;
            z-index: 500 !important;
            opacity: 0.8;
            overflow: hidden;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="20" DynamicLayout="true">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel8" DisplayAfter="20" DynamicLayout="true">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel13" DisplayAfter="20" DynamicLayout="true">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
        
    <div class="card text-center">
        <div class="card-header">
             <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="pills-home-tab" data-toggle="pill" href="#pills-home" role="tab" aria-controls="pills-home" aria-selected="true">OT Abiertas</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-profile-tab" data-toggle="pill" href="#pills-profile" role="tab" aria-controls="pills-profile" aria-selected="false">OT Pendientes de autorizar</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-contact-tab" data-toggle="pill" href="#pills-contact" role="tab" aria-controls="pills-contact" aria-selected="false">OT Finalizadas</a>
                </li>
            </ul>
        </div>
        <div class="card-body">
            <div class="tab-content" id="pills-tabContent">
                <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                    <div class="card ">
                        <h5 class="card-header text-white bg-info">OT Abiertos</h5>
                        <div class="card-body">
                                  
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text " id="SPAN_Linea">Linea</span>
                                                </div>
                                                <asp:DropDownList ID="DDL_Filtro_Linea" runat="server" class="form-control" ></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <asp:Button ID="BTN_AplicarFiltro" OnClick="BTN_AplicarFiltro_Click"  runat="server" Text="Aplicar filtro" />
                                             <asp:Button ID="BTN_LimpiarFiltro_Abiertas" OnClick="BTN_LimpiarFiltro_Abiertas_Click"  runat="server" Text="Limpiar filtro" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>          
                                    <hr />
                            <div class="table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="always" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GV_OT_Abiertas" AllowPaging="true" OnPageIndexChanging="GV_OT_Abiertas_PageIndexChanging" OnSelectedIndexChanged="GV_OT_Abiertas_SelectedIndexChanged" AutoGenerateSelectButton="true" class="table table-striped table-responsive" runat="server"></asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                                               
                        </div>
                    </div>
                    <br/>
                     <div class="card ">
                        <h5 class="card-header text-white bg-warning">OT Abiertos y desaprobadas</h5>
                        <div class="card-body">
                                  
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text " id="SPAN_Linea_Desaprobados">Linea</span>
                                                </div>
                                                <asp:DropDownList ID="DDL_Linea_Desaprobados" runat="server" class="form-control" ></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <asp:Button ID="BTN_AplicarFiltro_Desaprobados" OnClick="BTN_AplicarFiltro_Desaprobados_Click"  runat="server" Text="Aplicar filtro" />
                                             <asp:Button ID="BTN_LimparFiltro_Desaprobados" OnClick="BTN_LimparFiltro_Desaprobados_Click"  runat="server" Text="Limpiar filtro" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>          
                                    <hr />
                            <div class="table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="always" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GV_Desaprobados" AllowPaging="true" OnPageIndexChanging="GV_Desaprobados_PageIndexChanging" OnSelectedIndexChanged="GV_Desaprobados_SelectedIndexChanged" AutoGenerateSelectButton="true" class="table table-striped table-responsive" runat="server"></asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                                               
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                    <div class="card  ">
                        <h5 class="card-header  text-white bg-primary">OT Atendidos en espera de aprobacion-Produccion</h5>
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-3">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" id="SPAN_Linea_atendidos">Linea</span>
                                                </div>
                                                <asp:DropDownList ID="DDL_Linea_Atendidos" runat="server" class="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <asp:Button ID="BTN_Aplicar_Filtro_Linea_Aprobacion" OnClick="BTN_Aplicar_Filtro_Linea_Aprobacion_Click" runat="server" Text="Aplicar filtro" />
                                             <asp:Button ID="BTN_Limpiar_Filtro_EnAprobacion" OnClick="BTN_Limpiar_Filtro_EnAprobacion_Click" runat="server" Text="Limpiar filtro" />
                                        </div>
                                    </div>
                                    <hr />
                                    <asp:GridView ID="GV_Espera_Aprobacion"  AutoGenerateSelectButton="true" OnSelectedIndexChanged="GV_Espera_Aprobacion_SelectedIndexChanged" OnPageIndexChanging="GV_Espera_Aprobacion_PageIndexChanging" AllowPaging="true" class="table table-hover table-responsive" runat="server"></asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                          
                        </div>
                    </div>
                    <br/>
                     <div class="card ">
                        <h5 class="card-header text-white bg-warning">OT Atendidos en espera de aprobacion-Calidad</h5>
                        <div class="card-body">
                                  
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text " id="SPAN_Linea_Desaprobados-calidad">Linea</span>
                                                </div>
                                                <asp:DropDownList ID="DDL_Linea_Calidad" runat="server" class="form-control" ></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                           <asp:Button ID="BTN_Aplicar_Filtro_Linea_Aprobacion_Calidad" OnClick="BTN_Aplicar_Filtro_Linea_Aprobacion_Calidad_Click" runat="server" Text="Aplicar filtro" />
                                             <asp:Button ID="BTN_Borrarr_Filtro_Linea_Aprobacion_Calidad" OnClick="BTN_Borrarr_Filtro_Linea_Aprobacion_Calidad_Click" runat="server" Text="Limpiar filtro" />
                                         </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>          
                                    <hr />
                            <div class="table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel12" UpdateMode="always" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GV_Espera_Aprobacion_Calidad" AllowPaging="true" OnPageIndexChanging="GV_Espera_Aprobacion_Calidad_PageIndexChanging" OnSelectedIndexChanged="GV_Espera_Aprobacion_Calidad_SelectedIndexChanged" AutoGenerateSelectButton="true" class="table table-striped table-responsive" runat="server"></asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                                               
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-contact" role="tabpanel" aria-labelledby="pills-contact-tab">
                    <div class="card ">
                        <h5 class="card-header text-white bg-success mb-3">OT Finalizados y aprobados</h5>

                        <div class="row">
                            <div class="col-4">
                                #OT a buscar: <asp:TextBox ID="TXT_FiltroID_OT" TextMode="Number" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-3">
                                <asp:UpdatePanel ID="UpdatePanel55" runat="server">
                                    <ContentTemplate>
                                      <asp:Button ID="BRN_AplicarFiltro_OTFinalizados" OnClick="BRN_AplicarFiltro_OTFinalizados_Click" runat="server" Text="Aprobar filtro" />

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        

                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GV_OT_Finalizados" AllowPaging="true" OnPageIndexChanging="GV_OT_Finalizados_PageIndexChanging" class="table table-hover table-responsive table-sm" runat="server"></asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <!-- The Modal Abiertos-->
    <div class="modal fade" id="Modal_Registro">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Cerrar OT</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="always">
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
                            <div style="text-align: center">
                                <b>Descripcion del trabajo realizado:</b>
                                   <br />
                                <b></b>
                                <br />

                                Seleccione la hora que realizo el trabajo:
                            
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-3">
                                                        Mes: 
                                                    </div>
                                                    <div class="col-3">
                                                        Dia inicio: 
                                                    </div>
                                                    <div class="col-3">
                                                        Hora inicio: 
                                                    </div>
                                                    <div class="col-3">
                                                        Minutos inicio:
                                                    </div>
                                                </div>
                                                <div class="row">          
                                                      <div class="col-3">
                                                       
                                    <asp:DropDownList ID="DDL_Mes_Inicio" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-3">
                                                       
                                    <asp:DropDownList ID="DDL_Dia_Inicio" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-3">
                                                       
                                    <asp:DropDownList ID="DDL_Hora_Inicio" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-3">
                                                        
                                    <asp:DropDownList ID="DDL_Minutos_Inicio" runat="server"></asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-3">
                                                        Mes finalizo: 
                                                    </div>
                                                    <div class="col-3">
                                                        Dia finalizo: 
                                                    </div>
                                                    <div class="col-3">
                                                        Hora finalizo: 
                                                    </div>
                                                    <div class="col-3">
                                                        Minutos finalizo:
                                                    </div>
                                                </div>
                                                <div class="row">
                                                     <div class="col-3">
                                                        <asp:DropDownList ID="DDL_Mes_Fin" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-3">
                                                        <asp:DropDownList ID="DDL_Dia_Fin" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-3">
                                                        <asp:DropDownList ID="DDL_Hora_Fin" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="col-3">
                                                        <asp:DropDownList ID="DDL_Minutos_Fin" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 

                                <br />
                                <div class="row">
                                    
                                    <div class="col-12" id="DIV_SeleccionCordon" runat="server">
                                         <label>Seleccione el cordon afectado: </label>
                                        <div class="input-group mb-12">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="SPAN_Cordon">Seleccion de cordon: </span>
                                            </div>
                                            <asp:DropDownList ID="DDL_Cordon" class="form-control" aria-describedby="SPAN_Cordon" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-12" id="DIV_Sensores" runat="server">
                                        <label>Seleccione la memoria del sensor afectado: </label>
                                        <div class="row">
                                            <div class="col-3" id="DIV_SeleccionTabla1" runat="server">
                                                <asp:DropDownList ID="DDL_SENSOR1" class="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-3" id="DIV_SeleccionTabla2" runat="server">
                                                <asp:DropDownList ID="DDL_SENSOR2" class="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-3" id="DIV_SeleccionTabla3" runat="server">
                                                <asp:DropDownList ID="DDL_SENSOR3" class="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>                                       
                                    </div>
                                </div>
                                

                                <br />
                                <div class="row">
                                    <div class="col">
                                        ¿Que tipo de contramedida realizo?
                                    <asp:DropDownList ID="DDL_NecesitoCambioComponente" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                 <div class="row">
                                    <div class="col">
                                        ¿Afecto produccion?
                                    <asp:DropDownList ID="DDL_AfectoProduccion" AutoPostBack="true" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <b>Comentarios de contramedida (Obligatorio):</b>
                                <br />
                                <asp:TextBox ID="TXT_Comentarios" Width="600" Height="100" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                     <ContentTemplate>
                           <button type="button" class="btn btn-danger" onclick=" Modal_ConfirmarEliminar();" data-dismiss="modal">Eliminar OT</button>
                          <asp:Button ID="BTN_FinalizarOT" runat="server" OnClick="BTN_FinalizarOT_Click" class="btn btn-success" Text="Finalizar OT" />
                     </ContentTemplate>
                 </asp:UpdatePanel> 
                   
                    <button type="button" class="btn btn-secondary" data-dismiss="Modal_Registro">Close</button>
                </div>

            </div>
        </div>
    </div>
 
    <!-- Modal no aprobados -->
    <div class="modal fade" id="Modal_Aprobar">
        <div class="modal-dialog modal-xl">
            <div class="modal-content"  style="text-align:center">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Aprobacion de OT</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <!-- Modal body -->
                <div class="modal-body" style="text-align:center">
                    <asp:UpdatePanel runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:TextBox ID="TXT_ComentariosContramedida" Width="600" Height="100" TextMode="MultiLine" runat="server"></asp:TextBox>
                            <h2> <asp:Label ID="LBL_ID_PorAprovar" runat="server" Text="-"></asp:Label></h2>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="BTN_AprobarOT" runat="server" OnClick="BTN_AprobarOT_Click"  class="btn btn-success" Text="Aprobar OT" /> 
                           <button type="button" class="btn btn-danger" onclick=" Modal_ConfirmarDesaprobar();" data-dismiss="modal">Des-Aprobar OT</button>
             
                        </ContentTemplate>
                    </asp:UpdatePanel>
                       </div>
                <!-- Modal footer -->
                <div class="modal-footer" >                    
                     <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>                   
                </div>

            </div>
        </div>
    </div>
     
     <!-- Modal no aprobados calidad -->
    <div class="modal fade" id="Modal_Aprobar_Calidad">
        <div class="modal-dialog modal-xl">
            <div class="modal-content"  style="text-align:center">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Aprobacion de OT - Calidad</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <!-- Modal body -->
                <div class="modal-body" style="text-align:center">
                    <asp:UpdatePanel runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:TextBox ID="TXT_Contramedida_Calidad" Width="600" Height="100" TextMode="MultiLine" runat="server"></asp:TextBox>
                            <h2> <asp:Label ID="LBL_OT_Seleccionada_Calidad" runat="server" Text="-"></asp:Label></h2>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="BTN_Aprobar_Calidad" runat="server" OnClick="BTN_Aprobar_Calidad_Click"  class="btn btn-success" Text="Aprobar OT" /> 
                         
                        </ContentTemplate>
                    </asp:UpdatePanel>
                       </div>
                <!-- Modal footer -->
                <div class="modal-footer" >                    
                     <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>                   
                </div>

            </div>
        </div>
    </div>

    <!-- Modal aviso de aprobacion-->
    <div class="modal fade" id="Modal_Aviso_OT_Finalizada">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Espera de autorizacion OT</h4>
                    <button type="button" class="close" data-dismiss="Modal_Aviso_OT_Finalizada">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:UpdatePanel runat="server" ID="UP_AvisoFinalizado">
                        <ContentTemplate>
                            <h3> <asp:Label ID="LBL_OT_Aviso_Aprovacion" runat="server" Text="-"></asp:Label></h3>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                                
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">                                    
                     <button type="button" id="CerrarModalAviso_OT_Finalizado" class="btn btn-secondary" data-dismiss="Modal_Aviso_OT_Finalizada">Close</button>                   
                </div>

            </div>
        </div>
    </div>

    <!-- Modal no confirmacion para desaprobar OT -->
    <div class="modal fade" id="Modal_ConfirmacionDesapruebo">
        <div class="modal-dialog modal-xl">
            <div class="modal-content" style="text-align:center">
               
                <!-- Modal body -->
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                              <h5>ID Seleccionado: <asp:Label ID="LBL_ConfirmarCancelarAprobacionOT" runat="server" Text="-"></asp:Label></h5>
                              <asp:Button ID="BTN_DesaprobarOT" OnClick="BTN_DesaprobarOT_Click" class="btn btn-danger"  runat="server" Text="Si, deseo confirmar des-apruebo de OT" />                    
                              <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    <br />
                  
                </div>

            </div>
        </div>
    </div>

     <!-- Modal aviso de modal aprobada satisfactoriamente -->
    <div class="modal fade" id="Modal_aprobada_satisfactoriamente">
        <div class="modal-dialog modal-xl">
            <div class="modal-content" style="text-align:center">
               
                <!-- Modal body -->
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                             <h5><asp:Label ID="LBL_OT_Aprobada" runat="server" Text="-"></asp:Label></h5>
                            <button onclick="Modal_AprobadoOK_hide();">Cerrar</button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                   <%-- <asp:Button ID="BTN_CerrarVentanaAprobada" class="btn btn-secondary" OnClick="BTN_CerrarVentanaAprobada_Click" runat="server" Text="Cerrar ventana" />
                    --%>
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
