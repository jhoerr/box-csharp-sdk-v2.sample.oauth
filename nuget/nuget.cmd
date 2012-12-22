%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe ..\..\BoxApiV2.sln /t:Clean,Rebuild /p:Configuration=Release /fileLogger

rd /s /q packages

mkdir packages\content\Controllers
mkdir packages\content\Models
mkdir packages\content\Views

xcopy ..\..\BoxApi.V2.Samples.WebAuthentication.MVC\Controllers packages\content\Controllers /e /y
xcopy ..\..\BoxApi.V2.Samples.WebAuthentication.MVC\Models packages\content\Models /e /y
xcopy ..\..\BoxApi.V2.Samples.WebAuthentication.MVC\Views packages\content\Views /e /y
xcopy ..\..\BoxApi.V2.Samples.WebAuthentication.MVC\readme.txt packages /y

move packages\content\Controllers\HomeController.cs packages\content\Controllers\HomeController.cs.pp
move packages\content\Models\ErrorModel.cs packages\content\Models\ErrorModel.cs.pp

powershell -File preprocess.ps1

nuget.exe update -self
nuget.exe pack Package.nuspec -BasePath packages
