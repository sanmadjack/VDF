using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace VDF {
    public class NestedElementFile {
        public Dictionary<String, NestedElement> Elements = new Dictionary<string, NestedElement>();

        public NestedElementFile(String file_name) {
            TextReader read = new StreamReader(file_name);
            Queue<string> lines = new Queue<string>();
            String line = read.ReadLine();
            while (line != null) {
                lines.Enqueue(line);
                line = read.ReadLine();
            }

            while(lines.Count>0) {
                NestedElement ele = new NestedElement(lines);
                if (ele.Ready) {
                    Elements.Add(ele.Name,ele);
                }
            }
            System.Console.Out.WriteLine("adas");
        }
    }
}
