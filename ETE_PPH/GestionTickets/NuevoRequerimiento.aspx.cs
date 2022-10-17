    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoNegocio;

namespace ETE_PPH.GesistionTickets
{
    public partial class NuevoRequerimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];             
                AN_GestionOT gestionOT = new AN_GestionOT();
                if (user.Puesto==1||user.Rango==3||user.Puesto==3)
                {
                    AN_ETE ETE = new AN_ETE();
                    Session["Lineas"] = gestionOT.Get_Lineas();
                    SetearDropDownList(DDL_TipoImpacto, gestionOT.Get_UltimoTipoImpactos(), "Tipo_Impacto_OT", "ID_TipoImpacto");
                    SetearDropDownList(DDL_Linea, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");
                    SetearDropDownList(DDL_Filtro_Linea_MisOT, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");
                    SetearDropDownList(DDL_Filtro_Linea, (DataTable)Session["Lineas"], "Nombre", "ID_Linea");
                    
                    SetearDropDownList(DDL_Celda, gestionOT.Get_Celdas_ByLinea(Convert.ToInt32(3)), "Nom_Celda", "ID_Celda");
                    SetearDropDownList(DDL_ResultadoDeBusqueda, gestionOT.Get_Codigos_Fallas(), "Descripcion", "ID_Codigo");
   
                    //
                    SetearDropDownList(DDL_Robot, gestionOT.Get_Robots(), "Robot", "Robot");


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
                    SetearDropDownList(DDL_Dia_Inicio, Dias, "Dia", "Dia");
                    SetearDropDownList(DDL_Hora_Inicio, Horas, "Hora", "Hora");
                    SetearDropDownList(DDL_Minutos_Inicio, Minutos, "Minuto", "Minuto");

                    DDL_Dia_Inicio.SelectedValue = DateTime.Now.Day.ToString();
                    DDL_Hora_Inicio.SelectedValue = DateTime.Now.Hour.ToString();
                    DDL_Minutos_Inicio.SelectedValue = DateTime.Now.AddMinutes(-2).Minute.ToString();

                    Session["DTS_OT_Todas"] = gestionOT.OT_Todas();
                    GV_OT_Abiertas.DataSource = (DataTable)Session["DTS_OT_Todas"];
                    GV_OT_Abiertas.DataBind();

                    Session["DTS_Mis_OT"] = gestionOT.OTS_De_Usuario(user.ID_Usuario);
                    GV_Mis_OT.DataSource = (DataTable)Session["DTS_Mis_OT"];
                    GV_Mis_OT.DataBind();
                }
                else
                {
                    Response.Redirect("~/Error404.aspx");
                }
            }
        }
        private void Generar_Nueva_OT()
        {
            OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
            AN_GestionOT gestionOT = new AN_GestionOT();

            DateTime FechaInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(DDL_Dia_Inicio.SelectedValue));
            FechaInicio = FechaInicio.AddHours(Convert.ToInt32(DDL_Hora_Inicio.SelectedValue));
            FechaInicio = FechaInicio.AddMinutes(Convert.ToInt32(DDL_Minutos_Inicio.SelectedValue));
            string script = @"<script type='text/javascript'>
                            alerta(6);
                        </script>";
            try
            {               
                    if (gestionOT.Guardar_Nuevo_Requerimiento(user.ID_Usuario, Convert.ToInt32(DDL_TipoImpacto.SelectedValue), Convert.ToInt32(DDL_ResultadoDeBusqueda.SelectedValue), Convert.ToInt32(DDL_Celda.SelectedValue), TXT_Comentarios.Text.Trim(), FechaInicio, DDL_Robot.SelectedValue))
                    {
                        LBL_ID_LastOT.Text = gestionOT.Get_IDUltimoRequerimiento(user.ID_Usuario).ToString();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#exampleModal').modal('show');</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error al generar la peticion!", script, false);
                    }  
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Error al generar la peticion!" + ex.Message, script, false);
            }
         
        }

        [WebMethod(EnableSession = true)]
        public static string GetSelecicon_Fecha(string fecha)
        {
            string Fecha = Convert.ToDateTime(fecha).ToString("yyyy-MM-dd");
            HttpContext.Current.Session["Fecha_Requerimiento_OT"] = Fecha;
            return "";
        }
        [WebMethod(EnableSession = true)]
        public static string GetSelecicon_HoraI(string HoraI)
        {
            string Hora = Convert.ToDateTime(HoraI).ToString("HH:mm:ss");
            HttpContext.Current.Session["Hora_Requerimiento_OT"] = Hora;
            return "";
        }

        void SetearDropDownList(DropDownList downList, DataTable sourceDT, string ColumnaTexto, string ColumnaValor)
        {
            downList.DataSource = sourceDT;
            downList.DataTextField = ColumnaTexto;
            downList.DataValueField = ColumnaValor;
            downList.DataBind();
        }

        protected void BTN_GenerarOT_Click(object sender, EventArgs e)
        {
            BTN_GenerarOT.Enabled = false;
            Thread.Sleep(50);
            Generar_Nueva_OT();
        }

        protected void DDL_Linea_SelectedIndexChanged(object sender, EventArgs e)
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            SetearDropDownList(DDL_Celda, gestionOT.Get_Celdas_ByLinea(Convert.ToInt32(DDL_Linea.SelectedValue)), "Nom_Celda", "ID_Celda");
            
        }

        protected void DDL_AreaFalla_SelectedIndexChanged(object sender, EventArgs e)
        {
         }

        protected void TXT_Buscar_Falla_TextChanged(object sender, EventArgs e)
        {
            

        }

        protected void BTN_RealizarBsuquedaFallas_Click(object sender, EventArgs e)
        {
           
            AN_GestionOT gestionOT = new AN_GestionOT();
            SetearDropDownList(DDL_ResultadoDeBusqueda, gestionOT.Get_Codigos_FallasByAreaFalla_PalabraClave(TXT_Buscar_Falla.Text), "Descripcion", "ID_Codigo");
            TXT_Buscar_Falla.Text = "";
           
        }

        protected void DDL_ResultadoDeBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }
        bool ValidarSeleccionSensores()
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            if (gestionOT.Get_ID_TipoFallo(Convert.ToInt32( DDL_ResultadoDeBusqueda.SelectedValue)) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void GV_OT_Abiertas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GV_OT_Abiertas_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void BTN_AplicarFiltro_Click(object sender, EventArgs e)
        {
            AccesoNegocio.AN_GestionOT gestionOT = new AccesoNegocio.AN_GestionOT();
            GV_OT_Abiertas.DataSource = gestionOT.OT_Abiertas(Convert.ToInt32(DDL_Filtro_Linea.SelectedValue));
            GV_OT_Abiertas.DataBind();
        }

        protected void BTN_LimpiarFiltro_Abiertas_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_AplicarFiltro_MisOT_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_Limpiar_Filtro_MisOT_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_ActualizarOT_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_ActualizarOT_Click1(object sender, EventArgs e)
        {

        }

        protected void BTN_EliminarOT_Click(object sender, EventArgs e)
        {
            AN_GestionOT gestionOT = new AN_GestionOT();
            int ID_OT = Convert.ToInt32(Session["DTS_ID_OT_Seleccionada"]);
            gestionOT.Actualizar_Estatus_OT(ID_OT, 8);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void GV_OT_Abiertas_SelectedIndexChanged1(object sender, EventArgs e)
        {
           
        }

        protected void GV_Mis_OT_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GV_Mis_OT.SelectedRow;
            TXT_ID_OT.Text = row.Cells[1].Text;
            Session["DTS_ID_OT_Seleccionada"] = row.Cells[1].Text;
            TXT_Solicito.Text = row.Cells[2].Text;
            TXT_Impacto.Text = row.Cells[3].Text;
            TXT_Celda.Text = row.Cells[4].Text;
            TXT_Linea.Text = row.Cells[5].Text;
            TXT_FechaRegistro.Text = row.Cells[6].Text;
            TXT_FechaRequerida.Text = row.Cells[7].Text;
            TXT_TipoParo.Text = row.Cells[10].Text;
            TXT_Cordones_o_Sensores.Text = row.Cells[11].Text;
            LBL_OT_A_ELIMINAR.Text = (string)Session["DTS_ID_OT_Seleccionada"];
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Modal_Editar(); });", true);
        }

        protected void GV_OT_Abiertas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // you only want to check DataRow type, and not headers, footers etc.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // you already know you're looking at this row, so check your cell text
                switch (e.Row.Cells[6].Text)
                {
                    case "Abierta":
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Blue;
                        e.Row.Cells[6].ForeColor = System.Drawing.Color.White;
                    break;
                    case "Cerrada autorizada por produccion":
                        e.Row.Cells[6].BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case "Cancelada por Supervisor":
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
                        break;
                    case "En espera de aprobacion":
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Aqua;
                        e.Row.Cells[6].ForeColor = System.Drawing.Color.White;
                        break;
                    case "Abierta desaprobada":
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Yellow;
                        break;
                    case "Cancelada por administrador":
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Red;

                        break;
                    case "Cancelada por Lider":
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
                        break;
                    case "Espera aprobacion - calidad":
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Yellow;
                        break;
                }
            }
        }

        protected void GV_OT_Abiertas_PageIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GV_OT_Abiertas_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GV_OT_Abiertas.PageIndex = e.NewPageIndex;
            GV_OT_Abiertas.DataSource = (DataTable)Session["DTS_OT_Todas"];
            GV_OT_Abiertas.DataBind();
        }
    }
}