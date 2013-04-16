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
    protected void grd_Doc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (grd_Doc.DataSource != null)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlSpec = (DropDownList)(e.Row.FindControl("ddlSpecDoc"));
                    ddlSpec.DataSource = SpecialiteDAL.GetAllSpec();
                    ddlSpec.DataTextField = "NomSpecialite";
                    ddlSpec.DataValueField = "IDSpecialite";
                    ddlSpec.DataBind();
                    ddlSpec.SelectedValue = ((Docteur)e.Row.DataItem).IDSpecialite.ToString();

                }
            }
        }
    }
    protected void grd_Doc_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grd_Doc.EditIndex = e.NewEditIndex;
        lstDoc = docteurDAL.GetAllDoc();
        grd_Doc.DataBind();
    }
    protected void grd_Doc_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int ID = int.Parse(grd_Doc.DataKeys[e.RowIndex].Value.ToString());
        string nomDoc = ((TextBox)(grd_Doc.Rows[grd_Doc.EditIndex].FindControl("txtNomDoc"))).Text;
        string prenomDoc = ((TextBox)(grd_Doc.Rows[grd_Doc.EditIndex].FindControl("txtPrenomDoc"))).Text;
        int specialite = int.Parse(((DropDownList)(grd_Doc.Rows[e.RowIndex].FindControl("ddlSpecDoc"))).SelectedValue);
        string txtt = ((TextBox)(grd_Doc.Rows[grd_Doc.EditIndex].FindControl("txtt"))).Text;
        string txtc = ((TextBox)(grd_Doc.Rows[grd_Doc.EditIndex].FindControl("txtc"))).Text;
       
        Docteur d = new Docteur();
        d.IDDocteur = ID;
        d.NomDocteur = nomDoc;
        d.PrenomDocteur = prenomDoc;
        d.IDSpecialite = specialite;
        d.Telephone = txtt;
        d.Cellulaire = txtc;
        int temp = docteurDAL.Update(d);
        lstDoc = docteurDAL.GetAllDoc();
        grd_Doc.EditIndex = -1;
        grd_Doc.DataBind();
         
    }
}