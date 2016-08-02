using System;
using System.Collections.Concurrent;

namespace Piwik.NETCore.Analytics
{
    public interface IServiceLocator
    {
        void Register<TService>(Func<TService> factory);
        TService Get<TService>();
    }

    internal class ServiceLocator : IServiceLocator
    {
        private readonly ConcurrentDictionary<Type, object> _factories;

        /// <summary>
        /// Creates a new instance of ServiceLocator.
        /// </summary>
        public ServiceLocator()
        {
            _factories = new ConcurrentDictionary<Type, object>();
        }

        /// <summary>
        /// Registers a service.
        /// </summary>
        /// <param name="factory">Factory that creates the service instance.</param>
        public void Register<TService>(Func<TService> factory)
        {
            _factories.AddOrUpdate(typeof(TService), factory, (s, f) => factory);
        }

        /// <summary>
        /// Gets a service.
        /// </summary>
        public TService Get<TService>()
        {
            object factoryObj;
            if (_factories.TryGetValue(typeof(TService), out factoryObj))
            {
                return ((Func<TService>)factoryObj).Invoke();
            }
            else
            {
                throw new InvalidOperationException(String.Format("Service '{0}' not found.", typeof(TService)));
            }
        }
    }
}