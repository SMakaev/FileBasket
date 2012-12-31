using System;
using System.Linq;
using FileBasket.Data.Repositories;
using FileBasket.Data.Repositories.Impl;
using FileBasket.Data.v20;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileBasket.Data.Tests
{
    [TestClass]
    public class UnitOfWorkTests
    {
        [TestMethod]
        public void TestFilesRead()
        {
            using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
            {
                unitOfWork.Files.GetAll().ToList().ForEach(file => Console.WriteLine(file.Name));
            }
        }

        [TestMethod]
        public void TestAddFile()
        {
            using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
            {
                unitOfWork.AttributeTypes.InsertOrUpdate(new AttributeType {Name = "test-test", Type = "Video"});
                unitOfWork.Commit();
            }
        }
    }
}