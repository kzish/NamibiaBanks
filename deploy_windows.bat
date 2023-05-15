git stash
git pull origin
dotnet publish WindoekBank --configuration Release --output "C:\\inetpub\\wwwroot\\AmadeusSol\\NamibiaBanks\\WindoekBank"
dotnet publish StandardBank --configuration Release --output "C:\\inetpub\\wwwroot\\AmadeusSol\\NamibiaBanks\\StandardBank"
dotnet publish NedBank --configuration Release --output "C:\\inetpub\\wwwroot\\AmadeusSol\\NamibiaBanks\\NedBank"
dotnet publish Fnb --configuration Release --output "C:\\inetpub\\wwwroot\\AmadeusSol\\NamibiaBanks\\Fnb"

::on windows run this in iis
::dotnet "C:\\inetpub\\wwwroot\\WiseOwlVisionAndComplianceAdmin\\Admin.dll" --urls http://0.0.0.0:1003
::dotnet "C:\\inetpub\\wwwroot\\WiseOwlVisionAndComplianceApi\\Api.dll" --urls http://0.0.0.0:1004


pause
