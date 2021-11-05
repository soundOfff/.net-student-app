<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAutogestion.aspx.cs" Inherits="UI.Web.MenuAutogestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="menu-aut-container">
        
        <div  runat="server" class="menu-aut-top">
           &nbsp;<div>
                <asp:Image CssClass="menu-aut-top-img" ID="userImage" runat="server" />
                <p id="lblUsuario" runat="server">Usuario: -NombreDeUsuario-</p>
                <p id="lblTipo" runat="server">Tipo De Usuario: -TipoDeUsuario-</p>
            </div>
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
                        <asp:LinkButton runat="server" OnClick="Cerrar_Click" CssClass="button button01" Text="Cerrar Sesion" />
                    </li>
                </ul>
            
        </div>
    </div>
</asp:Content>
