Uploading CSV files using Entity Framework

Stack

- MVC Asp.Net Application;
- Entity Framework;
- UnityMVC (Dependency injection into controllers);
- C#,HTML, CSS and JavaScript;
- MS SqlServer Express;
- Visual Studio 2017 (.Net Framework 4.6);

Setup

- Update NuGet Packages if it is applicable;
- Web Application - Web.Config
	Set your connectionString as following:
	<connectionStrings>
      <add name="SalesDBContext" connectionString="Data Source=YOURDATASOURCE;Initial Catalog=Sales;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
    </connectionStrings>
	
- Unittest Application - App.config
	Set your connectionString as following:
	<connectionStrings>
      <add name="DefaultConnection" connectionString="Data Source=YOURDATASOURCE;Initial Catalog=Sales;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
    </connectionStrings>
	