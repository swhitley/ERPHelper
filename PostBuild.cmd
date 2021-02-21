REM % 1 = Configuration Name
REM % 2 = Platform Name
REM % 3 = Target Path

if not %1 == "Release" goto exit

if %2 == "x86" (
	set dir="C:\Program Files (x86)\Notepad++\plugins\ERPHelper\"
	set file="ERPHelper_x86.zip"
)

if %2 == "x64" (
	set dir="C:\Program Files\Notepad++\plugins\ERPHelper\"
	set file="ERPHelper_x64.zip"
)

if exist %dir% powershell Compress-Archive -Path '%~3' -DestinationPath '%dir:"=%%file:"=%' -Update

if exist %dir% powershell "Get-FileHash '%dir:"=%%file:"=%' | select -expandproperty Hash | select @{n='Hash';e={$_.toLower()}} | Out-File -FilePath '%dir:"=%sha256.txt'"

:exit