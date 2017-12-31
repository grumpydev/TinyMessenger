﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyMessenger;

namespace TinyMessenger.Tests.TestData
{
    public class TestMessage : TinyMessageBase
    {
        public TestMessage(object sender) : base(sender)
        {
            
        }
    }

    public class DerivedMessage<TThings> : TestMessage
    {
        public TThings Things { get; set; }

        public DerivedMessage(object sender)
            : base(sender)
        {
        }
    }

    public interface ITestMessageInterface : ITinyMessage
    {
        
    }

    public class InterfaceDerivedMessage<TThings> : ITestMessageInterface
    {
        public object Sender { get; private set; }
        public bool Consume { get; private set; }

        public TThings Things { get; set; }

        public InterfaceDerivedMessage(object sender) : this(sender, false)
        {
        }

        public InterfaceDerivedMessage(object sender, bool consume)
        {
            this.Sender = sender;
            this.Consume = consume;
        }
    }

    public class TestProxy : ITinyMessageProxy
    {
        public ITinyMessage Message {get; private set;}

        public void Deliver(ITinyMessage message, ITinyMessageSubscription subscription)
        {
            this.Message = message;
            subscription.Deliver(message);
        }
    }

    public class TestSubscriptionErrorHandler : ISubscriberErrorHandler
    {
        public void Handle(ITinyMessage message, Exception exception)
        {
            throw exception;
        }
    }


}
