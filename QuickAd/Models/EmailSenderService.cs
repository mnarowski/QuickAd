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
            return true;
        }
		private static void Send() {
		    if (DateTime.Now > lastSend.AddHours(1))
		    {
		        var smtp = new SmtpClient
		            {
		                Host = "smtp.gmail.com",
		                Port = 465,
		                EnableSsl = true,
		                DeliveryMethod = SmtpDeliveryMethod.Network,
		                UseDefaultCredentials = false,
		                Credentials = new NetworkCredential("wzim2010.sggw","informatyka2010")
		            };

		        foreach (Email email in emails)
		        {
		            MailMessage mmsg = new MailMessage(DBHelper.FindOne<User>(email.IdSender).Email,DBHelper.FindOne<User>(email.IdRecipent).Email,email.Title,email.Content);
		            email.DateSend = DateTime.Now;
                    DBHelper.SaveOrUpdate(email);
		            smtp.Send(mmsg);
		        }

		        emails = new List<Email>();
		        
		    }

		    lastSend = DateTime.Now;
		}

		private static List<Email> emails;

	}

    

}
