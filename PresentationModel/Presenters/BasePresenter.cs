namespace FileBasket.PresentationModel.Presenters
{
    public class BasePresenter<T>
    {
        public BasePresenter(T view)
        {
            View = view;
        }

        public T View
        {
            get;
            set;
        }
    }
}