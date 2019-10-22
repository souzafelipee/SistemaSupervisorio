using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.Threading;

namespace Sistema_Supervisório
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public OpcClient client;
        public string resultadoConexao = "";
        Thread threadLeituraSensores;
        Thread threadLeituraRpm;
        string enderecoSensores = "Server_2.Driver_1000.DEV255.M20";
        string enderecoRpm = "Server_2.Driver_1000.DEV255.M21";
        string enderecoModoManual = "Server_2.Driver_1000.DEV255.R20";
        string escreveVelocidade = "Server_2.Driver_1000.DEV255.R16";

        public Dashboard()
        {
            this.client = new OpcClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            modoDeOperacao.RepeatDirection = RepeatDirection.Horizontal;
            resultadoConexao = client.conectar();
            if (resultadoConexao.Substring(0, 1).Equals("E") || resultadoConexao.Equals("Connection closed") || resultadoConexao.Equals("Connecting"))
            {
                lblConectado.Text = "Não Conectado";
                lblMensagem.Text = resultadoConexao;
            }
            else
            {
                lblConectado.Text = "Conectado";
                lblMensagem.Text = resultadoConexao;
                ledConexao.ImageUrl = "~/img/led_verde2.png";
                threadLeituraSensores = new Thread(LeituraSensores);
                threadLeituraSensores.Start();
                threadLeituraRpm = new Thread(LeituraRpm);
                threadLeituraRpm.Start();
            }
                
            if (Page.IsPostBack)
            {
                if (Request.Form["btnConectar"] != null)
                {
                    resultadoConexao = client.conectar();
                    if (resultadoConexao.Substring(0, 1).Equals("E") || resultadoConexao.Equals("Connection closed") || resultadoConexao.Equals("Connecting"))
                    {
                        
                        lblConectado.Text = "Não Conectado btn";
                        lblMensagem.Text = resultadoConexao;
                    }
                    else
                    {
                        lblConectado.Text = "Conectado";
                        lblMensagem.Text = resultadoConexao;
                        ledConexao.ImageUrl = "~/img/led_verde2.png";
                        threadLeituraSensores = new Thread(LeituraSensores);
                        threadLeituraSensores.Start();
                    }
                }
            }
        }

        private void LeituraSensores()
        {
            Boolean continuar = true;
            string auxS;
            string aux1;
            string ultimaLeitura;
            ultimaLeitura = auxS = client.leitura(enderecoSensores);
            while (continuar)
            {
                auxS = client.leitura(enderecoSensores);
                if (auxS.Substring(0, 1).Equals("E"))
                {
                    lblAlto.Text = "Desativado";
                    ledAlto.ImageUrl = "~/img/led_vermelho2.png";
                    lblMedio.Text = "Desativado";
                    ledMedio.ImageUrl = "~/img/led_vermelho2.png";
                    lblBaixo.Text = "Desativado";
                    ledBaixo3.ImageUrl = "~/img/led_vermelho2.png";
                    sinotico.ImageUrl = "~/img/chute-Donnely_000.png";
                    lblStatus.Text = auxS;
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    if (!auxS.Equals(ultimaLeitura))
                    {
                        aux1 = auxS.Substring(0, 1);
                        #region leds
                        switch (aux1)
                        {
                            case "0"://sensores desligados
                                lblAlto.Text = "Desativado";
                                ledAlto.ImageUrl = "~/img/led_vermelho2.png";
                                lblMedio.Text = "Desativado";
                                ledMedio.ImageUrl = "~/img/led_vermelho2.png";
                                lblBaixo.Text = "Desativado";
                                ledBaixo3.ImageUrl = "~/img/led_vermelho2.png";
                                break;
                            case "1": //1 sensor ligado
                                lblAlto.Text = "Desativado";
                                ledAlto.ImageUrl = "~/img/led_vermelho2.png";
                                lblMedio.Text = "Desativado";
                                ledMedio.ImageUrl = "~/img/led_vermelho2.png";
                                lblBaixo.Text = "Ativado";
                                ledBaixo3.ImageUrl = "~/img/led_verde2.png";
                                break;
                            case "2": //1 sensor ligado
                                lblAlto.Text = "Desativado";
                                ledAlto.ImageUrl = "~/img/led_vermelho2.png";
                                lblMedio.Text = "Ativado";
                                ledMedio.ImageUrl = "~/img/led_verde2.png";
                                lblBaixo.Text = "Desativado";
                                ledBaixo3.ImageUrl = "~/img/led_vermelho2.png";
                                break;
                            case "3": //1 sensor ligado
                                lblAlto.Text = "Desativado";
                                ledAlto.ImageUrl = "~/img/led_vermelho2.png";
                                lblMedio.Text = "Ativado";
                                ledMedio.ImageUrl = "~/img/led_verde2.png";
                                lblBaixo.Text = "Ativado";
                                ledBaixo3.ImageUrl = "~/img/led_verde2.png";
                                break;
                            case "4": //1 sensor ligado
                                lblAlto.Text = "Ativado";
                                ledAlto.ImageUrl = "~/img/led_verde2.png";
                                lblMedio.Text = "Desativado";
                                ledMedio.ImageUrl = "~/img/led_vermelho2.png";
                                lblBaixo.Text = "Desativado";
                                ledBaixo3.ImageUrl = "~/img/led_vermelho2.png";
                                break;
                            case "5": //1 sensor ligado
                                lblAlto.Text = "Ativado";
                                ledAlto.ImageUrl = "~/img/led_verde2.png";
                                lblMedio.Text = "Desativado";
                                ledMedio.ImageUrl = "~/img/led_vermelho2.png";
                                lblBaixo.Text = "Ativado";
                                ledBaixo3.ImageUrl = "~/img/led_verde2.png";
                                break;
                            case "6": //1 sensor ligado
                                lblAlto.Text = "Ativado";
                                ledAlto.ImageUrl = "~/img/led_verde2.png";
                                lblMedio.Text = "Ativado";
                                ledMedio.ImageUrl = "~/img/led_verde2.png";
                                lblBaixo.Text = "Desativado";
                                ledBaixo3.ImageUrl = "~/img/led_vermelho2.png";
                                break;
                            case "7": //1 sensor ligado
                                lblAlto.Text = "Ativado";
                                ledAlto.ImageUrl = "~/img/led_verde2.png";
                                lblMedio.Text = "Ativado";
                                ledMedio.ImageUrl = "~/img/led_verde2.png";
                                lblBaixo.Text = "Ativado";
                                ledBaixo3.ImageUrl = "~/img/led_verde2.png";
                                break;
                        }
                        #endregion

                        #region sinotico
                        switch (auxS)
                        {
                            case "0":
                                sinotico.ImageUrl = "~/img/chute-Donnely_000.png";
                                break;
                            case "1":
                                sinotico.ImageUrl = "~/img/chute-Donnely_001.png";
                                break;
                            case "2":
                                sinotico.ImageUrl = "~/img/chute-Donnely_010.png";
                                break;
                            case "3":
                                sinotico.ImageUrl = "~/img/chute-Donnely_011.png";
                                break;
                            case "4":
                                sinotico.ImageUrl = "~/img/chute-Donnely_100.png";
                                break;
                            case "5":
                                sinotico.ImageUrl = "~/img/chute-Donnely_101.png";
                                break;
                            case "6":
                                sinotico.ImageUrl = "~/img/chute-Donnely_110.png";
                                break;
                            case "7":
                                sinotico.ImageUrl = "~/img/chute-Donnely_111.png";
                                break;
                        }
                        #endregion
                        Response.Redirect(Request.RawUrl);
                    }
                    ultimaLeitura = auxS;

                }
                Thread.Sleep(100);
                
                
            }

        }
        private void LeituraRpm()
        {
            Boolean continuar = true;
            string auxS;
            string ultimaLeitura;
            int aux1 = 0;
            ultimaLeitura = auxS = client.leitura(enderecoRpm);
            while (continuar)
            {
                if (!auxS.Substring(0, 1).Equals("E"))
                { 
                    aux1 = Convert.ToInt32(auxS)/100 *180/2;
                    lblRPM.Text = Convert.ToString(aux1) + " Rpm";
                }
                Thread.Sleep(100);
            }
        }
    }
}