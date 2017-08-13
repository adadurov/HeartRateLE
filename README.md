# Bluetooth LE Heart Rate Device Monitor sample

This repo contains an example of using the WinRT api to pair and connect to Bluetooth LE heart rate devices. The point of 
this sample is to show how its possible to reference and utilize WinRT apis without having to write a UWP application. The
client can be any windows client that can reference a C# library (i.e. windows forms, wpf, etc)

> **Note:** This sample consists of a Visual Studio 2015 solution with C# projects.
> The UI project is a WPF application. 
> The Bluetooth project has a class wrapper for WinRT code (HeartRateMonitor) so that the client calling the library does not have to 
> know about UWP objects or coding. The client only has to instantiate basic classes and schemas and attach event handlers to
> the class. 
> This sample makes use of another Library available in Nuget and Github called "UWP for Desktop". This provides the hooks to call
> the WinRT api without having to use a UWP application. https://github.com/ljw1004/uwp-desktop

Specifically, this sample shows how to:

- Enumerate nearby Bluetooth LE devices
- Query for supported services
- Query for supported characteristics
- Interogate device for information
- Subscribe to device events such as connection status changed and value changed
