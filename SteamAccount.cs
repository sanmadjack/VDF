using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDF {
    public class SteamAccount {
        public String Name { get; protected set; }
        public String SteamID { get; protected set; }
        public SteamAccount(NestedElement uele) {
            Name = uele.Name;
            if (uele.Children.ContainsKey("SteamID")) {
                SteamID = uele.Children["SteamID"].Value;
            }
        }
    }
}
