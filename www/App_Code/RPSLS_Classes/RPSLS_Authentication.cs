using System;
using System.Web;

/*
 * SUMMARY
 * RPSLS_Authentication class manage the interaction between the system and the session.
 * It allows to login, login, register, check if some user is logged in the system
 * and finally to get the current logged in user.
*/

public class RPSLS_Authentication
{
    public RPSLS_Authentication()       
	{
	}

    /*
     * Performs the login of currUserName if its instance is present in the db.
     */
    public static Boolean Login(String currUserName) 
    {
        RPSLS_User currUser = RPSLS_DB_UserManager.GetUser(currUserName);
        if (currUser != null)
        {
            RPSLS_Session.OpenSession(currUser);
            return true;
        }
        else
            return false;
    }

    /*
     * Performs the registration of currUserName if its instance is not
     * already present in the db.
     */

    public static Boolean Register(RPSLS_User newUser) 
    {
        RPSLS_User isUserRegistered = RPSLS_DB_UserManager.GetUser(newUser.GetUserName());
        if (isUserRegistered == null)
        {
            RPSLS_DB_UserManager.AddUser(newUser);
            RPSLS_Session.OpenSession(newUser);
            return true;
        }
        else
            return false;  
    }

    /*
     * Perform the logout of the current user from the system.
     */
    public static void Logout() 
    {
        RPSLS_Session.CloseSession();  
    }

    /*
     * Check if some user is currently logged into the system.
     */
    public static Boolean IsLogged()
    {
        return RPSLS_Session.CheckSession();

    }

    /*
     * Get the user currently logged in the system as RPSLS_User.
     */
    public static RPSLS_User GetCurrentUser()
    {
        return RPSLS_DB_UserManager.GetUser(RPSLS_Session.GetCurrentUserName());
    }

    /*
     * Get the user currently logged in the system as String.
     */
    public static String GetCurrentUserName()
    {
        return GetCurrentUser().GetUserName();
    }
}