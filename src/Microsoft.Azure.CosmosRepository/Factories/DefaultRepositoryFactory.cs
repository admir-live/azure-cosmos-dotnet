// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.CosmosRepository.Repositories;

namespace Microsoft.Azure.CosmosRepository.Factories;

/// <inheritdoc/>
/// <summary>
/// Constructor for the default repository factory.
/// </summary>
/// <param name="serviceProvider"></param>
public class DefaultRepositoryFactory(IServiceProvider serviceProvider) : IRepositoryFactory
{
    public IRepository<TItem> RepositoryOf<TItem>() where TItem : class, IItem =>
        serviceProvider.GetRequiredService<IRepository<TItem>>();
}
