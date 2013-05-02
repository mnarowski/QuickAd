using System;
using System.Collections.Generic;
using NHibernate;
using QuickAd.Models;

namespace QuickAd.Models
{
	public class DBHelper {
		public static List<T> GetAll<T>() where T : class
		{
		    using (ISession session = SessionFactory.GetNewSession())
		    {
                return (List<T>) session.CreateCriteria<T>().List<T>();
		    }
		}
		public static T FindOne<T>(int id) {
            using (ISession session = SessionFactory.GetNewSession())
            {
                return session.Get<T>(id);
            }
		}
		public static void SaveOrUpdate(Object obj) {
            using (ISession session = SessionFactory.GetNewSession())
            {
                session.SaveOrUpdate(obj);
                session.Flush();
            }
		}
		public static void Delete(Object obj) {
            using (ISession session = SessionFactory.GetNewSession())
            {
                session.Delete(obj);
            }
        }

	    public static string generateHash()
	    {
	        byte[] bytes;
            Random r = new Random();
	        String dateStamp = r.NextDouble().ToString() + DateTime.Now.ToString("s") + "hashedExtra";
            bytes = new byte[dateStamp.Length];
	        char[] chars = dateStamp.ToCharArray();
            for(int i=0;i<dateStamp.Length;i++)
            {
                bytes[i] = (byte) chars[i] ;
            }
	        return System.Security.Cryptography.MD5.Create().ComputeHash(bytes).ToString();
	    }
	}

}
