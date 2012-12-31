using System;
using System.Collections;
using System.Web.UI;
using FileBasket.PresentationModel.Presenters;
using FileBasket.PresentationModel.Views;

namespace FileBasket.Web
{
    public partial class Default : Page, IDefaultView
    {
        public DefaultPresenter Presenter
        {
            get
            {
                return new DefaultPresenter(this);
            }
        }


        public IEnumerable IntoFiles
        {
            get
            {
                return (IEnumerable) lvFiles.DataSource;
            }
            set
            {
                lvFiles.DataSource = value;
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.ShowFiles(txtSearch.Text.Trim(' '));
        }


        protected override void OnPreRender(EventArgs e)
        {
            lvFiles.DataBind();

            base.OnPreRender(e);
        }

        protected void btnDefaultSearch_Click(object sender, EventArgs e)
        {
        }
    }
}