<%@ Page Title="Docteurs"Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Docteurs.aspx.cs" Inherits="Docteurs" EnableTheming="true" Theme="Controles" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Recherche d'un Docteur
    </h1>
    <p>
        <asp:Label ID="lblNom" runat="server" Text="NomPatient">Nom du Docteur:</asp:Label>
        <asp:TextBox ID="txtNom" runat="server" style="margin-left: 0px" Width="165px"></asp:TextBox>
        
            
    </p>
    <p>
        <asp:Label ID="lblPrenom" runat="server" Text="Prenom">Spécialité:</asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnRecherche" runat="server" onclick="Button1_Click" 
            Text="Recherche" Width="100px" />
        <asp:Button ID="btnEffacer" runat="server" onclick="Button2_Click" 
            Text="Effacer" style="margin-left: 54px" Width="75px" Height="26px" />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
             style="margin-right: 1px">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="NomDocteur" HeaderText="Nom" />
                <asp:BoundField DataField="PrenomDocteur" HeaderText="PréNom" />
                <asp:BoundField DataField="NomSpecialite" HeaderText="Specialiste" />
                <asp:BoundField DataField="Telephone" HeaderText="Téléphone" />
                <asp:BoundField DataField="Cellulaire" HeaderText="Cellulaire" />

                
                
                
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