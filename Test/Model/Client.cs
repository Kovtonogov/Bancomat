﻿namespace Test.Model
{
    class Client
    {
        public bool client(string login, string password1)
        {
            try
            {
                string password2 = null;
                ClientServer clientServer = new ClientServer();
                if ((login != null) && (password1 != null))
                    password2 = clientServer.LoginRead(login);
                else
                    return false;

                if (password2 == password1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


    }
}
