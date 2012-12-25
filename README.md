# Box C# SDK (API v2) OAuth2 Sample (MVC)

An MVC-based demonstration for Box's OAuth implementation in the v2 API.  This is based on the [Box C# SDK (API v2)](https://github.com/jhoerr/box-csharp-sdk-v2).

## License

[Creative Commons Attribution 3.0 Unported License](http://creativecommons.org/licenses/by/3.0/)

## NuGet

This project is available as a [NuGet package](https://nuget.org/packages/Box.v2.SDK.Sample.Oauth2).  

## Usage

You can run this project as-is or integrate it into an existing MVC application with the [NuGet package](https://nuget.org/packages/Box.v2.SDK.Sample.Oauth2).

Part of the OAuth2 workflow involves an HTTPS redirect from Box's site to the one you'll be running here. An HTTPS URL for your site *must* be pre-registered with Box in order for everything to work. (This pre-registration is done in order to prevent rogue redirects.) Visual Studio 
doesn't enable SSL by default, so there are a few manual steps required to make it all work.

### Enable SSL connections in your project

1.  In the Solution Explorer, left-click on the MVC project to select it.
2.  Press F4 to bring up the project's Properties.
3.  Change 'SSL Enabled' from False to True.  The SSL URL field should be 
    automatically populated.
4.  Copy the SSL URL to the clipboard.

### Configure your project to start with the SSL URL

5.  Now right-click on the project name and select 'Properties'
6.  Click the 'Web' tab
7.  In the 'Servers' section find the text box labeled 'Project Url'
8.  Paste the SSL URL into this text box and save the changes.

### Configure your Box application to redirect to the SSL URL

9.  Browse to http://developers.box.com
10.  Click on "My Box Apps" on the upper right; log in.1
11.  Edit the application that you want to work with.
12.  Under 'OAuth2 Parameters' locate the 'redirect\_uri' field.
13.  Paste the SSL URL into this field.  Save your changes.

This configures your app to use SSL and tells Box to redirect you back to this HTTPS site after you've authenticated and agreed to let your application access your Box data.
