using System;
using System.IO;
using System.Web;
using FileBasket.Data.Repositories;
using FileBasket.Data.Repositories.Impl;
using FileBasket.Data.v20;

namespace FileBasket.Web.LoggedInPages
{
    /// <summary>
    ///     Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler
    {
        #region IHttpHandler Members

        public void ProcessRequest(HttpContext context)
        {
            int fileId;
            if (int.TryParse(context.Request.QueryString["id"], out fileId))
            {
                fileId = Convert.ToInt32(context.Request.QueryString["id"]);
                string filePath = null;

                using (IFilesUnitOfWork unitOfWork = new FilesUnitOfWork(new FileDbContext()))
                {
                    StoredFile firstOrDefault = unitOfWork.Files.GetById(fileId);
                    if (firstOrDefault != null)
                    {
                        filePath = firstOrDefault.PathOnServer;
                    }
                }
                context.Response.AddHeader(
                    "content-disposition", "attachment;filename=" + "\"" + Path.GetFileName(filePath) + "\"");

                using (FileStream stream = File.OpenRead(filePath))
                {
                    stream.CopyTo(context.Response.OutputStream);
                    context.Response.OutputStream.Flush();
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}