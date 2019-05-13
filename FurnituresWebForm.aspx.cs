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
    public partial class FurnituresWebForm : System.Web.UI.Page
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
            var material = tbMaterial.Text;
            var description = tbDescription.Text;
            var cost = tbCost.Text;
            var count = tbCount.Text;

            if (!string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(material))
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=temp;Integrated Security=True"))
                {
                    conn.Execute("INSERT INTO Furnitures VALUES (@name, @material, @description, @cost, @count)", new { name, material, description, cost = int.Parse(cost), count = int.Parse(count) });
                    GridView1.DataBind();
                }
            }
        }
    }
}