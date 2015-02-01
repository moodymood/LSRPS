using System;

public partial class Statistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /*
     * When the user press the clearStats the database is updated with the new values
     * and the page need to be refreshed.
     * Finally a message show the action has been performed.
     */
    protected void ClearStats_Click(object sender, EventArgs e)
    {
       
        RPSLS_DB_UserManager.DeleteStats(RPSLS_Authentication.GetCurrentUserName());
        UserStatsGridView.DataBind();
        DeleteStatsMessge.Text = "All your statistics have been deleted";
    }
}
    