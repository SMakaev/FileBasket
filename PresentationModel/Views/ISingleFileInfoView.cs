using System.Collections;

namespace FileBasket.PresentationModel.Views
{
    public interface ISingleFileInfoView
    {
        IEnumerable AllComments
        {
            get;
            set;
        }

        IEnumerable FileInfo
        {
            get;
            set;
        }

        int FileId
        {
            get;
        }

        string NewComment
        {
            get;
        }
    }
}