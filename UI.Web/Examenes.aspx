<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Examenes.aspx.cs" Inherits="UI.Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
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
                    <asp:BoundField HeaderText="IdCurso" DataField="ID" Visible = "false" />
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true"/>
                </Columns>

            </asp:GridView>
            <asp:Panel ID="Panel3" runat="server" Height="132px" Width="566px">
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
                <asp:LinkButton ID="btonAceptar" runat="server" OnClick="btonAceptar_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="btonCancelar" runat="server">Cancelar</asp:LinkButton>
                <br />
 
            </asp:Panel>
            <asp:Panel ID="Panel4" runat="server">
                <asp:LinkButton ID="btonEditar" runat ="server" Text="Editar" OnClick="btonEditar_Click" CssClass="button-10"></asp:LinkButton>
               
                <asp:LinkButton ID="btonNuevo" runat ="server" Text="Nuevo" OnClick="btonNuevo_Click" CssClass="button-10"></asp:LinkButton>
                
                <asp:LinkButton ID="btonEliminar" runat ="server" Text="Eliminar" OnClick="btonEliminar_Click" CssClass="button-10"></asp:LinkButton>

            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
