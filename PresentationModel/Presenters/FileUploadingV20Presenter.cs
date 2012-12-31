using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileBasket.Data.Repositories;
using FileBasket.Data.Repositories.Impl;
using FileBasket.Data.v20;
using FileBasket.PresentationModel.Views;

namespace FileBasket.PresentationModel.Presenters
{
    public class FileUploadingV20Presenter : BasePresenter<IFileUploadingViewV20>
    {
        public FileUploadingV20Presenter(IFileUploadingViewV20 view)
            : base(view)
        {
        }

        public void ExistTypesInicialize()
        {
            using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
            {
                View.TypesOfAttributes =
                    unitOfWork.AttributeTypes.GetAll().Where(type => type.Type != null)
                              .Select(type => type.Type)
                              .Distinct()
                              .ToList();
            }
        }

        public void InicializeStandardAttributeSet()
        {
            using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
            {
                var result = new List<AttributesPresentationModel>();
                unitOfWork.AttributeTypes.GetAll().Where(type => type.Type == View.FileType)
                          .ToList()
                          .ForEach(
                              attrubute =>
                              result.Add(new AttributesPresentationModel
                                  {
                                      NameOfAttribute = attrubute.Name,
                                      ValueOfAttribute = "",
                                      IsStandard = true
                                  }));
                View.FileAttributes = result;
            }
        }

        public void AddNewAttribute()
        {
            View.FileAttributes.Add(new AttributesPresentationModel {IsStandard = false});
        }

        public void FileSave()
        {
            using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
            {
                var newFile = new StoredFile
                    {
                        Name = View.FileName,
                        Raiting = 0,
                        FileType = View.FileType,
                        Size = View.FileSize,
                        PathOnServer = View.ServerFilePath + "\\" + View.FullName,
                        Image = new FileImage {ImageBytes = View.FileImageBytes}
                    };

                foreach (AttributesPresentationModel attribute in View.FileAttributes)
                {
                    if (attribute.ValueOfAttribute != "" && attribute.NameOfAttribute != "")
                    {
                        newFile.AttributeValue.Add(new AttributeValue
                            {
                                Type = new AttributeType {Name = attribute.NameOfAttribute},
                                StoredFile = newFile,
                                Value = attribute.ValueOfAttribute
                            });
                    }
                }
                unitOfWork.Files.InsertOrUpdate(newFile);
                unitOfWork.Commit();
            }
        }

        public string CreateFileFolder()
        {
            string path = View.ServerFilePath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}