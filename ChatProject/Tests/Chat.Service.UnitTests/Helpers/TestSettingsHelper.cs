using Chat.Service.Settings;

namespace Chat.Service.UnitTests.Helpers;

public static class TestSettingsHelper
{
    public static ChatSettings GetSettings()
    {
        return ChatSettingsReader.Read(ConfigurationHelper.GetConfiguration());
    }
}