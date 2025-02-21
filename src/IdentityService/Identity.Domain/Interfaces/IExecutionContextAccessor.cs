namespace Identity.Domain.Interfaces
{
    public interface IExecutionContextAccessor
    {
        Guid UserId { get; }
        string UserName { get; }
        string CorrelationId { get; }
        bool IsAuthenticated { get; }
    }
}
