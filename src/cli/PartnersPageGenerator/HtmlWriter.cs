namespace PartnersPageGenerator;

internal class HtmlWriter
{
    public string ReplaceFileExtension(string path, string newExtension)
    {
        var directory = Path.GetDirectoryName(path)!;

        var file = Path.GetFileNameWithoutExtension(path);

        return Path.Combine(directory, file + newExtension);
    }

    internal void WriteToFile(string path, string text)
    {
        File.WriteAllText(path, text);
    }
}