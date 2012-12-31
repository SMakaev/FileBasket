using System.Collections;

namespace FileBasket.PresentationModel.Views
{
    public interface IDefaultView
    {
        IEnumerable IntoFiles
        {
            get;
            set;
        }
    }
}