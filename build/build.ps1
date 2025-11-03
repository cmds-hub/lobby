$Now            = (Get-Date)
$NowUtc         = $Now.ToUniversalTime()

$MajorNumber    = 1  # increment for incompatible API changes or breaking changes
$MinorNumber    = 0  # increment for new functionality that is backward-compatible
$PatchNumber    = 1  # increment for backward-compatible hotfixes

$PackageVersion = "$MajorNumber.$MinorNumber.$PatchNumber"
$PackageName    = "Cmds.Lobby"


Write-Host "`nStep 1: Starting build for $PackageName version $PackageVersion`n" -ForegroundColor White

  $PublishFolder = ".\releases\publish\$PackageName"
  $ReleasePath   = ".\releases\$PackageName.$PackageVersion.zip"

  if (Test-Path -Path $PublishFolder) { Remove-Item -Path $PublishFolder\* -Recurse }

  Copy-Item -Path ..\data -Destination $PublishFolder\data -Recurse
  Copy-Item -Path ..\docs -Destination $PublishFolder\docs -Recurse
  Copy-Item -Path ..\public -Destination $PublishFolder\public -Recurse

  Compress-Archive -Path $PublishFolder\* -DestinationPath $ReleasePath -Force
  
  Remove-Item -Path $PublishFolder -Recurse

  $elapsedTime = $(get-date) - $Now
  Write-Host "`nStep 1: Completed build for $PackageName version $PackageVersion (elapsed time = $($elapsedTime.ToString("mm\:ss")))" -ForegroundColor Blue

  
# exit


Write-Host "`nStep 2: Uploading packages to Octopus...`n" -ForegroundColor White

  $OctoServer = Get-Content -Path d:\temp\secret\cmds-octopus-server.txt -TotalCount 1
  $OctoKey    = Get-Content -Path d:\temp\secret\cmds-octopus-key.txt -TotalCount 1

  Octo push --server=$OctoServer --apiKey=$OctoKey --replace-existing --package=$ReleasePath
 
  $elapsedTime = $(get-date) - $Now
  Write-Host "`nStep 2: Completed upload. Elapsed time = $($ElapsedTime.ToString("mm\:ss"))`n" -ForegroundColor Green