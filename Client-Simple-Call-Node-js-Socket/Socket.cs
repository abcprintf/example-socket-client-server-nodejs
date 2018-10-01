using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Node
{
    class Socket
    {
        public Quobject.SocketIoClientDotNet.Client.Socket _socket { get; set; }

        public Socket(Quobject.SocketIoClientDotNet.Client.Socket socket)
        {
            this._socket = socket;
        }

        public Socket(string UrlNode, Quobject.SocketIoClientDotNet.Client.IO.Options options = null)
        {
            if (options == null)
            {
                options = new Quobject.SocketIoClientDotNet.Client.IO.Options()
                {
                    IgnoreServerCertificateValidation = true,
                    AutoConnect = true,
                    ForceNew = true
                };
            }

            _socket = Quobject.SocketIoClientDotNet.Client.IO.Socket(UrlNode, options);
        }

        public void Emit(string name, object obj, Action<object> ack)
        {
            _socket.Emit(name, ack, ConverJObj(obj));
        }

        public void On(string name, Action<object> ack)
        {
            _socket.On(name, ack);
        }
        public void Emit(string name, object obj)
        {
            _socket.Emit(name, ConverJObj(obj));
        }
        private Newtonsoft.Json.Linq.JObject ConverJObj(object obj)
        {
            return Newtonsoft.Json.Linq.JObject.FromObject(obj);
        }
    }
}
