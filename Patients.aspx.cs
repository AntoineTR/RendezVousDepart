using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patients : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        RechercheFilter();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    public void RechercheFilter()
    {
        ObjectDataSource1.FilterExpression = null;

        //nom & prenom 
        if (txtprenom.Text != "" && txtNom.Text != "")
            ObjectDataSource1.FilterExpression = "NomPatient LIKE '" + txtNom.Text + "' AND PrenomPatient LIKE '" + txtprenom.Text + "'";
        //nom 
        else if (txtNom.Text != "" && txtprenom.Text == "")
            ObjectDataSource1.FilterExpression = "NomPatient LIKE '" + txtNom.Text + "'";
        //prenom 
        else
            ObjectDataSource1.FilterExpression = "PrenomPatient LIKE '" + txtprenom.Text + "'";
    }
}