using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliburn_MVVM.ViewModels
{
    public class ShellViewModel: Screen
    {
        private string _strFirstName = "Leamon";

        public string strFirstName
        {
            get { return _strFirstName = "Leamon"; }
            set
            {
                _strFirstName = value;
                NotifyOfPropertyChange(() => strFirstName);
            }
        }

        private string _strLastName;

        public string strLastName
        {
            get { return _strLastName; }
            set
            {
                _strLastName = value;
                NotifyOfPropertyChange(() => strLastName);
            }
        }

        
        public string strFullName
        {
            get { return $"{strFirstName} {strLastName}"; }
            
        }

    }
}
