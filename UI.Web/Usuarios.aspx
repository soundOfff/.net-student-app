<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <asp:LinkButton runat="server" OnClick="Volver_Click" CssClass="back-arrow">
                <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" fill="white" class="bi bi-arrow-return-left" viewBox="0 0 16 16">
                    <path fill-rule="evenodd" d="M14.5 1.5a.5.5 0 0 1 .5.5v4.8a2.5 2.5 0 0 1-2.5 2.5H2.707l3.347 3.346a.5.5 0 0 1-.708.708l-4.2-4.2a.5.5 0 0 1 0-.708l4-4a.5.5 0 1 1 .708.708L2.707 8.3H12.5A1.5 1.5 0 0 0 14 6.8V2a.5.5 0 0 1 .5-.5z"/>
                </svg>  
        </asp:LinkButton>
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" 
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                    <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true"/>
                </Columns>
            </asp:GridView>

             <asp:Panel ID ="gridActionsPanel" runat="server" CssClass="btn-panel">
        
                <asp:LinkButton ID ="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="button-10"> Editar</asp:LinkButton>
        
                <asp:LinkButton ID ="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CssClass="button-10"> Eliminar</asp:LinkButton>
        
                <asp:LinkButton ID ="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="button-10"> Nuevo</asp:LinkButton>
    
            </asp:Panel>

        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        
        <asp:RequiredFieldValidator ForeColor="Red" ID="rfvNombre" runat ="server" ControlToValidate ="nombreTextBox" ErrorMessage="El nombre no puede estar vacio" InitialValue=" "  >*</asp:RequiredFieldValidator>
       
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        
                <asp:RequiredFieldValidator ForeColor="Red" ID="rfvApellido" runat ="server" ControlToValidate ="apellidoTextBox" ErrorMessage="El apellido no puede estar vacio" InitialValue=" ">*</asp:RequiredFieldValidator>
        
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        
                <asp:RequiredFieldValidator ForeColor="Red" ID="rfvEmail" runat ="server" ControlToValidate ="emailTextBox" ErrorMessage="Email invalido" InitialValue=" " ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RequiredFieldValidator>
        
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="habilitadoChechBox" runat="server" />        
            <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        
                <asp:RequiredFieldValidator ForeColor="Red" ID="rfvNombreUsuario" runat ="server" ControlToValidate ="nombreUsuarioTextBox" ErrorMessage="El nombre de usuario no puede estar vacio" InitialValue=" ">*</asp:RequiredFieldValidator>
        
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        
                <asp:RequiredFieldValidator ForeColor="Red" ID="rfvClave" runat ="server" ControlToValidate ="claveTextBox" ErrorMessage="Clave no valida" InitialValue=" ">*</asp:RequiredFieldValidator>
        
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: ">
        </asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server">
        </asp:TextBox>
        
        <asp:RequiredFieldValidator ForeColor="Red" ID="rfvRepetirClave" runat ="server" ControlToValidate ="repetirClaveTextBox" ErrorMessage="Las claves no coinciden" InitialValue=" ">*</asp:RequiredFieldValidator>
        <br />
            <asp:LinkButton ID ="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID ="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
        
            <asp:ValidationSummary ForeColor="Red" ID="ResumenValidaciones" runat="server" DisplayMode="BulletList" ShowSummary="true" HeaderText="Errores" />
   
        </asp:Panel>
    </div>
</asp:Content>
