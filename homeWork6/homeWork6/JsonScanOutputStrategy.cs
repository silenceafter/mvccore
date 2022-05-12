using homeWork6.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6
{
    public class JsonScanOutputStrategy: IScanOutputStrategy
    {
        public void Save(string filename, byte[] data)
        {
            //название файла
            if (string.IsNullOrWhiteSpace(filename)) throw new Exception("filename is empty");
            var sb = new StringBuilder();
            sb.Append(filename);
            sb.Append(".json");

            //создать файл
            string data_string = System.Text.UTF8Encoding.UTF8.GetString(data);
            File.WriteAllText(@sb.ToString(), data_string);
        }
    }
}
