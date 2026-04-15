# Blazor Rich Text Editor — Import/Export & Image Upload (with Auth)

This sample demonstrates importing/exporting HTML with the Syncfusion Blazor Rich Text Editor and shows a simple image-upload flow where the client adds authentication data before uploading.

## Overview

- Import and export HTML content with the Rich Text Editor.
- Send images from the editor to a server endpoint and include custom form data (for example an auth token and user id) before upload.

## Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022+ or VS Code
- Syncfusion Blazor packages (a license may be required)

## Quick setup

```bash
git clone https://github.com/SyncfusionExamples/Blazor-RTE-Import-Export-HTML.git
cd Blazor-RTE-Import-Export-HTML
dotnet restore
dotnet run
```

Or open `RichTextEditor.sln` in Visual Studio and press F5.

## Usage (image upload with auth)

The sample includes an `SfRichTextEditor` configured with `RichTextEditorImageSettings.SaveUrl` and an `OnImageSelected` handler. In `OnImageSelected` the client can add extra form fields before the upload:

- `args.CurrentRequest` is set to a list of objects that become form data for the upload request (e.g. `new { authToken = authToken }, new { userId = "123" }`).
- The server-side upload endpoint can read these form fields and validate the `authToken` before saving the file.

Keep in mind this example uses a static `authToken` string for demonstration — in a real app the token should come from your authentication service.

## Troubleshooting

- If uploads fail, confirm `SaveUrl` points to a reachable server endpoint and CORS is configured if the endpoint is on a different origin.
- Verify the server reads the same field names you send (for example `authToken` / `userId`).
- Check browser console and server logs for error details.

## Support

This sample is provided for demonstration purposes. For issues, open an issue in the repository.

## See also

- [Online examples](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=fluent2)
- [Documentation](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-webapp)
