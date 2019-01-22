---
title: "Environment Variables"
weight: 2
---

## Environment Variables

If you recall from earlier, Environment Variables are one possible configuration source that we implicitly map to. Knowing this, we're going to add the values for the `NasaSettings` that we considered to be sensitive. Execute the following commands:

```
setx NasaSettings__ApiKey "Pickle Chips" && setx NasaSettings__ApiSecret "s0m3sECRitV@1^*"
```

When you're done doing this, you should have received a message stating that these values were successfully saved.

{{% notice tip %}}
We need to restart __Visual Studio__ in order to pick up these environment variables additions.
{{% /notice %}}

### Debug

Add an `IOptions<NasaSettings> options` parameter to the `ConfigureServices` method. Then start your application with debugging, but first set a __breakpoint__ on line 30. Your application should break - I want you to examine the members of the `options` instance to see that the `appsettings.json` file and the Environment Variables are both correctly mapped.

![Debugging](/4-configuration/environment-variables/images/debug.png?classes=border,shadow)