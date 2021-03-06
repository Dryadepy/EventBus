﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JKang.EventBus.DependencyInjection
{
    class EventPublisherProvider : IEventPublisherProvider
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly EventPublisherRegister _eventPublishers;

        public EventPublisherProvider(
            IServiceProvider serviceProvider,
            EventPublisherRegister eventPublishers)
        {
            _serviceProvider = serviceProvider;
            _eventPublishers = eventPublishers;
        }


        public IEnumerable<IEventPublisher> GetEventPublishers()
        {
            return _eventPublishers.Types.Select(t => (IEventPublisher)_serviceProvider.GetService(t));
        }
    }
}
