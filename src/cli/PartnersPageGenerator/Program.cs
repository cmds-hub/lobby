using PartnersPageGenerator;

var options = new ProgramOptions(args);

if (!options.IsValid)
{
    var errors = string.Join(Environment.NewLine, options.Errors);

    Console.WriteLine(errors);

    return;
}

var app = new Application(options);

app.Run();
