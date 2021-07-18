using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Test.Model
{
    class Connect
    {
        
        int port = 8005; 
        string address = "176.51.111.250"; 


        public async Task<string> ConnectingAsync()
        {
            string result = "good";
            await Task.Run(() => Connecting());
            return result;
        }

        public void Connecting()
        {

            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
               
                socket.Connect(ipPoint);
                
                string message = "mister";
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                
                data = new byte[256]; 
                StringBuilder builder = new StringBuilder();
                int bytes = 0; 

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                
                if(builder.ToString()!="mister")
                {
                    
                }

                
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch
            {
                
            }

            
            
        }
    }
}