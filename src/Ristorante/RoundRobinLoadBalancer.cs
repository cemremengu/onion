﻿namespace Ristorante
{
    public class RoundRobinLoadBalancer<T> : IHandle<T> where T : Message
    {
        private readonly IHandle<T>[] _handlers;

        private int _current;

        public RoundRobinLoadBalancer(IHandle<T>[] handlers)
        {
            _handlers = handlers;
        }

        public void Handle(T message)
        {
            _handlers[_current].Handle(message);

            _current = (_current + 1)%_handlers.Length;
        }
    }
}