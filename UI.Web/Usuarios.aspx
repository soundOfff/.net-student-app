<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
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
        <asp:ValidationSummary ForeColor="Red" ID="ResumenValidaciones" runat="server" DisplayMode="BulletList" ShowSummary="true" HeaderText="Errores" />
    </asp:Panel>
    <asp:Panel ID ="gridActionsPanel" runat="server">     <asp:LinkButton ID ="editarLinkButton" runat="server" OnClick="editarLinkButton_Click"> Editar</asp:LinkButton>
    <asp:LinkButton ID ="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click"> Eliminar</asp:LinkButton>
    <asp:LinkButton ID ="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click"> Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID ="formActionsPanel" runat="server">     <asp:LinkButton ID ="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID ="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
