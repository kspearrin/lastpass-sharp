using CsvHelper;
using LastPass;
using System.Globalization;

namespace CLI;

class Program
{
    static void Main(string[] args)
    {
        // LastPass API now uses TLS 1.2
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

        var username = "";
        if (args.Length > 0)
        {
            username = args[0];
        }
        else
        {
            username = Helpers.Prompt("Username");
        }


        var password = "";
        if (args.Length > 1)
        {
            password = args[1];
        }
        else
        {
            password = Helpers.Prompt("Password");
        }

        var clientId = Guid.NewGuid().ToString().ToLower();
        var clientDescription = "LastPass exporter";

        try
        {
            // Fetch and create the vault from LastPass
            var vault = Vault.Open(
                username,
                password,
                new ClientInfo(Platform.Desktop, clientId, clientDescription, false),
                new Ui(args));

            var exportAccounts = vault.Accounts.Select(a => new ExportAccount(a));
            using var writer = new StringWriter();
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(exportAccounts);
            csv.Flush();

            var csvOutput = writer.ToString();
            Console.WriteLine(csvOutput);
        }
        catch (LoginException e)
        {
            Console.WriteLine("Error logging in: {0}", e.Message);
        }

        Console.ReadLine();
    }
}
