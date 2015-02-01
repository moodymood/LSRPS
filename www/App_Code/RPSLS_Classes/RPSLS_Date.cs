using System;
using System.Web.UI.WebControls;

/*
 * SUMMARY
 *  For details see @http://www.aspsnippets.com/Articles/Select-Day-Month-and-Year-Date-from-DropDownList-in-ASPNet.aspx
*/

public class RPSLS_Date
{
    DropDownList ddlDay;
    DropDownList ddlMonth;
    DropDownList ddlYear;

    public RPSLS_Date(DropDownList DD, DropDownList MM, DropDownList YYYY)
	{
        ddlDay = DD;
        ddlMonth = MM;
        ddlYear = YYYY;
        PopulateYear();
        PopulateMonth();
        PopulateDay();
    }

    private int Day
    {
        get
        {
            return int.Parse(ddlDay.SelectedItem.Value);
        }
        set
        {
            this.PopulateDay();
            ddlDay.ClearSelection();
            ddlDay.Items.FindByValue(value.ToString()).Selected = true;
        }
    }

    private int Month
    {
        get
        {
            return int.Parse(ddlMonth.SelectedItem.Value);
        }
        set
        {
            this.PopulateMonth();
            ddlMonth.ClearSelection();
            ddlMonth.Items.FindByValue(value.ToString()).Selected = true;
        }
    }

    private int Year
    {
        get
        {
            return int.Parse(ddlYear.SelectedItem.Value);
        }
        set
        {
            this.PopulateYear();
            ddlYear.ClearSelection();
            ddlYear.Items.FindByValue(value.ToString()).Selected = true;
        }
    }

    public DateTime SelectedDate
    {
        get
        {
            try
            {
                return DateTime.Parse(this.Year + "-" + this.Month + "-" + this.Day);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        set
        {
            if (!value.Equals(DateTime.MinValue))
            {
                this.Year = value.Year;
                this.Month = value.Month;
                this.Day = value.Day;
            }
        }
    }

    public void PopulateDay()
    {
        ddlDay.Items.Clear();
        ListItem lt = new ListItem();
        int days = DateTime.DaysInMonth(this.Year, this.Month);
        for (int i = 1; i <= days; i++)
        {
            lt = new ListItem();
            lt.Text = i.ToString();
            lt.Value = i.ToString();
            ddlDay.Items.Add(lt);
        }
        ddlDay.Items.FindByValue(DateTime.Now.Day.ToString()).Selected = true;
    }

    public void PopulateMonth()
    {
        ddlMonth.Items.Clear();
        ListItem lt = new ListItem();
        for (int i = 1; i <= 12; i++)
        {
            lt = new ListItem();
            lt.Text = Convert.ToDateTime(i.ToString() + "/1/1900").ToString("MMMM");
            lt.Value = i.ToString();
            ddlMonth.Items.Add(lt);
        }
        ddlMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
    }

    public void PopulateYear()
    {
        ddlYear.Items.Clear();
        ListItem lt = new ListItem();
        for (int i = DateTime.Now.Year; i >= 1900; i--)
        {
            lt = new ListItem();
            lt.Text = i.ToString();
            lt.Value = i.ToString();
            ddlYear.Items.Add(lt);
        }
        ddlYear.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
    }   
}