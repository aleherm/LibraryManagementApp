// <copyright file="Program.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace LibraryManagementApp
{
    using System;
    using DomainModel;
    using log4net;
    using Services;

    /// <summary>
    /// Main class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            log4net.GlobalContext.Properties["LogFileName"] = @"C:\\Users\\ahermeneanu\\Desktop\\logfile.txt"; // log file path
            log4net.Config.XmlConfigurator.Configure();

            Log.Info("Entering application.");

            Edition edition = new Edition("Publisher", 200, 2010, EBookType.EPaperBack, 2, 10);

            EditionService service = new EditionService();
            if (service.AddNewEdition(edition))
            {
                Log.Info("Edition added succesfully!");
                Console.WriteLine("Edition addded succesfully");
            }
            else
            {
                Log.Error("Failed to insert Edition!");
                Console.WriteLine("Edition not valid!");
            }

            Log.Info("LEaving application.");
        }
    }
}
