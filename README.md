# XD HAX aspnetcore Xero Alexa Hack

I have already entered XDHAX with TaxOptimiser which is a way more complex project but I gave myself one morning to create an Xero Alexa Mashup in one morning. Therefore the scope is relatively limited. 
I will have a video soon on how I developed it.
  
### Other Examples Tech

Jordan Walsh from Xero has created a starter project with connections via oAuth

* [NodeAlexaXeroSample](https://github.com/XeroAPI/xdhax-alexa-sample) - There is a node sample app by Jordan Walsh


### Installation

Change the appsettings file and then publish to Azure. Create a relevant skill as per the video.

```cs
 public class AppSettings
    {
        public string Uri = "https://api.xero.com/api.xro/2.0/";
        public string SigningCertificatePath = @"";
        public string Key = "";
        public string Secret = "";
        public string SigningCertificatePassword = "";
    }
```
In production I would never store the results like this and would hold them in managed secrets


### Limitations

It is currently limited to a Xero private app to save time on development.

