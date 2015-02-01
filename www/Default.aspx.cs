using System;

public partial class _Default : System.Web.UI.Page {
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

     /*
     * After the game has been played, the database is updated with the new result.
     */
    protected void UpdateUserStats(String gameResult)
    {
        if(gameResult.Equals("won"))
            RPSLS_DB_UserManager.UpdateWon(RPSLS_Authentication.GetCurrentUserName());
        else if (gameResult.Equals("lost"))
            RPSLS_DB_UserManager.UpdateLost(RPSLS_Authentication.GetCurrentUserName());
        else
            RPSLS_DB_UserManager.UpdateDrawn(RPSLS_Authentication.GetCurrentUserName());
    }

    /*
    * When the user presses one of the button the games starts
    * and the result is shown.
    */
    protected void PlayGame_Click(object sender, EventArgs e)
    {
        RPSLS_Game currGame = new RPSLS_Game(sender);
        String gameRes = currGame.getResultToString();
        UpdateUserStats(gameRes);
        RPSLSResult.Text = currGame.GetResultMessage();
    }
}
