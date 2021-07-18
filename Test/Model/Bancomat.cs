using System;
using System.IO;

namespace Test.Model
{

    class Bancomat
    {

        public string Summa(string login)
        {
            DataBase program = new DataBase();
            string wordss = program.read(login);
            return wordss;

        }

        private static string read()
        {
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bank";
            string path = $"{Path}\\Bank.txt";
            string line = null;

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {

                line = sr.ReadLine();
            }

            return line;
        }

        public int give(int One, int fifty, int hundred, int fhundred, string login)
        {
            int status;
            
            try
            {
                DataBase program = new DataBase();
                int sum;
                
                string wordss = program.read(login);
                sum = Convert.ToInt32(wordss);
                sum = sum + 10 * One + 50 * fifty + 100 * hundred + 500 * fhundred;

                write(read(), One, fifty, hundred, fhundred, sum);
                program.writeSQL(sum + "", login);

                status = 1;
                return status;
            }
            catch
            {
                status = 0;
                return status;
            }

        }

        public void write(string line, int One, int fifty, int hundred, int fhundred, int sum)
        {
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bank";
            string path = $"{Path}\\Bank.txt";

            string max = "";

            string[] wordss = line.Split(new char[] { ' ' });
            for (int i = 0; i < wordss.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        One += Convert.ToInt32(wordss[i]);
                        if (One > 150)
                            max = max + "10 ";
                        break;
                    case 1:
                        fifty += Convert.ToInt32(wordss[i]);
                        if (fifty > 150)
                            max = max + "50 ";
                        break;
                    case 2:
                        hundred += Convert.ToInt32(wordss[i]);
                        if (hundred > 150)
                            max = max + "100 ";
                        break;
                    case 3:
                        fhundred += Convert.ToInt32(wordss[i]);
                        if (fhundred > 150)
                            max = max + "500 ";
                        break;
                }
            }

            if ((One <= 150) & (fifty <= 150) & (hundred <= 150) & (fhundred <= 150))
            {
                line = One + " " + fifty + " " + hundred + " " + fhundred;
                

                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(line);
                }
            }
            else
                Console.WriteLine($"Достигнуто максиальное количество купюр номиналом:\t {max}");

        }


        public int take(String Summ , string login)
        {
            int status;

           


                double tbank = Convert.ToDouble(Summ); ;
                int bank = Convert.ToInt32(tbank);

            string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bank";
            string path = $"{Path}\\Bank.txt";
            string line = null;

                int Onez = 0, fiftyz = 0, hundredz = 0, fhundredz = 0, sum = 0;

                string[] words = read().Split(new char[] { ' ' });
                double[] a = new double[4];
                int b = 0;

                if (Convert.ToInt32(Summa(login)) >= bank)
                {


                    while (tbank != 0)
                    {
                        if (Convert.ToInt32(words[0]) > Onez)
                            a[0] = tbank / 10.0;
                        else
                            a[0] = 0.2;
                        if (Convert.ToInt32(words[1]) > fiftyz)
                            a[1] = tbank / 50.0;
                        else
                            a[1] = 0.3;
                        if (Convert.ToInt32(words[2]) > hundredz)
                            a[2] = tbank / 100.0;
                        else
                            a[2] = 0.4;
                        if (Convert.ToInt32(words[3]) > fhundredz)
                            a[3] = tbank / 500.0;
                        else
                            a[3] = 0.5;


                        for (int i = 0; i < 4; i++)
                        {
                            if (i != 0)
                            {
                                if ((a[i] >= 1))
                                {
                                    if ((a[i] < a[i - 1]))
                                    {
                                        b = i;
                                    }
                                }
                                else
                                    a[i] = a[i - 1] + 1;

                            }
                            else if (a[i] >= 1)
                                b = i;
                            else
                            {
                                b = 4;
                                a[i] = a[i + 1] + 1;
                            }

                        }



                        switch (b)
                        {
                            case 0:
                                tbank = tbank - 10;
                                Onez++;
                                break;
                            case 1:
                                tbank = tbank - 50;
                                fiftyz++;
                                break;
                            case 2:
                                tbank = tbank - 100;
                                hundredz++;
                                break;
                            case 3:
                                tbank = tbank - 500;
                                fhundredz++;
                                break;
                            case 4:
                                tbank = 0;
                                break;

                        }

                    }
                    double m = (Onez * 10 + fiftyz * 50 + hundredz * 100 + fhundredz * 500);


                    if (m == bank)
                    {
                        for (int i = 0; i < words.Length; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    if (Convert.ToInt32(words[i]) >= Onez)
                                        Onez = Convert.ToInt32(words[i]) - Onez;
                                    break;
                                case 1:
                                    if (Convert.ToInt32(words[i]) >= fiftyz)
                                        fiftyz = Convert.ToInt32(words[i]) - fiftyz;
                                    break;
                                case 2:
                                    if (Convert.ToInt32(words[i]) >= hundredz)
                                        hundredz = Convert.ToInt32(words[i]) - hundredz;
                                    break;
                                case 3:
                                    if (Convert.ToInt32(words[i]) >= fhundredz)
                                        fhundredz = Convert.ToInt32(words[i]) - fhundredz;
                                    break;
                            }
                        }


                        sum = Convert.ToInt32(Summa(login)) - bank;
                        line = Onez + " " + fiftyz + " " + hundredz + " " + fhundredz+ " ";



                        using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(line);
                        }
                        status = 3;
                        DataBase program = new DataBase();
                        program.writetake(sum + "", login);
                        
                        return status;
                    }
                    else
                    {
                        status = 2;
                        return status;
                    }
                }
                else
                {
                    status = 1;
                    return status;
                }
           
        }

        public string head(string line)
        {

            string[] wordss = line.Split(new char[] { ' ' });
            return wordss[0];
        }

    }

}


