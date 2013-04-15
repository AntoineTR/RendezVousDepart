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
   

    <ItemTemplate> 
            <table class="tableRepeater" id="table" style="border : 2px solid black; margin : 10px; float : left"> 
            <tr > 
               <th align="left"> 
                  Nom Docteur
               </th>  
               <th align="left"> 
                  Date
               </th> 
               
            </tr> 
            <tr> 
               <td valign="top"> 
                  <%# DataBinder.Eval(Container.DataItem, "NomDocteur") %> 
               </td> 
               <td valign="top"> 
                  <%# DataBinder.Eval(Container.DataItem, "DateDebut") %> 
               </td> 
               
             </tr>
             <tr class="trMed">
            <td class="tdMed">MEDICAMENTS <br /> 
            <!-- Repeater imbriqué MedicamentsRDV est une propriété de RendezVous--> 
            <asp:Repeater runat="server" ID="medicamentsRepeater" EnableViewState="false" DataSource='<%# DataBinder.Eval(Container.DataItem, "MedicamentsRDV") %>'>  
                <ItemTemplate>
                     <%# CheminMedicament(DataBinder.Eval(Container.DataItem, "NomMedicament"))%>
<br /> 
<%# DataBinder.Eval(Container.DataItem, "NomMedicament")%> 
                </ItemTemplate>
            </asp:Repeater>
            </td>
        </tr>

             
             </table>
      </ItemTemplate> 
    </asp:Repeater>
    
    </asp:Content>

