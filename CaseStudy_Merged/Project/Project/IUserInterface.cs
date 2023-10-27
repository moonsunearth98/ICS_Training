using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUserInterface_1
{
  
        public interface IUserInterface
        {
            void ShowFirstScreen();
        }

       public class UserInteface : IUserInterface
    {
        public void ShowFirstScreen()
        {
            Console.WriteLine("Welcome to SMS (Student Management System) v1.0");
            Console.WriteLine("Tell us who you are: \n1. Student\n2. Admin");
            Console.WriteLine("Enter your choice (1 or 2): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ShowStudentScreen();
                    break;
                case 2:
                    ShowAdminScreen();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public void ShowStudentScreen()
        {
            Console.WriteLine("Student Screen");
            // Implement student-related functionality
        }

        public void ShowAdminScreen()
        {
            Console.WriteLine("Admin Screen");
            // Implement admin-related functionality
        }
    }
    

}
