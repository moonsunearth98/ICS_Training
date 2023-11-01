using System;
using System.Web.UI;

namespace UserInfo
{
    public partial class Validator : Page
    {
        protected void CheckButton_Click(object sender, EventArgs e)
        {
            
            string name = Name.Text;
            string familyName = FamilyName.Text;
            string address = Address.Text;
            string city = City.Text;
            string zipCode = ZipCode.Text;
            string phone = Phone.Text;
            string email = Email.Text;

          
            bool isValid = true;
            string errorMessage = "Please correct the following errors:<br />";

            // Validate Name
            if (string.IsNullOrWhiteSpace(name))
            {
                isValid = false;
                errorMessage += "- Name is required<br />";
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                isValid = false;
                errorMessage += "- Invalid Email address<br />";
            }

            // If isValid is still true, no validation errors were found
            if (isValid)
            {
                // Redirect to the validation page with query parameters
                Response.Redirect($"ValidationPage.aspx?Name={name}&FamilyName={familyName}&Address={address}&City={city}&ZipCode={zipCode}&Phone={phone}&Email={email}");
            }
            else
            {
                // Display the error message
                ValidationSummary.Text = errorMessage;
            }
        }

        // Helper function to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
