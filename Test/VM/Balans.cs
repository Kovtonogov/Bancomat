using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.VM.Base;
using Test.Viw;
using Test.Utils;


namespace Test.VM
{
    class BalansVM:Vmodel
    {       

        private String _Users = "Mister_xXx";
        public String Users
        {

            get { return _Users; }
            set
            {
                _Users = value;
                OnPropertyChanged("Users");
            }
        }    
        
    }

    
}
