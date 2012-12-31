using System;
using System.Collections;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileBasket.Data.v20;
using FileBasket.PresentationModel.Presenters;
using FileBasket.PresentationModel.Views;

namespace FileBasket.Web.AdminPages
{
    public partial class FileAdministrationPage : Page, IFileAdministrationView
    {
        private FileAdministrationPresenter Presenter
        {
            get
            {
                return new FileAdministrationPresenter(this);
            }
        }


        public IEnumerable StroredFiles
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnDeleteClick(object sender, EventArgs e)
        {
            if (gvFileGrid.SelectedIndex >= 0)
            {
                if (gvFileGrid.SelectedIndex < gvFileGrid.DataKeys.Count)
                {
                    DataKey dataKey = gvFileGrid.DataKeys[gvFileGrid.SelectedIndex];

                    if (dataKey != null)
                    {
                        Presenter.DeleteFile((int) dataKey.Value);
                    }
                }
            }
        }

        public IQueryable<StoredFile> SelectMethod()
        {
            return (IQueryable<StoredFile>) StroredFiles;
        }


        protected override void OnPreRender(EventArgs e)
        {
            StroredFiles = Presenter.SelectedMethod();
            gvFileGrid.DataBind();
            base.OnPreRender(e);
        }
    }
}