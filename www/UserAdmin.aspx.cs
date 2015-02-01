using System;

public partial class UserAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /*
     * When the user press the delete user the database is updated with the new values
     * and the user is redirected to the login page.
     * Finally a message show the action has been performed.
     */
    protected void DeleteUser_Click(object sender, EventArgs e)
    {
        RPSLS_DB_UserManager.DeleteUser(RPSLS_Authentication.GetCurrentUserName());
        RPSLS_Authentication.Logout();
        Response.Redirect("~/Login.aspx?del=true");
     }
}