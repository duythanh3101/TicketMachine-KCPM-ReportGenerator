.\packages\OpenCover.4.7.922\tools\OpenCover.Console.exe^
 -output:"coverage.xml"^
 -target:"unit_test.bat"^
 -filter:"+[*]* -[nunit.framework*]*"^
 -register:user
.\packages\ReportGenerator.4.2.20\tools\net47\ReportGenerator.exe^
 -reports:"coverage.xml"^
 -targetdir:".\coverage"^
 
