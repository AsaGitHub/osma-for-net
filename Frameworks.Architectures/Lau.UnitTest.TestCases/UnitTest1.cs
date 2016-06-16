﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Security.Cryptography;

namespace Lau.UnitTest.TestCases
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1() { }

        [TestMethod]
        public void TestMethod1()
        {
            
            string abc = ToMD5String("123456");
            int a = 0;
        }

        public string ToMD5String(string value)
        {
            return GetMD5(string.Concat(GetMD5(value), "KupartsY"));//增加加密复杂度
        }

        internal  string GetMD5(string str)
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));

            //e10adc3949ba59abbe56e057f20f883e

            return sb.ToString();
        }


    }
}
