using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WebApplication1
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set the initial selection of the dropdown list
                ddlItems.SelectedIndex = 0;
                // Display the default image (you can set this in the markup as well)
                imgItem.ImageUrl = "~/Images/default.jpg";
            }
        }

        protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the image URL based on the selected item
            string selectedImageUrl = ddlItems.SelectedValue;
            imgItem.ImageUrl = $"~/Images/{selectedImageUrl}";
            lblCost.Text = ""; // Clear the cost label.
        }

        protected void btnShowCost_Click(object sender, EventArgs e)
        {
            string selectedItem = ddlItems.SelectedValue;

            // Define a dictionary of item costs (you can use a database in a real application).
            var itemCosts = new Dictionary<string, decimal>
            {
                { "bracelet.jpg", 20000.00m },
                { "earring.jpg", 50000.00m },
                { "necklace.jpg", 10000.00m },
                { "sunglass.jpg", 12900.00m },
            };

            if (itemCosts.ContainsKey(selectedItem))
            {
                lblCost.Text = $"Cost: ${itemCosts[selectedItem]}";
            }
            else
            {
                lblCost.Text = "Cost not available.";
            }
        }
    }
}
