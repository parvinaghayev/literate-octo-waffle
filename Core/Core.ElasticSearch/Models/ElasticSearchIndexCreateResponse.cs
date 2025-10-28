using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ElasticSearch.Models;

public class ElasticSearchIndexCreateResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public ElasticSearchIndexCreateResponse()
    {
    }

    public ElasticSearchIndexCreateResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}