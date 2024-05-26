using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardTestEngine.Wpf.Other
{
    public static class Log
    {
        public static event EventHandler<string> MessageLogged;

        public static void Add(string message)
        {
            //Console.WriteLine(message);
            MessageLogged?.Invoke(null, message);
        }
    }
}
