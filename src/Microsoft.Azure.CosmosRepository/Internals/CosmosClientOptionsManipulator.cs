// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.CosmosRepository.Internals;

public class CosmosClientOptionsManipulator
{
     public Action<CosmosClientOptions> Configure { get; }

     public CosmosClientOptionsManipulator(Action<CosmosClientOptions> configure) =>
        Configure = configure ?? (options => { /* if not provided, act as a pass-thru */ });
}
