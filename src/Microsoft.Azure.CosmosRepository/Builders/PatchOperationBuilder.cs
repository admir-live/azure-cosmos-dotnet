// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.CosmosRepository.Builders;

  public class PatchOperationBuilder<TItem> : IPatchOperationBuilder<TItem> where TItem : IItem
{
    private readonly List<PatchOperation> _patchOperations = new();
    private readonly NamingStrategy _namingStrategy;

    public readonly List<PatchOperation> _rawPatchOperations = new();

    public IReadOnlyList<PatchOperation> PatchOperations => _patchOperations;

    public PatchOperationBuilder() =>
        _namingStrategy = new CamelCaseNamingStrategy();

    public PatchOperationBuilder(CosmosPropertyNamingPolicy? cosmosPropertyNamingPolicy) =>
        _namingStrategy = cosmosPropertyNamingPolicy == CosmosPropertyNamingPolicy.Default
            ? new DefaultNamingStrategy()
            : new CamelCaseNamingStrategy();

    public IPatchOperationBuilder<TItem> Replace<TValue>(Expression<Func<TItem, TValue>> expression, TValue? value)
    {
        PropertyInfo property = expression.GetPropertyInfo();
        var propertyToReplace = GetPropertyToReplace(property);
        _rawPatchOperations.Add(PatchOperation.Replace($"/{propertyToReplace}", value));
        _patchOperations.Add(PatchOperation.Replace($"/{propertyToReplace}", value));
        return this;
    }

    private string GetPropertyToReplace(MemberInfo propertyInfo)
    {
        JsonPropertyAttribute[] attributes =
            propertyInfo.GetCustomAttributes<JsonPropertyAttribute>(true).ToArray();

        return attributes.Length is 0
            ? _namingStrategy.GetPropertyName(propertyInfo.Name, false)
            : attributes[0].PropertyName;
    }
}