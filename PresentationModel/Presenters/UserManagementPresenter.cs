using System.Web.Security;
using FileBasket.PresentationModel.Views;

namespace FileBasket.PresentationModel.Presenters
{
    public class UserManagementPresenter : BasePresenter<IUserManagementView>
    {
        public UserManagementPresenter(IUserManagementView view)
            : base(view)
        {
        }

        public MembershipUser CurrentUser
        {
            get
            {
                return Membership.GetUser(View.UserName);
            }
        }

        public void DeleteUser()
        {
            if (View.User != null)
            {
                Membership.DeleteUser(View.User.UserName);
            }
        }

        public void UpdateUser()
        {
            if (View.User != null)
            {
                View.User.Email = View.UserEmail;
                View.User.IsApproved = View.IsApproved;

                foreach (string role in Roles.GetAllRoles())
                {
                    if (Roles.IsUserInRole(View.User.UserName, role))
                    {
                        Roles.RemoveUserFromRole(View.User.UserName, role);
                    }
                }
                if (View.UserRoles.Length != 0)
                {
                    Roles.AddUserToRoles(View.User.UserName, View.UserRoles);
                }
                Membership.UpdateUser(View.User);
            }
        }
    }
}