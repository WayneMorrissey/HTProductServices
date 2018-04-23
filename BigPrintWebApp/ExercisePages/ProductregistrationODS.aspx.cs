using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BigPrintWebApp.ExercisePages
{
    public partial class ProductregistrationODS : System.Web.UI.Page
    {
        List<string> errmsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageList.DataSource = null;
            MessageList.DataBind();
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            MessageList.CssClass = cssclass;
            MessageList.DataSource = errormsglist;
            MessageList.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ModelNumber.Text))
            {
                errmsgs.Add("Please enter a partial model number to search registrations.");
                LoadMessageDisplay(errmsgs, "alert alert-warning");
            }
        }
    }
}