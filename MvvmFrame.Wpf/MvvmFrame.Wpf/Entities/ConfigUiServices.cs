using GetcuReone.ComboPatterns.Factory;
using GetcuReone.MvvmFrame.Wpf.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace GetcuReone.MvvmFrame.Wpf.Entities
{
    /// <summary>
    /// UI services manager
    /// </summary>
    public sealed class ConfigUiServices : FactoryBase, IConfigUiServices
    {
        private readonly List<object> _uiServicesEntities = new List<object>();

        private void AddUiService<TUiService, TUiServiceImplementation>(Frame frame, bool isSingleton = false)
            where TUiServiceImplementation : UiServiceBase, TUiService, new()
        {
            if (Contains<TUiService>())
                throw new ArgumentException("service already added previously");

            var uiServiceEntity = new UiServiceEntity<TUiService>(this)
            {
                Frame = frame,
                IsSingleton = isSingleton,
            };

            uiServiceEntity.SetupFuncGetService((f) =>
            {
                var service = new TUiServiceImplementation();
                service.Setup(f, this);
                return service;
            });

            _uiServicesEntities.Add(uiServiceEntity);
        }

        /// <summary>
        /// Add a service that will be created every time you request
        /// </summary>
        /// <typeparam name="TUiService">interfaces services</typeparam>
        /// <typeparam name="TUiServiceImplementation">implement services</typeparam>
        /// <param name="frame"></param>
        public void AddTransient<TUiService, TUiServiceImplementation>(Frame frame) where TUiServiceImplementation : UiServiceBase, TUiService, new()
            => AddUiService<TUiService, TUiServiceImplementation>(frame, isSingleton: false);

        /// <summary>
        /// Get UI service
        /// </summary>
        /// <typeparam name="TUiService">service type</typeparam>
        /// <returns></returns>
        public TUiService GetUiService<TUiService>()
        {
            var entity = _uiServicesEntities.FirstOrDefault(obj => obj is UiServiceEntity<TUiService>);

            if (entity == null)
                throw new ArgumentException("service does not exist");

            return ((UiServiceEntity<TUiService>)entity).GetService();
        }

        /// <summary>
        /// Is the service contains
        /// </summary>
        /// <typeparam name="TUiService"></typeparam>
        /// <returns></returns>
        public bool Contains<TUiService>() => _uiServicesEntities.Any(entity => entity is UiServiceEntity<TUiService>);

        /// <summary>
        /// Add a service that will be created one time you request
        /// </summary>
        /// <typeparam name="TUiService">interfaces services</typeparam>
        /// <typeparam name="TUiServiceImplementation">implement services</typeparam>
        /// <param name="frame"></param>
        public void AddSingleton<TUiService, TUiServiceImplementation>(Frame frame) where TUiServiceImplementation : UiServiceBase, TUiService, new()
            => AddUiService<TUiService, TUiServiceImplementation>(frame, isSingleton: true);
    }
}
