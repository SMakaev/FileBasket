using System;
using System.ComponentModel.DataAnnotations.Schema;
using FileBasket.Data.Repositories;

namespace FileBasket.Data.v20
{
    public class Comment : IEntity

    {
        public Comment()
        {
            CreationDate = DateTime.Now;
        }

        public string User
        {
            get;
            set;
        }

        public StoredFile StoredFile
        {
            get;
            set;
        }

        [ForeignKey("StoredFile")]
        public int StrotedFileId
        {
            get;
            set;
        }

        public string CommentText
        {
            get;
            set;
        }

        public DateTime CreationDate
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }
    }
}