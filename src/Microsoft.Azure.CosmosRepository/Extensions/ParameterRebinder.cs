﻿// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.CosmosRepository.Extensions;

  public class ParameterRebinder : ExpressionVisitor
{
    readonly Dictionary<ParameterExpression, ParameterExpression> _map;

     ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map) =>
        _map = map ?? new();

     public static Expression ReplaceParameters(
        Dictionary<ParameterExpression, ParameterExpression> map, Expression exp) =>
        new ParameterRebinder(map).Visit(exp);

    /// <inheritdoc />
    protected override Expression VisitParameter(ParameterExpression parameter)
    {
        if (_map.TryGetValue(parameter, out var replacement))
        {
            parameter = replacement;
        }

        return base.VisitParameter(parameter);
    }
}