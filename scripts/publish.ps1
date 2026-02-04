<#
Publish script for WindowsScaler project.
Usage:
  .\publish.ps1                 # publish Release, win-x64, framework-dependent
  .\publish.ps1 -Runtime win-x64 -SelfContained  # publish self-contained
#>
param(
    [string]$Configuration = 'Release',
    [string]$Runtime = 'win-x64',
    [switch]$SelfContained
)

$projectPath = "WindowsScaler\WindowsScaler.csproj"
$publishDir = Join-Path -Path "$(Get-Location)" -ChildPath "artifacts\$Runtime"

if (Test-Path $publishDir) {
    Write-Host "Cleaning previous publish output: $publishDir"
    Remove-Item -Recurse -Force $publishDir
}

$sc = $SelfContained.IsPresent ? 'true' : 'false'
Write-Host "Publishing project: $projectPath"
Write-Host "Configuration: $Configuration, Runtime: $Runtime, Self-contained: $sc"

dotnet publish $projectPath -c $Configuration -r $Runtime --self-contained $sc -o $publishDir

if ($LASTEXITCODE -ne 0) {
    Write-Error "dotnet publish failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}

Write-Host "Published to: $publishDir"
Write-Host "Next: build installer with Inno Setup or your chosen packager. See installer/WindowsScalerInstaller.iss"