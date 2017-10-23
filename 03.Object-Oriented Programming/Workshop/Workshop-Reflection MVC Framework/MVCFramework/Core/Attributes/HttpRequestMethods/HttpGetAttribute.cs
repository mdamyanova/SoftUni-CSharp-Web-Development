namespace MVCFramework.Core.Attributes.HttpRequestMethods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToLower() == "get";
        }
    }
}