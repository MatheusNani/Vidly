# Vidly
Rent Movies Project usign MVC5, WEBAPI and EF6

## Social Login
To enable this option you have to create a Facebook Developer account and Add a new App to get the appID and appSecret.
Open the file Startup.Auth.cs and supply the information in code that follows:

app.UseFacebookAuthentication(appId: "", appSecret: "");
