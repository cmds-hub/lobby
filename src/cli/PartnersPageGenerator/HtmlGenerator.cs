namespace PartnersPageGenerator;

public class HtmlGenerator
{
    public string Generate(List<PartnerModel> partners)
    {
        var html = new System.Text.StringBuilder();

        html.AppendLine("<div class='flex-grid'>");

        foreach (var partner in partners)
        {
            var block = @$"
  <div class='col partner'>
    <div class=""links"">
      <a href=""{partner.SiteUrl}"" class=""visit-site"" target=""_blank"" rel=""noopener noreferrer"">
        <i class=""fas fa-up-right-from-square""></i>Visit Site
      </a>
      <a href=""{partner.LoginUrl}"" class=""cmds-sign-in"" target=""_blank"" rel=""noopener noreferrer"">
        <i class=""fas fa-sign-in""></i>CMDS Sign In
      </a>
    </div>
    <div class=""name"">{partner.Name}</div>
    <div class=""logo""><img src='{partner.ImageUrl}'></img></div>
  </div>
";
            html.Append(block);
        }

        html.AppendLine();

        html.AppendLine("</div>");

        return html.ToString();
    }
}
