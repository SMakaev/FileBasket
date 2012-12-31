using FileBasket.Data.Repositories;

namespace FileBasket.Data.v20
{
    public class FileImage : IEntity
    {
        public byte[] ImageBytes
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