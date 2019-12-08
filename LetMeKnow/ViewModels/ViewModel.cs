using System.ComponentModel;

namespace LetMeKnow.ViewModels
{
    // All page logic subclasses should extend this to have property changed detection
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsBusy { protected set; get;  }
    }
}
