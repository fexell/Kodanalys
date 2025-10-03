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
            string nameInput = Console.ReadLine();

            int index = -1;
            for ( int i = 0; i < userCount; i++ ) {
                if ( string.Equals( userList[ i ], nameInput, StringComparison.OrdinalIgnoreCase ) ) {
                    index = i;
                    break;
                }
            }

            if ( index != -1 ) {
                for ( int i = index; i < userCount - 1; i++ ) {
                    userList[ i ] = userList[ i + 1 ];
                }

                userCount--;

                Helpers.ColoredText( "Användaren har tagits bort.", ConsoleColor.Green );

            } else {
                Helpers.ColoredText( "Användaren hittades inte.", ConsoleColor.Red );
            }
        }

        public static void SearchUser() {
            Console.Write( "Ange namn att söka: " );
            string searchName = Console.ReadLine();

            if( userList.Exists( user => string.Equals( user, searchName, StringComparison.OrdinalIgnoreCase ) ) ) {
                Helpers.ColoredText( "Användaren finns i listan.", ConsoleColor.Green );
            } else {
                Helpers.ColoredText( "Användaren hittades inte.", ConsoleColor.Red );
            }
        }
    }
}
