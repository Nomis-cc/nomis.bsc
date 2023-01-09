﻿// ------------------------------------------------------------------------------------------------------
// <copyright file="BscExtensions.cs" company="Nomis">
// Copyright (c) Nomis, 2022. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Api.Bsc.Settings;
using Nomis.Api.Common.Extensions;
using Nomis.Bscscan.Interfaces;
using Nomis.ScoringService.Interfaces.Builder;

namespace Nomis.Api.Bsc.Extensions
{
    /// <summary>
    /// Bsc extension methods.
    /// </summary>
    public static class BscExtensions
    {
        /// <summary>
        /// Add BSC blockchain.
        /// </summary>
        /// <typeparam name="TServiceRegistrar">The service registrar type.</typeparam>
        /// <param name="optionsBuilder"><see cref="IScoringOptionsBuilder"/>.</param>
        /// <returns>Returns <see cref="IScoringOptionsBuilder"/>.</returns>
        // ReSharper disable once InconsistentNaming
        public static IScoringOptionsBuilder WithBSCBlockchain<TServiceRegistrar>(
            this IScoringOptionsBuilder optionsBuilder)
            where TServiceRegistrar : IBscServiceRegistrar, new()
        {
            return optionsBuilder
                .With<BscAPISettings, TServiceRegistrar>();
        }
    }
}