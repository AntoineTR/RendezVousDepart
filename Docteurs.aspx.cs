using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Docteurs : System.Web.UI.Page
{
    public List<Docteur> lstDoc = new List<Docteur>();
    public List<Specialite> lstSpec = new List<Specialite>();
    protected void Page_Load(object sender, EventArgs e)
    {
        lstDoc = docteurDAL.GetAllDoc();
        lstSpec = SpecialiteDAL.GetAllSpec();
        grd_Doc.DataSource = lstDoc.Where(docteur => (docteur.NomDocteur.ToLower().StartsWith(txtNom.Text.ToLower())));
        if (ddl_Spec.SelectedIndex != 0)
        {
            grd_Doc.DataSource = lstDoc.Where(docteur => (docteur.NomDocteur.ToLower().StartsWith(txtNom.Text.ToLower())) && (docteur.IDSpecialite.Equals(ddl_Spec.SelectedIndex)));
        }
        grd_Doc.DataBind();
        ddl_Spec.DataSource = lstSpec;
        ddl_Spec.DataTextField = "NomSpecialite";
        ddl_Spec.DataValueField = "NomSpecialite";
        ddl_Spec.DataBind();
        ddl_Spec.Items.Insert(0, "");
       
    }
    public static string GetSpec(int pID) {
        return SpecialiteDAL.GetSpecbyID(pID).NomSpecialite;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}