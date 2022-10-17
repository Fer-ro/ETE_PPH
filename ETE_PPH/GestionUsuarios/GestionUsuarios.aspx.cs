using AccesoNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETE_PPH.GestionUsuarios
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
                AN_Login login = new AN_Login();
                if (user.Rango != 3 && user.ID_Usuario!=6)
                {
                    Response.Redirect("~/Error404.aspx");
                }
                else
                {
                    DataTable tablaEditar = new DataTable();
                    tablaEditar.Columns.Add("Valor");
                    DataRow row = tablaEditar.NewRow();
                    row[0] = "Editar usuario";
                    DataRow row2 = tablaEditar.NewRow();
                    row2[0] = "Editar permisos";
                    tablaEditar.Rows.Add(row);
                    tablaEditar.Rows.Add(row2);
                   
                    SetearDropDownList(DDL_SeleccionarEditar_Permisos_Usuario, tablaEditar, "Valor", "Valor");
                    AccesoNegocio.AN_GestionUsuarios aN_Gestion = new AccesoNegocio.AN_GestionUsuarios();
                    Session["DT_UsuariosActivos"] = aN_Gestion.UsuariosActivos();
                    Session["DT_Usuarios_Filtro"] = new DataView((DataTable)Session["DT_UsuariosActivos"]); 
                    GV_Usuarios.DataSource = Session["DT_UsuariosActivos"];
                    GV_Usuarios.DataBind();
                    
                    SetearDropDownList(DDL_Puesto, aN_Gestion.Get_Puestos(), "Puesto_Usuario", "ID_Puesto");
                   
                    AN_Login aN_Login = new AN_Login();
                    List<string[]> Lista_PermisosPaginas = aN_Login.Paginas_Permitidos_ALL();
                    MostrarPermisos(Lista_PermisosPaginas);
                    CB_ListaPermisos.Visible = false;
                    BTN_GuardarPermisos.Enabled = false;
                    //SetearDropDownList(DDL_Departamento, aN_Gestion.Get_Departamentos(), "Departamento", "ID_Departamento");
                    SetearDropDownList(DDL_RolNuevoUsaurio, aN_Gestion.Get_Puestos(), "Puesto_Usuario", "ID_Puesto");
                    if (login.Rango_De_Usuario(user.ID_Usuario.ToString()) != "3" && user.ID_Usuario!=6)
                    {
                        CB_ListaPermisos.Visible = false;
                        BTN_GuardarPermisos.Visible = false;
                    }
                }
                
                
            }


        }

        protected void GV_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            AN_Login aN_Login = new AN_Login();
            OBJ_Usuario userSesion = (OBJ_Usuario)Session["sesion_usuario"];
            if (DDL_SeleccionarEditar_Permisos_Usuario.SelectedValue == "Editar permisos")
            {

                if (userSesion.Rango == 3||userSesion.ID_Usuario==6)
                {
                    int selectedRow = GV_Usuarios.SelectedIndex;
                    //teaking the value of first column in selected row
                    OBJ_Usuario usuario = new OBJ_Usuario();
                    usuario.Username = GV_Usuarios.Rows[selectedRow].Cells[2].Text;
                    usuario.ID_Usuario = Convert.ToInt32(GV_Usuarios.Rows[selectedRow].Cells[1].Text);
                    //taking the value of second column in selected row
                    Session["Usuario_Seleccionado"] = usuario;
                    LBL_ID_Seleccionado.Text = usuario.Username;
                    BTN_GuardarPermisos.Enabled = true;
                    CB_ListaPermisos.Visible = true;
                    List<string[]> Lista_PermisosPaginas_Usuario = aN_Login.Paginas_Permitidos_Usuario(usuario.ID_Usuario);
                    foreach (ListItem chk in CB_ListaPermisos.Items)
                    {
                        chk.Selected = false;
                    }
                    foreach (string[] a in Lista_PermisosPaginas_Usuario)
                    {
                        foreach (ListItem chk in CB_ListaPermisos.Items)
                        {

                            if (chk.Value == a[0].ToString())
                            {
                                chk.Selected = true;
                                break;
                            }

                        }

                    }
                }
                else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: Usted no tiene los permisos necesarios.')", true); }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#Modal_EditarUsuario').modal('show');</script>", false);
                // Get the currently selected row using the SelectedRow property.
                GridViewRow row = GV_Usuarios.SelectedRow;
                TXT_NuevaNomina.Text = row.Cells[4].Text;
                lbl_UsuaarioSeleccionado.Text= row.Cells[1].Text;
            }
           
           
        }
        protected void BTN_GuardarPermisos_Click(object sender, EventArgs e)
        {
            AccesoNegocio.AN_GestionUsuarios aN_Gestion = new AccesoNegocio.AN_GestionUsuarios();
            OBJ_Usuario UserLogin = new OBJ_Usuario();
            UserLogin = (OBJ_Usuario)Session["sesion_usuario"];
            if (UserLogin.Rango == 3)
            {
                if (LBL_ID_Seleccionado.Text != "-")
                {
                    OBJ_Usuario usuario = new OBJ_Usuario();
                    usuario = (OBJ_Usuario)Session["Usuario_Seleccionado"];                  
                    foreach (ListItem chk in CB_ListaPermisos.Items)
                    {
                        if (chk.Selected)
                        {
                            aN_Gestion.Asignar_Permiso_Usuario(Convert.ToInt32(chk.Value), usuario.ID_Usuario);
                        }
                        else
                        {
                            aN_Gestion.Quitar_Permiso_Usuario(Convert.ToInt32(chk.Value), usuario.ID_Usuario);
                        }
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Se guardaron los datos correctamente')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: Debes seleccionar un usuario')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: No tiene los permisos necesarios para realizar esta opcion')", true);
            }
        }

        void MostrarPermisos(List<string[]>ListaPaginas)
        {        
            foreach (string [] pagina in ListaPaginas)
            {
                CB_ListaPermisos.Items.Add(new ListItem()
                {
                    Text = pagina[1], Value=pagina[0]                    
                });
            }           
        }

        protected void BTN_NuevoUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_ConfrimarNuevoUsuario_Click(object sender, EventArgs e)
        {
            AN_GestionUsuarios aN_GestionUsuarios = new AN_GestionUsuarios();
            if(TXT_NombreNuevoUsuario.Text!= "" && TXT_nomina.Text!=""&& TXT_pass.Text!=""&& TXT_Nick_NuevoUsuario.Text != "")
            {
                if (aN_GestionUsuarios.usuarioExistente(Convert.ToInt32(TXT_nomina.Text)) == false)
                {
                    aN_GestionUsuarios.Dar_Alta_NuevoUsuario(TXT_Nick_NuevoUsuario.Text, TXT_NombreNuevoUsuario.Text, Convert.ToInt32(DDL_RolNuevoUsaurio.SelectedValue), 1, Convert.ToInt32(TXT_nomina.Text), Convert.ToInt32(TXT_pass.Text));
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Se creo el usuario correctamente')", true);
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: El usuario ya existe')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: Necesita llenar todos los campos.')", true);
            }
           
        }
        void SetearDropDownList(DropDownList downList, DataTable sourceDT, string ColumnaTexto, string ColumnaValor)
        {
            downList.DataSource = sourceDT;
            downList.DataTextField = ColumnaTexto;
            downList.DataValueField = ColumnaValor;
            downList.DataBind();
        }

        protected void GV_Usuarios_PageIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void GV_Usuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Usuarios.PageIndex = e.NewPageIndex;
            GV_Usuarios.DataSource = Session["DT_Usuarios_Filtro"];
            GV_Usuarios.DataBind();
        }

        protected void BTN_GuardarEdicionUsuario_Click(object sender, EventArgs e)
        {
            AN_GestionUsuarios aN_GestionUsuarios = new AN_GestionUsuarios();
            if(TXT_NuevaNomina.Text!=""&& TXT_NuevoPass.Text!=""&& TXT_Nuevo_Nombre_Usuario.Text != "")
            {
                if (aN_GestionUsuarios.usuarioExistente(Convert.ToInt32(TXT_NuevaNomina.Text)) == false)
                {
                    aN_GestionUsuarios.Editar_Usuario(Convert.ToInt32(DDL_RolNuevoUsaurio.SelectedValue), Convert.ToInt32(TXT_NuevaNomina.Text), Convert.ToInt32(TXT_NuevoPass.Text.Trim()), TXT_Nuevo_Nombre_Usuario.Text.Trim(), Convert.ToInt32(lbl_UsuaarioSeleccionado.Text));
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Se edito el usuario correctamente')", true);
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ya existe alguien con ese numero de nomina')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: Necesita llenar todos los campos.')", true);
            }


        }

        protected void BTN_Buscar_Click(object sender, EventArgs e)
        {
            DataTable dtUsers = (DataTable)Session["DT_UsuariosActivos"];
            DataView dvUsers = new DataView(dtUsers);
            Session["DT_Usuarios_Filtro"]= dvUsers;
            if (TXT_Busar_Usuario.Text == "")
            {
                Session["DT_Usuarios_Filtro"] = new DataView((DataTable)Session["DT_UsuariosActivos"]);
                GV_Usuarios.DataSource = (DataTable)Session["DT_UsuariosActivos"];
                GV_Usuarios.DataBind();
            }
            else
            {
                dvUsers.RowFilter = "Usuario like '%" + TXT_Busar_Usuario.Text + "%' ";
                Session["DT_Usuarios_Filtro"] = dvUsers;
                GV_Usuarios.DataSource = dvUsers;
                GV_Usuarios.DataBind();
            }         
        }
    }
}