Single Page Application - Building on Azure Microservices - Windows Platform

1- Environment Setup
	1.1 Install Visual Studio 2017 Community (*Will restore .Net and NPM dependencies automatic);
	1.2 Install Visual Studio Code;
	1.3 Install Node.js version 6 or later;
	1.4 Install Single Page Application (SPA) templates;
		dotnet new --install Microsoft.AspNetCore.SpaTemplates::* //or
		dotnet new --install Microsoft.DotNetCore.SpaTemplates*
		
2- Generate Project
	2.1 Create an empty directory for it to go into, cd to that	directory, and then use dotnet new to create your project;
		dotnet new angular //or
		dotnet new angular -n YOUR PROJECT NAME
	2.2 Navigate to your project folder and execute the following commands:
	    dotnet restore 
		npm install
		(**Visual Studio 2017 will do it automatic on Building time)
		
3- Running Application
	3.1 If you’re on Windows and want to use Visual Studio 2017 RC, you can simply open your newly-generated .csproj file in Visual Studio. 
		It will take care of restoring the .NET and NPM dependencies for you (though it can take a few minutes). When your dependencies are restored, 
		just press Ctrl+F5 to launch the application in a browser as usual;
		
	3.2 If you’re using cmd.exe in Windows, execute setx ASPNETCORE_ENVIRONMENT "Development", and then restart your command prompt to make the change take effect:
		dotnet run.
		
4- Publishing to Azure
	4.1 Sign in to an Azure Free Account;
	4.2 From Visual Studio: Right click on your project -> Select Publish to Azure and Create New App Service:
	4.3 Set the App Name; Set Subscription (Your Azure Account); Set Resource Group; Set Hosting Plan;
	4.4 Press Create;
	4.5 Copy Site URL, and check it on your browser;
	
		
		
	

