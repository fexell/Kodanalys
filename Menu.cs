using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodanalys {
    internal class Menu {
        static Dictionary<int, MenuItem> menuItems = new() {
            { 1, new MenuItem( "Lägg till användare", () => User.AddUser() ) },
            { 2, new MenuItem( "Visa alla användare", () => User.ListUsers() ) },
            { 3, new MenuItem( "Ta bort användare", () => User.DeleteUser() ) },
            { 4, new MenuItem( "Sök användare", () => User.SearchUser() ) },
            { 5, new MenuItem( "Avsluta", () => Exit() ) },
        };

        public static void ShowMenu() {
            Console.WriteLine( "===== Meny ======" );
            Console.WriteLine( "1. Lägg till användare" );
            Console.WriteLine( "2. Visa alla användare" );
            Console.WriteLine( "3. Ta bort användare" );
            Console.WriteLine( "4. Sök användare" );
            Console.WriteLine( "5. Avsluta" );
            Console.WriteLine( "=================" );
        }

        public static void MenuLoop() {
            while( true ) {
                Console.Clear();

                ShowMenu();

                Console.Write( "Val: " );
                int input = Helpers.ValidateInt( Console.ReadLine() );

                if( menuItems.ContainsKey( input ) ) {
                    menuItems[ input ].Action();
                }
            }
        }

        public static void Exit() {
            Environment.Exit( 0 );
        }
    }

    public class MenuItem {
        public string Name { get; set; }
        public Action Action { get; set; }

        public MenuItem( string name, Action action, bool isReturn = true ) {
            Name = name;
            
            if( isReturn ) {
                Action = () => {
                    action.Invoke();
                    Console.WriteLine( "\nTryck enter för att fortsätta..." );
                    Console.ReadKey();
                };
            } else {
                Action = action;
            }
        }
    }
}
