using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OpenCvTestingTool
{
    public class PerformanceMonitor
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private PerformanceCounter gpuCounter;

        private float cpuUsage; // Smoothed CPU usage value
        private const int MovingAveragePeriod = 5; // Number of samples to consider for the moving average

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long totalMemoryInKilobytes);

        public PerformanceMonitor()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

            // Create a custom category and counter name for GPU usage
            var gpuCategoryName = "GPU";
            var gpuCounterName = "3D Graphics Busy";

            if (PerformanceCounterCategory.Exists(gpuCategoryName))
            {
                gpuCounter = new PerformanceCounter(gpuCategoryName, gpuCounterName);
            }
            else
            {
                Console.WriteLine("GPU performance counters are not available on this system.");
            }
        }

        public float GetCpuUsage()
        {
            float rawCpuUsage = cpuCounter.NextValue();
            cpuUsage = CalculateMovingAverage(rawCpuUsage);
            return cpuUsage;
        }

        public float GetRamUsage()
        {
            return ramCounter.NextValue();
        }

        public float GetGpuUsage()
        {
            return gpuCounter?.NextValue() ?? 0f;
        }

        private float[] cpuUsageSamples = new float[MovingAveragePeriod];
        private int sampleIndex = 0;

        private float CalculateMovingAverage(float newValue)
        {
            cpuUsageSamples[sampleIndex] = newValue;
            sampleIndex = (sampleIndex + 1) % MovingAveragePeriod;

            float average = 0;
            for (int i = 0; i < MovingAveragePeriod; i++)
            {
                average += cpuUsageSamples[i];
            }
            average /= MovingAveragePeriod;

            return average;
        }
    }
}
