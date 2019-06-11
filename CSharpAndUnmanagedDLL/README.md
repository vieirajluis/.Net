C# and Unmanaged Code

-C++ DLL called from C#

------------------------------Unmanaged C++ DLL:------------------------------------- 

1- Create an Empty Project - Set is a DLL (Project Properties->General->Project Defaults->Configuration Type=DLL)
2- Project Properties -> C/C++ -> Preprocessor -> Add a Custom Macro (this example is using UNMANAGED_EXPORTS)
3- Create a global file (*.h), and set the EXPORT TAGS from the above MACRO;
    
    #ifndef UNMANAGED_GLOBAL_H
    #define UNMANAGED_GLOBAL_H

    #ifdef UNMANAGED_EXPORTS
    # define UNMANAGED_EXPORTDLL extern "C" __declspec( dllexport )
    #else
    # define UNMANAGED_EXPORTDLL extern "C" __declspec( dllimport )
    #endif
    #endif
    
4- Include the global file on your Source Files (*.cpp) that you want to export;
   Set your method's signature with the Export TAG;
   UNMANAGED_EXPORTDLL int doSomething()
   {
	   return something;
   }
   
5- Build and Deploy the generated (*.dll) file on the Caller Application compiled folder together with it’s (*.exe) file;

---------------------------Managed C#:-------------------------------------------------

1- Create a Windows Form Application;
2- Call your Unmanaged DLL;
    
    [DllImport("UnmanagedDll.dll",  CallingConvention = CallingConvention.Cdecl)]
    public static extern int doSomething();
