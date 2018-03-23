namespace P01.Stream_Progress
{
    public interface ISteamable
    {
        int BytesSent { get; }
        int Length { get; }
    }
}