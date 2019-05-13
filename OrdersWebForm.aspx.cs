using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab7
{
    public partial class OrdersWebForm1 : System.Web.UI.Page
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
            var OrderDate = tbOrderDate.SelectedDate == new DateTime(1, 1, 1, 0, 0, 0, 0) ? tbOrderDate.TodaysDate : tbOrderDate.SelectedDate;
            var IsOrderComplete = tbIsOrderComplete.Checked;
            var Discount = tbDiscount.Text;
            var Count = tbDiscount.Text;
            var Client = tbClientID.Text;
            var Furniture = tbFurnitureID.Text;
            var Worker = tbWorkerID.Text;

            if (!string.IsNullOrWhiteSpace(Discount) &&
                !string.IsNullOrWhiteSpace(Count) &&
                !string.IsNullOrWhiteSpace(Client) &&
                !string.IsNullOrWhiteSpace(Furniture) &&
                !string.IsNullOrWhiteSpace(Worker))
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=temp;Integrated Security=True"))
                {
                    conn.Execute("INSERT INTO Orders VALUES (@OrderDate, @IsOrderComplete, @Discount, @Count, @Client, @Furniture, @Worker)", new
                    {
                        OrderDate,
                        IsOrderComplete,
                        Discount = int.Parse(Discount),
                        Count = int.Parse(Discount),
                        Client = int.Parse(Client),
                        Furniture = int.Parse(Furniture),
                        Worker = int.Parse(Worker),
                    });
                    GridView1.DataBind();
                }
            }
        }
    }
}