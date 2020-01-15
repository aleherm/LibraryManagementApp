// <copyright file="ServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) Alexandra Hermeneanu. All rights reserved.
// </copyright>

namespace TestServices
{
    using NUnit.Framework;
    using Services;

    [TestFixture]
    public abstract class ServiceTest
    {
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
