using System;
using System.Web.Security;

namespace FileBasket.PresentationModel.Views
{
    public interface IUserManagementView
    {
        MembershipUser User
        {
            get;
        }

        string UserName
        {
            get;
            set;
        }

        string UserEmail
        {
            get;
            set;
        }

        DateTime CreationDate
        {
            get;
        }

        DateTime LastActicity
        {
            get;
        }

        bool IsOnline
        {
            get;
        }

        bool IsApproved
        {
            get;
        }

        string[] UserRoles
        {
            get;
        }
    }
}