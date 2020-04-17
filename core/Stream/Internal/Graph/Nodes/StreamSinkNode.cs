﻿using Kafka.Streams.Net.Processors;
using Kafka.Streams.Net.Processors.Internal;

namespace Kafka.Streams.Net.Stream.Internal.Graph.Nodes
{
    internal abstract class StreamSinkNode : StreamGraphNode
    {
        internal StreamSinkNode(string streamGraphNode)
            : base(streamGraphNode)
        {
        }
    }

    internal class StreamSinkNode<K, V> : StreamSinkNode
    {
        private ITopicNameExtractor<K, V> topicNameExtractor;
        private Produced<K, V> produced;

        public StreamSinkNode(ITopicNameExtractor<K, V> topicNameExtractor, string streamGraphNode, Produced<K, V> produced)
            : base(streamGraphNode)
        {
            this.topicNameExtractor = topicNameExtractor;
            this.produced = produced;
        }

        public override void WriteToTopology(InternalTopologyBuilder builder)
        {
            builder.AddSinkOperator(topicNameExtractor, this.streamGraphNode, produced);
        }
    }
}