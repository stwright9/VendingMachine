# VendingMachine

This project was programmed on Visual Studio 2017 Community edition using .NET Framework v4.6.1 and windows 7.

Steps to install/Run:
1. Download Visual Studio: https://www.visualstudio.com/vs/features/net-development/
2. Verify: run 'dir %windir%\Microsoft.NET\Framework /AD' to see your .NET versions
   or 
   Download .Net Framework v4.6+ https://www.microsoft.com/net/download/dotnet-framework-runtime
3. Run VendingMachine.sln and Build the project.
4. Run debuging mode with F5 or start the application in your ~\VendingMachine\bin\Debug\VendingMachine.exe directory.

Steps to run unit tests:
1. With the solution open and built run the tests from the top menu option Test>Run>All Tests.
2. This should pop open a Test Explorer menu on the left with the test results.

CLI:
1. Open Developer Command Prompt for VS 2017
2. navigate to your VendingMachineTests\bin\Debug
3. Run 'MSTest /testcontainer:VendingMachineTests.dll'?
