using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FileBasket.Data.Repositories;

namespace FileBasket.Data.v20
{
    public class AttributeValue : IEntity
    {
        public virtual StoredFile StoredFile
        {
            get;
            set;
        }

        public virtual AttributeType Type
        {
            get;
            set;
        }

        [ForeignKey("StoredFile")]
        public int FileId
        {
            get;
            set;
        }


        public string Value
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