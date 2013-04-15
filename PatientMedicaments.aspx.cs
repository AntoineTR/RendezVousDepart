using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatientMedicaments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblNumPatient.Text = Request.QueryString["IDPatient"];
        lblNom.Text = Request.QueryString["NomPatient"];
        lblPrenom.Text = Request.QueryString["PrenomPatient"];
        if (Request.QueryString["IDPatient"] != null)
        {
            int rdvID = int.Parse(Request.QueryString["IDPatient"]);
            this.Repeater1.DataSource = RendezVousDAL.GetRDVbyID(rdvID);
            this.Repeater1.DataBind();
        }

    }
    public string CheminMedicament(object pID)
    {
        Medicament m = MedicamentDAL.getMedbyNAME(pID.ToString());
        return "<a href='#' onclick='window.open(\"DetailsMedicament.aspx?ID=" + pID.ToString() + "\", \"info medicament\", \"width=200, height=150\")'>" + m.NomMedicament + "</a>";
    }
}