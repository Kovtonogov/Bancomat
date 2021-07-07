using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.VM.Base;
using System.Windows.Controls;
using Test.Viw;
using Test.Utils;


namespace Test.VM
{

    class MainWindowVM:Vmodel
    {
        public event EventHandler EventCloseWindow;
        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);

        private UserControl view;

        public UserControl UserInterface
        {
            get
            {
                if (view == null)
                {
                    view = new Main();

                }                
                return view;
            }
        }

        private RelayCommand _ChangeHeadTextCommand;
        public RelayCommand ChangeHeadTextCommand
        {
            get
            {
                return _ChangeHeadTextCommand ??
                  (_ChangeHeadTextCommand = new RelayCommand(obj =>
                  {

                      view = new Balans();

                      OnPropertyChanged("UserInterface");
                  }));
            }
        }
        
        private RelayCommand _Back;
        public RelayCommand Back
        {
            get
            {
                return _Back ??
                  (_Back = new RelayCommand(obj =>
                  {

                      view = new Main();

                      OnPropertyChanged("UserInterface");
                  }));
            }
        }

        private RelayCommand _Give;
        public RelayCommand Give
        {
            get
            {
                return _Give ??
                  (_Give = new RelayCommand(obj =>
                  {

                      view = new GiveMoney();

                      OnPropertyChanged("UserInterface");
                  }));
            }
        }

        private RelayCommand _Take;
        public RelayCommand Take
        {
            get
            {
                return _Take ??
                  (_Take = new RelayCommand(obj =>
                  {

                      view = new TakeMoney();

                      OnPropertyChanged("UserInterface");
                  }));
            }
        }


        private RelayCommand _Exit;
        public RelayCommand Exit
        {
            get
            {
                return _Exit ??
                  (_Exit = new RelayCommand(obj =>
                  {
                      CloseWindow();                      
                  }));
            }
        }

        
        private String _Users;        
        public String Users
        {
            
                get { return _Users; }
                set
                {
                    _Users = value;
                     
                }
        }

    }
}
