dotnet publish SafeCity/SafeCity.Server/SafeCity.Server.csproj

dotnet publish SafeCity/SafeCity.UI/SafeCity.UI.csproj

mkdir buildArtifacts

xcopy /y /o /e "SafeCity\SafeCity.Server\bin\Debug\netcoreapp3.1\publish" "buildArtifacts\webbApp\"

xcopy /y /o /e "SafeCity\SafeCity.UI\bin\Debug\netcoreapp3.1\publish" "buildArtifacts\webbClient\"