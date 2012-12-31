using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileBasket.Data
{
  public  class File
    {
        public int FileID
        {
            get;
            set;
        }
        [MaxLength(50)]
        public string FileName
        {
            get;
            set;
        }

        public Dictionary<string,string> Description
        {
            get;
            set;
        }
        
        public string FileUrl
        {
            get;
            set;
        }
       
        public int Populatity
        {
            get;
            set;
        }

        public double FileSize
        {
            get;
            set;
        }
    }
}
