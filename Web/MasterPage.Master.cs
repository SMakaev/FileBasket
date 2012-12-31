using System;
using System.Web.Security;

namespace FileBasket.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            MembershipUser membershipUser = Membership.GetUser();
            if (membershipUser != null)
            {
                lblUserName.Text = membershipUser.UserName;
            }
            base.OnInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)

        {
            Page.Header.DataBind();
        }

        protected void OnError(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}