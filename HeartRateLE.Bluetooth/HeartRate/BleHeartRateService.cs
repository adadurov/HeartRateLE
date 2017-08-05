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

using HeartRateLE.Bluetooth.Base;

namespace HeartRateLE.Bluetooth.HeartRate
{
    internal class BleHeartRateService : BleService
    {
        /// <summary>
        /// Heart Rate Measurement characteristic.
        /// </summary>
        public BleCharacteristic HeartRateMeasurement { get; set; } = new BleCharacteristic("Heart Rate Measurement", "2A37", true);

        /// <summary>
        /// Body Sensor Location characteristic.
        /// </summary>
        public BleCharacteristic BodySensorLocation { get; set; } = new BleCharacteristic("Body Sensor Location", "2A38", false);

        /// <summary>
        /// Heart Rate Control Point characteristic.
        /// </summary>
        public BleCharacteristic HeartRateControlPoint { get; set; } = new BleCharacteristic("Heart Rate Control Point", "2A39", false);

        private const bool IsServiceMandatory = true;

        public BleHeartRateService() : base("180D", IsServiceMandatory)
        {
        }
    }
}
