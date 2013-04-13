<%@ Page Title="PatientMedicaments"Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatientMedicaments.aspx.cs" Inherits="PatientMedicaments" EnableTheming="true" Theme="Controles"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Numéro du Patient:
        <asp:Label ID="lblNumPatient" runat="server"></asp:Label>
    </h1>
    <h1>
        Nom:
        <asp:Label ID="lblNom" runat="server"></asp:Label>
    </h1>
    <h1>
        Prénom:
        <asp:Label ID="lblPrenom" runat="server"></asp:Label>
    </h1>
    
    <asp:Repeater ID="Repeater1" runat="server">
    </asp:Repeater>
    
</asp:Content>

