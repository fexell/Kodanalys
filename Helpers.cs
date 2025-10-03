using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kodanalys {
    public class Helpers {
        public static int ValidateInt( string input ) {
            while( true ) {
                if ( int.TryParse( input, out int result ) ) {
                    return result;
                } else {
                    Console.Write( "\nOgiltig inmatning (kan bara vara heltal). Försök igen: " );
                    input = Console.ReadLine();
                }
            }
        }

        public static string ValidateName( string input ) {
            while( true ) {
                if ( !string.IsNullOrWhiteSpace( input.Trim() ) && Regex.IsMatch( input.Trim(), @"^[a-zA-Z]+$" ) ) {
                    return char.ToUpper( input.Trim()[ 0 ] ) + input.Trim().Substring( 1 ).ToLower();
                } else {
                    Console.Write( "\nOgiltig inmatning (kan bara vara bokstäver och 1 ord). Försök igen: " );
                    input = Console.ReadLine();
                }
            }
        }

        public static void ColoredText( string text, ConsoleColor color ) {
            Console.ForegroundColor = color;
            Console.WriteLine( text );
            Console.ResetColor();
        }
    }
}
