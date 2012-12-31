using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using FileBasket.PresentationModel.Presenters;
using FileBasket.PresentationModel.Views;
using Image = System.Drawing.Image;

namespace FileBasket.Web.UserControls
{
    public partial class FileUploadingV20 : UserControl, IFileUploadingViewV20
    {
        private const string Attributeskey = "AttributesKey";
        private const string TypesKey = "TypesKey";

        public FileUploadingV20Presenter Presenter
        {
            get
            {
                return new FileUploadingV20Presenter(this);
            }
        }

        #region IFileUploadingViewV20 Members

        public string FileName
        {
            get
            {
                return txtFileName.Text;
            }
            set
            {
                txtFileName.Text = value;
            }
        }


        public string FullName
        {
            get
            {
                return FileUpload.HasFile ? FileUpload.FileName : "";
            }
        }

        public string ServerFilePath
        {
            get
            {
                return FileUpload.HasFile
                           ? ResolveFilePath()
                           : "";
            }
        }

        public byte[] FileImageBytes
        {
            get
            {
                if (ImageUpload.HasFile && ImageUpload.PostedFile.ContentType.ToLower().Contains("image"))
                {
                    using (var ms = new MemoryStream())
                    {
                        Image.FromStream(ImageUpload.PostedFile.InputStream)
                             .GetThumbnailImage(300, 200, null, IntPtr.Zero)
                             .Save(ms, ImageFormat.Gif);

                        return ms.ToArray();
                    }
                }
                return null;
            }
        }

        public int FileSize
        {
            get
            {
                return FileUpload.HasFile ? FileUpload.PostedFile.ContentLength : 0;
            }
        }

        public List<AttributesPresentationModel> FileAttributes
        {
            get
            {
                return (List<AttributesPresentationModel>) Session[Attributeskey];
            }
            set
            {
                Session[Attributeskey] = value;
            }
        }

        public string FileType
        {
            get
            {
                return ddlFileType.SelectedValue;
            }
            set
            {
                ddlFileType.SelectedValue = value;
            }
        }

        public IEnumerable<string> TypesOfAttributes
        {
            get
            {
                return (IEnumerable<string>) Session[TypesKey];
            }
            set
            {
                Session[TypesKey] = value;
            }
        }

        private string ResolveFilePath()
        {
            return
                Path.Combine(
                    ConfigurationManager.AppSettings["UploadFolder"].Replace("~", AppDomain.CurrentDomain.BaseDirectory),
                    FileType, FileName);
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.ExistTypesInicialize();
                ddlFileType.DataSource = TypesOfAttributes;
                ddlFileType.DataBind();
                Presenter.InicializeStandardAttributeSet();
                AttributesRepeater.DataSource = FileAttributes;
            }


            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                AttributesRepeater.DataSource = FileAttributes;
                foreach (RepeaterItem item in AttributesRepeater.Items)
                {
                    AttributesPresentationModel attribute = FileAttributes[item.ItemIndex];
                    var valueTextBox = (HtmlTextArea) item.FindControl("txtAttributeValue");
                    var nameTextBox = (TextBox) item.FindControl("txtAttributeName");
                    if (attribute.IsStandard)
                    {
                        attribute.ValueOfAttribute = valueTextBox.InnerText;
                    }
                    else
                    {
                        attribute.NameOfAttribute = nameTextBox.Text.Trim(' ');
                        attribute.ValueOfAttribute = valueTextBox.InnerText.Trim(' ');
                    }
                }
            }
        }


        private bool IsValidForUpload()
        {
            try
            {
                string path = Path.Combine(ServerFilePath, FileUpload.FileName);
                if (FileUpload.HasFile && !ImageUpload.PostedFile.ContentType.ToLower().Contains("image"))
                {
                    throw new Exception(message: "is not image");
                }
            }

            catch (ArgumentException)
            {
                lblError.Text = "Possible Invalid File Name";
                lblError.Visible = true;
                return false;
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
                lblError.Visible = true;
                return false;
            }
            return true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            AttributesRepeater.DataBind();
            base.OnPreRender(e);
        }

        protected void DdlFileTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Presenter.InicializeStandardAttributeSet();
                AttributesRepeater.DataSource = FileAttributes;
            }
        }

        protected void BtnAddAttributeClick(object sender, EventArgs e)
        {
            Presenter.AddNewAttribute();
        }

        protected void BtnUploadFileClick(object sender, EventArgs e)
        {
            if (IsValidForUpload())
            {
                if (FileUpload.HasFile)
                {
                    Presenter.CreateFileFolder();
                    FileUpload.SaveAs(Path.Combine(ServerFilePath, FileUpload.FileName));
                    Presenter.FileSave();
                }
            }
        }
    }
}