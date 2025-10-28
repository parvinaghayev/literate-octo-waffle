using Core.CrossCuttingConcerns.Logging.Models;

namespace Core.CrossCuttingConcerns.Logging.Commons;

public interface ILogger
{
    Task Information(LogModel logModel);
    Task Debug(LogModel logModel);
    Task Warning(LogModel logModel);
    Task Error(LogModel logModel);
    Task Fatal(LogModel logModel);
}