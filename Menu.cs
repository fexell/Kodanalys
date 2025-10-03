using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodanalys {
    internal class Menu {
        static Dictionary<int, MenuItem> menuItems = new() {
            { 1, new MenuItem( "Lägg till användare", () => User.AddUser() ) },
        };

        public static void ShowMenu() {
            Console.WriteLine( "Välj ett alternativ:" );
            Console.WriteLine( "1. Lägg till användare" );
            Console.WriteLine( "2. Visa alla användare" );
            Console.WriteLine( "3. Ta bort användare" );
            Console.WriteLine( "4. Sök användare" );
            Console.WriteLine( "5. Avsluta" );
        }

        public static void MenuLoop() {
            while( true ) {
                Console.Clear();

                ShowMenu();

                var input = Console.ReadLine();
                if( menuItems.ContainsKey( int.Parse( input ) ) ) {
                    menuItems[ int.Parse( input ) ].Action();
                }
            }
        }
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
