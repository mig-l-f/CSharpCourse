using System;
using System.Windows.Input;

namespace FezStore.ViewModel
{
    public class CommandViewModel : ViewModelBase
    {
        public CommandViewModel(string displayName, ICommand command) 
        { 
            if (command == null) throw new ArgumentNullException("command"); 
            base.DisplayName = displayName; 
            this.Command = command; 
        } 
        
        public ICommand Command { get; private set; }
    }
}
