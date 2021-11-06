<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <asp:LinkButton runat="server" OnClick="Unnamed_Click"  CssClass="back-arrow">
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
                    <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                    <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNac" />
                    <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                    <asp:BoundField HeaderText="Tipo Persona" DataField="TipoPersona" />
                    <asp:BoundField HeaderText="Id Plan" DataField="IdPlan" />
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
        <asp:Label ID="direccionLabel" runat="server" Text="Direccion: "></asp:Label>
        <asp:TextBox ID="direccionTxt" runat="server" />        
            <br />
        <asp:Label  runat="server" Text="Legajo: "></asp:Label>
        <asp:TextBox ID="legajoTxt" runat="server"></asp:TextBox>
        
        <asp:RequiredFieldValidator ForeColor="Red" ID="rfvlegajo" runat ="server" ControlToValidate ="legajoTxt" ErrorMessage="El legajo no puede estar vacio" InitialValue=" ">*</asp:RequiredFieldValidator>
        
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Telefono: "></asp:Label>
        <asp:TextBox ID="telTxt" runat="server"></asp:TextBox>
        
        <asp:RequiredFieldValidator ForeColor="Red" ID="rfvClave" runat ="server" ControlToValidate ="telTxt" ErrorMessage="El telefono no puede estar vacio" InitialValue=" ">*</asp:RequiredFieldValidator>
                
        <br />

        <asp:Label ID="Label1" runat="server" Text="Fecha Nacimiento: "></asp:Label>
        <asp:TextBox ID="fechaTxt" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat ="server" ControlToValidate ="fechaTxt" ErrorMessage="La fecha de nac no puede estar vacia" InitialValue=" ">*</asp:RequiredFieldValidator>
                
        <br />
           
        <asp:Label ID="Label2" runat="server" Text="Tipo: "></asp:Label>
        <asp:DropDownList ID="dropTipo" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat ="server" ControlToValidate ="dropTipo" ErrorMessage="El tipo de usuario no puede estar vacio" InitialValue=" ">*</asp:RequiredFieldValidator>
                
        <br />
            
        <asp:Label ID="Label3" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="dropPlan" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat ="server" ControlToValidate ="dropPlan" ErrorMessage="El plan no puede estar vacio" InitialValue=" ">*</asp:RequiredFieldValidator>
                
        <br />

        <asp:Label ID="Label4" runat="server" Text="Especialidad: "></asp:Label>
        <asp:DropDownList ID="dropEsp" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat ="server" ControlToValidate ="dropEsp" ErrorMessage="La especialidad no puede estar vacia" InitialValue=" ">*</asp:RequiredFieldValidator>
                
        <br />
            <asp:LinkButton ID ="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID ="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
        
            <asp:ValidationSummary ForeColor="Red" ID="ResumenValidaciones" runat="server" DisplayMode="BulletList" ShowSummary="true" HeaderText="Errores" />
   
        </asp:Panel>
        <asp:Panel ID ="gridActionsPanel" runat="server" CssClass="btn-panel">
        
                <asp:LinkButton ID ="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="button-10"> Editar</asp:LinkButton>
        
                <asp:LinkButton ID ="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CssClass="button-10"> Eliminar</asp:LinkButton>
        
                <asp:LinkButton ID ="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="button-10"> Nuevo</asp:LinkButton>
    
            </asp:Panel>
    </div>
</asp:Content>
