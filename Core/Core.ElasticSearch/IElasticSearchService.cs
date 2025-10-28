using Core.ElasticSearch.Models;

namespace Core.ElasticSearch;

public interface IElasticSearchService
{
    Task<ElasticSearchIndexCreateResponse> CreateNewIndexAsync<T>(string indexName, string? aliases = null)
        where T : class, new();

    void InsertDocToIndex<T>(T document, string indexName) where T : class, new();
}