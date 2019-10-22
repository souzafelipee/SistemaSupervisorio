using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPC;
using OPCDA;
using OPCDA.NET;

namespace ClassLibrary
{
    public class OpcClient
    {
        public OpcServer Srv;
        SyncIOGroup srwGroup;
        public string itensS;
        public string resultadoConexao = "";

        public string resultado(int rtc)
        {
            string aux;
            switch (rtc)
            {
                case HRESULTS.E_FAIL :
                    aux = "E_FAIL";
                    break;
                case HRESULTS.S_OK:
                    aux = "S_OK";
                    break;
                case HRESULTS.S_FALSE:
                    aux = "S_FALSE";
                    break;
                case HRESULTS.E_INVALIDARG:
                    aux = "E_INVALIDARG";
                    break;
                case HRESULTS.E_OUTOFMEMORY:
                    aux = "E_OUTOFMEMORY";
                    break;
                case HRESULTS.OPC_E_NOTFOUND:
                    aux = "E_NOTFOUND";
                    break;
                case HRESULTS.CONNECT_E_NOCONNECTION:
                    aux = "CONNECT_E_NOCONNECTION";
                    break;
                case HRESULTS.OPC_E_BADRIGHTS:
                    aux = "OPC_E_BADRIGHTS: O item não é legível";
                    break;
                case HRESULTS.OPC_E_INVALIDHANDLE:
                    aux = "OPC_E_INVALIDHANDLE: The item Handle is invalid";
                    break;
                case HRESULTS.OPC_E_UNKNOWNITEMID:
                    aux = "OPC_E_UNKNOWNITEMID: The item is no longer available in the server address space.";
                    break;
                default:
                    aux = "Problema do Windows ou DCOM ao criar instancia do Servidor";
                    break;
            }

            return aux;
        }

        public string conectar()
        {
            //variável auxiliar que será retornada
            string aux = "";
            Boolean erro =false;
            //conexão com o Servidor OPC;
            Srv = new OpcServer();
            int rtc = Srv.Connect("HITecnologia.SOS.DA.1");
            int localeID = Srv.GetLocaleID(out localeID);
            if (HRESULTS.Failed(rtc))
            {
                aux = "Erro na conexão: ";
                erro = true;
            }                
            else
                aux = "Conectado com Sucesso. LocaleId=" + localeID;
            if (!erro)
            {
                srwGroup = new SyncIOGroup(Srv);
                OPCItemState resultadoLeitura;
                int auxRtc;
                auxRtc = srwGroup.Read(OPCDATASOURCE.OPC_DS_DEVICE, "Server_2.Driver_1000.DEV255.state", out resultadoLeitura);

                if (HRESULTS.Failed(auxRtc))
                {
                    aux = "Erro na Leitura: " + resultado(auxRtc);
                }
                else
                {
                    aux = resultadoLeitura.DataValue.ToString();
                }
            }
            
            
            return aux;
        }

        public string[] DisplayLocalOpcV2V3Servers()
        {
            string[] Servers;
            OpcServerBrowser srvBrowse = new OpcServerBrowser();  // local server
            srvBrowse.GetServerList(out Servers);
            return Servers;
            
        }

        public string leitura(string s)
        {
            string aux;
            OPCItemState resultadoLeitura;
            int auxRtc = srwGroup.Read(OPCDATASOURCE.OPC_DS_DEVICE,s,out resultadoLeitura);
            if (HRESULTS.Failed(auxRtc))
                aux = "Erro na Leitura: " + resultado(auxRtc);
            else
                aux = resultadoLeitura.DataValue.ToString();

            return aux;
        }
        public string escrita(string item,string valorAescrever)
        {
            string aux="";
            srwGroup.Write(item, valorAescrever);

            OPCItemState resultadoLeitura;
            int auxRtc = srwGroup.Read(OPCDATASOURCE.OPC_DS_DEVICE, item, out resultadoLeitura);
            if (HRESULTS.Failed(auxRtc))
                aux = "Erro na Leitura: " + resultado(auxRtc);
            else
                aux = resultadoLeitura.DataValue.ToString();
            if (!valorAescrever.Equals(aux))
            {
                aux = "Erro";
            }


            return aux;
        }

    }
}