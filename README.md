 # AGL Coding Challenge

This project has been commenced to submit some code to AGL Coding challenge.
The requirement is to write some code to consume the json result from API, and output a list of all the cats in alphabetical order under a heading of the gender of their owner.

The programming language is open to a developer, so I choosed technologies below to demonstrate my experience and knowledge with those techonologies.

* Approach: Onion Architecture for unit test friendly, easy to extend with it's loos coupling, and cross cutting concerns.
* Language: .net framework 4 with MVC 5 Web Application model along with jquery 3, plus Unity for Dependency Injection
* IDE: Visual Studio Enterprise 2017
* Unit Test: Visual Studio Testing Framework
* Deployment: Azure App Service
* Monitoring/Logging: Azure Application Insights


## Getting Started

Open solution file with Visual Studio Enterprise 2017.

### Nuget Packages Required

Add below from Nuget Package Manager to Build this project
* jQuery v3.3.1
* Microsoft.ApplicationInsights v2.5.0
* Microsoft.AspNet.Mvc v5.2.3
* Microsoft.AspNet.Razor v3.2.3
* Microsoft.AspNet.WebPage v3.2.3
* Microsoft.CodeDom.Provider.DotNetComplerPlatform v1.0.8
* Microsoft.Net.Compilers v2.6.1
* Microsoft.Web.Infrastructure v1.0.0
* Newtonsoft_Json 10.0.3
* System.Diagnostics.DiagnosticSource v4.4.0
* System.Net.Http v4.3.3
* System.Security.Cryptography.Algorithms v4.3.1
* System.Security.Cryptography.Encoding v4.3.0
* System.Security.Cryptography.Primitives v4.3.0
* System.Security.Cryptography.X509Certificates v4.3.2
* Unity v5.5.8
* Unity.Abstractions v3.1.3
* Unity.Container v5.5.8
* Unity.Nvc v5.0.12
* WebActivatorEx v2.2.0

### Logging and Monitoring

If you want to set up error logging and availability monitoring in Azure, you need to setup your own Application Insights on your own subscription.
If you do not want to set up for now, you can ignore.

#### Prerequisites

You need Azure Cloud Subscription.

```
New --> Search Application Insights --> Create Application Insights --> fill up information --> hit Create button 
```

Once Application Insights is created, 

```
Properties --> INSTRUMENTATION KEY --> Copy to notepad
```

Now set this key in the project

```
..\petowners\petowners\web.config --> <configuration> --> <appSettings> --> Update Value of TelemetryKey
```

## Running the tests

Unit Tests are set up using Visual Studio Testing Framework.
Here's how to run unit test.
```
Test --> Run --> All Tests
```

Or you can set live unit testing
```
Test --> Live Unit Testing --> Start
```

## Deployment

You can access output page here --> http://petownermvc.azurewebsites.net/

Website is set up in Azure subscription.
Deployment for your own copied project is up to you.

## Code Management

GitHub

## 

## Authors

Akiko Hosonuma

## Copyright

This project is under Copyright @ Akiko Hosonuma 2018

