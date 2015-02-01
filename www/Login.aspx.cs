using System;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckAlreadyLoggedIn();
        CheckLoginRequiredMessage();
        CheckDeletedSuccessfulMessage();
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
     * Show a message if the user is arriving at this page
     * after have been redirected to had tried to access an
     * unauthorized page.
     */
    protected void CheckLoginRequiredMessage()
    {
        if (Request.QueryString["auth"] == "false")
            LoginMessage.Text = "You need to login";
    }

    /*
     * Show a message if the user is arriving at this page
     * after have been deleted his account..
     */
    protected void CheckDeletedSuccessfulMessage()
    {
        if (Request.QueryString["del"] == "true")
            LoginMessage.Text = "Account deleted!";
    }


    /*
     * When the user click on the login button it tries to perform the
     * login. If fails stays in the page and shows an error; otherwise
     * redirects on the Defaults.aspx page.
     */
    protected void UserLogin_Click(object sender, EventArgs e)
    {
        if (RPSLS_Authentication.Login(UserNameLogin.Text))
            Response.Redirect("Default.aspx");
        else
            LoginMessage.Text = "Username not found";
    }  
}