namespace Application.Routes;

public static class ApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;

    public struct AppealRoute
    {
        public const string GetAll = Base + "/appeal";
        public const string GetById = Base + "/appeal/{id}";
        public const string Create = Base + "/appeal";
        public const string Update = Base + "/appeal/{id}";
        public const string Delete = Base + "/appeal/{id}";
    }
}