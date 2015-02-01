using System;

/*
 * SUMMARY
 * The RPSLS_User models the user of the system. It contains only the name and the date of birth 
 * but it can be used to easily support the implementation of new functionalities (such as e-mail, 
 * password, etc..)
*/

public class RPSLS_User
{
    /*
     * Fields to store user info at the moment of the registration
     */
    private String userName;
    private DateTime dateOfBirth;

    public RPSLS_User(String userName, DateTime dateOfBirth)
    {
        this.userName = userName.Trim();
        this.dateOfBirth = dateOfBirth;
    }

    /*
     *  Get the username 
     */
    public String GetUserName()
    {
        return userName;
    }

    /*
     * Get the date of birth as DataTime
     */
    public DateTime GetdateOfBirth()
    {
        return dateOfBirth;
    }

    /*
     * Get the date of birth as String
     */
    public String GetdateOfBirthToString()
    {
        return dateOfBirth.ToShortDateString();
    }

    /*
     * Check if is it the user birthday
     */
    public bool IsBirthday()
    {
        if (DateTime.Now.Day == dateOfBirth.Day && DateTime.Now.Month == dateOfBirth.Month)
            return true;
        else
            return false;
    }
}