Write-Host -ForegroundColor Cyan "Running Net45 tests..."
.\tools\Cake\Cake.exe test.net45.cake

Write-Host -ForegroundColor Cyan "`nRunning NetStandard1.6 tests..."
dotnet exec .\tools\Cake.CoreCLR\Cake.dll test.netstandard16.cake