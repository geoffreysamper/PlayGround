ECHO on


set SEN_FILENAME=scenario.ubr
set REPORT_FILENAME=%SEN_FILENAME%Report.xml
set SETTINGS_FILENAME=settings_localhost.ubr

set UBR_PATH=C:\Github\PlayGround\MemoryIssues\tests\wcattests\
set REPORT_FOLDER=%UBR_PATH%results\


set REPORT_PATH=%REPORT_FOLDER%%REPORT_FILENAME%
set SEN_PATH=%UBR_PATH%%SEN_FILENAME%
set SETTINGS_PATH=%UBR_PATH%%SETTINGS_FILENAME%
set CLIENTS=localhost

echo %SETTINGS_PATH%
ECHO %CLIENTS%
echo %REPORT_FOLDER%
ECHO %REPORT_PATH%
ECHO %SEN_PATH%



"C:\Program Files\wcat\wcat.wsf" -run -f %SETTINGS_PATH% -t %SEN_PATH%  -clients %CLIENTS%  -o %REPORT_PATH%  

Pause
