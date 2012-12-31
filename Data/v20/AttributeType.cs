using System;
using System.ComponentModel.DataAnnotations;
using FileBasket.Data.Repositories;

namespace FileBasket.Data.v20
{
    public class AttributeType : IEntity
    {
        public String Type
        {
            get;
            set;
        }


        public String Name
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