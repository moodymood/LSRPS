using System;

public partial class Registration : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckAlreadyLoggedIn();
        SetDate();       
    }

    /*
     * Check if the user is logged into the session, if he is
     * redirect to the Default.aspx page since he doesn't need
     * to login again.
     */
    protected bool CheckAlreadyLoggedIn()
    {
        if (RPSLS_Authentication.IsLogged())
        {
            Response.Redirect("~/Default.aspx");
            return false;
        }
        else
            return true;
    }

    /*
     * Populates the date of the DropDawnLists
     */
    protected void SetDate()
    {
        new RPSLS_Date(ddlDay, ddlMonth, ddlYear);
    }

    /*
     * When the user click on the registration button, tries to perform the registration.
     * If it fails, stay in the page and shows an errore message; otherwise it redirects
     * to the Default.aspx page.
     */
    protected void User_Registration_Click(object sender, EventArgs e)
    {
        RPSLS_User currUser = new RPSLS_User(UserNameRegistration.Text, (new RPSLS_Date(ddlDay, ddlMonth, ddlYear)).SelectedDate);
        if (RPSLS_Authentication.Register(currUser))
            Response.Redirect("Default.aspx");
        else
            RegistrationMessage.Text = "Username already taken: choose another one";
    }

 
}