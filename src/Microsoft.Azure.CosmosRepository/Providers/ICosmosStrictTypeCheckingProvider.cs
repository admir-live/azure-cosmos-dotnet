// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.CosmosRepository.Providers;

public interface ICosmosStrictTypeCheckingProvider
{
    bool UseStrictTypeChecking<TItem>()
        where TItem : IItem;

    bool UseStrictTypeChecking(Type itemType);
}