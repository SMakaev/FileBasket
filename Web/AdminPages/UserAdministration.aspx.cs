using System;
using System.Collections;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using FileBasket.PresentationModel.Presenters;
using FileBasket.PresentationModel.Views;

namespace FileBasket.Web.AdminPages
{
    public partial class UserAdministration : Page, IUserAdministrationView
    {
        public UserAdministrationPresenter Presenter
        {
            get
            {
                return new UserAdministrationPresenter(this);
            }
        }

        #region IUserAdministrationView Members

        public IEnumerable UserList
        {
            get;
            set;
        }

        public string SelectUserName
        {
            get
            {
                return ucUserManagement.UserName;
            }
            set
            {
                ucUserManagement.UserName = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            UserList = Presenter.SelectMethod(txtSearchKeyWord.Text.Trim(' '));
        }

        protected void GvUserGridViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvUserGridView.SelectedIndex >= 0)
            {
                SelectUserName = ((string) gvUserGridView.SelectedValue);
            }
        }


        public IQueryable<MembershipUser> SelectMethod()
        {
            return (IQueryable<MembershipUser>) UserList;
        }

        protected override void OnPreRender(EventArgs e)
        {
            gvUserGridView.DataBind();
            base.OnPreRender(e);
        }
    }
}