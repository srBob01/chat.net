namespace Chat.WebAPI.Settings
{
    public static class ChatSettingsReader
    {
        public static ChatSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new ChatSettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                ChatDbContextConnectionString = configuration.GetValue<string>("FitnessClubDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                UserId = configuration.GetValue<string>("IdentityServerSettings:UserId"),
                MessageId = configuration.GetValue<string>("IdentityServerSettings:MessageId"),
            };
        }
    }
}
