using Core.ElasticSearch.Models;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.Transport;
using Microsoft.Extensions.Options;

namespace Core.ElasticSearch
{
    public class ElasticSearchManager : IElasticSearchService
    {
        private readonly IOptions<ElasticSearchSettings> _elasticSettings;
        private readonly ElasticsearchClient _elasticSearchClient;

        public ElasticSearchManager(IOptions<ElasticSearchSettings> elasticSettings)
        {
            _elasticSettings = elasticSettings;
            _elasticSearchClient = CreateClient();
        }

        public async Task<ElasticSearchIndexCreateResponse> CreateNewIndexAsync<T>(string indexName,
            string? aliases = null)
            where T : class, new()
        {
            indexName = indexName.ToLower();
            var existsResponse = await _elasticSearchClient.Indices.ExistsAsync(indexName);
            if (existsResponse.Exists)
            {
                return new ElasticSearchIndexCreateResponse(false,
                    $"'{indexName}' already exists. Try creating the index with a different name.");
            }

            var indexSettings = new IndexSettings
            {
                NumberOfShards = 1,
                NumberOfReplicas = 1
            };
            // Build the request
            var request = new CreateIndexRequest(indexName)
            {
                Settings = indexSettings
            };

            if (!string.IsNullOrEmpty(aliases))
            {
                request.Aliases = new Dictionary<Name, Alias>
                {
                    [aliases] = new Alias()
                };
            }

            var createResponse = await _elasticSearchClient.Indices.CreateAsync(request);

            if (!createResponse.IsValidResponse)
            {
                return new ElasticSearchIndexCreateResponse(false,
                    $"Failed to create index: {createResponse.DebugInformation}");
            }

            return new ElasticSearchIndexCreateResponse(true, $"'{indexName}' index was created.");
        }

        public void InsertDocToIndex<T>(T document, string indexName) where T : class, new()
        {
            indexName = indexName.ToLower();
            IndexResponse response = _elasticSearchClient.Index<T>(document, indexDesc => indexDesc.Index(indexName));
        }

        private ElasticsearchClient CreateClient()
        {
            // Create the transport settings
            var settings = new ElasticsearchClientSettings(new Uri(_elasticSettings.Value.Uri))
                .Authentication(new BasicAuthentication(_elasticSettings.Value.UserName,
                    _elasticSettings.Value.Password))
                .ServerCertificateValidationCallback((sender, certificate, chain, errors) => true)
                .MaximumRetries(1)
                .RequestTimeout(TimeSpan.FromSeconds(2))
                .EnableDebugMode(); // Optional: set if you use a default index

            // Create the Elasticsearch client
            var client = new ElasticsearchClient(settings);

            return client;
        }
    }
}