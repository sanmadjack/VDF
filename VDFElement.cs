using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDF {
    public class VDFElement : NestedElement {
        public new Dictionary<String, VDFElement> Children { get; protected set; }

        public VDFElement(Queue<string> read)
            : base(read) {

        }
    }
}
