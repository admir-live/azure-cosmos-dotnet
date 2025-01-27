// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.CosmosRepository.Providers;

 public class DefaultRepositoryExpressionProvider(ICosmosItemConfigurationProvider itemConfigurationProvider) : IRepositoryExpressionProvider
{
    public Expression<Func<TItem, bool>> Build<TItem>(Expression<Func<TItem, bool>> predicate)
        where TItem : IItem
    {
        ItemConfiguration options = itemConfigurationProvider.GetItemConfiguration<TItem>();

        return options.UseStrictTypeChecking ? predicate.Compose(Default<TItem>(), Expression.AndAlso) : predicate;
    }

    public Expression<Func<TItem, bool>> Default<TItem>() where TItem : IItem =>
        item => !item.Type.IsDefined() || item.Type == typeof(TItem).Name;

    public TItem CheckItem<TItem>(TItem item) where TItem : IItem
    {
        ItemConfiguration options = itemConfigurationProvider.GetItemConfiguration<TItem>();

        if (options.UseStrictTypeChecking)
        {
            return item is { Type.Length: 0 } || item.Type == typeof(TItem).Name
                ? item
                : throw new MissMatchedTypeDiscriminatorException(typeof(TItem).Name, item.Type);
        }

        return item;
    }
}