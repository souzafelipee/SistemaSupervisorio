<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Sistema_Supervisório.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    
    <title>Moenda</title>
    
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen"/>
    
    <!-- Custom styles for this template -->
    <link href="css/dashboard.css" rel="stylesheet" media="screen"/>
</head>
<body runat="server">
    <form runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="titulo">
                <div class="col-xs-12">
                    <label >Moenda</label>
                </div>
            </div> 
        </div>
        
        <div class="row justify-content-center">
            <div class="status">
                <div class="col-xs-12">
                    
                        <asp:Label runat="server" ID="lblStatus" Text="Status: "></asp:Label>
                        <asp:Image ID="ledConexao" runat="server" ImageUrl="~/img/led_vermelho2.png" />
                        <asp:Label ID="lblConectado" runat="server" Text= "Não Conectado"></asp:Label>
                        
                </div>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="mensagem text-center">
                <div class="col-xs-12">
                    <asp:Label runat="server" ID="lblMensagem" Text="Não foi possível conectar" class="lblMensagem"></asp:Label>
                </div>
            </div> 
        </div>
        <div class="row justify-content-center">
            <div class="btnConectarClass ">
                <div class="col-xs-12">
                    <button name="btnConectar" class="btn btn-primary btn-center btn-sm" type="submit">Conectar</button>
                </div>
            </div>
        </div>
        <div class="row justify-content-center corpo" runat="server">
                <div class="col-12 offset-3 col-md-3 offset-md-3 text-center">
                    <asp:Image ID="sinotico" runat="server"  ImageUrl="~/img/chute-Donnely_000.png" />
                </div>
                <div class="col-12 col-md-3 text-center">
                    <div class="row">
                        <div class="visualizaRpm text-center">
                            <div class="col-12">
                                <label>Rotação:</label>
                            </div>
                            <div class="col-12">
                                <asp:Label ID="lblRPM" runat="server" Text="0000 Rpm"></asp:Label>
                            </div>
                        </div>
                        <div class="modoOperacao text-center">
                            <div class="col-12" >
                                <label>Modo de Operação:</label>
                                    <asp:RadioButtonList ID="modoDeOperacao" runat="server">
                                        <asp:ListItem Selected="True">Automatico</asp:ListItem>
                                        <asp:ListItem>Manual</asp:ListItem>
                                    </asp:RadioButtonList>
                            </div>
                            <div class="col-12 botoes" >
                                    <button name="btnConectar" class="btn btn-success btn-center btn-sm" type="submit">Ligar</button>
                                    <button name="btnConectar" class="btn btn-danger btn-center btn-sm" type="submit">Desligar</button>
                            
                            </div>
                            <div class="col-12">
                                <div class="input-group">
                                    <input type="text" class="form-control" id="rotacaoRpm" placeholder="Alterar RPM" />
                                    <span class="input-group-btn">
                                        <button name="alterarRpm" class="btn btn-secondary " type="submit" >OK</button>
                                           
                                    </span>
                                    
                                </div>
                            </div>   
                        </div>
                        <div class="col-12">

                        </div>
                        <div class="col-12">
                            <label>Sensor1: </label>
                            <asp:Image ID="ledAlto" runat="server" ImageUrl="~/img/led_vermelho2.png" />
                            <asp:Label runat="server"  ID="lblAlto" Text="Desativado"></asp:Label>
                        </div>
                        <div class="col-12">
                            <label>Sensor2: </label>
                            <asp:Image ID="ledMedio" runat="server" ImageUrl="~/img/led_vermelho2.png"/>
                            <asp:Label runat="server"  ID="lblMedio" Text="Desativado"></asp:Label>
                        </div>
                        <div class="col-12">
                            <label>Sensor3: </label>
                            <asp:Image ID="ledBaixo3" runat="server" ImageUrl="~/img/led_vermelho2.png" />
                            <asp:Label runat="server"  ID="lblBaixo" Text="Desativado"></asp:Label>
                        </div>
                    </div>
                    
                </div>
            </div>
    </div>
    </form>
    <script type="text/javascript">
        $(function(){ 
            $("submit").click(function(){
                var valor = $(this).val();
                if(valor == "Conectar"){
                    alert("Botão Conectar");
                }
            });
        });
    </script>
    <!-- Bootstrap core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-3.2.1.min.js"></script>
    <!-- Placed at the end of the document so the pages load faster -->
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../../../assets/js/ie10-viewport-bug-workaround.js"></script>
</body>
</html>
