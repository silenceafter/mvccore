using homeWork6.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace homeWork6
{
    public class XmlScanOutputStrategy: IScanOutputStrategy
    {
        public void Save(string filename, byte[] data)
        {
            //название файла
            if (string.IsNullOrWhiteSpace(filename)) throw new Exception("filename is empty");
            var sb = new StringBuilder();
            sb.Append(filename);
            sb.Append(".xml");

            //создать файл
            string data_string = System.Text.UTF8Encoding.UTF8.GetString(data);
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(data_string);
            if (values != null)
            {
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = true;
                xws.Indent = true;
                //
                using (XmlWriter xw = XmlWriter.Create(sb.ToString(), xws))
                {
                    XDocument doc = new XDocument();
                    var xmlTree = new XElement("Root", "");
                    //
                    foreach (var item in values)
                    {
                        var element = new XElement(item.Key, item.Value);
                        xmlTree.Add(element);
                    }
                    doc.Add(xmlTree);
                    doc.Save(xw);
                }
            }
        }
    }
}
