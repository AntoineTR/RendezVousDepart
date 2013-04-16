using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class PageRendezVous : System.Web.UI.Page
{
    List<RendezVous> lstrdv = new List<RendezVous>();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        DateTime date = new DateTime(e.Day.Date.Year, e.Day.Date.Month, e.Day.Date.Day);
        lstrdv = RendezVousDAL.GetRDVbyDate(date);

        if (lstrdv.Count > 0)
        {
            if (Calendar1.SelectedDate != date)
            {
                e.Cell.BackColor = Color.Green;
                e.Cell.ForeColor = Color.Black;
            }

            e.Cell.Controls.Add(new LiteralControl("<br>" + lstrdv.Count + " rdv"));
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
    