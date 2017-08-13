/******************************************************************************
The MIT License (MIT)

Copyright (c) 2016 Matchbox Mobile Limited <info@matchboxmobile.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*******************************************************************************/

// This file was generated by Bluetooth (R) Developer Studio on 2016.03.17 21:39
// with plugin Windows 10 UWP Client (version 1.0.0 released on 2016.03.16).
// Plugin developed by Matchbox Mobile Limited.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using HeartRateLE.Bluetooth.Base;

namespace HeartRateLE.Bluetooth.HeartRate
{
    internal class BleHeartRate : BleDevice
    {
        private static readonly string[] RequiredServices = new string[] { "180D", "180A", "180F" };
        public BleHeartRateService HeartRate { get; set; } = new BleHeartRateService();
        public BleDeviceInformationService DeviceInformation { get; set; } = new BleDeviceInformationService();
        public BleBatteryServiceService BatteryService { get; set; } = new BleBatteryServiceService();


        /// <summary>
        /// Search and returns all Bluetooth Smart devices matching BleHeartRate profile
        /// </summary>
        /// <returns>List<BleHeartRate> list with all devices matching our device; empty list if there is no device matching</returns>
        public static async Task<List<BleHeartRate>> FindAll()
        {
            List<BleHeartRate> result = new List<BleHeartRate>();
            // get all BT LE devices
            var all = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(BluetoothLEDevice.GetDeviceSelector());
            BluetoothLEDevice leDevice = null;

            foreach (var device in all)
            {
                try
                {
                    leDevice = await BluetoothLEDevice.FromIdAsync(device.Id);
                }
                catch
                {
                    leDevice = null;
                }

                if (leDevice == null)
                    continue;

                bool matches = true;
                foreach (var requiredService in RequiredServices)
                {
                    matches = CheckForCompatibility(leDevice, requiredService.ToGuid());
                    if (!matches)
                        break;
                }

                if (!matches)
                    continue;

                var toAdd = new BleHeartRate(device, leDevice);
                toAdd.Initialize();
                result.Add(toAdd);
            }

            return result;
        }

        /// <summary>
        /// Search and returns first Bluetooth Smart device matching BleHeartRate profile
        /// </summary>
        /// <returns>first BleHeartRate device; null if there is no device matching</returns>
        public static async Task<BleHeartRate> FirstOrDefault()
        {
            var all = await FindAll();
            return all.FirstOrDefault();
        }

        public static async Task<BleHeartRate> FindByName(string deviceName)
        {
            var all = await FindAll();
            return all.FirstOrDefault(a => a.Name.Equals(deviceName, StringComparison.InvariantCultureIgnoreCase));
        }

        private BleHeartRate(DeviceInformation device, BluetoothLEDevice leDevice) : base(device, leDevice)
        {
            RegisterNewService(HeartRate);
            RegisterNewService(DeviceInformation);
            RegisterNewService(BatteryService);
        }
    }
}
