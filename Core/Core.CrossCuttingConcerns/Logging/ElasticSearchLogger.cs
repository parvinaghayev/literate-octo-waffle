using Core.CrossCuttingConcerns.Logging.Commons;
using Core.CrossCuttingConcerns.Logging.Models;
using Core.ElasticSearch;
using Microsoft.Extensions.Configuration;

namespace Core.CrossCuttingConcerns.Logging;

public class ElasticSearchLogger : ILogger
{
    private readonly IElasticSearchService _elasticSearchService;
    private readonly string _indexName;

    public ElasticSearchLogger(IElasticSearchService elasticSearchService, IConfiguration configuration)
    {
        _elasticSearchService = elasticSearchService;
        _indexName = $"{configuration["ElasticSearchSettings:LogIndex"]}-{DateTime.Now:MM-yyyy}";
    }

    public async Task Debug(LogModel log)
    {
        await _elasticSearchService.CreateNewIndexAsync<LogModel>(_indexName);
        log.Level = LogLevel.Debug;
        _elasticSearchService.InsertDocToIndex(log, _indexName);
    }

    public async Task Error(LogModel log)
    {
        await _elasticSearchService.CreateNewIndexAsync<LogModel>(_indexName);
        log.Level = LogLevel.Error;
        _elasticSearchService.InsertDocToIndex(log, _indexName);
    }

    public async Task Fatal(LogModel log)
    {
        await _elasticSearchService.CreateNewIndexAsync<LogModel>(_indexName);
        log.Level = LogLevel.Fatal;
        _elasticSearchService.InsertDocToIndex(log, _indexName);
    }

    public async Task Information(LogModel log)
    {
        await _elasticSearchService.CreateNewIndexAsync<LogModel>(_indexName);
        log.Level = LogLevel.Information;
        _elasticSearchService.InsertDocToIndex(log, _indexName);
    }

    public async Task Warning(LogModel log)
    {
        await _elasticSearchService.CreateNewIndexAsync<LogModel>(_indexName);
        log.Level = LogLevel.Warning;
        _elasticSearchService.InsertDocToIndex(log, _indexName);
    }
}