using System.Collections;

namespace FileBasket.PresentationModel.Views
{
    public interface IFileAdministrationView
    {
        IEnumerable StroredFiles
        {
            get;
            set;
        }
    }
}