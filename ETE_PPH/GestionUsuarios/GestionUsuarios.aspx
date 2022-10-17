<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="ETE_PPH.GestionUsuarios.GestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        //Lanzamiento de modal de AD
        function ModalOT() {
            $('#Modal_EditarUsuario').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <!--BODY-->
    <div class="card">
        <h5 class="card-header">Usuarios</h5>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <br />
                    <asp:Button ID="BTN_NuevoUsuario" OnClick="BTN_NuevoUsuario_Click" runat="server" Text="Crear nuevo usuario" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg"/> 
                    <asp:DropDownList ID="DDL_SeleccionarEditar_Permisos_Usuario" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <asp:TextBox ID="TXT_Busar_Usuario" runat="server"></asp:TextBox>
                    <asp:Button ID="BTN_Buscar" OnClick="BTN_Buscar_Click" runat="server" Text="Buscar" class="btn btn-primary"/>
                    <br />

                    <br />
                    <asp:GridView ID="GV_Usuarios" runat="server" OnPageIndexChanged="GV_Usuarios_PageIndexChanged" OnPageIndexChanging="GV_Usuarios_PageIndexChanging" OnSelectedIndexChanged="GV_Usuarios_SelectedIndexChanged" AllowPaging="true" AutoGenerateSelectButton="true" class="table table-hover table-responsive-sm"></asp:GridView>
                    <br />
                    <div class="card">

                        <div class="card-body" style="text-align: center">
                            <h5>Permisos</h5>
                            <hr />
                            <div id="DIV_CatalogoPermisos" runat="server" style="text-align: center">
                                <b>Usuario seleccionado :
                 <asp:Label ID="LBL_ID_Seleccionado" runat="server" Text="-"></asp:Label></b>
                                <br />
                                Lista de permisos:
                <br />
                                <div style="text-align: center; width: 60%; margin: auto;">
                                    <asp:CheckBoxList ID="CB_ListaPermisos" Style="text-align: center" runat="server" RepeatLayout="Flow"></asp:CheckBoxList>
                                </div>
                            </div>
                            <br />
                            <asp:Button ID="BTN_GuardarPermisos" class="btn btn-primary" OnClick="BTN_GuardarPermisos_Click" runat="server" Text="Guardar Cambios" />
                            <br />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <!-- Modal alta de nuevo usuario-->
    <div class="modal fade bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Alta de nuevo usuario</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
           
          
          <div class="modal-body">
              <div class="row">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                   <div class="col">
                      <div class="input-group mb-3">
                          <div class="input-group-prepend">
                              <span class="input-group-text" id="user">usuario</span>
                          </div>
                          <asp:TextBox ID="TXT_Nick_NuevoUsuario" class="form-control" aria-describedby="user" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   <div class="col">
                      <div class="input-group mb-3">
                          <div class="input-group-prepend">
                              <span class="input-group-text" id="nombre">Nombre</span>
                          </div>
                          <asp:TextBox ID="TXT_NombreNuevoUsuario" class="form-control" aria-describedby="nombre" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   <div class="col">
                      <div class="input-group mb-3">
                          <div class="input-group-prepend">
                              <span class="input-group-text" id="nomina">Nomina</span>
                          </div>
                          <asp:TextBox ID="TXT_nomina" class="form-control" aria-describedby="nomina" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   <div class="col">
                      <div class="input-group mb-3">
                          <div class="input-group-prepend">
                              <span class="input-group-text" id="pass">Password</span>
                          </div>
                          <asp:TextBox ID="TXT_pass" class="form-control" aria-describedby="pass" runat="server"></asp:TextBox>
                      </div>
                  </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
              </div>
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                      <ContentTemplate>
                          <div class="row">
                              <div class="col">
                                  <div class="input-group mb-3">
                                      <div class="input-group-prepend">
                                          <span class="input-group-text" id="rol">Puesto</span>
                                      </div>
                                      <asp:DropDownList ID="DDL_RolNuevoUsaurio" class="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                                  </div>
                              </div>
                             
                          </div>
                      </ContentTemplate>
                  </asp:UpdatePanel>
              <div class="modal-footer">
                  <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar ventana</button>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="BTN_ConfrimarNuevoUsuario" OnClick="BTN_ConfrimarNuevoUsuario_Click" class="btn btn-primary" runat="server" Text="Guardar registro" />
                        </ContentTemplate>
                          </asp:UpdatePanel>
              </div>
          </div>
  </div>
</div>
    </div>

    <!-- Modal modificar usuario -->       
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
             <div class="modal fade bd-example-modal-lg" id="Modal_EditarUsuario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                         <div class="modal-dialog modal-lg" role="document">
                             <div class="modal-content">
                                 <div class="modal-header">
                                     <h5 class="modal-title">Modificar usuario</h5>
                                     
                                 </div>
                                 <div class="modal-body">
                                     <div class="row">
                                         <div class="col-2">
                                            ID:  <asp:Label ID="lbl_UsuaarioSeleccionado"  runat="server" Text="-"></asp:Label>
                                         </div>
                                          <div class="col">
                                            Puesto: <asp:DropDownList ID="DDL_Puesto" runat="server"></asp:DropDownList>
                                          </div>
                                          <div class="col">
                                            Nomina:  <asp:TextBox ID="TXT_NuevaNomina" runat="server"></asp:TextBox>
                                              </div>
                                         <div class="col">
                                            Password:  <asp:TextBox ID="TXT_NuevoPass" runat="server"></asp:TextBox>
                                              </div>
                                     </div>
                                     <div class="row">
                                         <div class="col">                   
                                            Nombre:  <asp:TextBox ID="TXT_Nuevo_Nombre_Usuario" runat="server"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>
                                 <div class="modal-footer">
                                     <button type="button" class="btn btn-secondary" onclick="Reload(this);" data-dismiss="modal">Cerrar</button>
                                     <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                         <ContentTemplate>
                                             <asp:Button ID="BTN_GuardarEdicionUsuario" OnClick="BTN_GuardarEdicionUsuario_Click" class="btn btn-primary" runat="server" Text="Guardar edicion" />
                                         </ContentTemplate>
                                     </asp:UpdatePanel>
                                 </div>

                             </div>
                         </div>
                     </div>
        </ContentTemplate>
                          </asp:UpdatePanel>           
                    
</asp:Content>
