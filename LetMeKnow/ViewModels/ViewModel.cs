using System.ComponentModel;

namespace LetMeKnow.ViewModels
{
    // All ViewModel subclasses should extend this to have property changed detection
    // so targets can be updated when a property changes
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsBusy { protected set; get;  }
    }
}
