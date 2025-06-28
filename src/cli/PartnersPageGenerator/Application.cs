namespace PartnersPageGenerator;

internal class Application(ProgramOptions options)
{
    private readonly ProgramOptions _options = options;

    public void Run()
    {
        try
        {
            var reader = new PartnerReader();

            var partners = reader.LoadFromFile(_options.JsonInputFile!);

            var generator = new HtmlGenerator();

            var html = generator.Generate(partners);

            var writer = new HtmlWriter();

            writer.WriteToFile(_options.HtmlOutputFile!, html);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred. {ex.Message}");
        }
    }
}