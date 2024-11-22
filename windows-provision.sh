Set-ExecutionPolicy Bypass -Scope Process -Force
[System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072
iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
choco install dotnet-8.0-sdk -y
refreshenv
dotnet nuget add source http://10.0.2.2:5555/v3/index.json -n MyLocalRepo
dotnet tool install --global EVytvytskyi --version 1.0.0
dotnet --version
cd C:\lab
dotnet run help