using System.Linq;
using FileBasket.Data.Repositories;
using FileBasket.Data.Repositories.Impl;
using FileBasket.Data.v20;
using FileBasket.PresentationModel.Views;

namespace FileBasket.PresentationModel.Presenters
{
    public class DefaultPresenter : BasePresenter<IDefaultView>
    {
        public DefaultPresenter(IDefaultView view) : base(view)
        {
        }

        public void ShowFiles(string searchKeyWord)
        {
            using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
            {
                View.IntoFiles =
                    unitOfWork.Files.GetAll()
                              .Where(file => file.Name.Contains(searchKeyWord) | file.FileType.Contains(searchKeyWord))
                              .ToList();
            }
        }
    }
}