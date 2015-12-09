
namespace Subscriber2
{
    using NHibernate.Cfg;
    using NServiceBus;
    using NServiceBus.Persistence;
    using NServiceBus.Persistence.Legacy;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration busConfiguration)
        {
            // NServiceBus provides the following durable storage options
            // To use RavenDB, install-package NServiceBus.RavenDB and then use configuration.UsePersistence<RavenDBPersistence>();
            // To use SQLServer, install-package NServiceBus.NHibernate and then use configuration.UsePersistence<NHibernatePersistence>();

            // If you don't need a durable storage you can also use, configuration.UsePersistence<InMemoryPersistence>();
            // more details on persistence can be found here: http://docs.particular.net/nservicebus/persistence-in-nservicebus

            //Also note that you can mix and match storages to fit you specific needs. 
            //http://docs.particular.net/nservicebus/persistence-order
            //busConfiguration.EnableInstallers();



            //FOr RavenDB RabbitMQ
            busConfiguration.EndpointName("Two");
            //busConfiguration.UseSerialization<JsonSerializer>();
            //busConfiguration.UsePersistence<RavenDBPersistence>();
            //busConfiguration.UseTransport<RabbitMQTransport>().ConnectionString("host=localhost");


            //FOr SQLServer MSMQ
            //Configuration nhConfiguration = new Configuration();
            //nhConfiguration.Properties["dialect"] = "NHibernate.Dialect.MsSql2012Dialect";
            //nhConfiguration.Properties["connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
            //nhConfiguration.Properties["connection.driver_class"] = "NHibernate.Driver.Sql2012ClientDriver";

            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<NHibernatePersistence>();
            busConfiguration.UseTransport<MsmqTransport>();

            //busConfiguration.UsePersistence<NHibernatePersistence, StorageType.Sagas>();
            busConfiguration.UsePersistence<NHibernatePersistence, StorageType.Subscriptions>();
            busConfiguration.UsePersistence<NHibernatePersistence, StorageType.Timeouts>();
            //busConfiguration.UsePersistence<NHibernatePersistence, StorageType.Outbox>();
            //busConfiguration.UsePersistence<NHibernatePersistence, StorageType.GatewayDeduplication>();
            
        }
    }
}
