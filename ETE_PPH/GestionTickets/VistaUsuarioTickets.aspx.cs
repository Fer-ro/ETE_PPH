using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using AccesoNegocio;
using System.Web.UI.WebControls;

namespace ETE_PPH.GestionTickets
{
    public partial class VistaUsuarioTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
                //Validamos si es tecnico, supervisor o admin
                if (user.Puesto == 2 || user.Puesto == 3 || user.Rango==3 || user.ID_Usuario==6)
                {
                    Utilidades utilidades = new Utilidades(); 
                    //DT  Dias 
                    DataTable Dias = new DataTable();
                    Dias.Columns.Add("Dia");
                    for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
                    {
                        DataRow row = Dias.NewRow();
                        row["Dia"] = i;
                        Dias.Rows.Add(row);
                    }
                    DataTable Horas = new DataTable();
                    Horas.Columns.Add("Hora");
                    for (int i = 0; i < 24; i++)
                    {
                        DataRow row = Horas.NewRow();
                        row["Hora"] = i;
                        Horas.Rows.Add(row);
                    }
                    DataTable Minutos = new DataTable();
                    Minutos.Columns.Add("Minuto");
                    for (int i = 0; i <= 59; i++)
                    {
                        DataRow row = Minutos.NewRow();
                        row["Minuto"] = i;
                        Minutos.Rows.Add(row);
                    }
                    DataTable Meses = new DataTable();
                    Meses.Columns.Add("Mes");
                    for (int i = 1; i <= 12 ; i++)
                    {
                        DataRow row = Meses.NewRow();
                        row["Mes"] = i;
                        Meses.Rows.Add(row);
                    }
                    //
                    utilidades.SetearDropDownList(DDL_Mes_Inicio, Meses, "Mes", "Mes");
                    utilidades.SetearDropDownList(DDL_Dia_Inicio, Dias, "Dia", "Dia");
                    utilidades.SetearDropDownList(DDL_Hora_Inicio, Horas, "Hora", "Hora");
                    utilidades.SetearDropDownList(DDL_Minutos_Inicio, Minutos, "Minuto", "Minuto");

                    utilidades.SetearDropDownList(DDL_Mes_Fin, Meses, "Mes", "Mes");
                    utilidades.SetearDropDownList(DDL_Dia_Fin, Dias, "Dia", "Dia");
                    utilidades.SetearDropDownList(DDL_Hora_Fin, Horas, "Hora", "Hora");
                    utilidades.SetearDropDownList(DDL_Minutos_Fin, Minutos, "Minuto", "Minuto");
                    AccesoNegocio.AN_GestionOT gestionOT = new AccesoNegocio.AN_GestionOT();

                   // utilidades.SetearDropDownList(DDL_Cordon, gestionOT.Get_Codigos_Cordones(Convert.ToInt32(DDL_Filtro_Linea.SelectedValue)), "Cordon", "ID_Cordon");
                    utilidades.SetearDropDownList(DDL_SENSOR1, gestionOT.Get_Sensor1(), "Direccion1", "Direccion1");
                    utilidades.SetearDropDownList(DDL_SENSOR2, gestionOT.Get_Sensor2(), "Direccion2", "Direccion2");
                    utilidades.SetearDropDownList(DDL_SENSOR3, gestionOT.Get_Sensor3(), "Direccion3", "Direccion3");

                   

                    DIV_Sensores.Visible = false;
                    DIV_SeleccionCordon.Visible = false;

                   

                    DataTable SiNo_AfectoProduccion = new DataTable();
                    SiNo_AfectoProduccion.Columns.Add("Valor");
                    DataRow row_si = SiNo_AfectoProduccion.NewRow();
                    row_si[0] = "Si";
                    DataRow row_no = SiNo_AfectoProduccion.NewRow();
                    row_no[0] = "No";
                    SiNo_AfectoProduccion.Rows.Add(row_si);
                    SiNo_AfectoProduccion.Rows.Add(row_no);

                    utilidades.SetearDropDownList(DDL_AfectoProduccion, SiNo_AfectoProduccion, "Valor", "Valor");

                    DDL_Dia_Inicio.SelectedValue = DateTime.Now.Day.ToString();
                    DDL_Hora_Inicio.SelectedValue = DateTime.Now.Hour.ToString();
                    DDL_Minutos_Inicio.SelectedValue = DateTime.Now.Minute.ToString();

                    DDL_Dia_Fin.SelectedValue = DateTime.Now.Day.ToString();
                    DDL_Hora_Fin.SelectedValue = DateTime.Now.Hour.ToString();
                    DDL_Minutos_Fin.SelectedValue = DateTime.Now.Minute.ToString();

                    DDL_Mes_Inicio.SelectedValue = DateTime.Now.Month.ToString();
                    DDL_Mes_Fin.SelectedValue = DateTime.Now.Month.ToString();

                    Session["DTS_OT_Abiertas"] = gestionOT.OT_Abiertas();
                    GV_OT_Abiertas.DataSource = (DataTable)Session["DTS_OT_Abiertas"];
                    GV_OT_Abiertas.DataBind();

                   Session["DTS_OT_Abiertas_Desaprobadas"]= gestionOT.OT_Abiertas_Desaprobadas();
                    GV_Desaprobados.DataSource = (DataTable)Session["DTS_OT_Abiertas_Desaprobadas"];
                    GV_Desaprobados.DataBind();

                    Session["DTS_OT_Cerradas"] = gestionOT.OT_Cerradas();
                    GV_OT_Finalizados.DataSource = (DataTable)Session["DTS_OT_Cerradas"];
                    GV_OT_Finalizados.DataBind();

                    Session["DTS_OT_Espera_Aprobacion"] = gestionOT.OT_Espera_Aprobacion();
                    GV_Espera_Aprobacion.DataSource = (DataTable)Session["DTS_OT_Espera_Aprobacion"];
                    GV_Espera_Aprobacion.DataBind();

                    Session["DTS_OT_Espera_Aprobacion_Calidad"] = gestionOT.OT_Espera_Aprobacion_Calidad();
                    GV_Espera_Aprobacion_Calidad.DataSource = (DataTable)Session["DTS_OT_Espera_Aprobacion_Calidad"];
                    GV_Espera_Aprobacion_Calidad.DataBind();

                    Session["Contramedidas"] = gestionOT.Get_Contramedidas();
                    utilidades.SetearDropDownList(DDL_NecesitoCambioComponente, (DataTable)Session["Contramedidas"], "Contramedida", "ID_Contramedida");

                    Session["DTS_ID_OT_Seleccionada"] = "";
                    Session["Lineas"] = gestionOT.Get_Lineas();

                 //   utilidades.SetearDropDownList(DDL_Liea_OTFinalizados_Aprobados, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");
                    utilidades.SetearDropDownList(DDL_Filtro_Linea, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");
                    utilidades.SetearDropDownList(DDL_Linea_Desaprobados, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");
                    utilidades.SetearDropDownList(DDL_Linea_Atendidos, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");

                    //Desabilitamos el boton de eliminar 
                    BTN_EliminarOT.Enabled = false;
                    if (user.Puesto == 3 || user.Rango == 3)
                    {
                        BTN_EliminarOT.Enabled = true;
                    }

                    }
                else
                {
                    Response.Redirect("~/Error404.aspx");
                }
                 
              
            }
        }

        protected void GV_OT_Abiertas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GV_OT_Abiertas.SelectedRow;
            TXT_ID_OT.Text = row.Cells[1].Text;
            Session["DTS_ID_OT_Seleccionada"] = row.Cells[1].Text;
            TXT_Solicito.Text = row.Cells[2].Text;
            TXT_Impacto.Text = row.Cells[3].Text;
            TXT_Celda.Text = row.Cells[4].Text;
            TXT_Linea.Text = row.Cells[5].Text;
            TXT_FechaRegistro.Text = row.Cells[6].Text;
            TXT_FechaRequerida.Text = row.Cells[7].Text;
            TXT_TipoParo.Text = row.Cells[10].Text;
            TXT_Cordones_o_Sensores.Text= row.Cells[11].Text;
            LBL_OT_A_ELIMINAR.Text =(string)Session["DTS_ID_OT_Seleccionada"];
            AccesoNegocio.AN_GestionOT gestionOT = new AccesoNegocio.AN_GestionOT();
            DIV_Sensores.Visible = false;
            DIV_SeleccionCordon.Visible = false;
            if (row.Cells[9].Text.Trim() == "Weld Macro" )
            {
                TXT_Cordones_o_Sensores.Visible = true;
                DIV_SeleccionCordon.Visible = true;
                Utilidades utilidades = new Utilidades();
                utilidades.SetearDropDownList(DDL_Cordon, gestionOT.Get_Codigos_Cordones(Convert.ToInt32(gestionOT.Get_ID_Linea(row.Cells[5].Text))), "Cordon", "Cordon");
            }
            if ( row.Cells[9].Text.Trim() == "Sensores")
            {
                TXT_Cordones_o_Sensores.Visible = true;
                DIV_Sensores.Visible = true;
            }
            //TXT_Comentarios.Text = gestionOT.Get_ComenatrioByOT(Convert.ToInt32(row.Cells[1].Text));
            //UpdatePanel2.Update();           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { ModalOT(); });", true);
        }

