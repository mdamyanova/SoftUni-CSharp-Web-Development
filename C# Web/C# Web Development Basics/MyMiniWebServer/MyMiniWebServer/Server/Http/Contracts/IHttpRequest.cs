namespace MyMiniWebServer.Server.Http.Contracts
{
    using System.Collections.Generic;
    using MyMiniWebServer.Server.Enums;

    public interface IHttpRequest
    {
        IDictionary<string, string> FormData { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        string Path { get; }
        
        HttpRequestMethod Method { get; }

        string Url { get; }

        IDictionary<string, string> UrlParameters { get; }

        IHttpSession Session { get; set; }

        void AddUrlParameter(string key, string value);
    }
}
