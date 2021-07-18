using System;
using Test.VM.Base;
using System.Windows.Controls;
using Test.Viw;
using Test.Utils;
using Test.Model;
using Test.Dialog;



namespace Test.VM
{

    class MainWindowVM : Vmodel
    {
        public event EventHandler EventCloseWindow;
        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);

        TestConnect testconnect = new TestConnect();

        private UserControl view;
        public UserControl UserInterface
        {
            get
            {
                if (view == null)
                {
                    if (testconnect.read() == true)
                        view = new IdClient();
                    else
                        view = new Acces();

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

                      view = new Main(1);
                      one = 0;
                      fifty = 0;
                      hundred = 0;
                      fhundred = 0;

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
        public Client client = new Client();
        private RelayCommand _LogInz;
        public RelayCommand LogInz
        {
            get
            {
                return _LogInz ??
                  (_LogInz = new RelayCommand(obj =>
                  {
                      if (client.client(Users,Password)==true) 
                      {
                          view = new Main(0);
                          OnPropertyChanged("UserInterface");
                      }
                      else
                      {
                          takeResult1 = new TakeResult1();
                          takeResult1.ShowDialog();
                      }

                  }));
            }
        }


        public string Password { private get; set; }





        private string _Users;      
        public string Users
        {

            get => _Users;
            set
            {
                _Users = value;
                OnPropertyChanged("Users2");
            }
        }

        public string Users2
        {
            get => Users;
        }

        public Bancomat bancomat = new Bancomat();
       

        private string _BalansM
        {
            get => bancomat.Summa(Users);
            set
            {

            }
        }
        public string BalansM
        {

            get => _BalansM;
            set
            {
                if (_BalansM != value)
                    _BalansM = value;
            }
        }

        private string _number1;
        public string Number1
        {
            get { return _number1; }
            set
            {
                _number1 = value;
                OnPropertyChanged("Number2");
            }
        }
        public string Number2
        {
            get => Number1;
        }

        private TakeResult1 takeResult1;
        private TakeResult2 takeResult2;
        private TakeResult3 takeResult3;
        private TakeResult4 takeResult4;

        private RelayCommand _Taked;
        public RelayCommand Taked
        {
            get
            {
                return _Taked ??
                  (_Taked = new RelayCommand(obj =>
                  {

                      int a;
                      a = bancomat.take(Number2,Users);
                      switch (a)
                      {

                          case 0:
                              takeResult1 = new TakeResult1();
                              takeResult1.ShowDialog();
                              break;
                          case 1:
                              takeResult2 = new TakeResult2();
                              takeResult2.ShowDialog();
                              break;
                          case 2:
                              takeResult3 = new TakeResult3();
                              takeResult3.ShowDialog();
                              break;
                          case 3:
                              takeResult4 = new TakeResult4();
                              takeResult4.ShowDialog();
                              break;

                      }
                  }));
            }
        }

        private int one;
        private int fifty;
        private int hundred;
        private int fhundred;


        private RelayCommand _One;
        public RelayCommand One
        {
            get
            {
                return _One ??
                  (_One = new RelayCommand(obj =>
                  {

                      one++;
                      OnPropertyChanged("Sum");

                  }));
            }
        }

        private RelayCommand _Fifty;
        public RelayCommand Fifty
        {
            get
            {
                return _Fifty ??
                  (_Fifty = new RelayCommand(obj =>
                  {

                      fifty++;
                      OnPropertyChanged("Sum");

                  }));
            }
        }

        private RelayCommand _Hundred;
        public RelayCommand Hundred
        {
            get
            {
                return _Hundred ??
                  (_Hundred = new RelayCommand(obj =>
                  {

                      hundred++;
                      OnPropertyChanged("Sum");

                  }));
            }
        }

        private RelayCommand _Fhundred;
        public RelayCommand Fhundred
        {
            get
            {
                return _Fhundred ??
                  (_Fhundred = new RelayCommand(obj =>
                  {

                      fhundred++;
                      OnPropertyChanged("Sum");

                  }));
            }
        }

        private RelayCommand _Result;
        public RelayCommand Result
        {
            get
            {
                return _Result ??
                  (_Result = new RelayCommand(obj =>
                  {
                      int a;
                      a = bancomat.give(one, fifty, hundred, fhundred, Users);
                      switch (a)
                      {

                          case 0:
                              takeResult1 = new TakeResult1();
                              takeResult1.ShowDialog();
                              break;
                          case 1:
                              takeResult4 = new TakeResult4();
                              takeResult4.ShowDialog();
                              break;
                      }
                      one = 0;
                      fifty = 0;
                      hundred = 0;
                      fhundred = 0;
                  }));
            }
        }

        
        public string Sum
        {
            get => summa();
        }

        private string summa() 
        {
            int Summa = 10 * one + 50 * fifty + 100 * hundred + 500 * fhundred;
            string sum = Summa + "";
            return sum; 
        }

        private RelayCommand _TConnect;
        public RelayCommand TConnect
        {
            get
            {
                return _TConnect ??
                  (_TConnect = new RelayCommand(obj =>
                  {

                      view = new IdClient();

                      OnPropertyChanged("UserInterface");
                  }));
            }
        }

    }
}
