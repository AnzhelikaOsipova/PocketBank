using PocketBank.User.DataAccess.Common.Enums;

namespace PocketBank.User.DataAccess.Common.Exceptions
{
    public class RepositoryDatabaseException : Exception
    {
        public RepositoryDatabaseException(Exception ex, OperationType operationType, string entityType)
        : base($"Failed to {operationType} item/items of type {entityType}.", ex)
        { }

        public RepositoryDatabaseException(Exception ex, OperationType operationType, string entityType, 
            params (string, string)[] additionalParams)
        : base($"Failed to {operationType} item/items of type {entityType} with parameters: " +
              string.Join(", ", additionalParams.Select(pr => $"{pr.Item1}:{pr.Item2}")), ex)
        { }
    }
}
