using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUserInterface_1;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the database
            StudentDatabase.DatabaseInitializer.InitializeDatabase();

            // Show the first screen
            new UserInteface().ShowFirstScreen();
        }
    }
}
