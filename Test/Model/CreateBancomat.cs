using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test.Model
{
    class CreateBancomat
    {

        public void Create()
        {
            string text = null;
            string Path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\Bank";
            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                text = "100 50 20 10";
                using (FileStream fstream = new FileStream($"{Path}\\Bank.txt", FileMode.OpenOrCreate))
                {
                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    // запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                }
            }

        }
    }
}
