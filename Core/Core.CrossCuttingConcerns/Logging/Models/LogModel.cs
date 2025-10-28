namespace Core.CrossCuttingConcerns.Logging.Models;

public class LogModel
{
    public string? RequestCorrelationId { get; set; }
    public string? SentryEventId { get; set; }
    public string? Response { get; set; }
    public string? IPAddress { get; set; }
    public string? Level { get; set; }
    public string? Url { get; set; }
    public string? Header { get; set; } = "";
    public string? Body { get; set; }
    public string? Controller { get; set; }
    public string? Action { get; set; }
    public string? UserProfileId { get; set; }
    public string? UserFullName { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? Message { get; set; }
}