// <copyright file="Service.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using DomainModel;
    using Newtonsoft.Json;

    /// <summary>
    /// Base service.
    /// </summary>
    public abstract class Service
    {
        /// <summary>
        /// The validation errors.
        /// </summary>
        public readonly ErrorsHandler ErrorsHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        public Service()
        {
            string solutionDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetAssembly(this.GetType()).Location)));
            Threshold = GetThresholdFromJSON(solutionDirectory);

            ErrorsHandler = new ErrorsHandler();
        }

        /// <summary>
        /// Gets or sets the threshold.
        /// </summary>
        protected Threshold Threshold { get; set; }

        /// <summary>
        /// Gets the threshold data needed for validation from the external JSON file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>A Threshold object.</returns>
        protected Threshold GetThresholdFromJSON(string path)
        {
            StreamReader reader = new StreamReader(path + "\\Data\\external-data.json");
            string json = reader.ReadToEnd();
            List<Threshold> items = JsonConvert.DeserializeObject<List<Threshold>>(json);
            return items[0];
        }
    }
}
