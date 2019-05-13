using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab7
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;

            if (FormsAuthentication.Authenticate(tbLogin.Text, tbPass.Text))
            {
                // Создать билет, добавить cookie-набор к ответу и 
                // перенаправить на исходную запрошенную страницу
                FormsAuthentication.RedirectFromLoginPage(tbLogin.Text, false);
            }
            else
            {
                tbPass.Text = "";
            }
        }
    }
}