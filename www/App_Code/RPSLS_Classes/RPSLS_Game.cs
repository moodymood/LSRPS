using System;
using System.Web.UI.WebControls;

/*
 *  SUMMARY
 * RPSLS_Game perform the Rock-Paper-Scissors-Lizard-Spock game.
 * 
*/

public class RPSLS_Game
{
    /*
     * RPSLS_Choices describes the possible choice of the game;
     * matrixResult gives the result of the game for the first player: in particular
     * -1 means he lost
     *  0 drwan
     *  1 means he won.
     *  Each position corresponds to the player choice, according to the RPSLS_Choices
     *  int value.
     */
    public enum RPSLS_Choices { Rock, Paper, Scissors, Lizard, Spok };
    private RPSLS_Choices computerChoice;
    private RPSLS_Choices userChoice;
    private int gameResult;
    private readonly int[,] matrixResult = new int[5, 5] {{0, -1, 1, 1, -1}, 
                                                         {1, 0, -1, -1, 1}, 
                                                         {-1, 1, 0, 1, -1}, 
                                                         {-1, 1, -1, 0, 1}, 
                                                         {1, -1, 1, -1, 0}};

    /*
     *  Create the game and store the result.
     */
    public RPSLS_Game(object sender)
	{
        userChoice = GetUserChoice(sender);
        computerChoice = GetComputerChoice();
        gameResult = matrixResult[(int)userChoice, (int)computerChoice];
	}

    /*
     * Get the user choice as RPSLS_Choices given a LinkButton sender.
     */
    public RPSLS_Choices GetUserChoice(object sender)
    {
        LinkButton usrSender = (LinkButton) sender;
        if (usrSender.Text.Equals("Rock"))
            return RPSLS_Choices.Rock;
        else if (usrSender.Text.Equals("Paper"))
            return RPSLS_Choices.Paper;
        else if (usrSender.Text.Equals("Scissors"))
            return RPSLS_Choices.Scissors;
        else if (usrSender.Text.Equals("Lizard"))
            return RPSLS_Choices.Lizard;
        else
            return RPSLS_Choices.Spok;
    }

    /*
     * Returns the computer choice as RPSLS_Choices choosing randomly a number
     * from 0 to 5.
     */
    public RPSLS_Choices GetComputerChoice()
    {
        return (RPSLS_Choices) (new Random()).Next(0, 5);
    }

    /*
     * Returns the computer choice as RPSLS_Choices.
     */
    public String GetResultMessage()
    {
        return "You " + getResultToString() + "! [PC choose " + (RPSLS_Choices) computerChoice + "]";
    }

    /*
     * Returns the result in a string format.
     */
    public String getResultToString()
    {
        if (gameResult < 0)
            return "lost";
        else if (gameResult > 0)
            return "won";
        else
            return "drawn";
    }
}