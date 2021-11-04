<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/Login.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</head>
<body>

    <div class="alert alert-danger fade in" id="alert" runat="server">
         <a href="#" id="alertX" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Incorrecto!</strong> Las credenciales ingresadas son incorrectas o estan vacias.
    </div>
    <script>
        const alertX = document.getElementById("alertX");
        alertX.addEventListener("click", (e) => {
            document.getElementById("alert").style.display = "none";
        })
    </script>
         <div class="wrapper">
            <div id="formContent">
  
                <div class="first">
                  <img id="icon" alt="UTN Icon" height="200px" width="100px" src="Content/img/utnLogo.jpg" />
                </div>

  
                <form runat="server">
                    <asp:Label ID="Label1" Font-Size="25px" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="second"></asp:TextBox>
                    <asp:Label ID="Label2" Font-Size="25px" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server"  CssClass="third"></asp:TextBox>
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="fourth" OnClick="btnLogin_Click"/>  
                </form>

                <div id="formFooter">
                  <a class="underlineHover" href="#">Forgot Password?</a>
                </div>

            </div>
       </div>

</body>
</html>