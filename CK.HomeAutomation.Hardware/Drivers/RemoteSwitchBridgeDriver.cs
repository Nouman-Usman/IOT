﻿using System;
using CK.HomeAutomation.Hardware.RemoteSwitch;

namespace CK.HomeAutomation.Hardware.Drivers
{
    public class RemoteSwitchBridgeDriver
    {
        private readonly I2CBus _i2CBus;
        private readonly int _address;

        public RemoteSwitchBridgeDriver(I2CBus i2CBus, int address)
        {
            if (i2CBus == null) throw new ArgumentNullException(nameof(i2CBus));

            _i2CBus = i2CBus;
            _address = address;
        }

        public void Send(RemoteSwitchCode code)
        {
            var codeBuffer = BitConverter.GetBytes(code.Code);

            var package = new byte[6];
            package[0] = 2; // Action "send 433Mhz signal"
            Array.Copy(codeBuffer, 0, package, 1, 4); // The code.
            package[5] = (byte)code.Length; // The length.

            _i2CBus.Execute(_address, bus => bus.Write(package), false);
        }
    }
}
