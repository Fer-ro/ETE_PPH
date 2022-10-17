using AccesoNegocio;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ETE_PPH.ETE
{
    public partial class Reportes : System.Web.UI.Page
    {

        //Listas Generales
        public List<int> MinDisp = new List<int>() { };
        public List<int> MinEfec = new List<int>() { };
        public List<double> EstandarPzas = new List<double>() { };
        public List<int> Tiempo = new List<int>() { };
        public List<string> Causa = new List<string>() { };
        public List<string> Celda = new List<string>() { };
        public List<string> Folio = new List<string>() { };
        public List<string> AtendidoPor = new List<string>() { };
        public double Man_Time;
        public DateTime fecha_tabla;
        public string nom_linea;
        public string Nombres_Registro;
        //Listas Primer Diseño
        public List<int> Produccion_Real = new List<int>() { };
        public List<double> Produccion_Acumulada_1 = new List<double>() { };
        public List<double> Produccion_Acumulada_2 = new List<double>() { };
        public List<double> Diferencia_1 = new List<double>() { };
        public List<double> Diferencia_2 = new List<double>() { };
        public List<int> Scrap = new List<int>() { };
        //Listas Segundo Diseño
        public List<int> Produccion_Real_2_1 = new List<int>() { };
        public List<int> Produccion_Real_2_2 = new List<int>() { };
        public List<double> Produccion_Acumulada_2_1 = new List<double>() { };
        public List<double> Produccion_Acumulada_2_2 = new List<double>() { };
        public List<double> Produccion_Acumulada_2_3 = new List<double>() { };
        public List<double> Diferencia_2_1 = new List<double>() { };
        public List<double> Diferencia_2_2 = new List<double>() { };
        public List<double> Diferencia_2_3 = new List<double>() { };
        public List<int> Scrap_2_1 = new List<int>() { };
        public List<int> Scrap_2_2 = new List<int>() { };

        //Tabla General
        public struct DatosLinea
        {
            public string proyecto, nombre_linea, tipo;
            public int A, B, C, D, E, F, G, G1, G2, H, H1, H2, I, P, P1, P2, planrh1, planrh2, planrh3, planlh1, planlh2, planlh3;
            public double J, K, K1, K2, L, L1, L2, M, M1, M2, N, N1, N2, O, O1, O2;
            public List<int> produccion_real;
            public List<int> produccion_real1;
            public List<int> produccion_real2;
        }

        public List<DatosLinea> datos_lineas = new List<DatosLinea>() { };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OBJ_Usuario user = (OBJ_Usuario)Session["sesion_usuario"];
                AN_Login login = new AN_Login();
                if (!login.ValidarPermiso_Pagina(2, user.ID_Usuario))
                {
                    Response.Redirect("~/Error404.aspx");
                }

            }
        }
           
        protected void BTN_Exportar_Click(object sender, EventArgs e)
        {
            //Exportar();
        }


        public void InicializarListas()
        {
            MinDisp = new List<int>() { };
            MinEfec = new List<int>() { };
            EstandarPzas = new List<double>() { };
            Tiempo = new List<int>() { };
            Causa = new List<string>() { };
            Celda = new List<string>() { };
            Folio = new List<string>() { };
            AtendidoPor = new List<string>() { };

            //Listas Primer Diseño
            Produccion_Real = new List<int>() { };
            Produccion_Acumulada_1 = new List<double>() { };
            Produccion_Acumulada_2 = new List<double>() { };
            Diferencia_1 = new List<double>() { };
            Diferencia_2 = new List<double>() { };
            Scrap = new List<int>() { };
            //Listas Segundo Diseño
            Produccion_Real_2_1 = new List<int>() { };
            Produccion_Real_2_2 = new List<int>() { };
            Produccion_Acumulada_2_1 = new List<double>() { };
            Produccion_Acumulada_2_2 = new List<double>() { };
            Produccion_Acumulada_2_3 = new List<double>() { };
            Diferencia_2_1 = new List<double>() { };
            Diferencia_2_2 = new List<double>() { };
            Diferencia_2_3 = new List<double>() { };
            Scrap_2_1 = new List<int>() { };
            Scrap_2_2 = new List<int>() { };
            return;
        }

        public void crear_Tabla_1(ref ExcelWorksheet workSheet)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //Fechas
            string fecha = fecha_tabla.ToString();
            fecha_tabla.AddDays(1);
            string fecha2 = fecha_tabla.ToString();

            workSheet.Cells[1, 1, 68, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[1, 1, 68, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Column(1).Width = 0.5;
            workSheet.Column(2).Width = 13.71;
            workSheet.Column(3).Width = 14.43;
            workSheet.Column(4).Width = 5.86;
            workSheet.Column(5).Width = 5.86;
            workSheet.Column(6).Width = 11.57;
            workSheet.Column(7).Width = 13.43;
            workSheet.Column(8).Width = 7.57;
            workSheet.Column(9).Width = 6.29;
            workSheet.Column(10).Width = 7.57;
            workSheet.Column(11).Width = 5;
            workSheet.Column(12).Width = 7.43;
            workSheet.Column(13).Width = 8.86;
            workSheet.Column(14).Width = 22.57;
            workSheet.Column(15).Width = 7.29;
            workSheet.Column(16).Width = 10.43;
            workSheet.Column(17).Width = 11.29;
            workSheet.Row(1).Height = 12.75;
            workSheet.Row(2).Height = 14.5;
            workSheet.Row(3).Height = 16.25;
            workSheet.Row(4).Height = 13.25;
            workSheet.Row(5).Height = 12.75;
            workSheet.Row(6).Height = 12.75;
            workSheet.Row(7).Height = 12.75;
            workSheet.Row(8).Height = 12.75;
            workSheet.Row(9).Height = 43.25;
            workSheet.Cells[2, 3, 3, 13].Merge = true;
            workSheet.Cells[2, 3].Value = "TABLERO DE PRODUCCIÓN";
            workSheet.Cells[2, 3].Style.Font.Size = 28;
            workSheet.Cells[2, 3].Style.Font.Bold = true;
            workSheet.Cells[5, 4, 5, 7].Merge = true;
            workSheet.Cells[5, 4, 5, 7].Value = "CUELLO DE BOTELLA CICLO (man time)";
            workSheet.Cells[5, 8].Value = Man_Time;
            workSheet.Cells[5, 10, 5, 11].Merge = true;
            workSheet.Cells[5, 10].Value = "LINEA: ";
            workSheet.Cells[5, 12, 5, 13].Merge = true;
            workSheet.Cells[5, 12].Value = nom_linea;
            workSheet.Cells[7, 2].Value = "FECHA:";
            workSheet.Cells[7, 3].Value = fecha;
            workSheet.Cells[7, 7, 7, 10].Merge = true;
            workSheet.Cells[7, 7].Value = "RESPONSABLE DE REGISTRO: ";
            workSheet.Cells[7, 11, 7, 13].Merge = true;
            workSheet.Cells[7, 11].Value = Nombres_Registro;

            workSheet.Cells[9, 2, 9, 17].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[9, 2, 9, 17].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 102));
            workSheet.Cells[9, 3].Value = "HORA";
            workSheet.Cells[9, 4].Value = "Min Disp";
            workSheet.Cells[9, 5].Value = "Min Efec";
            workSheet.Cells[9, 6].Value = "ESTANDAR (PZAS/HR)";

            workSheet.Cells[9, 7].Value = "PRODUCCIÓN REAL";
            workSheet.Cells[9, 8, 9, 9].Merge = true;
            workSheet.Cells[9, 8].Value = "PRODUCCIÓN ACUMULADA";
            workSheet.Cells[9, 10, 9, 11].Merge = true;
            workSheet.Cells[9, 10].Value = "DIFERENCIA";
            workSheet.Cells[9, 12].Value = "SCRAP";
            workSheet.Cells[9, 13].Value = "TIEMPO DE PARO";
            workSheet.Cells[9, 14].Value = "CAUSA DE PARO";
            workSheet.Cells[9, 15].Value = "CELDA #";
            workSheet.Cells[9, 16].Value = "FOLIO ORDEN DE TRABAJO";
            workSheet.Cells[9, 17].Value = "ATENDIDO POR";
            for (int i = 2; i <= 17; i++)
            {
                workSheet.Cells[9, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[9, i].Style.WrapText = true;
                workSheet.Cells[9, i].Style.Font.Bold = true;
                workSheet.Cells[9, i].Style.Font.Color.SetColor(Color.White);
            }
            List<string> horas1 = new List<string>() {"7:00", "8:00", "8:00", "9:00", "9:00", "10:00", "10:00",
                                                    "11:00","11:00","12:00","12:00","13:00","13:00","14:00","14:00",
                                                    "15:00","15:00","16:00","16:00","17:00","17:00","18:00","18:00",
                                                    "19:00","19:00","20:00","20:00","21:00","21:00","22:00","22:00",
                                                    "22:30","22:30","23:00","23:00","0:00","0:00","1:00","1:00",
                                                    "2:00","2:00","15:00","15:00","16:00","16:00","17:00","17:00","18:00","18:00","19:00"};
            List<string> horas2 = new List<string>(){"7:00:00 AM","8:00:00 AM","8:00:00 AM","9:00:00 AM","9:00:00 AM","10:00:00 AM","10:00:00 AM"
                                                    ,"11:00:00 AM","11:00:00 AM","12:00:00 PM","12:00:00 PM","1:00:00 PM","1:00:00 PM"
                                                    ,"2:00:00 PM","2:00:00 PM","3:00:00 PM","3:00:00 PM","4:00:00 PM","4:00:00 PM"
                                                    ,"5:00:00 PM","5:00:00 PM","6:00:00 PM","6:00:00 PM","7:00:00 PM","7:00:00 PM"
                                                    ,"8:00:00 PM","8:00:00 PM","9:00:00 PM","9:00:00 PM","10:00:00 PM","10:00:00 PM"
                                                    ,"10:30:00 PM","10:30:00 PM","11:00:00 PM","11:00:00 PM","12:00:00 AM","12:00:00 AM"
                                                    ,"1:00:00 AM","1:00:00 AM","2:00:00 AM","2:00:00 AM","3:00:00 PM","3:00:00 PM"
                                                    ,"4:00:00 PM","4:00:00 PM","5:00:00 PM","5:00:00 PM","6:00:00 PM","6:00:00 AM","7:00:00 AM"};

            for (int i = 10; i <= 59; i += 2)
            {
                workSheet.Row(i).Height = 11;
                workSheet.Row(i + 1).Height = 11;
                workSheet.Cells[i, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[i + 1, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i < 41)
                {
                    workSheet.Cells[i, 2].Value = fecha + " " + horas1[(i - 10)];
                    workSheet.Cells[i + 1, 2].Value = fecha + " " + horas1[(i - 10) + 1];
                }
                else
                {
                    if (i == 41)
                    {
                        workSheet.Cells[i, 2].Value = fecha + " " + horas1[(i - 10)];
                        workSheet.Cells[i + 1, 2].Value = fecha2 + " " + horas1[(i - 10) + 1];
                    }
                    else
                    {
                        workSheet.Cells[i, 2].Value = fecha2 + " " + horas1[(i - 10)];
                        workSheet.Cells[i + 1, 2].Value = fecha2 + " " + horas1[(i - 10) + 1];
                    }
                }
            }

            for (int i = 10; i <= 59; i += 2)
            {
                workSheet.Cells[i, 3, i + 1, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[i, 3].Value = horas2[(i - 10)];
                workSheet.Cells[i + 1, 3].Value = horas2[(i - 10) + 1];
            }


            double SumEstandarPzas = 0.0;

            //MinDisp
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 4, j + 1, 4].Merge = true;
                workSheet.Cells[j, 4, j + 1, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 4].Value = MinDisp[i];
            }
            //MinEfec
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 5, j + 1, 5].Merge = true;
                workSheet.Cells[j, 5, j + 1, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 5].Value = MinEfec[i];
            }
            //EstandarPzas
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 6, j + 1, 6].Merge = true;
                workSheet.Cells[j, 6, j + 1, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                //Calcular Valores
                EstandarPzas.Add((double)MinEfec[i] / (double)Man_Time);
                if ((EstandarPzas[EstandarPzas.Count - 1] - Convert.ToInt32(EstandarPzas[EstandarPzas.Count - 1])) >= 0.5)
                {
                    workSheet.Cells[j, 6].Value = Convert.ToInt32(EstandarPzas[EstandarPzas.Count - 1]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 6].Value = Convert.ToInt32(EstandarPzas[EstandarPzas.Count - 1]);
                }

                SumEstandarPzas += EstandarPzas[EstandarPzas.Count - 1];
            }
            //ProduccionReal
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 7, j + 1, 7].Merge = true;
                workSheet.Cells[j, 7, j + 1, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                //Calcular Valores
                workSheet.Cells[j, 7].Value = Produccion_Real[i];
            }
            //ProduccionAcumulada
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 8, j + 1, 8].Merge = true;
                workSheet.Cells[j, 9, j + 1, 9].Merge = true;
                workSheet.Cells[j, 8, j + 1, 9].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                //Calcular dos valores
                if (i == 0)
                {
                    Produccion_Acumulada_1.Add((double)Produccion_Real[0]);
                    Produccion_Acumulada_2.Add(EstandarPzas[0]);
                }
                else
                {
                    Produccion_Acumulada_1.Add(Produccion_Acumulada_1[i - 1] + (double)Produccion_Real[i]);
                    Produccion_Acumulada_2.Add(Produccion_Acumulada_2[i - 1] + EstandarPzas[i]);
                }
                if ((Produccion_Acumulada_1[i] - Convert.ToInt32(Produccion_Acumulada_1[i])) >= 0.5)
                {
                    workSheet.Cells[j, 8].Value = Convert.ToInt32(Produccion_Acumulada_1[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 8].Value = Convert.ToInt32(Produccion_Acumulada_1[i]);
                }
                if ((Produccion_Acumulada_2[i] - Convert.ToInt32(Produccion_Acumulada_2[i])) >= 0.5)
                {
                    workSheet.Cells[j, 9].Value = Convert.ToInt32(Produccion_Acumulada_2[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 9].Value = Convert.ToInt32(Produccion_Acumulada_2[i]);
                }

            }
            //Diferencia
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 10, j + 1, 10].Merge = true;
                workSheet.Cells[j, 11, j + 1, 11].Merge = true;
                workSheet.Cells[j, 10, j + 1, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                //Calcular dos valores
                Diferencia_1.Add((double)Produccion_Real[i] - EstandarPzas[i]);

                if (i == 0)
                {
                    Diferencia_2.Add(Diferencia_1[0]);
                }
                else
                {
                    Diferencia_2.Add(Diferencia_1[i] + Diferencia_2[i - 1]);
                }

                if (Diferencia_1[i] < 0)
                {
                    workSheet.Cells[j, 10].Style.Font.Color.SetColor(Color.Red);
                }
                if (Diferencia_2[i] < 0)
                {
                    workSheet.Cells[j, 11].Style.Font.Color.SetColor(Color.Red);
                }

                if (Math.Abs(Diferencia_1[i] - Convert.ToInt32(Diferencia_1[i])) >= 0.5)
                {
                    workSheet.Cells[j, 10].Value = Convert.ToInt32(Diferencia_1[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 10].Value = Convert.ToInt32(Diferencia_1[i]);
                }
                if (Math.Abs(Diferencia_2[i] - Convert.ToInt32(Diferencia_2[i])) >= 0.5)
                {
                    workSheet.Cells[j, 11].Value = Convert.ToInt32(Diferencia_2[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 11].Value = Convert.ToInt32(Diferencia_2[i]);
                }

            }
            //SCRAP
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 12, j + 1, 12].Merge = true;
                workSheet.Cells[j, 12, j + 1, 12].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 12].Value = Scrap[i];
            }
            //Tiempo de Paro
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 13, j + 1, 13].Merge = true;
                workSheet.Cells[j, 13, j + 1, 13].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 13].Value = Tiempo[i];
            }

            //CausaDeParo
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 14, j + 1, 14].Merge = true;
                workSheet.Cells[j, 14, j + 1, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 14].Style.WrapText = true;
                workSheet.Cells[j, 14].Value = Causa[i];
            }
            //CELDA
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 15, j + 1, 15].Merge = true;
                workSheet.Cells[j, 15, j + 1, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 15].Style.WrapText = true;
                workSheet.Cells[j, 15].Value = Celda[i];
            }
            //Folio Orden de Trabajo
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 16, j + 1, 16].Merge = true;
                workSheet.Cells[j, 16, j + 1, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 16].Value = Folio[i];
            }
            //Atendido por 
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 17, j + 1, 17].Merge = true;
                workSheet.Cells[j, 17, j + 1, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 17].Style.WrapText = true;
                workSheet.Cells[j, 17].Value = AtendidoPor[i];
            }

            int SumMinDisp = MinDisp.Sum();
            int SumMinEfec = MinEfec.Sum();
            int SumProduccionReal = Produccion_Real.Sum();

            workSheet.Cells[60, 2, 61, 3].Merge = true;
            workSheet.Cells[60, 2, 61, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[60, 2, 61, 3].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 102));
            workSheet.Cells[60, 2].Value = "TOTAL";
            workSheet.Cells[60, 2].Style.Font.Color.SetColor(Color.White);
            workSheet.Cells[60, 4].Value = SumMinDisp;
            workSheet.Cells[60, 5].Value = SumMinEfec;
            workSheet.Cells[60, 6].Value = SumEstandarPzas;
            workSheet.Cells[60, 7].Value = SumProduccionReal;

            double sum = 0.0, sum2 = 0.0;
            double pph1, pph2, pph3;
            for (int i = 0; i < 8; i++)
            {
                sum += MinEfec[i];
                sum2 += Produccion_Real[i];

            }
            workSheet.Cells[63, 5].Value = sum / 60;
            workSheet.Cells[63, 7].Value = sum2;
            pph1 = sum2 / (sum / 60);

            sum = 0.0;
            sum2 = 0.0;

            for (int i = 8; i < 16; i++)
            {
                sum += MinEfec[i];
                sum2 += Produccion_Real[i];

            }
            workSheet.Cells[64, 5].Value = sum / 60;
            workSheet.Cells[64, 7].Value = sum2;
            pph2 = sum2 / (sum / 60);
            sum = 0.0;
            sum2 = 0.0;

            for (int i = 16; i < 25; i++)
            {
                sum += MinEfec[i];
                sum2 += Produccion_Real[i];
            }
            workSheet.Cells[65, 5].Value = sum / 60;
            workSheet.Cells[65, 7].Value = sum2;

            workSheet.Cells[62, 8].Value = "PPH";
            pph3 = sum2 / (sum / 60);

            if (pph1 - Convert.ToInt32(pph1) >= 0.5)
            {
                workSheet.Cells[63, 8].Value = Convert.ToInt32(pph1) + 1;
            }
            else
            {
                workSheet.Cells[63, 8].Value = Convert.ToInt32(pph1);
            }
            if (pph2 - Convert.ToInt32(pph2) >= 0.5)
            {
                workSheet.Cells[64, 8].Value = Convert.ToInt32(pph2) + 1;
            }
            else
            {
                workSheet.Cells[64, 8].Value = Convert.ToInt32(pph2);
            }
            if (pph3 - Convert.ToInt32(pph3) >= 0.5)
            {
                workSheet.Cells[65, 8].Value = Convert.ToInt32(pph3) + 1;
            }
            else
            {
                workSheet.Cells[65, 8].Value = Convert.ToInt32(pph3);
            }

            //LOGO
            string conn = "Data Source = 172.25.10.90\\FYPAPP; Initial Catalog = FYP_Soldadura_ETE; User ID = prensas; Password = Fypprensas; MultipleActiveResultSets = true;";
            using (SqlConnection cnn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT img FROM Logo WHERE Id_Logo = 1";
                cnn.Open();
                byte[] Logo = (Byte[])cmd.ExecuteScalar();
                using (var mslogo = new MemoryStream(Logo, 0, Logo.Length))
                {
                    System.Drawing.Image imagelogo = System.Drawing.Image.FromStream(mslogo, true);
                    var excelImagelogo = workSheet.Drawings.AddPicture("Logo", imagelogo);
                    excelImagelogo.SetSize(90, 70);
                    excelImagelogo.SetPosition(5, 5);
                }
                cnn.Close();
            }

            return;
        }

        public void crear_Tabla_2(ref ExcelWorksheet workSheet)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //Fechas
            string fecha = fecha_tabla.ToString();
            fecha_tabla.AddDays(1);
            string fecha2 = fecha_tabla.ToString();

            workSheet.Cells[1, 1, 68, 25].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[1, 1, 68, 25].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Column(1).Width = 0.5;
            workSheet.Column(2).Width = 13.71;
            workSheet.Column(3).Width = 14.43;
            workSheet.Column(4).Width = 5.86;
            workSheet.Column(5).Width = 5.86;
            workSheet.Column(6).Width = 11.57;
            workSheet.Column(7).Width = 7.14;
            workSheet.Column(8).Width = 7.14;
            workSheet.Column(9).Width = 5.8;
            workSheet.Column(10).Width = 5.8;
            workSheet.Column(11).Width = 5.8;
            workSheet.Column(12).Width = 5.57;
            workSheet.Column(13).Width = 5.57;
            workSheet.Column(14).Width = 5.57;
            workSheet.Column(15).Width = 6.71;
            workSheet.Column(16).Width = 6.71;
            workSheet.Column(17).Width = 8.57;
            workSheet.Column(18).Width = 22.57;
            workSheet.Column(19).Width = 7.29;
            workSheet.Column(20).Width = 10.43;
            workSheet.Column(21).Width = 11.29;
            workSheet.Row(1).Height = 12.75;
            workSheet.Row(2).Height = 14.5;
            workSheet.Row(3).Height = 16.25;
            workSheet.Row(4).Height = 13.25;
            workSheet.Row(5).Height = 12.75;
            workSheet.Row(6).Height = 12.75;
            workSheet.Row(7).Height = 12.75;
            workSheet.Row(8).Height = 12.75;
            workSheet.Row(9).Height = 43.25;
            workSheet.Cells[2, 3, 3, 13].Merge = true;
            workSheet.Cells[2, 3].Value = "TABLERO DE PRODUCCIÓN";
            workSheet.Cells[2, 3].Style.Font.Size = 28;
            workSheet.Cells[2, 3].Style.Font.Bold = true;
            workSheet.Cells[5, 4, 5, 8].Merge = true;
            workSheet.Cells[5, 4].Value = "CUELLO DE BOTELLA CICLO (man time)";
            workSheet.Cells[5, 9].Value = Man_Time;
            workSheet.Cells[5, 11, 5, 12].Merge = true;
            workSheet.Cells[5, 11].Value = "LINEA: ";
            workSheet.Cells[5, 13, 5, 14].Merge = true;
            workSheet.Cells[5, 13].Value = nom_linea;
            workSheet.Cells[7, 2].Value = "FECHA:";
            workSheet.Cells[7, 3].Value = fecha;
            workSheet.Cells[7, 7, 7, 10].Merge = true;
            workSheet.Cells[7, 7].Value = "RESPONSABLE DE REGISTRO: ";
            workSheet.Cells[7, 11, 7, 13].Merge = true;
            workSheet.Cells[7, 11].Value = Nombres_Registro;

            workSheet.Cells[9, 2, 9, 21].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[9, 2, 9, 21].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 102));
            workSheet.Cells[9, 3].Value = "HORA";
            workSheet.Cells[9, 4].Value = "Min Disp";
            workSheet.Cells[9, 5].Value = "Min Efec";
            workSheet.Cells[9, 6].Value = "ESTANDAR (PZAS/HR) RH / LH";

            workSheet.Cells[9, 7, 9, 8].Merge = true;
            workSheet.Cells[9, 7].Value = "PRODUCCIÓN RH REAL LH";

            workSheet.Cells[9, 9, 9, 11].Merge = true;
            workSheet.Cells[9, 9].Value = "PRODUCCIÓN ACUMULADA";

            workSheet.Cells[9, 12, 9, 14].Merge = true;
            workSheet.Cells[9, 12].Value = "DIFERENCIA";
            workSheet.Cells[9, 15].Value = "SCRAP RH";
            workSheet.Cells[9, 16].Value = "SCRAP LH";
            workSheet.Cells[9, 17].Value = "TIEMPO DE PARO";
            workSheet.Cells[9, 18].Value = "CAUSA DE PARO";
            workSheet.Cells[9, 19].Value = "CELDA #";
            workSheet.Cells[9, 20].Value = "FOLIO ORDEN DE TRABAJO";
            workSheet.Cells[9, 21].Value = "ATENDIDO POR";
            for (int i = 2; i <= 21; i++)
            {
                workSheet.Cells[9, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[9, i].Style.WrapText = true;
                workSheet.Cells[9, i].Style.Font.Bold = true;
                workSheet.Cells[9, i].Style.Font.Color.SetColor(Color.White);
            }
            List<string> horas1 = new List<string>() {"7:00", "8:00", "8:00", "9:00", "9:00", "10:00", "10:00",
                                                    "11:00","11:00","12:00","12:00","13:00","13:00","14:00","14:00",
                                                    "15:00","15:00","16:00","16:00","17:00","17:00","18:00","18:00",
                                                    "19:00","19:00","20:00","20:00","21:00","21:00","22:00","22:00",
                                                    "22:30","22:30","23:00","23:00","0:00","0:00","1:00","1:00",
                                                    "2:00","2:00","15:00","15:00","16:00","16:00","17:00","17:00","18:00","18:00","19:00"};
            List<string> horas2 = new List<string>(){"7:00:00 AM","8:00:00 AM","8:00:00 AM","9:00:00 AM","9:00:00 AM","10:00:00 AM","10:00:00 AM"
                                                    ,"11:00:00 AM","11:00:00 AM","12:00:00 PM","12:00:00 PM","1:00:00 PM","1:00:00 PM"
                                                    ,"2:00:00 PM","2:00:00 PM","3:00:00 PM","3:00:00 PM","4:00:00 PM","4:00:00 PM"
                                                    ,"5:00:00 PM","5:00:00 PM","6:00:00 PM","6:00:00 PM","7:00:00 PM","7:00:00 PM"
                                                    ,"8:00:00 PM","8:00:00 PM","9:00:00 PM","9:00:00 PM","10:00:00 PM","10:00:00 PM"
                                                    ,"10:30:00 PM","10:30:00 PM","11:00:00 PM","11:00:00 PM","12:00:00 AM","12:00:00 AM"
                                                    ,"1:00:00 AM","1:00:00 AM","2:00:00 AM","2:00:00 AM","3:00:00 PM","3:00:00 PM"
                                                    ,"4:00:00 PM","4:00:00 PM","5:00:00 PM","5:00:00 PM","6:00:00 PM","6:00:00 AM","7:00:00 AM"};

            for (int i = 10; i <= 59; i += 2)
            {
                workSheet.Row(i).Height = 11;
                workSheet.Row(i + 1).Height = 11;
                workSheet.Cells[i, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[i + 1, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i < 41)
                {
                    workSheet.Cells[i, 2].Value = fecha + " " + horas1[(i - 10)];
                    workSheet.Cells[i + 1, 2].Value = fecha + " " + horas1[(i - 10) + 1];
                }
                else
                {
                    if (i == 41)
                    {
                        workSheet.Cells[i, 2].Value = fecha + " " + horas1[(i - 10)];
                        workSheet.Cells[i + 1, 2].Value = fecha2 + " " + horas1[(i - 10) + 1];
                    }
                    else
                    {
                        workSheet.Cells[i, 2].Value = fecha2 + " " + horas1[(i - 10)];
                        workSheet.Cells[i + 1, 2].Value = fecha2 + " " + horas1[(i - 10) + 1];
                    }
                }
            }

            for (int i = 10; i <= 59; i += 2)
            {
                workSheet.Cells[i, 3, i + 1, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[i, 3].Value = horas2[(i - 10)];
                workSheet.Cells[i + 1, 3].Value = horas2[(i - 10) + 1];
            }


            double SumEstandarPzas = 0.0;

            //MinDisp
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 4, j + 1, 4].Merge = true;
                workSheet.Cells[j, 4, j + 1, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 4].Value = MinDisp[i];
            }
            //MinEfec
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 5, j + 1, 5].Merge = true;
                workSheet.Cells[j, 5, j + 1, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 5].Value = MinEfec[i];
            }
            //EstandarPzas
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 6, j + 1, 6].Merge = true;
                workSheet.Cells[j, 6, j + 1, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                //Calcular Valores
                EstandarPzas.Add((double)MinEfec[i] / (double)Man_Time);
                SumEstandarPzas += EstandarPzas[EstandarPzas.Count - 1];
                if ((EstandarPzas[EstandarPzas.Count - 1] - Convert.ToInt32(EstandarPzas[EstandarPzas.Count - 1])) >= 0.5)
                {
                    workSheet.Cells[j, 6].Value = Convert.ToInt32(EstandarPzas[EstandarPzas.Count - 1]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 6].Value = Convert.ToInt32(EstandarPzas[EstandarPzas.Count - 1]);
                }

            }
            //ProduccionReal
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 7, j + 1, 7].Merge = true;
                workSheet.Cells[j, 7, j + 1, 7].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[j, 8, j + 1, 8].Merge = true;
                workSheet.Cells[j, 8, j + 1, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                //Calcular Valores
                workSheet.Cells[j, 7].Value = Produccion_Real_2_1[i];
                workSheet.Cells[j, 8].Value = Produccion_Real_2_2[i];
            }
            //ProduccionAcumulada
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 9, j + 1, 9].Merge = true;
                workSheet.Cells[j, 10, j + 1, 10].Merge = true;
                workSheet.Cells[j, 11, j + 1, 11].Merge = true;
                workSheet.Cells[j, 9, j + 1, 11].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                //Calcular dos valores
                if (i == 0)
                {
                    Produccion_Acumulada_2_1.Add((double)Produccion_Real_2_1[0]);
                    Produccion_Acumulada_2_2.Add((double)Produccion_Real_2_2[0]);
                    Produccion_Acumulada_2_3.Add(EstandarPzas[0]);
                }
                else
                {
                    Produccion_Acumulada_2_1.Add(Produccion_Acumulada_2_1[i - 1] + (double)Produccion_Real_2_1[i]);
                    Produccion_Acumulada_2_2.Add(Produccion_Acumulada_2_2[i - 1] + (double)Produccion_Real_2_2[i]);
                    Produccion_Acumulada_2_3.Add(Produccion_Acumulada_2_3[i - 1] + EstandarPzas[i]);
                }
                if ((Produccion_Acumulada_2_1[i] - Convert.ToInt32(Produccion_Acumulada_2_1[i])) >= 0.5)
                {
                    workSheet.Cells[j, 9].Value = Convert.ToInt32(Produccion_Acumulada_2_1[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 9].Value = Convert.ToInt32(Produccion_Acumulada_2_1[i]);
                }
                if ((Produccion_Acumulada_2_2[i] - Convert.ToInt32(Produccion_Acumulada_2_2[i])) >= 0.5)
                {
                    workSheet.Cells[j, 10].Value = Convert.ToInt32(Produccion_Acumulada_2_2[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 10].Value = Convert.ToInt32(Produccion_Acumulada_2_2[i]);
                }
                if ((Produccion_Acumulada_2_3[i] - Convert.ToInt32(Produccion_Acumulada_2_3[i])) >= 0.5)
                {
                    workSheet.Cells[j, 11].Value = Convert.ToInt32(Produccion_Acumulada_2_3[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 11].Value = Convert.ToInt32(Produccion_Acumulada_2_3[i]);
                }


            }
            //Diferencia
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 12, j + 1, 12].Merge = true;
                workSheet.Cells[j, 13, j + 1, 13].Merge = true;
                workSheet.Cells[j, 14, j + 1, 14].Merge = true;
                workSheet.Cells[j, 12, j + 1, 14].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                //Calcular dos valores
                Diferencia_2_1.Add(Produccion_Real_2_1[i] - EstandarPzas[i]);
                Diferencia_2_2.Add(Produccion_Real_2_2[i] - EstandarPzas[i]);
                if (i == 0)
                {
                    Diferencia_2_3.Add(Diferencia_2_2[0]);
                }
                else
                {
                    Diferencia_2_3.Add(Diferencia_2_2[i] + Diferencia_2_3[i - 1]);
                }

                if (Diferencia_2_1[i] < 0)
                {
                    workSheet.Cells[j, 12].Style.Font.Color.SetColor(Color.Red);
                }
                if (Diferencia_2_2[i] < 0)
                {
                    workSheet.Cells[j, 13].Style.Font.Color.SetColor(Color.Red);
                }
                if (Diferencia_2_3[i] < 0)
                {
                    workSheet.Cells[j, 14].Style.Font.Color.SetColor(Color.Red);
                }

                if (Math.Abs(Diferencia_2_1[i] - Convert.ToInt32(Diferencia_2_1[i])) >= 0.5)
                {
                    workSheet.Cells[j, 12].Value = Convert.ToInt32(Diferencia_2_1[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 12].Value = Convert.ToInt32(Diferencia_2_1[i]);
                }
                if (Math.Abs(Diferencia_2_2[i] - Convert.ToInt32(Diferencia_2_2[i])) >= 0.5)
                {
                    workSheet.Cells[j, 13].Value = Convert.ToInt32(Diferencia_2_2[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 13].Value = Convert.ToInt32(Diferencia_2_2[i]);
                }
                if (Math.Abs(Diferencia_2_3[i] - Convert.ToInt32(Diferencia_2_3[i])) >= 0.5)
                {
                    workSheet.Cells[j, 14].Value = Convert.ToInt32(Diferencia_2_3[i]) + 1;
                }
                else
                {
                    workSheet.Cells[j, 14].Value = Convert.ToInt32(Diferencia_2_3[i]);
                }
            }
            //SCRAP RH
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 15, j + 1, 15].Merge = true;
                workSheet.Cells[j, 15, j + 1, 15].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 15].Value = Scrap_2_1[i];
            }
            //SCRAP LH
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 16, j + 1, 16].Merge = true;
                workSheet.Cells[j, 16, j + 1, 16].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 16].Value = Scrap_2_2[i];
            }
            //Tiempo de Paro
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 17, j + 1, 17].Merge = true;
                workSheet.Cells[j, 17, j + 1, 17].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 17].Value = Tiempo[i];
            }

            //CausaDeParo
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 18, j + 1, 18].Merge = true;
                workSheet.Cells[j, 18, j + 1, 18].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 18].Style.WrapText = true;
                workSheet.Cells[j, 18].Value = Causa[i];
            }
            //CELDA
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 19, j + 1, 19].Merge = true;
                workSheet.Cells[j, 19, j + 1, 19].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 19].Style.WrapText = true;
                workSheet.Cells[j, 19].Value = Celda[i];
            }
            //Folio Orden de Trabajo
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 20, j + 1, 20].Merge = true;
                workSheet.Cells[j, 20, j + 1, 20].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 20].Value = Folio[i];
            }
            //Atendido por 
            for (int i = 0, j = 10; i <= 25; i++, j += 2)
            {
                workSheet.Cells[j, 21, j + 1, 21].Merge = true;
                workSheet.Cells[j, 17, j + 1, 21].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (i == 25)
                {
                    break;
                }
                workSheet.Cells[j, 21].Style.WrapText = true;
                workSheet.Cells[j, 21].Value = AtendidoPor[i];
            }

            int SumMinDisp = MinDisp.Sum();
            int SumMinEfec = MinEfec.Sum();
            int SumProduccionReal_1 = Produccion_Real_2_1.Sum();
            int SumProduccionReal_2 = Produccion_Real_2_2.Sum();

            workSheet.Cells[60, 2, 61, 3].Merge = true;
            workSheet.Cells[60, 2, 61, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[60, 2, 61, 3].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 102));
            workSheet.Cells[60, 2].Value = "TOTAL";
            workSheet.Cells[60, 2].Style.Font.Color.SetColor(Color.White);
            workSheet.Cells[60, 4].Value = SumMinDisp;
            workSheet.Cells[60, 5].Value = SumMinEfec;
            if (SumEstandarPzas - Convert.ToInt32(SumEstandarPzas) >= 0.5)
            {
                workSheet.Cells[60, 6].Value = Convert.ToInt32(SumEstandarPzas) + 1;
            }
            else
            {
                workSheet.Cells[60, 6].Value = Convert.ToInt32(SumEstandarPzas);
            }

            workSheet.Cells[60, 7].Value = SumProduccionReal_1;
            workSheet.Cells[60, 8].Value = SumProduccionReal_2;

            double pph1_1, pph1_2, pph1_3, pph2_1, pph2_2, pph2_3;
            double sum = 0.0, sum2 = 0.0, sum3 = 0.0;
            for (int i = 0; i < 8; i++)
            {
                sum += MinEfec[i];
                sum2 += Produccion_Real_2_1[i];
                sum3 += Produccion_Real_2_2[i];
            }
            workSheet.Cells[63, 5].Value = sum / 60;
            workSheet.Cells[63, 7].Value = sum2;
            workSheet.Cells[63, 8].Value = sum3;
            pph1_1 = sum2 / (sum / 60);
            pph2_1 = sum3 / (sum / 60);

            sum = 0.0;
            sum2 = 0.0;
            sum3 = 0.0;
            for (int i = 8; i < 16; i++)
            {
                sum += MinEfec[i];
                sum2 += Produccion_Real_2_1[i];
                sum3 += Produccion_Real_2_2[i];
            }
            workSheet.Cells[64, 5].Value = sum / 60;
            workSheet.Cells[64, 7].Value = sum2;
            workSheet.Cells[64, 8].Value = sum3;
            pph1_2 = sum2 / (sum / 60);
            pph2_2 = sum3 / (sum / 60);
            sum = 0.0;
            sum2 = 0.0;
            sum3 = 0.0;
            for (int i = 16; i < 25; i++)
            {
                sum += MinEfec[i];
                sum2 += Produccion_Real_2_1[i];
                sum3 += Produccion_Real_2_2[i];
            }
            workSheet.Cells[65, 5].Value = sum / 60;
            workSheet.Cells[65, 7].Value = sum2;
            workSheet.Cells[65, 8].Value = sum3;
            pph1_3 = sum2 / (sum / 60);
            pph2_3 = sum3 / (sum / 60);

            workSheet.Cells[62, 9].Value = "PPRH";
            workSheet.Cells[62, 10].Value = "PPLH";

            if (pph1_1 - Convert.ToInt32(pph1_1) >= 0.5)
            {
                workSheet.Cells[63, 9].Value = Convert.ToInt32(pph1_1) + 1;
            }
            else
            {
                workSheet.Cells[63, 9].Value = Convert.ToInt32(pph1_1);
            }
            if (pph1_2 - Convert.ToInt32(pph1_2) >= 0.5)
            {
                workSheet.Cells[64, 9].Value = Convert.ToInt32(pph1_2) + 1;
            }
            else
            {
                workSheet.Cells[64, 9].Value = Convert.ToInt32(pph1_2);
            }
            if (pph1_3 - Convert.ToInt32(pph1_3) >= 0.5)
            {
                workSheet.Cells[65, 9].Value = Convert.ToInt32(pph1_3) + 1;
            }
            else
            {
                workSheet.Cells[65, 9].Value = Convert.ToInt32(pph1_3);
            }

            if (pph2_1 - Convert.ToInt32(pph2_1) >= 0.5)
            {
                workSheet.Cells[63, 10].Value = Convert.ToInt32(pph2_1) + 1;
            }
            else
            {
                workSheet.Cells[63, 10].Value = Convert.ToInt32(pph2_1);
            }
            if (pph2_2 - Convert.ToInt32(pph2_2) >= 0.5)
            {
                workSheet.Cells[64, 10].Value = Convert.ToInt32(pph2_2) + 1;
            }
            else
            {
                workSheet.Cells[64, 10].Value = Convert.ToInt32(pph2_2);
            }
            if (pph2_3 - Convert.ToInt32(pph2_3) >= 0.5)
            {
                workSheet.Cells[65, 10].Value = Convert.ToInt32(pph2_3) + 1;
            }
            else
            {
                workSheet.Cells[65, 10].Value = Convert.ToInt32(pph2_3);
            }

            //LOGO
            string conn = "Data Source = 172.25.10.90\\FYPAPP; Initial Catalog = FYP_Soldadura_ETE; User ID = prensas; Password = Fypprensas; MultipleActiveResultSets = true;";
            using (SqlConnection cnn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT img FROM Logo WHERE Id_Logo = 1";
                cnn.Open();
                byte[] Logo = (Byte[])cmd.ExecuteScalar();
                using (var mslogo = new MemoryStream(Logo, 0, Logo.Length))
                {
                    System.Drawing.Image imagelogo = System.Drawing.Image.FromStream(mslogo, true);
                    var excelImagelogo = workSheet.Drawings.AddPicture("Logo", imagelogo);
                    excelImagelogo.SetSize(90, 70);
                    excelImagelogo.SetPosition(5, 5);
                }
                cnn.Close();
            }

            return;
        }

        public void Tabla_General(ref ExcelWorksheet workSheet)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            workSheet.Cells[3, 2, 19, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[3, 2, 19, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
            workSheet.Cells[1, 2, 1, 4].Merge = true;
            workSheet.Cells[1, 2].Style.Font.Color.SetColor(Color.White);
            workSheet.Cells[1, 2].Value = "EFECTIVIDAD TOTAL DE EQUIPO";
            for (int i = 1; i <= 100; i++)
            {
                workSheet.Row(i).Height = 15.0;
                for (int j = 1; j <= 50; j++)
                {
                    workSheet.Cells[i, j].Style.Font.Size = 10;
                }
            }
            List<string> turnos = new List<string>() { "1° Turno", "2° Turno", "3° Turno", "Total" };
            for (int i = 0; i < 4; i++)
            {
                workSheet.Cells[21 + (i * 4), 4].Value = turnos[i];
                workSheet.Cells[21 + (i * 4), 4].Style.Font.Color.SetColor(Color.White);
                workSheet.Cells[21 + (i * 4), 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[21 + (i * 4), 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 0));
                workSheet.Cells[22 + (i * 4), 4].Value = "Plan de Producción";
                workSheet.Cells[23 + (i * 4), 4].Value = "Produccíón Real";
                workSheet.Cells[24 + (i * 4), 4].Value = "Diferencia";
                workSheet.Cells[22 + (i * 4), 4].Style.Font.Color.SetColor(Color.White);
                workSheet.Cells[23 + (i * 4), 4].Style.Font.Color.SetColor(Color.White);
                workSheet.Cells[24 + (i * 4), 4].Style.Font.Color.SetColor(Color.White);
                workSheet.Cells[22 + (i * 4), 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[22 + (i * 4), 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
                workSheet.Cells[23 + (i * 4), 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[23 + (i * 4), 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
                workSheet.Cells[24 + (i * 4), 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[24 + (i * 4), 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
            }

            char let = 'A';
            List<string> conceptos = new List<string>() { "Tiempo Disponible (min)", "Tiempo de Comunicación (min)", "Tiempo de Trabajo Planeado (min)", "Tiempo de Paro Planeado (min)", "Tiempo de Paro No Planeado (min)", "Tiempo de Trabajo Real (min)", "Producción (pz ok)"
                                                         , "Scrap (pz)", "Tiempo ciclo (seg)", "Disponibilidad (%)", "Desempeño (%)", "Calidad (%)", "Efectividad Total de Equipo (%)", "PPH con Paros ", "PPH sin paros", "PPH objetivo"};
            List<string> formulas = new List<string>() { "", "", "", "", "", "C - E", "", "", "", "F / C", "I / [(F*60) / G]", "(G - H) / G", "L * K * J", "G / (A / 60)", "G / (F / 60)", "" };
            for (int i = 4; i <= 19; i++)
            {
                workSheet.Cells[i, 2].Value = let++;
                workSheet.Cells[i, 3].Value = conceptos[i - 4];
                workSheet.Cells[i, 4].Value = formulas[i - 4];
                workSheet.Cells[i, 2].Style.Font.Bold = true;
                workSheet.Cells[i, 2].Style.Font.Color.SetColor(Color.White);
                workSheet.Cells[i, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[i, 3].Style.Font.Bold = true;
                workSheet.Cells[i, 3].Style.Font.Color.SetColor(Color.White);
                workSheet.Cells[i, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                workSheet.Cells[i, 4].Style.Font.Bold = true;
                workSheet.Cells[i, 4].Style.Font.Color.SetColor(Color.White);
                workSheet.Cells[i, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);
            }
            workSheet.Cells[3, 2].Style.Font.Bold = true;
            workSheet.Cells[3, 2].Style.Font.Color.SetColor(Color.White);
            workSheet.Cells[3, 4].Style.Font.Bold = true;
            workSheet.Cells[3, 4].Style.Font.Color.SetColor(Color.White);
            workSheet.Cells[3, 2, 3, 3].Merge = true;
            workSheet.Cells[3, 2].Value = "CONCEPTOS";
            workSheet.Cells[3, 2, 3, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);
            workSheet.Cells[3, 4].Value = "FORMULAS";
            workSheet.Cells[3, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);

            int pos_act = 5;
            int pos_ini = 5;
            string proyecto_act = datos_lineas[0].proyecto;
            for (int i = 0; i < datos_lineas.Count; i++)
            {
                if (datos_lineas[i].proyecto != proyecto_act)
                {
                    workSheet.Cells[2, pos_ini, 2, pos_act - 1].Merge = true;
                    workSheet.Cells[2, pos_ini, 2, pos_act - 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.White);
                    workSheet.Cells[2, pos_ini, 2, pos_act - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[2, pos_ini, 2, pos_act - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 0));
                    workSheet.Cells[2, pos_ini].Value = proyecto_act;
                    workSheet.Cells[2, pos_ini].Style.Font.Color.SetColor(Color.White);
                    pos_ini = pos_act;
                    proyecto_act = datos_lineas[i].proyecto;
                }
                if (datos_lineas[i].tipo == "Ordinaria")
                {
                    for (int j = 3; j <= 19; j++)
                    {
                        workSheet.Cells[j, pos_act].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        workSheet.Cells[j, pos_act].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(191, 191, 191));
                        workSheet.Cells[j, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                    workSheet.Cells[3, pos_act].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[3, pos_act].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
                    workSheet.Cells[3, pos_act].Style.Font.Color.SetColor(Color.White);
                    workSheet.Cells[16, pos_act].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[16, pos_act].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
                    workSheet.Cells[16, pos_act].Style.Font.Color.SetColor(Color.White);
                    workSheet.Cells[18, pos_act].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[18, pos_act].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 204, 0));
                    workSheet.Cells[18, pos_act].Style.Font.Color.SetColor(Color.Red);

                    workSheet.Cells[3, pos_act].Value = datos_lineas[i].nombre_linea;
                    workSheet.Cells[4, pos_act].Value = datos_lineas[i].A;
                    workSheet.Cells[5, pos_act].Value = datos_lineas[i].B;
                    workSheet.Cells[6, pos_act].Value = datos_lineas[i].C;
                    workSheet.Cells[7, pos_act].Value = datos_lineas[i].D;
                    workSheet.Cells[8, pos_act].Value = datos_lineas[i].E;
                    workSheet.Cells[9, pos_act].Value = datos_lineas[i].F;
                    workSheet.Cells[10, pos_act].Value = datos_lineas[i].G;
                    workSheet.Cells[11, pos_act].Value = datos_lineas[i].H;
                    workSheet.Cells[12, pos_act].Value = datos_lineas[i].I;
                    string tem = "";
                    if (datos_lineas[i].J == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].J * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[13, pos_act].Value = tem;
                    if (datos_lineas[i].K == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].K * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[14, pos_act].Value = tem;
                    if (datos_lineas[i].L == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].L * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[15, pos_act].Value = tem;
                    if (datos_lineas[i].M == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].M * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[16, pos_act].Value = tem;
                    if (datos_lineas[i].N == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round(datos_lineas[i].N, 2).ToString();
                    }
                    workSheet.Cells[17, pos_act].Value = tem;
                    if (datos_lineas[i].O == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round(datos_lineas[i].O, 2).ToString();
                    }
                    workSheet.Cells[18, pos_act].Value = tem;
                    if (datos_lineas[i].P == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = datos_lineas[i].P.ToString();
                    }
                    workSheet.Cells[19, pos_act].Value = tem;
                    int sum1 = 0, sum2 = 0, sum3 = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        sum1 += datos_lineas[i].produccion_real[j];
                    }
                    for (int j = 8; j < 16; j++)
                    {
                        sum2 += datos_lineas[i].produccion_real[j];
                    }
                    for (int j = 16; j < 25; j++)
                    {
                        sum3 += datos_lineas[i].produccion_real[j];
                    }
                    workSheet.Cells[22, pos_act].Value = datos_lineas[i].planrh1;
                    workSheet.Cells[26, pos_act].Value = datos_lineas[i].planrh2;
                    workSheet.Cells[30, pos_act].Value = datos_lineas[i].planrh3;
                    workSheet.Cells[34, pos_act].Value = datos_lineas[i].planrh1 + datos_lineas[i].planrh2 + datos_lineas[i].planrh3;
                    workSheet.Cells[22, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[26, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[30, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[34, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    workSheet.Cells[23, pos_act].Value = sum1;
                    workSheet.Cells[23, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[27, pos_act].Value = sum2;
                    workSheet.Cells[27, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[31, pos_act].Value = sum3;
                    workSheet.Cells[31, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[35, pos_act].Value = sum1 + sum2 + sum3;
                    workSheet.Cells[35, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    int difrh1 = sum1 - datos_lineas[i].planrh1;
                    int difrh2 = sum2 - datos_lineas[i].planrh2;
                    int difrh3 = sum3 - datos_lineas[i].planrh3;
                    int difrtot = (sum1 + sum2 + sum3) - (datos_lineas[i].planrh1 + datos_lineas[i].planrh2 + datos_lineas[i].planrh3);
                    workSheet.Cells[24, pos_act].Value = difrh1;
                    workSheet.Cells[28, pos_act].Value = difrh2;
                    workSheet.Cells[32, pos_act].Value = difrh3;
                    workSheet.Cells[36, pos_act].Value = difrtot;
                    if (difrh1 < 0)
                    {
                        workSheet.Cells[24, pos_act].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[24, pos_act].Style.Font.Color.SetColor(Color.Green);
                    }
                    if (difrh2 < 0)
                    {
                        workSheet.Cells[28, pos_act].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[28, pos_act].Style.Font.Color.SetColor(Color.Green);
                    }
                    if (difrh3 < 0)
                    {
                        workSheet.Cells[32, pos_act].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[32, pos_act].Style.Font.Color.SetColor(Color.Green);
                    }
                    if (difrtot < 0)
                    {
                        workSheet.Cells[36, pos_act].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[36, pos_act].Style.Font.Color.SetColor(Color.Green);
                    }
                    workSheet.Cells[24, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[28, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[32, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[36, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    pos_act++;
                }
                else
                {
                    for (int j = 3; j <= 19; j++)
                    {
                        workSheet.Cells[j, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        workSheet.Cells[j, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        workSheet.Cells[j, pos_act].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        workSheet.Cells[j, pos_act].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(191, 191, 191));
                        workSheet.Cells[j, pos_act + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        workSheet.Cells[j, pos_act + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(191, 191, 191));
                    }
                    for (int j = 3; j <= 9; j++)
                    {
                        workSheet.Cells[j, pos_act, j, pos_act + 1].Merge = true;
                        workSheet.Cells[j, pos_act, j, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                    workSheet.Cells[12, pos_act, 12, pos_act + 1].Merge = true;
                    workSheet.Cells[12, pos_act, 12, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[13, pos_act, 13, pos_act + 1].Merge = true;
                    workSheet.Cells[13, pos_act, 13, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[3, pos_act].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[3, pos_act].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
                    workSheet.Cells[3, pos_act].Style.Font.Color.SetColor(Color.White);
                    workSheet.Cells[16, pos_act].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[16, pos_act].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
                    workSheet.Cells[16, pos_act].Style.Font.Color.SetColor(Color.White);
                    workSheet.Cells[16, pos_act + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[16, pos_act + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));
                    workSheet.Cells[16, pos_act + 1].Style.Font.Color.SetColor(Color.White);
                    workSheet.Cells[18, pos_act].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[18, pos_act].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 204, 0));
                    workSheet.Cells[18, pos_act].Style.Font.Color.SetColor(Color.Red);
                    workSheet.Cells[18, pos_act + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[18, pos_act + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 204, 0));
                    workSheet.Cells[18, pos_act + 1].Style.Font.Color.SetColor(Color.Red);


                    workSheet.Cells[3, pos_act].Value = datos_lineas[i].nombre_linea;
                    workSheet.Cells[4, pos_act].Value = datos_lineas[i].A;
                    workSheet.Cells[5, pos_act].Value = datos_lineas[i].B;
                    workSheet.Cells[6, pos_act].Value = datos_lineas[i].C;
                    workSheet.Cells[7, pos_act].Value = datos_lineas[i].D;
                    workSheet.Cells[8, pos_act].Value = datos_lineas[i].E;
                    workSheet.Cells[9, pos_act].Value = datos_lineas[i].F;
                    workSheet.Cells[10, pos_act].Value = datos_lineas[i].G1;
                    workSheet.Cells[10, pos_act + 1].Value = datos_lineas[i].G2;
                    workSheet.Cells[11, pos_act].Value = datos_lineas[i].H1;
                    workSheet.Cells[11, pos_act + 1].Value = datos_lineas[i].H2;
                    workSheet.Cells[12, pos_act].Value = datos_lineas[i].I;
                    string tem = "";
                    if (datos_lineas[i].J == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].J * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[13, pos_act].Value = tem;
                    if (datos_lineas[i].K1 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].K1 * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[14, pos_act].Value = tem;
                    if (datos_lineas[i].K2 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].K2 * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[14, pos_act + 1].Value = tem;
                    if (datos_lineas[i].L1 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].L1 * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[15, pos_act].Value = tem;
                    if (datos_lineas[i].L2 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].L2 * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[15, pos_act + 1].Value = tem;
                    if (datos_lineas[i].M1 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].M1 * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[16, pos_act].Value = tem;
                    if (datos_lineas[i].M2 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round((datos_lineas[i].M2 * 100), 2).ToString() + "%";
                    }
                    workSheet.Cells[16, pos_act + 1].Value = tem;
                    if (datos_lineas[i].N1 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round(datos_lineas[i].N1, 2).ToString();
                    }
                    workSheet.Cells[17, pos_act].Value = tem;
                    if (datos_lineas[i].N2 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round(datos_lineas[i].N2, 2).ToString();
                    }
                    workSheet.Cells[17, pos_act + 1].Value = tem;
                    if (datos_lineas[i].O1 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round(datos_lineas[i].O1, 2).ToString();
                    }
                    workSheet.Cells[18, pos_act].Value = tem;
                    if (datos_lineas[i].O2 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = Math.Round(datos_lineas[i].O2, 2).ToString();
                    }
                    workSheet.Cells[18, pos_act + 1].Value = tem;
                    if (datos_lineas[i].P1 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = datos_lineas[i].P1.ToString();
                    }
                    workSheet.Cells[19, pos_act].Value = tem;
                    if (datos_lineas[i].P2 == -1)
                    {
                        tem = "#DIV/0!";
                    }
                    else
                    {
                        tem = datos_lineas[i].P2.ToString();
                    }
                    workSheet.Cells[19, pos_act + 1].Value = tem;

                    workSheet.Cells[21, pos_act].Value = "RH";
                    workSheet.Cells[21, pos_act + 1].Value = "LH";
                    workSheet.Cells[21, pos_act].Style.Font.Color.SetColor(Color.White);
                    workSheet.Cells[21, pos_act + 1].Style.Font.Color.SetColor(Color.White);
                    workSheet.Cells[21, pos_act].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[21, pos_act].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 102));
                    workSheet.Cells[21, pos_act + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[21, pos_act + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 102));
                    int sum1 = 0, sum2 = 0, sum3 = 0, sum1_2 = 0, sum2_2 = 0, sum3_2 = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        sum1 += datos_lineas[i].produccion_real1[j];
                        sum1_2 += datos_lineas[i].produccion_real2[j];
                    }
                    for (int j = 8; j < 16; j++)
                    {
                        sum2 += datos_lineas[i].produccion_real1[j];
                        sum2_2 += datos_lineas[i].produccion_real2[j];
                    }
                    for (int j = 16; j < 25; j++)
                    {
                        sum3 += datos_lineas[i].produccion_real1[j];
                        sum3_2 += datos_lineas[i].produccion_real2[j];
                    }

                    workSheet.Cells[22, pos_act].Value = datos_lineas[i].planrh1;
                    workSheet.Cells[26, pos_act].Value = datos_lineas[i].planrh2;
                    workSheet.Cells[30, pos_act].Value = datos_lineas[i].planrh3;
                    workSheet.Cells[34, pos_act].Value = datos_lineas[i].planrh1 + datos_lineas[i].planrh2 + datos_lineas[i].planrh3;
                    workSheet.Cells[22, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[26, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[30, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[34, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    workSheet.Cells[22, pos_act + 1].Value = datos_lineas[i].planlh1;
                    workSheet.Cells[26, pos_act + 1].Value = datos_lineas[i].planlh2;
                    workSheet.Cells[30, pos_act + 1].Value = datos_lineas[i].planlh3;
                    workSheet.Cells[34, pos_act + 1].Value = datos_lineas[i].planlh1 + datos_lineas[i].planlh2 + datos_lineas[i].planlh3;
                    workSheet.Cells[22, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[26, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[30, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[34, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    workSheet.Cells[23, pos_act].Value = sum1;
                    workSheet.Cells[23, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[27, pos_act].Value = sum2;
                    workSheet.Cells[27, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[31, pos_act].Value = sum3;
                    workSheet.Cells[31, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[35, pos_act].Value = sum1 + sum2 + sum3;
                    workSheet.Cells[35, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[23, pos_act + 1].Value = sum1_2;
                    workSheet.Cells[23, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[27, pos_act + 1].Value = sum2_2;
                    workSheet.Cells[27, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[31, pos_act + 1].Value = sum3_2;
                    workSheet.Cells[31, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[35, pos_act + 1].Value = sum1_2 + sum2_2 + sum3_2;
                    workSheet.Cells[35, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    int difrh1 = sum1 - datos_lineas[i].planrh1;
                    int difrh2 = sum2 - datos_lineas[i].planrh2;
                    int difrh3 = sum3 - datos_lineas[i].planrh3;
                    int difrtot = (sum1 + sum2 + sum3) - (datos_lineas[i].planrh1 + datos_lineas[i].planrh2 + datos_lineas[i].planrh3);
                    workSheet.Cells[24, pos_act].Value = difrh1;
                    workSheet.Cells[28, pos_act].Value = difrh2;
                    workSheet.Cells[32, pos_act].Value = difrh3;
                    workSheet.Cells[36, pos_act].Value = difrtot;
                    if (difrh1 < 0)
                    {
                        workSheet.Cells[24, pos_act].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[24, pos_act].Style.Font.Color.SetColor(Color.Green);
                    }
                    if (difrh2 < 0)
                    {
                        workSheet.Cells[28, pos_act].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[28, pos_act].Style.Font.Color.SetColor(Color.Green);
                    }
                    if (difrh3 < 0)
                    {
                        workSheet.Cells[32, pos_act].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[32, pos_act].Style.Font.Color.SetColor(Color.Green);
                    }
                    if (difrtot < 0)
                    {
                        workSheet.Cells[36, pos_act].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[36, pos_act].Style.Font.Color.SetColor(Color.Green);
                    }
                    workSheet.Cells[24, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[28, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[32, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[36, pos_act].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    int diflh1 = sum1_2 - datos_lineas[i].planlh1;
                    int diflh2 = sum2_2 - datos_lineas[i].planlh2;
                    int diflh3 = sum3_2 - datos_lineas[i].planlh3;
                    int difltot = (sum1_2 + sum2_2 + sum3_2) - (datos_lineas[i].planlh1 + datos_lineas[i].planlh2 + datos_lineas[i].planlh3);
                    workSheet.Cells[24, pos_act + 1].Value = diflh1;
                    workSheet.Cells[28, pos_act + 1].Value = diflh2;
                    workSheet.Cells[32, pos_act + 1].Value = diflh3;
                    workSheet.Cells[36, pos_act + 1].Value = difltot;
                    if (diflh1 < 0)
                    {
                        workSheet.Cells[24, pos_act + 1].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[24, pos_act + 1].Style.Font.Color.SetColor(Color.Green);
                    }
                    if (diflh2 < 0)
                    {
                        workSheet.Cells[28, pos_act + 1].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[28, pos_act + 1].Style.Font.Color.SetColor(Color.Green);
                    }
                    if (diflh3 < 0)
                    {
                        workSheet.Cells[32, pos_act + 1].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[32, pos_act + 1].Style.Font.Color.SetColor(Color.Green);
                    }
                    if (difltot < 0)
                    {
                        workSheet.Cells[36, pos_act + 1].Style.Font.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[36, pos_act + 1].Style.Font.Color.SetColor(Color.Green);
                    }
                    workSheet.Cells[24, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[28, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[32, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[36, pos_act + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    pos_act += 2;
                }

            }
            workSheet.Cells[2, pos_ini, 2, pos_act - 1].Merge = true;
            workSheet.Cells[2, pos_ini, 2, pos_act - 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.White);
            workSheet.Cells[2, pos_ini, 2, pos_act - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[2, pos_ini, 2, pos_act - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 0));
            workSheet.Cells[2, pos_ini].Value = proyecto_act;
            workSheet.Cells[2, pos_ini].Style.Font.Color.SetColor(Color.White);

            workSheet.Cells[1, 2, 2, pos_act - 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[1, 2, 2, pos_act - 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 0));
            workSheet.Cells[1, 5, 1, pos_act - 1].Merge = true;
            workSheet.Cells[1, 5].Value = fecha_tabla.ToString();
            workSheet.Cells[1, 5].Style.Font.Color.SetColor(Color.White);
            workSheet.Cells[4, 4, 19, pos_act - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[4, 4, 19, pos_act - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[1, 1, 3, pos_act - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[1, 1, 3, pos_act - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            workSheet.Cells[20, 1, 37, pos_act - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[20, 1, 37, pos_act - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
            workSheet.Column(1).Width = 0.83;

            return;
        }

        public void Exportar(string [] NombresLlenoRegistro, DateTime Dia)
        {
            //Obtener Catalogo de Líneas
            List<Tuple<string, string>> lineas = new List<Tuple<string, string>>() { };
            List<string> proyectos = new List<string>();
            string conn = "Data Source = 172.25.10.90\\FYPAPP; Initial Catalog = FYP_Soldadura_ETE; User ID = prensas; Password = Fypprensas; MultipleActiveResultSets = true;";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                string query = "";

                query = "SELECT Lineas.Nombre, Lineas.Tipo_Linea, Proyectos.Proyecto FROM Lineas, Proyectos WHERE Lineas.FK_ID_Proyecto = Proyectos.ID_Proyecto";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nom = (string)reader["Nombre"];
                            string tipo = (string)reader["Tipo_Linea"];
                            proyectos.Add((string)reader["Proyecto"]);
                            tipo = tipo.Substring(0, 9);
                            lineas.Add(new Tuple<string, string>(nom, tipo));
                        }
                    }
                }
                con.Close();
            }


            int turnorh1, turnorh2, turnorh3, turnolh1, turnolh2, turnolh3;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excel = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
            {
                // name of the sheet 
                ExcelWorksheet workSheet1;
                //Fecha Solicitada 
                fecha_tabla = Dia.Date;
                workSheet1 = excel.Workbook.Worksheets.Add("ETE GENERAL");
                //Crear Excel de cada línea
                for (int i = 0; i < lineas.Count; i++)
                {
                    //Inicializar Variables        
                    InicializarListas();
                    nom_linea = lineas[i].Item1;
                    //Obtener MinDisp de la base de datos
                    MinDisp = new List<int>() { 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 30, 30, 60, 60, 60, 60, 60, 60, 60, 60 };

                    //Obtener MinEfec de la base de datos
                    MinEfec = new List<int>() { 50, 60, 60, 50, 30, 50, 60, 50, 50, 60, 60, 50, 30, 50, 60, 20, 20, 60, 60, 50, 60, 20, 60, 60, 50 };
                    //Obtener Man Time
                    Man_Time = 2.5;
                    //Obtener Tiempo de Paro
                    Tiempo = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    //Obtener Causas
                    Causa = new List<string>() { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    //Obtener Celdas
                    Celda = new List<string>() { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    //Obtener Folio de Trabajo
                    Folio = new List<string>() { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    //Obtener Atendido por
                    AtendidoPor = new List<string>() { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    //Obtener Lista Nombres Registros
                    Nombres_Registro = NombresLlenoRegistro[0]+" , "+ NombresLlenoRegistro[3]+" , "+ NombresLlenoRegistro[2];
                    if (lineas[i].Item2 == "Ordinaria")
                    {
                        //Obtener Produccion Real
                        Produccion_Real = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 7, 11, 13, 9, 23, 18, 3, 8, 4, 22, 12, 1, 24, 0, 0, 0, 0 };
                        //Obtener Scrap 
                        Scrap = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        //Obtener Plan Produccion por turno
                        turnorh1 = 0;
                        turnorh2 = 0;
                        turnorh3 = 0;
                        //No modificar esto
                        turnolh1 = 0;
                        turnolh2 = 0;
                        turnolh3 = 0;

                        workSheet1 = excel.Workbook.Worksheets.Add(lineas[i].Item1);
                        crear_Tabla_1(ref workSheet1);
                    }
                    else
                    {
                        //Obtener Produccion Real (RH y LH)
                        Produccion_Real_2_1 = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        Produccion_Real_2_2 = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        //Obtener Scrap RH
                        Scrap_2_1 = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        //Obtener Scrap LH
                        Scrap_2_2 = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        //Obtener Plan Produccion RH por turno
                        turnorh1 = 0;
                        turnorh2 = 0;
                        turnorh3 = 0;
                        //Obtener Plan Produccion LH por turno
                        turnolh1 = 0;
                        turnolh2 = 0;
                        turnolh3 = 0;

                        workSheet1 = excel.Workbook.Worksheets.Add(lineas[i].Item1);
                        crear_Tabla_2(ref workSheet1);
                    }

                    DatosLinea tem = new DatosLinea();
                    tem.planrh1 = turnorh1;
                    tem.planrh2 = turnorh2;
                    tem.planrh3 = turnorh3;
                    tem.planlh1 = turnolh1;
                    tem.planlh2 = turnolh2;
                    tem.planlh3 = turnolh3;

                    tem.proyecto = proyectos[i];
                    tem.nombre_linea = lineas[i].Item1;
                    tem.tipo = lineas[i].Item2;
                    tem.A = 1440;
                    tem.B = 40;
                    tem.C = MinEfec.Sum();
                    tem.D = 120;
                    tem.E = Tiempo.Sum();
                    tem.F = tem.C - tem.E;
                    if (lineas[i].Item2 == "Ordinaria")
                    {
                        tem.produccion_real = Produccion_Real;
                        tem.G = Produccion_Real.Sum();
                        tem.H = Scrap.Sum();
                    }
                    else
                    {
                        tem.produccion_real1 = Produccion_Real_2_1;
                        tem.produccion_real2 = Produccion_Real_2_2;
                        tem.G1 = Produccion_Real_2_1.Sum();
                        tem.G2 = Produccion_Real_2_2.Sum();
                        tem.H1 = Scrap_2_1.Sum();
                        tem.H2 = Scrap_2_2.Sum();
                    }
                    tem.I = Convert.ToInt32(Man_Time * 60.0 * 0.89);
                    tem.J = (double)tem.F / (double)tem.C;
                    if (lineas[i].Item2 == "Ordinaria")
                    {
                        if ((((double)tem.F * 60.0) / (double)tem.G) == 0)
                        {
                            tem.K = -1.0;
                        }
                        else
                        {
                            tem.K = (double)tem.I / (((double)tem.F * 60.0) / (double)tem.G);
                        }
                        if (tem.G == 0)
                        {
                            tem.L = -1.0;
                        }
                        else
                        {
                            tem.L = ((double)tem.G - (double)tem.H) / (double)tem.G;
                        }
                        tem.M = (double)tem.L * (double)tem.K * (double)tem.J;
                        if (tem.A == 0)
                        {
                            tem.N = -1.0;
                        }
                        else
                        {
                            tem.N = (double)tem.G / ((double)tem.A / 60);
                        }
                        if (tem.F == 0)
                        {
                            tem.O = -1.0;
                        }
                        else
                        {
                            tem.O = (double)tem.G / ((double)tem.F / 60);
                        }
                        if (tem.I == 0)
                        {
                            tem.P = -1;
                        }
                        else
                        {
                            tem.P = Convert.ToInt32(60.0 / ((double)tem.I / 60.0) * 0.88);
                        }
                    }
                    else
                    {
                        if ((((double)tem.F * 60.0) / (double)tem.G1) == 0)
                        {
                            tem.K1 = -1.0;
                        }
                        else
                        {
                            tem.K1 = (double)tem.I / (((double)tem.F * 60.0) / (double)tem.G1);
                        }
                        if ((((double)tem.F * 60.0) / (double)tem.G2) == 0)
                        {
                            tem.K2 = -1.0;
                        }
                        else
                        {
                            tem.K2 = (double)tem.I / (((double)tem.F * 60.0) / (double)tem.G2);
                        }

                        if (tem.G1 == 0)
                        {
                            tem.L1 = -1.0;
                        }
                        else
                        {
                            tem.L1 = ((double)tem.G1 - (double)tem.H1) / (double)tem.G1;
                        }
                        if (tem.G2 == 0)
                        {
                            tem.L2 = -1.0;
                        }
                        else
                        {
                            tem.L2 = ((double)tem.G2 - (double)tem.H2) / (double)tem.G2;
                        }

                        tem.M1 = (double)tem.L1 * (double)tem.K1 * (double)tem.J;
                        tem.M2 = (double)tem.L2 * (double)tem.K2 * (double)tem.J;


                        if (tem.A == 0)
                        {
                            tem.N1 = -1.0;
                            tem.N2 = -1.0;
                        }
                        else
                        {
                            tem.N1 = (double)tem.G1 / ((double)tem.A / 60);
                            tem.N2 = (double)tem.G2 / ((double)tem.A / 60);
                        }
                        if (tem.F == 0)
                        {
                            tem.O1 = -1.0;
                            tem.O2 = -1.0;
                        }
                        else
                        {
                            tem.O1 = (double)tem.G1 / ((double)tem.F / 60);
                            tem.O2 = (double)tem.G2 / ((double)tem.F / 60);
                        }
                        if (tem.I == 0)
                        {
                            tem.P1 = -1;
                            tem.P2 = -1;
                        }
                        else
                        {
                            tem.P1 = Convert.ToInt32(60.0 / ((double)tem.I / 60.0) * 0.88);
                            tem.P2 = Convert.ToInt32(60.0 / ((double)tem.I / 60.0) * 0.88);
                        }
                    }
                    datos_lineas.Add(tem);
                }

                //Ordenar por Proyectos y Nombre de línea
                for (int i = 0; i < datos_lineas.Count - 1; i++)
                {
                    for (int j = i + 1; j < datos_lineas.Count; j++)
                    {
                        int cmp = String.Compare(datos_lineas[i].proyecto, datos_lineas[j].proyecto);
                        if (cmp > 0)
                        {
                            DatosLinea temdatos = datos_lineas[i];
                            datos_lineas[i] = datos_lineas[j];
                            datos_lineas[j] = temdatos;
                        }
                        else
                        {
                            if (cmp == 0)
                            {
                                cmp = String.Compare(datos_lineas[i].nombre_linea, datos_lineas[j].nombre_linea);
                                if (cmp > 0)
                                {
                                    DatosLinea temdatos2 = datos_lineas[i];
                                    datos_lineas[i] = datos_lineas[j];
                                    datos_lineas[j] = temdatos2;
                                }
                            }
                        }
                    }
                }

                workSheet1 = excel.Workbook.Worksheets.SingleOrDefault(x => x.Name == "ETE GENERAL");
                Tabla_General(ref workSheet1);

                using (var memoryStream = new MemoryStream())
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename=test.xlsx");
                    excel.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
                //Close Excel package 
                excel.Dispose();
            }
         
            return;
        }
    }
}