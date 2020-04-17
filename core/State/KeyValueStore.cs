﻿using Kafka.Streams.Net.Processors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kafka.Streams.Net.State
{
    public interface KeyValueStore<K, V> : IStateStore, ReadOnlyKeyValueStore<K, V>
    {
        void Put(K key, V value);

        V PutIfAbsent(K key, V value);

        void PutAll(IEnumerable<KeyValuePair<K, V>> entries);

        V Delete(K key);
    }
}