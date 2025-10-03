using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodanalys {
    internal class User {
        private static List<string> userList = new();

        public static void AddUser() {
            Console.Write( "\nAnge namn: " );
            string nameInput = Helpers.ValidateName( Console.ReadLine() );

            if ( userList.Count < 10 ) {
                userList.Add( nameInput );
                Helpers.ColoredText( $"\nAnvändaren {nameInput} lades till.", ConsoleColor.Green );
            } else {
                Helpers.ColoredText( "\nDet finns redan 10 användare.", ConsoleColor.Red );
            }
        }

        public static void ListUsers() {
            if ( userList.Count == 0 ) {
                Helpers.ColoredText( "\nIngen användare hittades.", ConsoleColor.Red );
                return;
            }

            Console.WriteLine( "\n====== Användare ======" );

            foreach( string user in userList ) {
                Helpers.ColoredText( user, ConsoleColor.Yellow );
            }

            Console.WriteLine( "=======================" );
        }

        public static void DeleteUser() {
            Console.Write( "Ange namn att ta bort: " );
            string nameInput = Helpers.ValidateName( Console.ReadLine() );

            if( userList.Exists( user => string.Equals( user, nameInput, StringComparison.OrdinalIgnoreCase ) ) ) {
                userList.Remove( nameInput );
                Helpers.ColoredText( $"\nAnvändaren {nameInput} raderades.", ConsoleColor.Green );
            } else {
                Helpers.ColoredText( "\nAnvändaren hittades inte.", ConsoleColor.Red );
            }
        }

        public static void SearchUser() {
            Console.Write( "\nAnge namn att söka: " );
            string searchName = Helpers.ValidateName( Console.ReadLine() );

            if( userList.Exists( user => string.Equals( user, searchName, StringComparison.OrdinalIgnoreCase ) ) ) {
                Helpers.ColoredText( $"\nAnvändaren \"{searchName}\" finns i listan.", ConsoleColor.Green );
            } else {
                Helpers.ColoredText( $"\nAnvändaren \"{searchName}\" hittades inte.", ConsoleColor.Red );
            }
        }
    }
}
