<%@ Page Title="RendezVous" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PageRendezVous.aspx.cs" Inherits="PageRendezVous" EnableTheming="true" Theme="Controles"%>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 
    <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
        BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
        Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
        ondayrender="Calendar1_DayRender" 
        onselectionchanged="Calendar1_SelectionChanged" ShowGridLines="True" 
        Width="220px">
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
            ForeColor="#FFFFCC" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
    </asp:Calendar>
    <asp:Label ID="Label1" runat="server" Text="Les Rendez-Vous" ForeColor="Lime"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
        <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Select" Text="Sélectionner"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NomDocteur" HeaderText="NomDocteur" 
                SortExpression="NomDocteur" />
            <asp:BoundField DataField="DateDebut" HeaderText="DateDebut" 
                SortExpression="DateDebut" />
            <asp:BoundField DataField="DateFin" HeaderText="DateFin" 
                SortExpression="DateFin" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="Getrdvandname" TypeName="RendezVousDAL">
        <SelectParameters>
            <asp:ControlParameter ControlID="Calendar1" Name="dt" 
                PropertyName="SelectedDate" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
 
    <asp:Label ID="Label2" runat="server" ForeColor="#66FF33" 
        Text="Details du Rendez-Vous"></asp:Label>
 
    <br />
    <asp:Label ID="Label3" runat="server" Text="Nom du Docteur:"></asp:Label>
    <asp:TextBox ID="txtdoc" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Date aaaa/jj/aa:"></asp:Label>
    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Heure du RDV"></asp:Label>
    <br />
    <asp:Label ID="Label6" runat="server" Text="De:"></asp:Label>
    <asp:DropDownList ID="ddlDE" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label7" runat="server" Text="À:"></asp:Label>
    <asp:DropDownList ID="ddlA" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Text="Patient:"></asp:Label>
    <asp:DropDownList ID="ddl_Patient" runat="server">
    </asp:DropDownList>
 
    </asp:Content>