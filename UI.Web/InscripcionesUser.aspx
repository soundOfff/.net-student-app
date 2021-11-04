<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscripcionesUser.aspx.cs" Inherits="UI.Web.InscripcionesUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <link href="Content/Site.css" rel="stylesheet" />

    <div class="container">
        <asp:LinkButton runat="server" OnClick="Volver_Click" CssClass="back-arrow">
            <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" fill="white" class="bi bi-arrow-return-left" viewBox="0 0 16 16">
                <path fill-rule="evenodd" d="M14.5 1.5a.5.5 0 0 1 .5.5v4.8a2.5 2.5 0 0 1-2.5 2.5H2.707l3.347 3.346a.5.5 0 0 1-.708.708l-4.2-4.2a.5.5 0 0 1 0-.708l4-4a.5.5 0 1 1 .708.708L2.707 8.3H12.5A1.5 1.5 0 0 0 14 6.8V2a.5.5 0 0 1 .5-.5z"/>
            </svg>  
        </asp:LinkButton>
        <asp:GridView CssClass="grillaInsc" ID="grdInscripciones" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="192px" OnSelectedIndexChanged="grdInscripciones_SelectedIndexChanged" Width="700px" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescPlan" HeaderText="Plan" />
                <asp:BoundField DataField="HsTotales" HeaderText="Hs Totales" />
                <asp:BoundField DataField="HsSemanales" HeaderText="Hs Semanales" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:BoundField DataField="IdCurso" HeaderText="NroCurso" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle Height="60px" BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <div class="panel-container">
            <asp:Panel ID="Panel1" runat="server" Height="400px" Visible="False" Width="400px" style="margin-top: 35px">
                <asp:Label ID="lblMat" runat="server" Text="Materia"></asp:Label>
                <asp:TextBox ID="txtMat" runat="server" Enabled="False" style="margin-left: 60px; margin-top: 20px" Width="260px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblPlan" runat="server" Text="Plan"></asp:Label>
                <asp:TextBox ID="txtPlan" runat="server" Enabled="False" style="margin-left: 78px; margin-top: 20px" Width="260px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblCom" runat="server" Text="Comision"></asp:Label>
                <asp:TextBox ID="txtCom" runat="server" Enabled="False" style="margin-left: 44px; margin-top: 20px" Width="260px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblHsSem" runat="server" Text="HsSemanales"></asp:Label>
                <asp:TextBox ID="txtHsSem" runat="server" Enabled="False" style="margin-left: 20px; margin-top: 20px" Width="260px" AutoPostBack="True"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblHsTot" runat="server" Text="HsTotales"></asp:Label>
                <asp:TextBox ID="txtHsTot" runat="server" Enabled="False" style="margin-left: 38px; margin-top: 20px" Width="260px"></asp:TextBox>
                <asp:Button ID="btnInscripcion" runat="server" Text="Inscribirse" Visible="False" style="margin-left: 100px" OnClick="btnInscribirse_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" style="margin-left: 25px; margin-top: 26px" />
            </asp:Panel>
        </div>

    </div>    

</asp:Content>
