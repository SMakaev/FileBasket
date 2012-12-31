using System;
using System.IO;
using System.Web;
using FileBasket.Data.Repositories;
using FileBasket.Data.Repositories.Impl;
using FileBasket.Data.v20;

namespace FileBasket.Web.PublicPages
{
    /// <summary>
    ///     Summary description for ImagePresentation
    /// </summary>
    public class ImagePresentation : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            int imageId = int.Parse(context.Request.QueryString["id"]);
            byte[] imageBytes = null;
            using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
            {
                FileImage firstOrDefault = unitOfWork.FileImages.GetById(imageId);
                if (firstOrDefault != null)
                {
                    imageBytes = firstOrDefault.ImageBytes;
                }
                if (imageBytes == null)
                {
                    imageBytes =
                        File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/App_Data/Samples/img/file.png");
                }
            }

            context.Response.AddHeader("content-type", "image/jpeg");
            context.Response.OutputStream.Write(imageBytes, 0, imageBytes.Length);
            context.Response.OutputStream.Flush();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}