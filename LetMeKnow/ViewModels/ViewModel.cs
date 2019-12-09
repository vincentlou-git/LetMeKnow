using System.ComponentModel;

namespace LetMeKnow.ViewModels
{
    // All ViewModel subclasses should extend this to have property changed detection
    // so targets can be updated when a property changes
    // Added PropertyChanged.Fody (a helper nuget) that generates the code to handle property updates
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsBusy { protected set; get;  }

        protected void OnPropertyChanged(string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
