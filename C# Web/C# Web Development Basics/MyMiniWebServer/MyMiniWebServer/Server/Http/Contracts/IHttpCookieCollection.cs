namespace MyMiniWebServer.Server.Http.Contracts
{
    using System.Collections.Generic;
    using MyMiniWebServer.Server.Http;

    public interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        void Add(HttpCookie cookie);

        void Add(string key, string value);
        
        bool ContainsKey(string key);

        HttpCookie Get(string key);
    }
}
