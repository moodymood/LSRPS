using System;
using System.Data;
using System.Data.SqlClient;

/*
 * SUMMARY
 * The RSLS_DB_Command class creates e returns Sqlcommand given an Sqlconnection 
 * and the query in a String format.
*/

/*
 * QueryValues contains all the possible type of query required for the webapp.
 */ 
public static class QueryValues
{
    public static readonly String ADD_USR = "INSERT INTO [User] (user_name, date_of_birth, won, lost, drawn, tot) VALUES (@user, @birth, 0, 0, 0, 0)";
    public static readonly String DEL_USR = "DELETE FROM [User] WHERE user_name=@user";
    public static readonly String UP_DRAWN = "UPDATE [User] SET drawn = drawn + 1, tot = tot+1 WHERE  user_name=@user";
    public static readonly String UP_LOST = "UPDATE [User] SET lost = lost + 1, tot = tot+1 WHERE  user_name=@user";
    public static readonly String UP_WON = "UPDATE [User] SET won = won + 1, tot = tot+1 WHERE  user_name=@user";
    public static readonly String DEL_STATS = "UPDATE [User] SET lost = 0, won = 0, drawn = 0, tot = 0 WHERE user_name=@user";
    public static readonly String GET_USR = "SELECT * FROM [User] WHERE  user_name=@user";
}

public class RPSLS_DB_Command
{

	public RPSLS_DB_Command()
	{
	}

    /*
     * GetSQLcommand needs the username String and a query in a String form;
     * an Sqlconnection need to be already opened.
     * It return an SQLcommand ready to use (execute).
     */
    public static SqlCommand GetSQLcommand(String userName, String quertType)
    {
        SqlCommand SQLCmd = new SqlCommand(quertType, RPSLS_DB_Connector.GetConnection());
        SQLCmd.Parameters.Add("@user", SqlDbType.VarChar);
        SQLCmd.Parameters["@user"].Value = userName;
        return SQLCmd;
    }

    /*
     * GetSQLcommand needs a RPSLS_User and a query in a String form;
     * an Sqlconnection need to be already opened.
     * It return an SQLcommand ready to use (execute).
     */
    public static SqlCommand GetSQLcommand(RPSLS_User newUser, String quertType)
    {
        SqlCommand SQLCmd = new SqlCommand(quertType, RPSLS_DB_Connector.GetConnection());
        SQLCmd.Parameters.Add("@user", SqlDbType.VarChar);
        SQLCmd.Parameters["@user"].Value = newUser.GetUserName();
        SQLCmd.Parameters.Add("@birth", SqlDbType.DateTime);
        SQLCmd.Parameters["@birth"].Value = newUser.GetdateOfBirth();
        return SQLCmd;
    }
}