using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using FileBasket.Data.Repositories;
using FileBasket.Data.Repositories.Impl;
using FileBasket.Data.v20;
using FileBasket.PresentationModel.Views;

namespace FileBasket.PresentationModel.Presenters
{
    public class SingleFileInfoPresenter : BasePresenter<ISingleFileInfoView>
    {
        public SingleFileInfoPresenter(ISingleFileInfoView view) : base(view)
        {
        }


        private StoredFile Current
        {
            get;
            set;
        }

        public void AddComment()
        {
            MembershipUser membershipUser = Membership.GetUser();
            if (membershipUser != null)
            {
                using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
                {
                    Current = unitOfWork.Files.GetById(View.FileId);

                    if (Current != null)
                    {
                        unitOfWork.Comments.InsertOrUpdate(new Comment
                            {
                                StoredFile = Current,
                                User = membershipUser.UserName,
                                CommentText = View.NewComment
                            });
                        unitOfWork.Commit();
                    }
                }
            }
        }

        public void ShowFileInfo()
        {
            if (View.FileId != 0)
            {
                using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
                {
                    View.FileInfo =
                        unitOfWork.Files.GetAll().Where(id => id.Id == View.FileId)
                                  .Include(file => file.AttributeValue)
                                  .Include(value => value.AttributeValue.Select(attribute => attribute.Type))
                                  .ToList();


                    StoredFile firstOrDefault =
                        unitOfWork.Files.GetAll()
                                  .Include(file => file.FileComments)
                                  .FirstOrDefault(id => id.Id == View.FileId);

                    if (firstOrDefault != null)
                    {
                        View.AllComments = firstOrDefault.FileComments;
                    }
                }
            }
        }
    }
}