# Cake AddIns
## Cake.Path

A Cake AddIn that extends Cake with the ability to add items to the PATH.

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)


### Usage

```csharp
#addin "Cake.Path"

...

Task("AddToPath")
    .Does(() => 
    {
        AddToPath("C:\\Python27\\");
    });

```

# General Notes
**This is an initial version and not tested thoroughly**.

I've made these AddIns for use in my own cake scripts so they have only really been tested on Windows.
