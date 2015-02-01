using System;
using System.Data.SqlClient;

/*
 * SUMMARY
 * The RPSLS_DB_UserManager allows the interaction between the database and the system. 
*/

public class RPSLS_DB_UserManager
{
    
    public RPSLS_DB_UserManager()
	{   
	}

    /*
     * Add an user to the database.
     * Return true if seuccessful, false otherwise
     */
    public static bool AddUser(RPSLS_User newUser)
    {
        RPSLS_DB_Connector.OpenConnection();
        SqlCommand SQLCmd = RPSLS_DB_Command.GetSQLcommand(newUser, QueryValues.ADD_USR);
        return ExecuteVoidQuery(SQLCmd);
    }

    /*
    * Remove an user from the database.
    * Return true if seuccessful, false otherwise
    */
    public static bool DeleteUser(String currUserName)
    {
        RPSLS_DB_Connector.OpenConnection();
        SqlCommand SQLCmd = RPSLS_DB_Command.GetSQLcommand(currUserName, QueryValues.DEL_USR);
        return ExecuteVoidQuery(SQLCmd);
    }

    /*
     * Get an user to the database mathing the currUserName.
     * Return true if seuccessful, false otherwise (the user does not exists).
     */
    public static dynamic GetUser(String currUserName)
    {
        RPSLS_DB_Connector.OpenConnection();
        SqlCommand SQLCmd = RPSLS_DB_Command.GetSQLcommand(currUserName, QueryValues.GET_USR);
        return ExecuteQuery(SQLCmd);
    }

    /*
     * Reset all statistics of an user from the database.
     * Return true if seuccessful, false otherwise
     */
    public static bool DeleteStats(String currUserName)
    {
        RPSLS_DB_Connector.OpenConnection();
        SqlCommand SQLCmd = RPSLS_DB_Command.GetSQLcommand(currUserName, QueryValues.DEL_STATS);
        return ExecuteVoidQuery(SQLCmd);
    }

    /*
     * Increment the number of games lost by the currUserName
     * Return true if seuccessful, false otherwise
     */
    public static bool UpdateLost(String currUserName)
    {
        RPSLS_DB_Connector.OpenConnection();
        SqlCommand SQLCmd = RPSLS_DB_Command.GetSQLcommand(currUserName, QueryValues.UP_LOST);
        return ExecuteVoidQuery(SQLCmd);
    }

    /*
     * Increment the number of games won by the currUserName
     * Return true if seuccessful, false otherwise
     */
    public static bool UpdateWon(String currUserName)
    {
        RPSLS_DB_Connector.OpenConnection();
        SqlCommand SQLCmd = RPSLS_DB_Command.GetSQLcommand(currUserName, QueryValues.UP_WON);
        return ExecuteVoidQuery(SQLCmd);
    }

    /*
     * Increment the number of games drawn by the currUserName
     * Return true if seuccessful, false otherwise
     */
    public static bool UpdateDrawn(String currUserName)
    {
        RPSLS_DB_Connector.OpenConnection();
        SqlCommand SQLCmd = RPSLS_DB_Command.GetSQLcommand(currUserName, QueryValues.UP_DRAWN);
        return ExecuteVoidQuery(SQLCmd);
    }

    /*
     * Execute the SQLcommand.
     * Return true if seuccessful, false otherwise
     */
    public static bool ExecuteVoidQuery(SqlCommand SQLCmd)
    {
        try
        {
            SqlDataReader SQLResult = SQLCmd.ExecuteReader();
            return true;
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string errorMsg = "SQL Error:";
            errorMsg += ex.Message;
            return false;
        }
        finally
        {
            RPSLS_DB_Connector.CloseConnection();
        }
    }

    /*
     * Execute the SQLcommand.
     * Return the result of the query if seuccessful, null otherwise.
     */
    public static dynamic ExecuteQuery(SqlCommand SQLCmd)
    {
        try
        {
            SqlDataReader SQLResult = SQLCmd.ExecuteReader();
            if (SQLResult.HasRows)
            {
                SQLResult.Read();
                return (new RPSLS_User(((String)SQLResult["user_name"]).Trim(), (DateTime)SQLResult["date_of_birth"]));
            }
            else
                return null;
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string errorMsg = "SQL Error:";
            errorMsg += ex.Message;
            return null;
        }
        finally
        {
            RPSLS_DB_Connector.CloseConnection();
        }
    }
}