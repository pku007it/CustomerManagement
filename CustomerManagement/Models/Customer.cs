using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Models
{
    public class Customer: INotifyPropertyChanged, IDataErrorInfo
    {
        private string cName;

        public string CustomerName
        {
            get { return cName; }
            set { cName = value; OnPropertyChanged("CustomerName"); }
        }

        private string pass;


        public string Password
        {
            get { return pass; }
            set { pass = value; OnPropertyChanged("Password"); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!= null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "CustomerName":
                        if (string.IsNullOrEmpty(CustomerName))
                            result = "Please enter Customer Name";
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password))
                            result = "Please enter Password";
                        break;
                }
                return result;
            }
        }
    }
}
