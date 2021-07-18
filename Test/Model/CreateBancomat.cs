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
                    
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                   
                    fstream.Write(array, 0, array.Length);
                }
            }

        }
    }
}
