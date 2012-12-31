using System;
using System.Globalization;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileBasket.PresentationModel.Presenters;
using FileBasket.PresentationModel.Views;

namespace FileBasket.Web.UserControls
{
    public partial class UserManagement : UserControl, IUserManagementView
    {
        private const string TimeFormat = "dd/MM/yyyy HH:mm:ss";
        private const string CurrentUser = "CurrentUser";

        private UserManagementPresenter Presenter
        {
            get
            {
                return new UserManagementPresenter(this);
            }
        }

        #region IUserManagementView Members

        public MembershipUser User
        {
            get
            {
                return (MembershipUser) Session[CurrentUser];
            }
            private set
            {
                Session[CurrentUser] = value;
            }
        }

        public string UserName
        {
            get
            {
                return lblUserName.Text;
            }
            set
            {
                lblUserName.Text = value;
            }
        }

        public string UserEmail
        {
            get
            {
                return txtUserEmail.Text;
            }
            set
            {
                txtUserEmail.Text = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return DateTime.ParseExact(lblDateOfRegistration.Text, TimeFormat, CultureInfo.InvariantCulture);
            }
            private set
            {
                lblDateOfRegistration.Text = value.ToString(TimeFormat, CultureInfo.InvariantCulture);
            }
        }

        public DateTime LastActicity
        {
            get
            {
                return DateTime.ParseExact(lblLastActivity.Text, TimeFormat, CultureInfo.InvariantCulture);
            }
            private set
            {
                lblLastActivity.Text = value.ToString(TimeFormat, CultureInfo.InvariantCulture);
            }
        }

        public bool IsOnline
        {
            get
            {
                return lblIsOnline.Text == "Online";
            }
            private set
            {
                lblIsOnline.Text = value ? "Online" : "Offline";
            }
        }

        public bool IsApproved
        {
            get
            {
                return ddlIsUserApproved.SelectedValue == "Approved";
            }
            private set
            {
                ddlIsUserApproved.SelectedValue = value ? "Approved" : "Banned";
            }
        }

        public string[] UserRoles
        {
            get
            {
                string[] result = (from ListItem item in cbUserRoles.Items
                                   where item.Selected
                                   select item.Value).ToArray();
                return result;
            }
            private set
            {
                cbUserRoles.ClearSelection();
                foreach (string str in value)
                {
                    cbUserRoles.Items.FindByText(str).Selected = true;
                }
            }
        }

        #endregion

        private void LoadData()
        {
            User = Presenter.CurrentUser;
            if (User != null)
            {
                UserName = User.UserName;
                UserEmail = User.Email;
                UserRoles = Roles.GetRolesForUser(User.UserName);
                CreationDate = User.CreationDate;
                LastActicity = User.LastActivityDate;
                IsOnline = User.IsOnline;
                IsApproved = User.IsApproved;
            }
        }


        protected override void OnInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                cbUserRoles.DataSource = Roles.GetAllRoles();
                cbUserRoles.DataBind();
            }

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected override void OnPreRender(EventArgs e)
        {
            LoadData();
            base.OnPreRender(e);
        }

        protected void BtnDeleteUserClick(object sender, EventArgs e)
        {
            Presenter.DeleteUser();
            Response.Redirect("~/AdminPages/UserAdministration.aspx");
            User = null;
        }

        protected void BtnUpdateUserClick(object sender, EventArgs e)
        {
            Presenter.UpdateUser();
        }
    }
}