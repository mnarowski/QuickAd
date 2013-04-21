using System;
using System.Configuration;
using NHibernate;
using NHibernate.Impl;

namespace QuickAd.Models
{
	public class SessionFactory {
		private static string connectionString = ConfigurationManager.ConnectionStrings["remoteHost"].ConnectionString;
		private static NHibernate.ISessionFactory sFactory;

		private static void Init()
		{
		    NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
		    configuration.AddXmlFile(".\\DBO\\models.xml");
		    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.SqlClientDriver");
		    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, connectionString);
		    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSql2008Dialect");
            configuration.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass, "NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu");
		    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider,
		                              "NHibernate.Connection.DriverConnectionProvider");
		    configuration.Configure();
		    sFactory = configuration.BuildSessionFactory();
		}
		private static NHibernate.ISessionFactory GetSessionFactory() {
            if (sFactory == null)
            {
                Init();
            }
            return sFactory;

		}
		public static NHibernate.ISession GetNewSession() {
            return GetSessionFactory().OpenSession();
		}

	}

}
