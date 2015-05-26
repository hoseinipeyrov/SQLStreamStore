﻿namespace Cedar.EventStore
{
    using System;
    using System.Threading.Tasks;
    using FluentAssertions;

    internal static class TaskExtensions
    {
        internal static async Task ShouldThrow<T>(this Task task, string message)
        {
            try
            {
                await task;
            }
            catch(Exception ex)
            {
                ex.Should().BeOfType<T>();
                ex.Message.Should().Be(message);

                return;
            }
            throw new Exception("Exception not thrown");
        }
    }
}