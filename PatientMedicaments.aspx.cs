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

    }
}