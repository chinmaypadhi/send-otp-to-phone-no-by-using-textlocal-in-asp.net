using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Collections.Specialized;

namespace send_otp_in_asp.net
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Random random = new Random();
            int value = random.Next(1001, 9999);
            string destinationaddr =TextBox1.Text;
            string message = "your OTP Nubmer is" + value + "(send by curigma)";
            string message1 = HttpUtility.UrlEncode(message);
            using (var wb = new WebClient())
            {

                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                    { "apikey", "JRnjbxQDcEQ-h9UIa1c2r0Wyxkjs8xGSEQ0siGTzgq" },
                    { "numbers", destinationaddr },
                    {"message",message1},
                    { "sender", "TXTLCL" }
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                Session["OTP"] = value;
              
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["OTP"].ToString() == TextBox2.Text)
            {
                Response.Write("You have enter correct OTP.");
                Session["OTP"] = null;
            }
            else
            {
               Response.Write("Pleae enter correct OTP.");
            }
        }
    }
}
    