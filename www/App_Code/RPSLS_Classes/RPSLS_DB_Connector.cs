using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/*
 *  SUMMARY
 *  The RPSLS_DB_Connector class manages the connection with the database, opening, closing 
 *  and returning the connection when requested.
*/

public class RPSLS_DB_Connector
{
    private static SqlConnection SQLConn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\RPSLS.mdf;Integrated Security=True");
    
    public RPSLS_DB_Connector()
	{
	}

    /*
     *  Open the database connection.
     */
    public static void OpenConnection()
    {
        try
        {
            SQLConn.Open();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string errorMsg = "SQL Error:";
            errorMsg += ex.Message;
        }
    }

    /*
     * Close the database connection.
     */ 
    public static void CloseConnection()
    {
        try
        {
            SQLConn.Close();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string errorMsg = "SQL Error:";
            errorMsg += ex.Message;
        }

    }

    /*
     * Return the current connection as a SqlConnection type.
     */
    public static SqlConnection GetConnection()
    {
        return SQLConn;
    }
}