        protected void BTN_FinalizarOT_Click(object sender, EventArgs e)
        {
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            if (user.Puesto!=2)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: No tiene los privilegios para realizar esta opcion')", true);

            }
            else
            {
                if (TXT_Comentarios.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: debe de llenar los comentarios de la contramedida')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() {  ModalOT_Hide(); });", true);
                    AN_GestionOT gestionOT = new AN_GestionOT();
                    // OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];

                    DateTime Fecha_Inicio_Falla_OT = Convert.ToDateTime(gestionOT.GET_Fecha_Inicio_Falla_OT( Convert.ToInt32(TXT_ID_OT.Text)));


                    DateTime FechaInicio = new DateTime(DateTime.Now.Year, Convert.ToInt32(DDL_Mes_Inicio.SelectedValue), Convert.ToInt32(DDL_Dia_Inicio.SelectedValue));
                    FechaInicio = FechaInicio.AddHours(Convert.ToInt32(DDL_Hora_Inicio.SelectedValue));
                    FechaInicio = FechaInicio.AddMinutes(Convert.ToInt32(DDL_Minutos_Inicio.SelectedValue));


                    DateTime FechaFin = new DateTime(DateTime.Now.Year, Convert.ToInt32(DDL_Mes_Fin.SelectedValue), Convert.ToInt32(DDL_Dia_Fin.SelectedValue));
                    FechaFin = FechaFin.AddHours(Convert.ToInt32(DDL_Hora_Fin.SelectedValue));
                    FechaFin = FechaFin.AddMinutes(Convert.ToInt32(DDL_Minutos_Fin.SelectedValue));


                    if (FechaInicio >= FechaFin)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: La fecha inicial no puede ser menor o igual a la fecha de terminacion!')", true);
                    }
                    else
                    {
                        if (Fecha_Inicio_Falla_OT <= FechaInicio && Fecha_Inicio_Falla_OT < FechaFin)
                        {
                            BTN_FinalizarOT.Enabled = false;
                            gestionOT.Guardar_Nuevo_Contramedida(Convert.ToInt32(TXT_ID_OT.Text), user.ID_Usuario, Convert.ToInt32(DDL_NecesitoCambioComponente.SelectedValue), TXT_Comentarios.Text, FechaInicio, FechaFin, DDL_AfectoProduccion.SelectedValue);
                            if (gestionOT.Validar_Si_Es_OT_Calidad(Convert.ToInt32((string)Session["DTS_ID_OT_Seleccionada"])))
                            {
                                gestionOT.Actualizar_Estatus_OT(Convert.ToInt32((string)Session["DTS_ID_OT_Seleccionada"]), 10);
                            }
                            else
                            {
                                gestionOT.Actualizar_Estatus_OT(Convert.ToInt32((string)Session["DTS_ID_OT_Seleccionada"]), 2);
                            }

                            if (TXT_Cordones_o_Sensores.Text == "Weld Macro")
                            {
                                string Cordones = DDL_Cordon.SelectedValue;
                                gestionOT.Guardar_Nuevo_RegistroCordon(gestionOT.Get_IDUltimoContramedida(), Cordones);
                            }
                            if (TXT_Cordones_o_Sensores.Text == "Sensores")
                            {
                                string Sesnsores = DDL_SENSOR1.SelectedValue + "." + DDL_SENSOR2.SelectedValue + "." + DDL_SENSOR3.SelectedValue;
                                gestionOT.Guardar_Nuevo_RegistroSensores(gestionOT.Get_IDUltimoContramedida(), Sesnsores);
                            }

                            LBL_OT_Aviso_Aprovacion.Text = "Se finalizo la OT #" + (string)Session["DTS_ID_OT_Seleccionada"] + " , se encuentra en estatus de aprobacion";

                        }
                        else {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: Las fechas iniciales o finales de ajuste no pueden ser mayores a la fecha que inicio la falla!')", true);
                        }

                    }
                }
            }
            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() {  Modal_Aviso_Aprobar(); });", true);

        }

        protected void GV_OT_Abiertas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_OT_Abiertas.PageIndex = e.NewPageIndex;
            GV_OT_Abiertas.DataSource = (DataTable)Session["DTS_OT_Abiertas"];
            GV_OT_Abiertas.DataBind();
        }

        protected void GV_Espera_Aprobacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GV_Espera_Aprobacion.SelectedRow;
            LBL_ID_PorAprovar.Text = "#OT seleccionada: "+ row.Cells[2].Text;          
            TXT_ComentariosContramedida.Text = row.Cells[9].Text;
            Session["DTS_ID_OT_Seleccionada"] = row.Cells[2].Text;
            LBL_ConfirmarCancelarAprobacionOT.Text = Session["DTS_ID_OT_Seleccionada"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Modal_Aprobar(); });", true);

        }

        protected void GV_Espera_Aprobacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Espera_Aprobacion.PageIndex = e.NewPageIndex;
            GV_Espera_Aprobacion.DataSource = (DataTable)Session["DTS_OT_Espera_Aprobacion"];
            GV_Espera_Aprobacion.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_AprobarOT_Click(object sender, EventArgs e)
        {
           
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            if (user.Puesto==3||user.Rango==3)
            {
                //BTN_AprobarOT.Enabled = false;
                GridViewRow row = GV_Espera_Aprobacion.SelectedRow;
                LBL_OT_Aprobada.Text = "Se aprobo correctamente la OT #" + row.Cells[2].Text + "";
                AN_GestionOT gestionOT = new AN_GestionOT();
                gestionOT.Actualizar_Estatus_OT(Convert.ToInt32(row.Cells[2].Text), 3);
                gestionOT.Actualizar_FechaAprovacionYusuarioArobo_OT(Convert.ToInt32(row.Cells[2].Text), DateTime.Now,Convert.ToInt32(user.ID_Usuario));
                Session["DTS_OT_Espera_Aprobacion"] = gestionOT.OT_Espera_Aprobacion();
                GV_Espera_Aprobacion.DataSource = (DataTable)Session["DTS_OT_Espera_Aprobacion"];
                GV_Espera_Aprobacion.DataBind();
                UpdatePanel7.Update();
                //UpdatePanel6.Update();
                //UpdatePanel3.Update();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() {  Modal_AprobadoOK_hide(); });", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: ¡Usted no puede autorizar OT´s!')", true);
            }
        }

        protected void BNT_DesaprobarOT_Click(object sender, EventArgs e)
        {

        }

        //protected void BTN_CerrarVentanaAprobada_Click(object sender, EventArgs e)
        //{
        //    //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        //}

        protected void GV_Desaprobados_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GV_Desaprobados.SelectedRow;
            TXT_ID_OT.Text = row.Cells[1].Text;
            Session["DTS_ID_OT_Seleccionada"] = row.Cells[1].Text;
            TXT_Solicito.Text = row.Cells[2].Text;
            TXT_Impacto.Text = row.Cells[3].Text;
            TXT_Celda.Text = row.Cells[4].Text;
            TXT_Linea.Text = row.Cells[5].Text;
            TXT_FechaRegistro.Text = row.Cells[7].Text;
            TXT_FechaRequerida.Text = row.Cells[7].Text;
            TXT_TipoParo.Text = row.Cells[9].Text;
            LBL_ConfirmarCancelarAprobacionOT.Text= Session["DTS_ID_OT_Seleccionada"].ToString();
            LBL_OT_A_ELIMINAR.Text = (string)Session["DTS_ID_OT_Seleccionada"];
            AccesoNegocio.AN_GestionOT gestionOT = new AccesoNegocio.AN_GestionOT();
            if (gestionOT.Get_TipoFallaByID_OT(Convert.ToInt32(row.Cells[1].Text)) == 258)
            {

            }
            //TXT_Comentarios.Text = gestionOT.Get_ComenatrioByOT(Convert.ToInt32(row.Cells[1].Text));
            //UpdatePanel2.Update();           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { ModalOT(); });", true);

        }

        protected void GV_Desaprobados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Desaprobados.PageIndex = e.NewPageIndex;
            GV_Desaprobados.DataSource = (DataTable)Session["DTS_OT_Abiertas_Desaprobadas"];
            GV_Desaprobados.DataBind();
        }

        protected void BTN_DesaprobarOT_Click(object sender, EventArgs e)
        {
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            if (user.Puesto == 3 || user.Rango == 3)
            {

                AccesoNegocio.AN_GestionOT gestionOT = new AccesoNegocio.AN_GestionOT();
                int id = Convert.ToInt32(Session["DTS_ID_OT_Seleccionada"]);
                gestionOT.Actualizar_Estatus_OT(id, 4);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { ModalOT(); });", true);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: ¡Usted no puede desaprobar OT´s!')", true);
            }
        }

        protected void BTN_AplicarFiltro_Click(object sender, EventArgs e)
        {
            AccesoNegocio.AN_GestionOT gestionOT = new AccesoNegocio.AN_GestionOT();
             GV_OT_Abiertas.DataSource=gestionOT.OT_Abiertas(Convert.ToInt32(DDL_Filtro_Linea.SelectedValue));
            GV_OT_Abiertas.DataBind();
        }

        protected void BTN_AplicarFiltro_Desaprobados_Click(object sender, EventArgs e)
        {
            AccesoNegocio.AN_GestionOT gestionOT = new AccesoNegocio.AN_GestionOT();
            GV_Desaprobados.DataSource = gestionOT.OT_Abiertas_Desaprobadas(Convert.ToInt32(DDL_Linea_Desaprobados.SelectedValue));
            GV_Desaprobados.DataBind();
        }


        protected void BTN_LimparFiltro_Desaprobados_Click(object sender, EventArgs e)
        {
           
            GV_Desaprobados.DataSource = (DataTable)Session["DTS_OT_Abiertas_Desaprobadas"];
            GV_Desaprobados.DataBind();
            Utilidades utilidades = new Utilidades();           
            utilidades.SetearDropDownList(DDL_Linea_Desaprobados, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");
        }

        protected void BTN_LimpiarFiltro_Abiertas_Click(object sender, EventArgs e)
        {          
            GV_OT_Abiertas.DataSource = (DataTable)Session["DTS_OT_Abiertas"];
            GV_OT_Abiertas.DataBind();
            Utilidades utilidades = new Utilidades();
            utilidades.SetearDropDownList(DDL_Filtro_Linea, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");
        }

        protected void BTN_Limpiar_Filtro_EnAprobacion_Click(object sender, EventArgs e)
        {

            GV_Espera_Aprobacion.DataSource = (DataTable)Session["DTS_OT_Espera_Aprobacion"];
            GV_Espera_Aprobacion.DataBind();
            Utilidades utilidades = new Utilidades();
            utilidades.SetearDropDownList(DDL_Linea_Atendidos, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");
        }

        protected void BTN_Aplicar_Filtro_Linea_Aprobacion_Click(object sender, EventArgs e)
        {
            AccesoNegocio.AN_GestionOT gestionOT = new AccesoNegocio.AN_GestionOT();
            GV_Espera_Aprobacion.DataSource = gestionOT.OT_Espera_Aprobacion(Convert.ToInt32(DDL_Linea_Atendidos.SelectedValue));
            GV_Espera_Aprobacion.DataBind();

        }

        protected void GV_OT_Finalizados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_OT_Finalizados.PageIndex = e.NewPageIndex;
            GV_OT_Finalizados.DataSource = (DataTable)Session["DTS_OT_Cerradas"];
            GV_OT_Finalizados.DataBind();
        }

        protected void BTN_Aplicar_Filtro_Linea_Aprobacion_Calidad_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_Borrarr_Filtro_Linea_Aprobacion_Calidad_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_EliminarOT_Click(object sender, EventArgs e)
        {
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            //Validamos permisos
            if (user.Puesto == 3 || user.Rango == 3)
            {
                AN_GestionOT gestionOT = new AN_GestionOT();
                int ID_OT = Convert.ToInt32(Session["DTS_ID_OT_Seleccionada"]);
                gestionOT.Actualizar_Estatus_OT(ID_OT, 7);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: ¡Usted no puede eliminar OT´s!')", true);

            }


        }

        protected void GV_Espera_Aprobacion_Calidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GV_Espera_Aprobacion_Calidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GV_Espera_Aprobacion_Calidad.SelectedRow;
            LBL_OT_Seleccionada_Calidad.Text = "#OT seleccionada: " + row.Cells[3].Text;
            TXT_Contramedida_Calidad.Text = row.Cells[10].Text;
            Session["DTS_ID_OT_Seleccionada"] = row.Cells[3].Text;
            LBL_ConfirmarCancelarAprobacionOT.Text = Session["DTS_ID_OT_Seleccionada"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Modal_Aprobar_Calidad(); });", true);
        }

        protected void BTN_Aprobar_Calidad_Click(object sender, EventArgs e)
        {
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            if (user.Puesto == 4 || user.Rango == 3)
            {
                BTN_Aprobar_Calidad.Enabled = false;
                GridViewRow row = GV_Espera_Aprobacion_Calidad.SelectedRow;
                AN_GestionOT gestionOT = new AN_GestionOT();
                gestionOT.Actualizar_Estatus_OT(Convert.ToInt32(row.Cells[3].Text), 9);
                gestionOT.Actualizar_FechaAprovacionYusuarioArobo_OT(Convert.ToInt32(row.Cells[1].Text), DateTime.Now, Convert.ToInt32(user.ID_Usuario));
                LBL_OT_Aprobada.Text = "Se aprobo correctamente la OT #" + row.Cells[3].Text + "";
                 UpdatePanel7.Update();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() {  Modal_AprobadoOK(); });", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: ¡Usted no puede autorizar OT´s!')", true);
            }
        }

        protected void BRN_AplicarFiltro_OTFinalizados_Click(object sender, EventArgs e)
        {
            AccesoNegocio.AN_GestionOT gestionOT = new AccesoNegocio.AN_GestionOT();
            if (TXT_FiltroID_OT.Text != "")
            {
                GV_OT_Finalizados.DataSource = gestionOT.OT_Cerradas_ByLinea(Convert.ToInt32(TXT_FiltroID_OT.Text));
                GV_OT_Finalizados.DataBind();
            }
            else if (TXT_FiltroID_OT.Text=="")
            {
                GV_OT_Finalizados.DataSource = gestionOT.OT_Cerradas_ByLinea(0);
                GV_OT_Finalizados.DataBind();
            }
           

           
        }
    }
}