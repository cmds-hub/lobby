namespace PartnersPageGenerator;

internal class ProgramOptions
{
    public const string Usage = "Usage: PartnersPageGenerator <input> <output>";

    public string? JsonInputFile { get; set; }

    public string? HtmlOutputFile { get; set; }

    public List<string> Errors { get; set; }

    public bool IsValid => Errors.Count == 0;

    public ProgramOptions(string[] args)
    {
        Errors = new List<string>();

        if (args.Length <= 0 || args.Length > 2)
            Errors.Add(Usage);

        if (args.Length > 0)
            JsonInputFile = args[0];

        if (args.Length > 1)
            HtmlOutputFile = args[1];

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(JsonInputFile))
        {
            Errors.Add("Missing JSON input file.");
        }
        else if (!File.Exists(JsonInputFile))
        {
            Errors.Add($"Input file not found: {JsonInputFile}");
        }

        if (string.IsNullOrEmpty(HtmlOutputFile))
        {
            Errors.Add("Missing HTML output file.");
        }
        else
        {
            var folder = Path.GetDirectoryName(HtmlOutputFile);

            if (!Directory.Exists(folder))
            {
                Errors.Add($"Output folder not found: {folder}");
            }
        }
    }
}
