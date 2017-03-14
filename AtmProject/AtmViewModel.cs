using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AtmProject
{
    public class AtmViewModel : ViewModelBase
    {
        private string _withdrawlamount = "";
        private string _notes = "";
        private string _bigcoins = "";
        private string _smallcoins = "";
        private MoneySorter sorter = new MoneySorter();

       private ICommand _calculatewithdrawlcommand;
       private ICommand _clearbinscommand;


        public string WithDrawlAmount
        {
            get
            {
                return _withdrawlamount;
            }

            set
            {
                if (_withdrawlamount.Equals(value)) return;
                _withdrawlamount = value;
                OnPropertyChanged("WithDrawlAmount");
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                if (_notes.Equals(value)) return;
                _notes = value;
                OnPropertyChanged();
            }
        }

        public string BigCoins
        {
            get { return _bigcoins; }
            set
            {
                if (_bigcoins.Equals(value)) return;
                _bigcoins = value;
                OnPropertyChanged();
            }
           
        }
        public string SmallCoins
        {
            get { return _smallcoins; }
            set
            {
                if (_smallcoins.Equals(value)) return;
                _smallcoins = value;
                OnPropertyChanged();
            }
        }

        public AtmViewModel()
        {
            sorter.InitializeMoneyValues();
            WithDrawlAmount = "0";
            OnPropertyChanged();
        }

        public ICommand CalculateWithdrawlCommand
        {
            get
            {
 
                if (_calculatewithdrawlcommand == null)
                    _calculatewithdrawlcommand = new RelayCommand(withdrawcommandfunction);
                return _calculatewithdrawlcommand;
            }

        }


        public ICommand ClearBinsCommand
        {
            get
            {
                
                if (_clearbinscommand == null)
                    _clearbinscommand = new RelayCommand(clearbinscommandfunction);
                return _clearbinscommand;
            }

        }

        private void clearbinscommandfunction(Object o)
        {
            Notes = "";
            BigCoins = "";
            SmallCoins = "";
            WithDrawlAmount = "0";
            OnPropertyChanged();
        }

        private string getCurrencyString(KeyValuePair<int, int> moneyPair)
        {
            return moneyPair.Key.ToString() + "Kr * " + moneyPair.Value.ToString() + "\n";
        }

        private void withdrawcommandfunction(Object o)
        {
            int withdrawlamount = int.Parse(WithDrawlAmount);
            Dictionary<int, int> moneyamounts = sorter.CalculateMoneyAmounts(withdrawlamount);
            foreach (var money in moneyamounts)
            {
                int bin = sorter.FindBin(money.Key);
                if (bin == 0)
                {
                    Notes += getCurrencyString(money);
                }
                if (bin == 1)
                {
                    BigCoins += getCurrencyString(money);
                }
                if (bin == 2)
                {
                    SmallCoins += getCurrencyString(money);
                }

            }
         OnPropertyChanged();
        }

    }

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members
    }

    /// <summary>
    /// A command whose sole purpose is to 
    /// relay its functionality to other
    /// objects by invoking delegates. The
    /// default return value for the CanExecute
    /// method is 'true'.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;
       

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand( Action<object> execute,  Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// 
        /// Convenient constructor shortcuts without action arguments.
        /// 

        public RelayCommand(Action execute,  Func<bool> canExecute) : this(obj => execute(), obj => canExecute == null || canExecute()) { }


      
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
                try
                {
                    execute(parameter);
                }
                catch (Exception ex)
                {
                
                }
        }
    }

}
