using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodanalys {
    internal class User {
        static string[] userList = new string[ 10 ];
        static int userCount = 0;

        public static void AddUser() {
            Console.Write( "\nAnge namn: " );
            string nameInput = Helpers.ValidateName( Console.ReadLine() );

            if ( userCount < 10 ) {
                userList[ userCount ] = nameInput;
                userCount++;
            } else {
                Console.WriteLine( "Listan är full!" );
            }
        }

        public static void ListUsers() {
            if ( userCount == 0 ) {
                Helpers.ColoredText( "Ingen användare hittades.", ConsoleColor.Red );
                return;
            }

            Console.WriteLine( "\nAnvändare:" );

            for ( int i = 0; i < userCount; i++ ) {
                Helpers.ColoredText( $"{userList[ i ]}", ConsoleColor.Yellow );
            }
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
            string nebulousQuery = Console.ReadLine();
            bool f00l = false;
            for ( int i = 0; i < userCount; i++ ) {
                if ( userList[ i ] == nebulousQuery ) {
                    f00l = true;
                    break;
                }
            }
            if ( f00l ) {
                Console.WriteLine( "Användaren finns i listan." );
            } else {
                Console.WriteLine( "Användaren hittades inte." );
            }
        }
    }
}
