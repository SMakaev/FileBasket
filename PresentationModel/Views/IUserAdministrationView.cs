using System.Collections;

namespace FileBasket.PresentationModel.Views
{
    public interface IUserAdministrationView
    {
        IEnumerable UserList
        {
            get;
            set;
        }

        string SelectUserName
        {
            get;
            set;
        }
    }
}