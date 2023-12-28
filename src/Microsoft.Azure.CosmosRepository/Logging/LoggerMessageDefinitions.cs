// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.CosmosRepository.Logging;

 static  public class LoggerMessageDefinitions
{
    //Debug Definitions
    public static readonly Action<ILogger, string, Exception?> ItemRead = LoggerMessage.Define<string>(
        LogLevel.Debug,
        EventIds.CosmosItemRead,
        "Cosmos item read {CosmosItemJson}"
    );

    // Info Definitions
    public static readonly Action<ILogger, string, string, string, Exception?> PointReadStarted =
        LoggerMessage.Define<string, string, string>(
            LogLevel.Information,
            EventIds.CosmosPointReadStarted,
            "Point read started for item type {CosmosItemType} with id {CosmosItemId} and partitionKey {CosmosItemPartitionKey}"
        );

     public static readonly Action<ILogger, string, double, Exception?> PointReadExecuted =
        LoggerMessage.Define<string, double>(
            LogLevel.Information,
            EventIds.CosmosPointReadExecuted,
            "Point read executed for item type {CosmosItemType} total RU cost {CosmosOperationRUCharge}"
        );

     public static readonly Action<ILogger, string, string?, Exception?> QueryConstructed =
        LoggerMessage.Define<string, string?>(
            LogLevel.Information,
            EventIds.CosmosQueryConstructed,
            "Cosmos query constructed for item type {CosmosItemType}: {CosmosQuery}"
        );

     public static readonly Action<ILogger, string, double, string?, Exception?> QueryExecuted =
        LoggerMessage.Define<string, double, string?>(
            LogLevel.Information,
            EventIds.CosmosQueryExecuted,
            "Cosmos query executed for item type {CosmosItemType} with a charge of {CosmosOperationRUCharge} RUs Query: {CosmosQuery}");

     public static readonly Action<ILogger, string, string, string, Exception?> ItemNotFoundHandled =
        LoggerMessage.Define<string, string, string>(
            LogLevel.Information,
            EventIds.ItemNotFoundHandled,
            "CosmosException Status Code 404 handled for item of type {CosmosItemType} with {CosmosItemId} and partition key {CosmosItemPartitionKey}"
        );
}