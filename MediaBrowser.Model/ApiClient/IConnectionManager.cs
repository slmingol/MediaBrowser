﻿using MediaBrowser.Model.Connect;
using MediaBrowser.Model.Dto;
using MediaBrowser.Model.Events;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediaBrowser.Model.ApiClient
{
    public interface IConnectionManager
    {
        /// <summary>
        /// Occurs when [connected].
        /// </summary>
        event EventHandler<GenericEventArgs<ConnectionResult>> Connected;
        /// <summary>
        /// Occurs when [local user sign in].
        /// </summary>
        event EventHandler<GenericEventArgs<UserDto>> LocalUserSignIn;
        /// <summary>
        /// Occurs when [connect user sign in].
        /// </summary>
        event EventHandler<GenericEventArgs<ConnectUser>> ConnectUserSignIn;
        /// <summary>
        /// Occurs when [local user sign out].
        /// </summary>
        event EventHandler<GenericEventArgs<IApiClient>> LocalUserSignOut;
        /// <summary>
        /// Occurs when [connect user sign out].
        /// </summary>
        event EventHandler<EventArgs> ConnectUserSignOut;
        /// <summary>
        /// Occurs when [remote logged out].
        /// </summary>
        event EventHandler<EventArgs> RemoteLoggedOut;
        
        /// <summary>
        /// Gets the connect user.
        /// </summary>
        /// <value>The connect user.</value>
        ConnectUser ConnectUser { get; }

        /// <summary>
        /// Gets or sets a value indicating whether [save local credentials].
        /// </summary>
        /// <value><c>true</c> if [save local credentials]; otherwise, <c>false</c>.</value>
        bool SaveLocalCredentials { get; set; }

        /// <summary>
        /// Gets the API client.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>IApiClient.</returns>
        IApiClient GetApiClient(IHasServerId item);

        /// <summary>
        /// Connects the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;ConnectionResult&gt;.</returns>
        Task<ConnectionResult> Connect(CancellationToken cancellationToken);

        /// <summary>
        /// Connects the specified API client.
        /// </summary>
        /// <param name="apiClient">The API client.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;ConnectionResult&gt;.</returns>
        Task<ConnectionResult> Connect(IApiClient apiClient, CancellationToken cancellationToken);
        
        /// <summary>
        /// Connects the specified server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;ConnectionResult&gt;.</returns>
        Task<ConnectionResult> Connect(ServerInfo server, CancellationToken cancellationToken);

        /// <summary>
        /// Connects the specified server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="options">The options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;ConnectionResult&gt;.</returns>
        Task<ConnectionResult> Connect(ServerInfo server, ConnectionOptions options, CancellationToken cancellationToken);

        /// <summary>
        /// Connects the specified server.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;ConnectionResult&gt;.</returns>
        Task<ConnectionResult> Connect(string address, CancellationToken cancellationToken);

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns>Task&lt;ConnectionResult&gt;.</returns>
        Task Logout();

        /// <summary>
        /// Logins to connect.
        /// </summary>
        /// <returns>Task.</returns>
        Task LoginToConnect(string username, string password);

        /// <summary>
        /// Gets the active api client instance
        /// </summary>
        IApiClient CurrentApiClient { get; }

        /// <summary>
        /// Creates the pin.
        /// </summary>
        /// <returns>Task&lt;PinCreationResult&gt;.</returns>
        Task<PinCreationResult> CreatePin();

        /// <summary>
        /// Gets the pin status.
        /// </summary>
        /// <param name="pin">The pin.</param>
        /// <returns>Task&lt;PinStatusResult&gt;.</returns>
        Task<PinStatusResult> GetPinStatus(PinCreationResult pin);

        /// <summary>
        /// Exchanges the pin.
        /// </summary>
        /// <param name="pin">The pin.</param>
        /// <returns>Task.</returns>
        Task ExchangePin(PinCreationResult pin);

        /// <summary>
        /// Gets the available servers.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<List<ServerInfo>> GetAvailableServers(CancellationToken cancellationToken);
    }
}
