namespace WebServer.Server.Enums
{
    public enum HttpStatusCode
    {
        Ok = 200,
        MovedPermamently = 301,
        Found = 302,
        MovedTemporarily = 303,
        NotAuthorized = 401,
        NotFound = 404,
        InternalServerError = 500
    }
}