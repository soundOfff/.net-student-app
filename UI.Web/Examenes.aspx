<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Examenes.aspx.cs" Inherits="UI.Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
    <asp:LinkButton runat="server" OnClick="Volver_Click" CssClass="back-arrow">
            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" fill="white" class="bi bi-arrow-return-left" viewBox="0 0 16 16">
                <path fill-rule="evenodd" d="M14.5 1.5a.5.5 0 0 1 .5.5v4.8a2.5 2.5 0 0 1-2.5 2.5H2.707l3.347 3.346a.5.5 0 0 1-.708.708l-4.2-4.2a.5.5 0 0 1 0-.708l4-4a.5.5 0 1 1 .708.708L2.707 8.3H12.5A1.5 1.5 0 0 0 14 6.8V2a.5.5 0 0 1 .5-.5z"/>
            </svg>  
    </asp:LinkButton>
    <asp:Panel ID="Panel1" runat="server" Height="338px" style="margin-top: 9px">
        <asp:Panel ID="Panel2" runat="server" Height="67px">
            <asp:GridView ID="dgvExamenes" runat="server" DataKeyNames="ID" OnSelectedIndexChanged="dgvExamenes_SelectedIndexChanged" CssClass="mGrid"
                PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:BoundField HeaderText="Plan" DataField="DescPlan" />
                    <asp:BoundField HeaderText="Materia" DataField="DescMateria" />
                    <asp:BoundField HeaderText="Especialidad" DataField="DescEspecialidad" />
                    <asp:BoundField HeaderText="Nota" DataField="Nota" />
                    <asp:BoundField HeaderText="legajo" DataField="Legajo" Visible = "false" />
                    <asp:BoundField HeaderText="IdCurso" DataField="IdCurso" Visible = "false" />
                    <asp:BoundField HeaderText="IdInscripcion" DataField="ID" Visible = "false" />
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true"/>
                </Columns>

            </asp:GridView>
            <asp:Panel ID="Panel3" runat="server" Width="560">
                ID inscripcion:
                <asp:TextBox ID="txtIdInscripcion" runat="server" Enabled="False"></asp:TextBox>
                <br />
                LegajoAlumno:
                <asp:TextBox ID="txtLegajoAlumno" runat="server"></asp:TextBox>
                <br />
                Nota:
                <asp:TextBox ID="txtNota" runat="server"></asp:TextBox>
                <br />
                ID Curso:
                <asp:TextBox ID="txtIdCurso" runat="server"></asp:TextBox>
                <br />
                <asp:LinkButton ID="btonAceptar" runat="server" OnClick="btonAceptar_Click" CssClass="button-m10">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="btonCancelar" runat="server" CssClass="button-m10">Cancelar</asp:LinkButton>
                <br />
 
            </asp:Panel>
            <asp:Panel ID="Panel4" CssClass="btn-panel" runat="server">
                
                <asp:LinkButton ID="btonEditar" runat ="server" Text="Editar" OnClick="btonEditar_Click" CssClass="button-10"></asp:LinkButton>
                
                <asp:LinkButton ID="btonNuevo" runat ="server" Text="Nuevo" OnClick="btonNuevo_Click" CssClass="button-10"></asp:LinkButton>
                
                <asp:LinkButton ID="btonEliminar" runat ="server" Text="Eliminar" OnClick="btonEliminar_Click" CssClass="button-10"></asp:LinkButton>

            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
   </div>
</asp:Content>
