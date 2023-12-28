namespace Chat.WebAPI.Settings;
    public class ChatSettings
    {
        public Uri ServiceUri { get; set; }
        public string ChatDbContextConnectionString { get; set; }
        public string IdentityServerUri { get; set; }
        public string UserId { get; set; }
        public string MessageId { get; set; }
    }
