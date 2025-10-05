using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodanalys {
    internal class User {
        const int MaxUsers = 10;

        private static List<string> userList = new();

        /// <summary>
        /// Kontrollerar att det finns användare, och om inte, skriv ut ett felmeddelande
        /// </summary>
        public static bool UsersExists() {
            if ( userList.Count == 0 ) {
                Helpers.ColoredText( $"\nDet finns inga användare ännu.", ConsoleColor.Red );
                return false;
            }

            return true;
        }

        /// <summary>
        /// Lägger till en ny användare
        /// </summary>
        public static void AddUser() {

            // Be om namn för att lägga till bland användare
            Console.Write( "\nAnge namn: " );
            string nameInput = Helpers.ValidateName( Console.ReadLine() );

            // Kontrollera att namnet inte redan finns
            if ( userList.Exists( user => string.Equals( user, nameInput, StringComparison.OrdinalIgnoreCase ) ) ) {
                Helpers.ColoredText( $"\nAnvändaren {nameInput} finns redan.", ConsoleColor.Red );
                return;
            }

            // Kontrollera om det finns mer än 10 användare
            if ( userList.Count < MaxUsers ) {
                userList.Add( nameInput );
                Helpers.ColoredText( $"\nAnvändaren {nameInput} lades till.", ConsoleColor.Green );
            } else {
                Helpers.ColoredText( "\nDet finns redan 10 användare.", ConsoleColor.Red );
            }
        }

        /// <summary>
        /// Visar alla användare
        /// </summary>
        public static void ListUsers() {

            // Kontrollera att det _inte_ finns några användare
            if( !UsersExists() ) return;

            Console.WriteLine( "\n====== Användare ======" );

            // Skriv ut alla användare i listan
            foreach( string user in userList ) {
                Helpers.ColoredText( user, ConsoleColor.Yellow );
            }

            Console.WriteLine( "=======================" );
        }

        /// <summary>
        /// Tar bort en användare
        /// </summary>
        public static void DeleteUser() {

            // Kontrollera att det finns användare att radera
            if ( !UsersExists() ) return;

            // Be om namn att ta bort
            Console.Write( "\nAnge namn att ta bort: " );
            string nameInput = Helpers.ValidateName( Console.ReadLine() );

            // Kontrollera att namnet finns
            if( userList.Exists( user => string.Equals( user, nameInput, StringComparison.OrdinalIgnoreCase ) ) ) {

                // Radera användaren
                userList.Remove( nameInput );

                // Skriv ut att användaren raderades
                Helpers.ColoredText( $"\nAnvändaren {nameInput} raderades.", ConsoleColor.Green );
            } else {

                // Skriv ut att användaren hittades inte
                Helpers.ColoredText( "\nAnvändaren hittades inte.", ConsoleColor.Red );
            }
        }

        /// <summary>
        /// Söker efter en användare
        /// </summary>
        public static void SearchUser() {

            // Kontrollera att det finns användare att söka efter
            if( !UsersExists() ) return;

            // Be om namn att söka efter
            Console.Write( "\nAnge namn att söka: " );
            string searchName = Helpers.ValidateName( Console.ReadLine() );

            // Kontrollera att namnet finns
            if( userList.Exists( user => string.Equals( user, searchName, StringComparison.OrdinalIgnoreCase ) ) ) {

                // Skriv ut att användaren hittades
                Helpers.ColoredText( $"\nAnvändaren \"{searchName}\" finns i listan.", ConsoleColor.Green );
            } else {

                // Skriv ut att användaren hittades inte
                Helpers.ColoredText( $"\nAnvändaren \"{searchName}\" hittades inte.", ConsoleColor.Red );
            }
        }
    }
}
