namespace MyMiniWebServer.Server.Http.Contracts
{
    using System.Collections.Generic;
    using MyMiniWebServer.Server.Http;

    public interface IHttpHeaderCollection : IEnumerable<ICollection<HttpHeader>>
    {
        void Add(HttpHeader header);

        void Add(string key, string value);

        bool ContainsKey(string key);

        ICollection<HttpHeader> Get(string key);
    }
}
