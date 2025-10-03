using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodanalys {
    internal class Menu {
        Dictionary<int, MenuItem> menuItems = new() {
            { 1, new MenuItem( "Lägg till användare", () => Console.WriteLine( "Ange namn: " ) ) },
        };
    }

    public class MenuItem {
        public string Name { get; set; }
        public Action Action { get; set; }

        public MenuItem( string name, Action action ) {
            Name = name;
            Action = action;
        }
    }
}
