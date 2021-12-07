// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Device.Spi;
using System.Threading;
using Iot.Device.St7735;

Console.WriteLine("Hello, World!");

var spiSettings = new SpiConnectionSettings(0, 1);
spiSettings.ClockFrequency = 10_000_000;

var spiBus = SpiDevice.Create(spiSettings); // Ft4222Spi(new SpiConnectionSettings(0, 1) { ClockFrequency = 1_000_000, Mode = SpiMode.Mode0 });

var lcd = new PimoroniOled(spiBus, 9);

var randomNumber = new Random();
var whiteRectangleBuffer = new byte[10 * 10];
for (int i = 0; i < 10 * 10; i++)
{
    whiteRectangleBuffer[i] = 0xFF;
}

while (true)
{
    Thread.Sleep(10);

    var randomX = randomNumber.Next(lcd.ActualWidth - 10);
    var randomY = randomNumber.Next(lcd.ActualHeight - 10);

    lcd.SetRegion(randomX, randomY, 10, 10);
    lcd.SendBitmap(whiteRectangleBuffer);
}
