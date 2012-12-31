using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using FileBasket.PresentationModel.Presenters;
using FileBasket.PresentationModel.Views;

namespace FileBasket.Web.PublicPages
{
    public partial class SingleFileInfo : Page, ISingleFileInfoView
    {
        public SingleFileInfoPresenter Presenter
        {
            get
            {
                return new SingleFileInfoPresenter(this);
            }
        }


        public IEnumerable AllComments
        {
            get
            {
                return (IEnumerable) lvCommentList.DataSource;
            }

            set
            {
                lvCommentList.DataSource = value;
            }
        }

        public IEnumerable FileInfo
        {
            get
            {
                return (IEnumerable) lvSingleFile.DataSource;
            }

            set
            {
                lvSingleFile.DataSource = value;
            }
        }

        public int FileId
        {
            get
            {
                try
                {
                    return int.Parse(Request.QueryString["id"]);
                }
                catch (FormatException)
                {
                }
                catch (ArgumentNullException)
                {
                }
                return 0;
            }
        }

        public string NewComment
        {
            get
            {
                var box = (HtmlTextArea) lvAddComment.FindControl("txtComment");
                return box.InnerText;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            Presenter.AddComment();
        }

        protected override void OnPreRender(EventArgs e)
        {
            Presenter.ShowFileInfo();
            DataBind();

            base.OnPreRender(e);
        }
    }
}