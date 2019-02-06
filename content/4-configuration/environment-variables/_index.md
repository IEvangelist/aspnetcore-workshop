---
title: "Environment Variables"
weight: 2
---

## <i class="far fa-hdd"></i> Environment Variables

If you recall from earlier, Environment Variables are one possible configuration source that we implicitly map to. Knowing this, we're going to add the values for the `BrewerySettings` that we considered to be sensitive.

But first, <a href='https://www.brewerydb.com/signup' target='_blank'>we need to sign up</a> for the __BreweryDB__ service and a free API key. When you create an account, navigate to the <a href='https://www.brewerydb.com/developers/apps#' target='_blank'>__Developers > My API Keys__</a>. You will need the listed __Sandbox API Keys__.

 1. Verify that the _Sandbox URL_ matches the corresponding `appsettings.json` node
 2. Use the _Sandbox Key_ for the following command argument 

![Sandbox API Key](/4-configuration/environment-variables/images/sandbox.png?classes=shadow,border)

Execute the following command:

```
setx BrewerySettings__ApiKey "Sandbox API"
```

When you're done doing this, you should have received a message stating that these values were successfully saved.

{{% notice tip %}}
We need to restart __Visual Studio__ in order to pick up these environment variables additions.
{{% /notice %}}