using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
namespace ReadingDataSerialPort
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
       
        public static void Main()
        {
            try
            {
                RegistryKey rkApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rkApp.SetValue("ReadingDataSerialPort", Assembly.GetExecutingAssembly().Location);
            }
            catch (Exception)
            {
                /*
105 cm-s01
103 cm-s02
199 cm-s01
103 cm-s02
                 */

            }
            SerialPort _serialPort;
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";//Set your board COM
            _serialPort.BaudRate = 9600;
            if (!_serialPort.IsOpen)
                _serialPort.Open();
            List<string> sensor01Readings = new List<string>();
            List<string> sensor02Readings = new List<string>();
            while (true)
            {
               
                string a = _serialPort.ReadLine();
                Console.WriteLine(a);
                if(!a.Contains("Out of range")) { 
                   if (a.Contains("s01"))
                    sensor01Readings.Add(a.Split(' ')[0]);
                if (a.Contains("s02"))
                    sensor02Readings.Add(a.Split(' ')[0]);
            }
                if (sensor01Readings.Count == sensor02Readings.Count  && sensor02Readings.Count == 1)
                {
                    string valuesPart = "firstSensorId=1&" + "firstSensorValue="+sensor01Readings[0]+
                        "&secondSensorId=2&"+ "secondSensorValue=" + sensor02Readings[0];
                    CallApiGetRequest.MakeHttpRequest(valuesPart);
                    sensor01Readings = new List<string>();
                    sensor02Readings = new List<string>();
                }
                if ((sensor01Readings.Count > sensor02Readings.Count && sensor01Readings.Count - sensor02Readings.Count >=2)
                    || (sensor01Readings.Count < sensor02Readings.Count && sensor02Readings.Count - sensor01Readings.Count >= 2))
                {
                    sensor01Readings = new List<string>();
                    sensor02Readings = new List<string>();
                }
                a = "";
                Thread.Sleep(2000);
            }
        }
    }
}