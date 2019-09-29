mkdir .\reports
.\packages\OpenCover.4.7.922\tools\OpenCover.Console.exe^
 -register:user^
 -target:".\TicketMachine\bin\Debug\TicketMachine.exe"^
 -mergebyhash^
 -output:.\reports\output.xml
.\packages\ReportGenerator.4.2.20\tools\net47\ReportGenerator.exe^
 -reports:.\reports\output.xml^
 -targetdir:.\reports^
 -sourcedirs:.\TicketMachine