using System.Collections.Generic;
using FileBasket.PresentationModel.Presenters;

namespace FileBasket.PresentationModel.Views
{
    public interface IFileUploadingViewV20
    {
        string FileName
        {
            get;
            set;
        }

        string FullName
        {
            get;
        }

        string ServerFilePath
        {
            get;
        }

        byte[] FileImageBytes
        {
            get;
        }

        int FileSize
        {
            get;
        }

        List<AttributesPresentationModel> FileAttributes
        {
            get;
            set;
        }

        string FileType
        {
            get;
            set;
        }

        IEnumerable<string> TypesOfAttributes
        {
            get;
            set;
        }
    }
}