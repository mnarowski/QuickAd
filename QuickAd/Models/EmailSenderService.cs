using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;

namespace QuickAd.Models {
	public class EmailSenderService
	{
	    private static DateTime lastSend;
		    
        public static bool SendEmail(Email email) {
	        emails.Add(email);
            Send();
            return true;
        }
		private static void Send() {
		    //if (DateTime.Now > lastSend.AddHours(1))
		    //{
		        SmtpClient smtp = new SmtpClient
		            {
		                Host = "smtp.gmail.com",
		                Port = 587,
		                EnableSsl = true,
		                DeliveryMethod = SmtpDeliveryMethod.Network,
		                UseDefaultCredentials = false,
		                Credentials = new NetworkCredential("wzim2010.sggw","informatyka2010")
		            };

		        foreach (Email email in emails)
		        {
                    MailMessage mmsg = new MailMessage(DBHelper.FindOne<User>(email.VidSenderUser).Vemail, DBHelper.FindOne<User>(email.VidRecipent).Vemail, email.Vtitle, email.Vcontent);
                    mmsg.Sender = new MailAddress(DBHelper.FindOne<User>(email.VidSenderUser).Vemail);
                    mmsg.ReplyToList.Add(mmsg.Sender);
                    email.VsendDate = DateTime.Now;
                    DBHelper.SaveOrUpdate(email);
                    mmsg.BodyEncoding = System.Text.UTF8Encoding.Unicode;
		            smtp.Send(mmsg);
		        }

		        emails = new List<Email>();
		        
		    //}

		    //lastSend = DateTime.Now;
		}

		private static List<Email> emails = new List<Email>();

	}

    

}
