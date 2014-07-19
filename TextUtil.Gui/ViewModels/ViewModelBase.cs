using System.ComponentModel;

namespace TextUtil.Gui.ViewModels
{
    // Base for all viewmodels - provides INotifyPropertyChanged implementation

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperytyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
