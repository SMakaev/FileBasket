using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FileBasket.Data.Repositories;

namespace FileBasket.Data.v20
{
    public class StoredFile : IEntity
    {
        public StoredFile()
        {
            AttributeValue = new List<AttributeValue>();
            FileComments = new List<Comment>();
            CreationDate = DateTime.Now;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }

        public double Size
        {
            get;
            set;
        }

        public string FileType
        {
            get;
            set;
        }

        public FileImage Image
        {
            get;
            set;
        }

        [ForeignKey("Image")]
        public int ImageId
        {
            get;
            set;
        }

        public double Raiting
        {
            get;
            set;
        }

        public string PathOnServer
        {
            get;
            set;
        }


        public DateTime CreationDate
        {
            get;
            set;
        }


        public virtual ICollection<AttributeValue> AttributeValue
        {
            get;
            set;
        }

        public virtual ICollection<Comment> FileComments
        {
            get;
            set;
        }

        [Key]
        public int Id
        {
            get;
            set;
        }
    }
}