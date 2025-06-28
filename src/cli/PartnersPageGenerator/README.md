# Partners Page Generator

This is a lightweight .NET console application that generates the HTML content for the Partners directory page on the CMDS website. This tool reads company metadata from a JSON file and creates a responsive HTML grid layout for displaying partner logos, names, and links.

## Features

- **JSON to HTML conversion**: Transforms structured partner data into formatted HTML
- **Responsive grid layout**: Generates a flexible grid system for partner display
- **External link integration**: Creates "Visit Site" and "CMDS Sign In" buttons for each partner
- **Alphabetic sorting**: Partners are automatically sorted alphabetically by name
- **Command line validation**: Comprehensive validation of input arguments
- **Error handling**: Graceful error handling with descriptive messages

## Prerequisites

- .NET 9.0 or later
- Windows, macOS, or Linux

## Installation

1. Clone or download the project
2. Navigate to the project directory
3. Build the application:
   ```bash
   dotnet build
   ```

## Usage

### Command Line Syntax
```bash
PartnersPageGenerator <input> <output>
```

### Parameters
- `<input>`: Path to the JSON file containing company metadata
- `<output>`: Path where the generated HTML file will be saved

### Example
```bash
PartnersPageGenerator partners.json partners.html
```

### Input JSON Format

The input JSON file must contain an array of objects with the following structure:

```json
[
  {
    "Name": "Partner Company Name",
    "ImageUrl": "https://hub.cmds.app/logos/example.png",
    "SiteUrl": "https://www.example.com",
    "LoginUrl": "https://example.cmds.app"
  }
]
```

#### Required Fields
- **Name**: The display name of the company
- **ImageUrl**: URL to the company's logo image
- **SiteUrl**: URL to the company's main website
- **LoginUrl**: URL to the company's CMDS login page

### Output HTML Structure

The generated HTML creates a responsive grid layout where each item in the grid displays:
- The company logo as an image
- The company name as a text header
- The "Visit Site" URL as a hyperlink to the company's corporate website
- The "CMDS Sign In" URL as a hyperlink to the company's login page for the CMDS app

The HTML uses CSS classes that assume external styling:
- `.flex-grid`: Container for the grid layout
- `.col.partner`: Individual partner containers
- `.links`: Container for action buttons
- `.name`: Partner name styling
- `.logo`: Logo container styling

## Project Structure

```
PartnersPageGenerator/
├── Program.cs              # Application entry point
├── ProgramOptions.cs       # Command-line argument parsing and validation
├── Application.cs          # Main application orchestration
├── PartnerModel.cs         # Data model for partner information
├── PartnerReader.cs        # JSON file reading and deserialization
├── HtmlGenerator.cs        # HTML generation logic
├── HtmlWriter.cs           # File output operations
└── PartnersPageGenerator.csproj  # Project configuration
```

## Architecture

The application follows a modular architecture with clean separation of concerns:

- **Program.cs**: Entry point handles command-line arguments and error display
- **ProgramOptions**: Validates and parses command-line arguments
- **Application**: Orchestrates the main workflow (read → generate → write)
- **PartnerReader**: Handles JSON deserialization and data loading
- **HtmlGenerator**: Creates HTML markup from partner metadata
- **HtmlWriter**: Manages file output
- **PartnerModel**: Defines the data structure for partner information

## Error Handling

The application provides comprehensive error handling for:
- Missing or invalid command-line arguments
- Non-existent input files
- Invalid output directories
- JSON parsing errors
- File I/O exceptions

All errors are displayed with descriptive messages to help users resolve issues quickly.

## Development

### Building
```bash
dotnet build
```

### Running
```bash
dotnet run -- <input-file> <output-file>
```

### Testing
Create a sample JSON file with partner data and run:
```bash
dotnet run -- sample-partners.json output.html
```

## Dependencies

- **System.Text.Json**: For JSON deserialization (built into .NET)
- **System.IO**: For file operations (built into .NET)

No external NuGet packages are required.

## CSS Integration

The generated HTML expects external CSS styling for proper presentation. Ensure your webpage includes:
- Font Awesome for icons (`fas fa-up-right-from-square`, `fas fa-sign-in`)
- CSS definitions for the grid classes (`.flex-grid`, `.col`, `.partner`, etc.)