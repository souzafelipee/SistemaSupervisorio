<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teste.aspx.cs" Inherits="Sistema_Supervisório.Teste" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
        <p>
            <input id="Button2" type="button" value="button" /></p>
        <p>
            <asp:Label ID="lbl1" runat="server" Text="Servidores Encontrados: "></asp:Label>
            <br />
            <asp:Label ID="lbl2" runat="server" Text="Resultado da conexão com o servidor: "></asp:Label>
            <br />
            <asp:Label ID="lbl3" runat="server" Text="Respostas da conexão: "></asp:Label>
            <br />
            <asp:Label ID="lbl4" runat="server" Text="Estado do Server_0: "></asp:Label>
            <br />
            <asp:Label ID="lbl5" runat="server" Text="Estado do Server_0: "></asp:Label>
        </p>
    </form>
</body>
</html>
