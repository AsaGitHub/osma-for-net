using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simulated.Targets.CW
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string ToMD5String(string value)
        {
            return GetMD5(string.Concat(GetMD5(value), "KupartsY"));//增加加密复杂度
        }

        public string GetMD5(string str)
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));

            return sb.ToString();
        }
    }
}
