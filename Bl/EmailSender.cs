using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class EmailSender
    {
        public static string send(string Maill, string groupName, string password, string username,string senderUser)
        {
            using (MailMessage mm = new MailMessage("familyapllication@gmail.com", Maill))
            {

                mm.Subject = "registered user in group";
                mm.IsBodyHtml = true;
                mm.Body = ("<div style='text-align:left'>You have been registered to the group: " + groupName + "</div>" +
                    "<div style='text-align:left'>By: " + senderUser + "</div>" +
                    "<div style='text-align:left'>your user name: " + username + "</div>" +
                    "<div style='text-align:left'>your password: " + password + "</div>" +
                    "<div style='text-align:left'>If you do not want to be registered in this group, unregister on the site: 'MyFamily'</div> ");


                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Timeout = 30 * 1000;
                client.Credentials = new NetworkCredential("familyapllication@gmail.com", "fa2000fa!@#");
                client.Port = 587;
                client.EnableSsl = true;
                try
                {
                    client.Send(mm);
                    return "המייל נשלח בהצלחה";
                }
                catch (Exception ex)
                {
                    return mm.Body;
                }

            }
        }
    }
}
