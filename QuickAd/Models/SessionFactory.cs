using System;
using System.Configuration;
using NHibernate;
using NHibernate.Impl;
using System.Reflection;

namespace QuickAd.Models
{
	public class SessionFactory {
        private static string connectionString = "Server name: 148.81.130.59; Login: l_proj2013_1; Password: p_proj2013_1";
		private static NHibernate.ISessionFactory sFactory;

		private static void Init()
		{
		    NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
		    
            configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.SqlClientDriver");
		    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, connectionString);
		    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSql2008Dialect");
            configuration.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass, "NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu");
		    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider,
		                              "NHibernate.Connection.DriverConnectionProvider");
            configuration.AddInputStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("QuickAd.Models.DBO.models.xml"));
		    
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
