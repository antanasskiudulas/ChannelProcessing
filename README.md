ChannelProcessing Instructions
Running the Application
Usage
To run the ChannelProcessing application, use the following command in your terminal or command prompt:

.\ChannelProcessing.exe

Required Options
The application requires two options to be specified:

-c, --channel: Windows path to the channel file to be processed.
-p, --parameters: Windows path to the parameters file to be applied to channels.

Example Command
.\ChannelProcessing.exe -c "path\to\channel.txt" -p "path\to\parameters.txt"

Error Messages
If the required options are missing, you will see the following error message:

ERROR(S):
  Required option 'c, channel' is missing.
  Required option 'p, parameters' is missing.
  -c, --channel       Required. Windows path to channel file to be processed
  -p, --parameters    Required. Windows path to parameters file to be applied to channels
  --help              Display this help screen.
  --version           Display version information.

Default Behavior
By default, the application will attempt to look for channels.txt and parameters.txt in its binary folder. These files will be zipped and included in the binary folder.

Running the Tests
Prerequisites
To run the tests, you need to have the .NET SDK installed. You can download it from the .NET downloads page.

Running Tests
To run the tests, use the following command in your terminal or command prompt:

dotnet test .\ChannelProcessing.sln
This command will execute all the unit tests in the solution and display the results.