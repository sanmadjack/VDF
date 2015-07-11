using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace VDF {
    public class NestedElement {
        public Dictionary<String, NestedElement> Children { get; protected set; }

        public String Name { get; protected set; }
        public String Value;

        public Boolean Ready { get; protected set; }


        private static Regex name_value_regex = new Regex("\"[^\"]*\"");
        private static Regex open_regex = new Regex("{");
        private static Regex close_regex = new Regex("}");

        public NestedElement(Queue<string> read) {
            Children = new Dictionary<string, NestedElement>();
            String line = read.Dequeue();
            MatchCollection matches = name_value_regex.Matches(line);

            if (string.IsNullOrWhiteSpace(line.TrimEnd('}')))
                return;

            if (matches.Count == 0) {
                throw new Exception("WHT THE HELL");
            }

            Name = matches[0].Value.Trim('\"');
            if (matches.Count > 1) {
                Value = matches[1].Value.Trim('\"');
            }


            Ready = true;
            line = read.Peek();
            if (open_regex.IsMatch(line)) {
                read.Dequeue();
                while (true) {
                    NestedElement ele = new NestedElement(read);
                    if (ele.Ready) {
                        Children.Add(ele.Name, ele);
                    }
                    if (read.Count == 0 && line == "{")
                        break;

                    line = read.Peek();
                    if (close_regex.IsMatch(line)) {
                        read.Dequeue();
                        return;
                    }
                }
            }
        }
    }
}
