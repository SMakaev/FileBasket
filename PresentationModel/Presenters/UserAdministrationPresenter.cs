using System.Linq;
using System.Web.Security;
using FileBasket.PresentationModel.Views;

namespace FileBasket.PresentationModel.Presenters
{
    public class UserAdministrationPresenter : BasePresenter<IUserAdministrationView>
    {
        public UserAdministrationPresenter(IUserAdministrationView view)
            : base(view)
        {
        }


        public IQueryable<MembershipUser> SelectMethod(string searchKeyWord = "")
        {
            var result = new MembershipUserCollection();

            if (searchKeyWord != "")
            {
                foreach (MembershipUser user in Membership.GetAllUsers())
                {
                    if (user.UserName.ToUpper().Contains(searchKeyWord.ToUpper()))
                    {
                        result.Add(user);
                    }
                    if (user.Email.ToUpper().Contains(searchKeyWord.ToUpper()))
                    {
                        result.Add(user);
                    }
                }
                return result.OfType<MembershipUser>().AsQueryable();
            }
            return Membership.GetAllUsers().OfType<MembershipUser>().AsQueryable();
        }
    }
}