<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAutogestion.aspx.cs" Inherits="UI.Web.MenuAutogestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="menu-aut-container">
        <div class="menu-aut-top">
               Bienvenido NombreDeUsuario..!
        </div>
        <div class="menu-aut-content">
            
            <ul class="menu-aut">
                    <li>
                        <a class="button button01" href="Usuarios.aspx">Usuarios</a>
                    </li>
                    <li>
                        <a class="button button01" href="InscripcionesUser.aspx">Inscripciones</a>

                    </li>
                    <li>
                        <a class="button button01" href="Examenes.aspx" >Examenes</a>

                    </li>
                    <li>
                        <a runat="server" class="button button01" id="cerrar" href="Home.aspx" >Cerrar Sesion</a>
                    </li>
                </ul>
            
        </div>
    </div>
</asp:Content>
