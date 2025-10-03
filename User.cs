using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodanalys {
    internal class User {
        static string[] userList = new string[ 10 ];
        static int userCount = 0;

        static void AddUser() {
            Console.Write( "Ange namn: " );
            string strUsr = Console.ReadLine();
            if ( userCount < 10 ) {
                userList[ userCount ] = strUsr;
                userCount++;
            } else {
                Console.WriteLine( "Listan är full!" );
            }
        }
    }
}
