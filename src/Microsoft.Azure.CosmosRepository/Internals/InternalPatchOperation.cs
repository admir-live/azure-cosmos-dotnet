// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.CosmosRepository.Internals;

  public class PatchOperation(PropertyInfo propertyInfo, object? newValue, PatchOperationType type)
{
    public PatchOperationType Type { get; } = type;
    public PropertyInfo PropertyInfo { get; } = propertyInfo;

    public object? NewValue { get; } = newValue;
}