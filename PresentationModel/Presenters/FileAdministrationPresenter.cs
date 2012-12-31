using System.Collections;
using System.IO;
using System.Linq;
using FileBasket.Data.Repositories;
using FileBasket.Data.Repositories.Impl;
using FileBasket.Data.v20;
using FileBasket.PresentationModel.Views;

namespace FileBasket.PresentationModel.Presenters
{
    public class FileAdministrationPresenter : BasePresenter<IFileAdministrationView>

    {
        public FileAdministrationPresenter(IFileAdministrationView view)
            : base(view)
        {
        }


        public IEnumerable SelectedMethod()
        {
            using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
            {
                return unitOfWork.Files.GetAll().ToList().AsQueryable();
            }
        }

        public void DeleteFile(int fileId)
        {
            using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
            {
                StoredFile current = unitOfWork.Files.GetById(fileId);
                if (current != null)
                {
                    File.Delete(current.PathOnServer);
                    unitOfWork.Files.Delete(current);
                }
                unitOfWork.Commit();
            }
        }
    }
}