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
            <table class="tableRepeater"> 
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
             <tr><td><h1>Médicaments:</h1>
              <asp:Repeater runat="server" ID="medRepeater" EnableViewState="false" 
                 DataSource='<%# DataBinder.Eval(Container.DataItem, "Medicaments") %>' > 
                    
                    <ItemTemplate> 
                                         
                        
                        
                         <%# DataBinder.Eval(Container.DataItem, "NomMedicament") %> -<asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/page1.aspx?id=" + Eval("OrderID") %>' runat="server">  <%# DataBinder.Eval(Container.DataItem, "OrderName") %></asp:HyperLink>
                        - <%# DataBinder.Eval(Container.DataItem, "Description")%> $
                        
                        
                        
                     
                    </ItemTemplate> 
                 


                </asp:Repeater> 
           
             
             </td>
             
             </tr>
             </table>
      </ItemTemplate> 
    </asp:Repeater>
    
    </asp:Content>

