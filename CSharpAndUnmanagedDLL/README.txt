C# and Unmanaged Code

-C++ DLL called from C#

Unmanaged C++ DLL: 

1- Create an Empty Project - Set is a DLL (Project Properties->General->Project Defaults->Configuration Type=DLL)
2- Project Properties -> C/C++ -> Preprocessor -> Add a Custom Macro (this example is using UNMANAGED_EXPORTS)
3- Create a global file, and set the EXPORT TAGS from the above MACRO;
4- Include the global file on your Source Files that you want to export;
5- Build and Deploy the generated (*.dll) file with the Caller Application (*.exe);

Managed C#:

1- Create a Windows Form Application;
2- Call your Unmanaged DLL;
