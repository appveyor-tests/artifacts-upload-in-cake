﻿using System.Collections.Generic;
using Cake.Core.Composition;

namespace Cake.Composition
{
    internal sealed class ContainerRegistry : ICakeContainerRegistry
    {
        private readonly List<ContainerRegistration> _registrations;

        public IReadOnlyList<ContainerRegistration> Registrations
        {
            get { return _registrations; }
        }

        public ContainerRegistry()
        {
            _registrations = new List<ContainerRegistration>();
        }

        public void RegisterModule(ICakeModule module)
        {
            module.Register(this);
        }

        public ICakeRegistrationBuilder<TImplementationType> RegisterType<TImplementationType>()
        {
            var registration = new ContainerRegistration(typeof(TImplementationType));
            _registrations.Add(registration);
            return new ContainerRegistrationBuilder<TImplementationType>(registration);
        }

        public ICakeRegistrationBuilder<TImplementationType> RegisterInstance<TImplementationType>(TImplementationType instance)
        {
            var registration = new ContainerRegistration(typeof(TImplementationType), instance);
            _registrations.Add(registration);
            return new ContainerRegistrationBuilder<TImplementationType>(registration);
        }
    }
}