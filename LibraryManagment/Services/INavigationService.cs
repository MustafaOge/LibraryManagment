namespace LibraryManagment.Services
{
    public interface INavigationService
    {
        object CurrentView { get; }
        void NavigateTo<TView>() where TView : class;
    }
}
