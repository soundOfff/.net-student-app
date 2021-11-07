<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
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
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="descEspecialidad" HeaderText="Descripcion" />
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" />
                </Columns>
                <PagerStyle CssClass="pgr" />
                <SelectedRowStyle BackColor="Black" ForeColor="White" />
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        
        <asp:RequiredFieldValidator ForeColor="Red" ID="rfvDescripcion" runat ="server" ControlToValidate ="descripcionTextBox" ErrorMessage="La descripcion no puede estar vacia" InitialValue=" "  >*</asp:RequiredFieldValidator>
       
            <br />
        <asp:Label  runat="server" Text="ID:" ID="idLabel"></asp:Label>
        <asp:TextBox ID="idTxt" runat="server"></asp:TextBox>
       
        
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
