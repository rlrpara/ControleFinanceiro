namespace ControleFinanceiro.Mobile;

public static class AppSettings
{
    private static string DatabaseName = "database.db";
    private static string DirectoryPath = FileSystem.AppDataDirectory;

    public static string DatabasePath = Path.Combine(DirectoryPath, DatabaseName);
}
