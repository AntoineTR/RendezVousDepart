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
        <asp:DropDownList ID="ddl_Spec" runat="server">
            <asp:ListItem Selected="True"></asp:ListItem>
            
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnRecherche" runat="server" onclick="Button1_Click" 
            Text="Recherche" Width="100px" />
        <asp:Button ID="btnEffacer" runat="server" onclick="Button2_Click" 
            Text="Effacer" style="margin-left: 54px" Width="75px" Height="26px" />
    </p>
    <p>
        <asp:GridView ID="grd_Doc" runat="server" AutoGenerateColumns="False" 
             style="margin-right: 1px" onrowdatabound="grd_Doc_RowDataBound" 
            onrowediting="grd_Doc_RowEditing" onrowupdating="grd_Doc_RowUpdating">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField HeaderText="Nom">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNomDoc" runat="server" Text='<%# Bind("NomDocteur") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("NomDocteur") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PréNom">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPrenomDoc" runat="server" Text='<%# Bind("PrenomDocteur") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PrenomDocteur") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Specialiste">
                    <EditItemTemplate>
                    <asp:DropDownList ID="ddlSpecDoc" runat="server" AutoPostBack="true"></asp:DropDownList>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# GetSpec((int)Eval("IDSpecialite")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Téléphone">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtt" runat="server" Text='<%# Bind("Telephone") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Telephone") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cellulaire">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtc" runat="server" Text='<%# Bind("Cellulaire") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Cellulaire") %>'></asp:Label>
                    </ItemTemplate>
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