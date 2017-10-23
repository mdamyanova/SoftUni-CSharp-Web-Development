namespace MVCFramework.Core.Attributes.HttpRequestMethods
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToLower() == "post";
        }
    }
}