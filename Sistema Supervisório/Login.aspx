<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sistema_Supervisório.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Sistema SUpervisorio</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    ty
    <!-- Custom styles for this template -->
    <link href="css/signin.css" rel="stylesheet">
  </head>

  <body>
<div class="container">
      <form class="form-signin" runat="server">
        <h2 class="form-signin-heading">Sistema Supervisório</h2>
        <label for="inputUsuario" class="sr-only">Usuario</label>
        <input type="text" id="inputUsuario" runat="server" class="form-control" placeholder="Usuario" required autofocus>
        <label for="inputSenha" class="sr-only">Senha</label>
        <input type="password" id="inputSenha" runat="server" class="form-control" placeholder="Senha" required>
            <div class="checkbox">
              <label>
                <input type="checkbox" value="remember-me"> Lembrar senha
              </label>
            </div>
        <button name="btnEntrar" class="btn btn-lg btn-primary btn-block" type="submit">Entrar</button>
        </form>

    </div> <!-- /container -->


    <!-- Bootstrap core JavaScript -->
      <script src="js/bootstrap.min.js"></script>
      <script src="js/jquery-3.2.1.min.js"></script>
    <!-- Placed at the end of the document so the pages load faster -->
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../../../../assets/js/ie10-viewport-bug-workaround.js"></script>
  </body>
</html>
