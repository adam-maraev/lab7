using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;

namespace Lab7
{
    public partial class ClientsWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}

     

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            foreach (dynamic val in e.NewValues)
            {
                if (val.Value == null)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            var name = tbName.Text;
            var firmName = tbFirmName.Text;
            var phone = tbPhone.Text;
            var adress = tbAdress.Text;

            if (!string.IsNullOrWhiteSpace(name)&&
                !string.IsNullOrWhiteSpace(firmName)&&
                !string.IsNullOrWhiteSpace(phone)&&
                !string.IsNullOrWhiteSpace(adress))
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=temp;Integrated Security=True"))
                {
                    conn.Execute("INSERT INTO Clients VALUES (@name, @firmName, @phone, @adress)", new { name, firmName, phone, adress });
                    GridView1.DataBind();
                }
            }
        }
    }
}