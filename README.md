# Vidly
Rent Movies Project

# Social Login
To enable this option you have to create a Facebook Developer account and Add a new App to get the appID and appSecret.
Open the file Startup.Auth.cs and supply the information in the follow code:

´´´C#
app.UseFacebookAuthentication(
appId: "",
appSecret: "");
´´´

