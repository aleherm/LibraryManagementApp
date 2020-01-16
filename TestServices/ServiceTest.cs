// <copyright file="ServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using DomainModel;
    using NUnit.Framework;
    using Services;

    [TestFixture]
    public abstract class ServiceTest
    {
        /// <summary>
        /// The validation errors.
        /// </summary>
        public ErrorsHandler ErrorsHandler { get; private set; }

        /// <summary>
        /// Gets or sets the threshold.
        /// </summary>
        protected Threshold Threshold { get; set; }

        [SetUp]
        public void ServiceSetup()
        {
            ErrorsHandler = new ErrorsHandler();
            Threshold = new Threshold();
        }

        [Test]
        public abstract void EntityShouldBeValid();

        [Test]
        public abstract void EntityShouldNotBeValid();

        [Test]
        public abstract void AddNewValidEntityShouldBeSuccessful();

        [Test]
        public abstract void AddNewInvalidEntityShouldFail();
    }
}
