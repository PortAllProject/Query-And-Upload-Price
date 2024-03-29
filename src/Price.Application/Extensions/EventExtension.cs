﻿using AElf.CSharp.Core;
using AElf.Types;
using Google.Protobuf;

namespace Price.Query.AElfWeb.Extensions
{
    public static class EventExtension
    {
        public static void MergeFrom<T>(this T eventData, LogEvent log) where T : IEvent<T>
        {
            foreach (var bs in log.Indexed)
            {
                eventData.MergeFrom(bs);
            }

            eventData.MergeFrom(log.NonIndexed);
        }
    }
}