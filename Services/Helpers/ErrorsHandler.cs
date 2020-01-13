// <copyright file="ErrorsHandler.cs" company="Transilvania University of Brasov">
// Copyright (c) Transilvania University of Brasov. Code by Alexandra Hermeneanu. All rights reserved.
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
            foreach(string error in inputErrors)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
