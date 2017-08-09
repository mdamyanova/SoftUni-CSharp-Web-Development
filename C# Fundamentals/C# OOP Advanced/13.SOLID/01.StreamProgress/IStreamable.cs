namespace _01.StreamProgress
{
    public interface IStreamable
    {
        int Length { get; }
        int BytesSent { get; }
    }
}