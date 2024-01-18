namespace UPatterns.Test
{
    public record ProfileState : UState
    {
        public string user { get; init; }
        public string url { get; init; }
        public string account { get; init; }
        public string private_key { get; init; }
        public int port { get; init; }
        public string host { get; init; }
        public string schema { get; init; }
        public string role { get; init; }
    }
}