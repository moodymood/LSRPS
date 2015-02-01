using System;

/*
 * SUMMARY
 * The RPSLS_Session manage all aspects of the session variable management.
*/

public class RPSLS_Session
{
    public RPSLS_Session()
	{
	}

    /*
     * Get the username of the user currently logged in
     */
    public static String GetCurrentUserName()
    {
        return (String) System.Web.HttpContext.Current.Session["userName"].ToString().Trim();
    }

    /*
     *  Get the date of birth of the user currently logged in  as Object
     */
    public static dynamic GetCurrentUserDate()
    {
        return System.Web.HttpContext.Current.Session["dateOfBirth"];
    }

    /*
     *  Get the date of birth of the user currently logged in as String
     */
    public static String GetCurrentUserDateTostring()
    {
        return (String)System.Web.HttpContext.Current.Session["dateOfBirth"];
    }

    /*
     *  Set session variables userName and dateOfBirth for the current user session
     */
    public static void OpenSession(RPSLS_User currUser)
    {
        System.Web.HttpContext.Current.Session["userName"] = currUser.GetUserName();
        System.Web.HttpContext.Current.Session["dateOfBirth"] = currUser.GetdateOfBirthToString();
    }

    /*
     * Close the session
     */
    public static void CloseSession()
    {
        System.Web.HttpContext.Current.Session["userName"] = null;
    }

    /*
     * Check if some user is currently logged in.
     */
    public static bool CheckSession()
    {
        if (System.Web.HttpContext.Current.Session["userName"] == null)
            return false;
        else
            return true;
    }
}