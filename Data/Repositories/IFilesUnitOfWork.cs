using System;
using FileBasket.Data.v20;

namespace FileBasket.Data.Repositories
{
    public interface IFilesUnitOfWork : IDisposable
    {
        IRepository<StoredFile> Files
        {
            get;
        }

        IRepository<AttributeType> AttributeTypes
        {
            get;
        }

        IRepository<FileImage> FileImages
        {
            get;
        }

        IRepository<Comment> Comments
        {
            get;
        }

        IRepository<AttributeValue> Attributes
        {
            get;
        }

        void Commit();
    }
}