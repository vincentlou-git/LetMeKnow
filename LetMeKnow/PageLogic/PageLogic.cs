using System.ComponentModel;

namespace LetMeKnow.PageLogic
{
    // All page logic subclasses should extend this to have property changed detection
    public class PageLogic : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsBusy { protected set; get;  }
    }
}
