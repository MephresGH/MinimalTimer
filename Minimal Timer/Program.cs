//LIBRARY
using System;
using System.Runtime.InteropServices;
using System.Threading;

//FUNCTIONS
class Timer
{
[DllImport("ntdll.dll", SetLastError=true)]
public static extern int NtSetTimerResolution(uint DesiredResolution, bool SetResolution, out uint CurrentResolution);

	static void Main()
	{
	uint CurrentResolution=5000;
	uint MaximumResolution=0;
	bool SetResolution=true;
	uint DesiredResolution=MaximumResolution;
	NtSetTimerResolution(DesiredResolution, SetResolution, out CurrentResolution);
	Console.Title = "Minimal Multimedia Timer";
	Console.WriteLine("C# Minimal Multimedia Timer Application 1.0, Copyright @ 2022 Mephres\n");
	Console.WriteLine("The current timer has been set to 0.{0}ms. Default/minimum timer = 15.625ms. Maximum timer = 0.5ms.", CurrentResolution);
	Console.WriteLine("Close the application to reset the timer to default value.");
	Thread.Sleep(Timeout.Infinite);
	}
}