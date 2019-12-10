using CustomerManagement.Commands;
using CustomerManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CustomerManagement.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Customer customer;

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; OnPropertyChanged("Customer"); }
        }
        public LoginViewModel()
        {
            Customer = new Customer();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand command;

        public ICommand SubmitCommand
        {
            get
            {
                if (command == null)
                {
                    command = new Command(Execute, canExecute);
                }
                return command;
            }
        }

        private void Execute(object parameter)
        {
            MessageBox.Show("Welcome "+ Customer.CustomerName + " in Customer Portal");
        }

        private bool canExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Customer.CustomerName))
            {
                return false;
            }
            return true;
        }

    }
}
