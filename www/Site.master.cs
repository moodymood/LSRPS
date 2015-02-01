using System;

public partial class Site : System.Web.UI.MasterPage {

    /*
     * On the page load a session check happened: if the user is trying to
     * access to the web app but he is not logged in he will be redirected to the
     * login page.
     * Otherwise he gets access to the Default.aspx page and his info
     * are visualized.
     */
    protected void Page_Load(object sender, EventArgs e){
        if (CheckLogin())
        {
            DisplayUserInfo();
            Disable_Current_Menu();
        }
    }


    /*
     * Check if the user is logged into the session, if not
     * redirect to the login page.
     */
    protected bool CheckLogin()
    {
        if (!RPSLS_Authentication.IsLogged())
        {
            Response.Redirect("~/Login.aspx?auth=false");
            return false;
        }
        else
            return true;
    }

    /*
     * Display user info: name and birthday wishes if it is his
     * birthday.
     */
    protected void DisplayUserInfo()
    {
        RPSLS_User currUser = RPSLS_Authentication.GetCurrentUser();
        UserNameLink.Text = currUser.GetUserName();
        if (currUser.IsBirthday())
            UserBirth.Text = " Happy Birthday!!!";
    }

    /*
     * Disable the current menu section from the  navigation menu.
     */
    protected void Disable_Current_Menu()
    {
        String current = Request.Path.ToString();
        if (current.Contains("Statistics"))
            Statistics.Enabled = false;
        else
            Statistics.Enabled = true;
        if (current.Contains("Default"))
            HomePage.Enabled = false;
        else
            HomePage.Enabled = true;
    }

    /*
     * When the user press the logout link it perform the logout from the system.
     */
    protected void UserLogout_Click(object sender, EventArgs e)
    {
        RPSLS_Authentication.Logout();
        Response.Redirect("~/Login.aspx");
    }
}
