using System.Data.Entity;
using FileBasket.Data.v20;

namespace FileBasket.Data.Repositories.Impl
{
    public class FilesUnitOfWork : IFilesUnitOfWork
    {
        private readonly DbContext context;
        private IRepository<AttributeValue> attibuteValueRepository;
        private IRepository<AttributeType> attributeTypeRepository;
        private IRepository<Comment> fileCommentRepository;
        private IRepository<FileImage> fileImageRepository;
        private IRepository<StoredFile> fileRepository;

        public FilesUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        #region IFilesUnitOfWork Members

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public IRepository<StoredFile> Files
        {
            get
            {
                return fileRepository ?? (fileRepository = new GenericRepository<StoredFile>(context));
            }
        }

        public IRepository<AttributeType> AttributeTypes
        {
            get
            {
                return attributeTypeRepository ??
                       (attributeTypeRepository = new GenericRepository<AttributeType>(context));
            }
        }

        public IRepository<FileImage> FileImages
        {
            get
            {
                return fileImageRepository ?? (fileImageRepository = new GenericRepository<FileImage>(context));
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return fileCommentRepository ?? (fileCommentRepository = new GenericRepository<Comment>(context));
            }
        }

        public IRepository<AttributeValue> Attributes
        {
            get
            {
                return attibuteValueRepository ??
                       (attibuteValueRepository = new GenericRepository<AttributeValue>(context));
            }
        }


        public void Commit()
        {
            context.SaveChanges();
        }

        #endregion
    }
}