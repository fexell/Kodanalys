using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kodanalys {
    public class Helpers {

        /// <summary>
        /// Validerar inmatning av heltal
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ValidateInt( string input ) {
            while( true ) {

                // Kontrollera att inputen kan konverteras till heltal
                if ( int.TryParse( input, out int result ) ) {
                    return result;

                // Om input inte är ett heltal, skriv ut ett felmeddelande och be om ny inmatning
                } else {
                    Console.Write( "\nOgiltig inmatning (kan bara vara heltal). Försök igen: " );
                    input = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Validerar inmatning av namn
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ValidateName( string input ) {
            while( true ) {

                // Kontrollera att inputen inte bara består av mellanslag, och att inputen bara består av bokstäver
                if ( !string.IsNullOrWhiteSpace( input.Trim() ) && Regex.IsMatch( input.Trim(), @"^[a-zA-Z]+$" ) ) {

                    // Returnera namnet med stor bokstäver i början och små bokstäver i resten
                    return char.ToUpper( input.Trim()[ 0 ] ) + input.Trim().Substring( 1 ).ToLower();

                // Om input inte är ett namn, skriv ut ett felmeddelande och be om ny inmatning
                } else {
                    Console.Write( "\nOgiltig inmatning (kan bara vara bokstäver och 1 ord). Försök igen: " );
                    input = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Skriver ut text i vald färg
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void ColoredText( string text, ConsoleColor color ) {
            Console.ForegroundColor = color;
            Console.WriteLine( text );
            Console.ResetColor();
        }
    }
}
