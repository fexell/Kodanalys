using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodanalys {
    internal class Menu {

        // Menyval och deras tillhörande åtgärder
        static Dictionary<int, MenuItem> menuItems = new() {
            { 1, new MenuItem( "Lägg till användare", () => User.AddUser() ) },
            { 2, new MenuItem( "Visa alla användare", () => User.ListUsers() ) },
            { 3, new MenuItem( "Ta bort användare", () => User.DeleteUser() ) },
            { 4, new MenuItem( "Sök användare", () => User.SearchUser() ) },
            { 5, new MenuItem( "Avsluta", () => Exit() ) },
        };

        /// <summary>
        /// Visar meny
        /// </summary>
        public static void ShowMenu() {
            Console.WriteLine( "===== Meny ======" );
            Console.WriteLine( "1. Lägg till användare" );
            Console.WriteLine( "2. Visa alla användare" );
            Console.WriteLine( "3. Ta bort användare" );
            Console.WriteLine( "4. Sök användare" );
            Console.WriteLine( "5. Avsluta" );
            Console.WriteLine( "=================" );
        }

        /// <summary>
        /// Loopar menyn
        /// </summary>
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

        /// <summary>
        /// Avslutar programmet
        /// </summary>
        public static void Exit() {
            Environment.Exit( 0 );
        }
    }

    /// <summary>
    /// Menyval-klassen
    /// </summary>
    public class MenuItem {

        // Namn på menyval
        public string Name { get; set; }

        // Funktionen/action som ska köras vid menyval
        public Action Action { get; set; }

        /// <summary>
        /// Skapar ny menyval
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        /// <param name="isReturn"></param>
        public MenuItem( string name, Action action, bool isReturn = true ) {

            // Sätt namn
            Name = name;

            // Sätt action, med eller utan "tryck enter för att fortsätta"
            if ( isReturn ) {
                Action = () => {

                    // Kör action
                    action.Invoke();

                    // Vänta på inmatning innan menyn visas igen
                    Console.WriteLine( "\nTryck enter för att fortsätta..." );
                    Console.ReadKey();
                };
            } else {
                Action = action;
            }
        }
    }
}
