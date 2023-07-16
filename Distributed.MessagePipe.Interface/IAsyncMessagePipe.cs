// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiDepthByPlanController.cs" company="StepanovNO">
// Copyright (c) StepanovNO. Ufa, 2023.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
// <summary>
//  Async message pipe interface
// </summary>

using System.Collections.ObjectModel;

namespace Distributed.MessagePipe.Interface;

/// <summary>
/// Async message pipe interface
/// </summary>
/// <typeparam name="T">Message type</typeparam>
public interface IAsyncMessagePipe<T> : IDisposable
    where T : class
{
    /// <summary>
    /// Register message receiver
    /// </summary>
    /// <param name="receiver">Reciver name</param>
    /// <param name="message">Message</param>
    /// <returns>Async receiver registration</returns>
    Task SendAsync(string receiver, T message);

    /// <summary>
    /// Wait for message event
    /// </summary>
    /// <param name="receiver">Receiver</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Message collection</returns>
    Task<ReadOnlyCollection<T>> WaitForMessagesAsync(string receiver, CancellationToken cancellationToken);

    /// <summary>
    /// DisconnectAsync receiver
    /// </summary>
    /// <param name="receiver">Receiver name</param>
    /// <returns>Async operation</returns>
    Task DisconnectAsync(string receiver);
}