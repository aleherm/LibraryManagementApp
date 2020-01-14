// <copyright file="ErrorsHandler.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace Services
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Error handler class.
    /// </summary>
    public class ErrorsHandler
    {
        private readonly List<string> inputErrors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorsHandler"/> class.
        /// </summary>
        public ErrorsHandler()
        {
            inputErrors = new List<string>();
        }

        /// <summary>
        /// Adds the specified error message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void Add(string errorMessage)
        {
            inputErrors.Add(errorMessage);
        }

        /// <summary>
        /// Gets error at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The error message.</returns>
        public string Get(int index)
        {
            return inputErrors[index];
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            inputErrors.Clear();
        }

        /// <summary>
        /// Gets the instance of the inputErrors.
        /// </summary>
        /// <returns>The list of errors.</returns>
        public List<string> Errors()
        {
            return inputErrors;
        }

        /// <summary>
        /// Prints the errors.
        /// </summary>
        public void PrintErrors()
        {
            foreach (string error in inputErrors)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        
        /// <summary>
        /// The number of errors.
        /// </summary>
        /// <returns>The number of errors</returns>
        public int ErrorCount()
        {
            return inputErrors.Count;
        }
    }
}
