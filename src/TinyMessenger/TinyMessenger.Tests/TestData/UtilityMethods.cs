//===============================================================================
// TinyMessenger
//
// A simple messenger/event aggregator.
//
// https://github.com/grumpydev/TinyMessenger
//===============================================================================
// Copyright © Steven Robbins.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyMessenger;

namespace TinyMessenger.Tests.TestData
{
    public class UtilityMethods
    {
        public static ITinyMessengerHub GetMessenger()
        {
            return new TinyMessengerHub();
        }

        public static void FakeDeliveryAction<T>(T message)
            where T:ITinyMessage
        {
        }

        public static bool FakeMessageFilter<T>(T message)
            where T:ITinyMessage
        {
            return true;
        }

        public static TinyMessageSubscriptionToken GetTokenWithOutOfScopeMessenger()
        {
            var messenger = UtilityMethods.GetMessenger();

            var token = new TinyMessageSubscriptionToken(messenger, typeof(TestMessage));

            return token;
        }
    }
}
