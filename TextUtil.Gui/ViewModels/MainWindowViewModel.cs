namespace TextUtil.Gui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; private set; }

        public MainWindowViewModel()
        {
            // Only one viewmodel in this app which is WordCountsViewModel
            // so lets set it as the default 

            CurrentViewModel = new WordCountsViewModel();
        }
    }
}
