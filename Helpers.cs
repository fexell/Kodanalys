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
                    Console.Write( "\nOgiltig inmatning. Försök igen: " );
                    input = Console.ReadLine();
                }
            }
        }

        public static string ValidateName( string input ) {
            while( true ) {
                if ( !string.IsNullOrWhiteSpace( input ) ) {
                    return char.ToUpper( input[ 0 ] ) + input.Substring( 1 ).ToLower();
                } else {
                    Console.Write( "\nOgiltig inmatning. Försök igen: " );
                    input = Console.ReadLine();
                }
            }
        }
    }
}
