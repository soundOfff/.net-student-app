<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscripcionesUser.aspx.cs" Inherits="UI.Web.InscripcionesUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <link href="Content/Site.css" rel="stylesheet" />
    <p style="margin-left: 40px">
        &nbsp;&nbsp;&nbsp;
        Inscribete a una materia..!
         </p>
        <asp:GridView CssClass="grillaInsc" ID="grdInscripciones" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="192px" OnSelectedIndexChanged="grdInscripciones_SelectedIndexChanged" Width="553px">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
   
    <asp:Panel ID="Panel1" runat="server" Height="400px" Visible="False" Width="400px" style="margin-left: 100px; margin-top: 35px">
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
        <asp:Button ID="btnInscripcion" runat="server" Text="Inscribirse" Visible="False" style="margin-left: 100px" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" style="margin-left: 25px; margin-top: 26px" />
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
