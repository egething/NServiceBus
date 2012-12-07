﻿namespace NServiceBus.Gateway.Tests
{
    using System;
    using Unicast.Transport;

    public class FakeTransport : ITransport
    {
        public void Dispose()
        {
            
        }
        
        public void Start(string inputqueue)
        {
            Start(Address.Parse(inputqueue));
        }

        public bool IsStarted { get; set; }

        public Address InputAddress { get; set; }

        public void Start(Address localAddress)
        {
            IsStarted = true;
            InputAddress = localAddress;
        }

        public int HasChangedMaxDegreeOfParallelismNTimes { get; set; }

        public int MaxDegreeOfParallelism { get; private set; }

        public void ChangeNumberOfWorkerThreads(int targetNumberOfWorkerThreads)
        {
            ChangeMaxDegreeOfParallelism(targetNumberOfWorkerThreads);
        }

        public void ChangeMaxDegreeOfParallelism(int maxDegreeOfParallelism)
        {
            MaxDegreeOfParallelism = maxDegreeOfParallelism;
            HasChangedMaxDegreeOfParallelismNTimes++;
        }

        public void AbortHandlingCurrentMessage()
        {
            throw new NotImplementedException();
        }

        public int NumberOfWorkerThreads { get; private set; }

        public int MaxThroughputPerSecond { get; set; }

        public void RaiseEvent(TransportMessage message)
        {
            TransportMessageReceived(this, new TransportMessageReceivedEventArgs(message));
        }

        public void ChangeMaxThroughputPerSecond(int maxThroughputPerSecond)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<TransportMessageReceivedEventArgs> TransportMessageReceived;
        public event EventHandler<StartedMessageProcessingEventArgs> StartedMessageProcessing;
        public event EventHandler FinishedMessageProcessing;
        public event EventHandler<FailedMessageProcessingEventArgs> FailedMessageProcessing;
    }
}