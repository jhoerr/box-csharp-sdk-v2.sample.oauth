Thanks for trying out the Box SDK for the v2 API!

This sample site will provide you with a working example of how to get 
through the Box OAuth2 authentication flow.

*************************************************
* KEEP READING; YOU MUST DO A FEW THINGS FIRST! *
*************************************************

Part of the OAuth2 workflow involves an HTTP redirect from Box's site to the 
one you'll be running here. The URL of *this* demo site *must* be registered with 
Box in order for everything to work. (This pre-registration is done in order 
to prevent rogue redirects; it's part of the OAuth2 spec.)

1. In the Solution Explorer, click on this project.
2. Press F4 to bring up the project's Properties.
3. Change 'SSL Enabled' from False to True.  The SSL URL field should be 
   automatically populated.
4. Copy the SSL URL to the clipboard.
5. Browse to http://developers.box.com
6. Click on "My Box Apps" on the upper right; log in.
7. Edit the application that you want to work with.
8. Under 'OAuth2 Parameters' locate the 'redirect_uri' field.
9. Paste the SSL URL into this field.  Save your changes.

This tells Box to redirect you back to this site after you've authenticated 
and agreed to let your application access your Box data.

Ok, that's it -- everything should be ready to go now.  You might want to 
keep the browser window open that contains your Box application's Client
ID and Client Secret; you'll need those in a moment.

Press F5 to get started!




