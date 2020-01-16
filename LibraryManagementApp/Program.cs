using DomainModel;
using Services;
using log4net;
using System;

namespace LibraryManagementApp
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            log4net.GlobalContext.Properties["LogFileName"] = @"C:\\Users\\ahermeneanu\\Desktop\\logfile.txt"; //log file path
            log4net.Config.XmlConfigurator.Configure();

            log.Info("Entering application.");

            Edition edition = new Edition("Publisher", 200, 2010, EBookType.EPaperBack, 2, 10);

            EditionService service = new EditionService();
            if(service.AddNewEdition(edition))
            {
                log.Info("Edition added succesfully!");
                Console.WriteLine("Edition addded succesfully");
            } else
            {
                log.Error("Failed to insert Edition!");
                Console.WriteLine("Edition not valid!");
            }
        }
    }
}
