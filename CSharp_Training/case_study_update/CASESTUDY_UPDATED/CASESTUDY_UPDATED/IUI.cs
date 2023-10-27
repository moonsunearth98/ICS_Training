using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Study
{
    public interface IUserInterface
    {
        void ShowFirstScreen();
        void ShowStudentScreen();
        void ShowAdminScreen();
        void ShowAllStudentsScreen();
        void ShowStudentRegistrationScreen();
        void IntroduceNewCourseScreen();
        void ShowAllCoursesScreen();
        //void ShowEnrollmentsScreen();
    }
}
