<%@ Page Title="Patients" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Patients.aspx.cs" Inherits="Patients" EnableTheming="true" Theme="Controles" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Recherche d'un Patient
    </h1>
    <p>
        <asp:Label ID="lblNom" runat="server" Text="NomPatient">Nom du Patient:</asp:Label>
        <asp:TextBox ID="txtNom" runat="server" style="margin-left: 0px" Width="165px"></asp:TextBox>
        <asp:Label ID="lblInfo" runat="server" 
            Text="(* pour remplacer des caractères)" Width="400px"></asp:Label>
            
    </p>
    <p>
        <asp:Label ID="lblPrenom" runat="server" Text="Prenom">Prénom:</asp:Label>
        <asp:TextBox ID="txtprenom" runat="server" style="margin-left: 0px" 
            Width="165px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnRecherche" runat="server" onclick="Button1_Click" 
            Text="Recherche" Width="100px" />
        <asp:Button ID="btnEffacer" runat="server" onclick="Button2_Click" 
            Text="Effacer" style="margin-left: 54px" Width="75px" Height="26px" />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" style="margin-right: 1px">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="IDPatient" HeaderText="ID du Patient" />
                <asp:BoundField DataField="NomPatient" HeaderText="NomPatient" />
                <asp:BoundField DataField="PrenomPatient" HeaderText="Prenom du Patient" />
                <asp:BoundField DataField="TelephonePatient" HeaderText="Téléphone" />
                
                
                
                <asp:TemplateField>
                <ItemTemplate> <a href='<%# "PatientMedicaments.aspx?IDPatient=" + Eval("IDPatient") + 
                "&&NomPatient=" + Eval("NomPatient") +"&&PrenomPatient=" + Eval("PrenomPatient")
                 %>' >Les Prescriptions</a></ItemTemplate>
                </asp:TemplateField>
                
                
                
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DataObjectTypeName="Patient" SelectMethod="GetDTAllPatients" 
            TypeName="PatientDAL" UpdateMethod="ModifierPatient"></asp:ObjectDataSource>
    </p>
</asp:Content>
