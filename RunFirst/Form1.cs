using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Management;
using System.Diagnostics;

namespace RunFirst
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        //show console
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            GetCpuInfo();
            GetGpuInfo();
            GetMotherboardInfo();
            GetMemoryInfo();
            GetDriveInfo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void GetCpuInfo()
        {
            try
            {
                // Create a ManagementObjectSearcher object to query WMI
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");

                // Execute the query and get the results
                foreach (ManagementObject obj in searcher.Get())
                {
                    // Get CPU Name
                    string name = obj["Name"]?.ToString();

                    // Get CPU Cores
                    uint numberOfCores = (uint)obj["NumberOfCores"];

                    // Get CPU Threads
                    uint numberOfLogicalProcessors = (uint)obj["NumberOfLogicalProcessors"];

                    // Get CPU Speed in MHz
                    uint maxClockSpeed = (uint)obj["MaxClockSpeed"];
                    textBox1.Text = textBox1.Text + "CPU Name: " + name + "\r\n";
                    textBox1.Text = textBox1.Text + "Number of Cores: " + numberOfCores + "\r\n";
                    textBox1.Text = textBox1.Text + "Number of Threads: " + numberOfLogicalProcessors + "\r\n";
                    textBox1.Text = textBox1.Text + "Max Clock Speed: " + maxClockSpeed + "\r\n";

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void GetGpuInfo()
        {
            try
            {
                // Create a ManagementObjectSearcher object to query WMI
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_VideoController");

                // Execute the query and get the results
                foreach (ManagementObject obj in searcher.Get())
                {
                    // Get GPU Name
                    string name = obj["Name"]?.ToString();

                    // Get GPU Adapter RAM in bytes
                    uint adapterRAM = (uint)obj["AdapterRAM"];
                    double adapterRAMMB = adapterRAM / (1024.0 * 1024.0); // Convert bytes to megabytes

                    // Get GPU Driver Version
                    string driverVersion = obj["DriverVersion"]?.ToString();

                    // Get GPU Video Processor
                    string videoProcessor = obj["VideoProcessor"]?.ToString();

                    textBox1.Text += $"\r\nGPU Name: {name}\r\n";
                    textBox1.Text += $"Adapter RAM: {adapterRAMMB:F2} MB\r\n";
                    textBox1.Text += $"Driver Version: {driverVersion}\r\n";
                    textBox1.Text += $"Video Processor: {videoProcessor}\r\n";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void GetMemoryInfo()
        {
            try
            {

                int i = 0;
                // Create a ManagementObjectSearcher object to query WMI for physical memory
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PhysicalMemory");

                // Execute the query and get the results
                foreach (ManagementObject obj in searcher.Get())
                {
                    i++;
                    // Get memory capacity in bytes
                    ulong capacity = (ulong)obj["Capacity"];
                    double capacityGB = capacity / (1024.0 * 1024.0 * 1024.0); // Convert bytes to gigabytes

                    // Get memory speed
                    uint speed = (uint)obj["Speed"];

                    // Get memory manufacturer
                    string manufacturer = obj["Manufacturer"]?.ToString();

                    // Get memory part number
                    string partNumber = obj["PartNumber"]?.ToString();

                    textBox1.Text += $"Memory {i}:\r\n"; // Memory number
                    // Update the TextBox with memory information
                    textBox1.Text += $"Memory Capacity: {capacityGB:F2} GB\r\n";
                    textBox1.Text += $"Memory Speed: {speed} MHz\r\n";
                    textBox1.Text += $"Manufacturer: {manufacturer}\r\n";
                    textBox1.Text += $"Part Number: {partNumber}\r\n";
                    textBox1.Text += "\r\n"; // New line for better readability
                }
            }
            catch (Exception ex)
            {
                textBox1.Text += "An error occurred while retrieving memory information: " + ex.Message + "\r\n";
            }
        }

        private void GetMotherboardInfo()
        {
            try
            {
                // Create a ManagementObjectSearcher object to query WMI for motherboard information
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_BaseBoard");

                // Execute the query and get the results
                foreach (ManagementObject obj in searcher.Get())
                {
                    // Get motherboard manufacturer
                    string manufacturer = obj["Manufacturer"]?.ToString();

                    // Get motherboard model
                    string product = obj["Product"]?.ToString();

                    // Get motherboard version
                    string version = obj["Version"]?.ToString();

                    // Update the TextBox with motherboard information
                    textBox1.Text += $"\r\nMotherboard Manufacturer: {manufacturer}\r\n";
                    textBox1.Text += $"Motherboard Model: {product}\r\n";
                    textBox1.Text += $"Motherboard Version: {version}\r\n";
                    textBox1.Text += "\r\n"; // New line for better readability
                }
            }
            catch (Exception ex)
            {
                textBox1.Text += "An error occurred while retrieving motherboard information: " + ex.Message + "\r\n";
            }
        }
        static async Task SendMessageToDiscord(string webhookUrl, string message)
        {
            var payload = new
            {
                content = message
            };

            var jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(webhookUrl, content);
                response.EnsureSuccessStatusCode(); // Throws an exception if the HTTP response status is an error
                Console.WriteLine("Message sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }
        private void GetDriveInfo()
        {
            try
            {
                int i = 0;
                // Create a ManagementObjectSearcher object to query WMI for disk drive information
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");

                // Execute the query and get the results
                foreach (ManagementObject obj in searcher.Get())
                {
                    i++;
                    // Get device ID
                    string deviceID = obj["DeviceID"]?.ToString();

                    // Get model
                    string model = obj["Model"]?.ToString();

                    // Get size in bytes
                    ulong size = (ulong)obj["Size"];
                    double sizeGB = size / (1024.0 * 1024.0 * 1024.0); // Convert bytes to gigabytes

                    // Get interface type
                    string interfaceType = obj["InterfaceType"]?.ToString();
                    textBox1.Text += $"Drive {i}:\r\n"; // Drive number
                    // Update the TextBox with drive information
                    textBox1.Text += $"Device ID: {deviceID}\r\n";
                    textBox1.Text += $"Model: {model}\r\n";
                    textBox1.Text += $"Size: {sizeGB:F2} GB\r\n";
                    textBox1.Text += $"Interface Type: {interfaceType}\r\n";
                    textBox1.Text += "\r\n"; // New line for better readability
                }
            }
            catch (Exception ex)
            {
                textBox1.Text += "An error occurred while retrieving drive information: " + ex.Message + "\r\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // copy text to clipboard
            Clipboard.SetText(textBox1.Text);
            //message popup
            MessageBox.Show("Copied to clipboard");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Run Malwarebytes
            // Check if it's installed first
            if (File.Exists("C:\\Program Files\\Malwarebytes\\Anti-Malware\\mbam.exe"))
            {
                System.Diagnostics.Process.Start("C:\\Program Files\\Malwarebytes\\Anti-Malware\\mbam.exe");
            }
            else
            {
                // Popup
                MessageBox.Show("Malwarebytes not installed");
                // Open browser to download
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://www.malwarebytes.com/mwb-download/thankyou/",
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //wait second
            // scan for corrupted files
            var processInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c sfc /scannow");
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = false;
            System.Diagnostics.Process.Start(processInfo);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // open driver site depending on the manufacturer of the GPU
            // Check if it's installed first and get the manufacturer
            string manufacturer = "";
            try
            {
                // Create a ManagementObjectSearcher object to query WMI for GPU information
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_VideoController");

                // Execute the query and get the results
                foreach (ManagementObject obj in searcher.Get())
                {
                    // Get GPU Manufacturer
                    manufacturer = obj["AdapterCompatibility"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            // Open browser to download
            if (manufacturer == "NVIDIA")
            {
                // attempt to run the geforce experience 
                if (File.Exists("C:\\Program Files\\NVIDIA Corporation\\NVIDIA GeForce Experience\\GfExperience.exe"))
                {
                    System.Diagnostics.Process.Start("C:\\Program Files\\NVIDIA Corporation\\NVIDIA GeForce Experience\\GfExperience.exe");
                    MessageBox.Show("the new nvidia app is better :)");
                }
                else
                {
                    // check if they have the new nivdia app installed  C:\Program Files\NVIDIA Corporation\NVIDIA app\CEF\NVIDIA App.exe#
                    if (File.Exists("C:\\Program Files\\NVIDIA Corporation\\NVIDIA app\\CEF\\NVIDIA App.exe"))
                    {
                        System.Diagnostics.Process.Start("C:\\Program Files\\NVIDIA Corporation\\NVIDIA app\\CEF\\NVIDIA App.exe");
                    }
                    else
                    {
                        // Open browser to download
                        var psi = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "https://www.nvidia.com/Download/index.aspx",
                            UseShellExecute = true
                        };
                        System.Diagnostics.Process.Start(psi);
                        MessageBox.Show("NVIDIA driver not found. Download from the site");
                    }


                }

            }
            else if (manufacturer == "AMD")
            {
                // open adrenalin

                if (File.Exists("C:\\Program Files\\AMD\\CNext\\CNext\\RadeonSettings.exe"))
                {
                    System.Diagnostics.Process.Start("C:\\Program Files\\AMD\\CNext\\CNext\\RadeonSettings.exe");
                }
                else
                {
                    // Open browser to download
                    var psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "https://www.amd.com/en/support",
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(psi);
                    MessageBox.Show("AMD driver not found. idk i dont own an amd gpu so use the site :)");
                }
            }
            else
            {
                MessageBox.Show("GPU manufacturer not found");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //open settings to update windows

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("ms-settings:windowsupdate")
                {
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        //make a fuction that scans the device and give some recommendations
        private void sd()
        {
            string message = "\n";
            //scan the device and give some recommendations
            //check disk space left on c drive
            DriveInfo cDrive = new DriveInfo("C");
            double freeSpace = cDrive.TotalFreeSpace / (1024.0 * 1024.0 * 1024.0); // Convert bytes to gigabytes
            double totalSpace = cDrive.TotalSize / (1024.0 * 1024.0 * 1024.0); // Convert bytes to gigabytes
            double usedSpace = totalSpace - freeSpace;
            double usedSpacePercentage = (usedSpace / totalSpace) * 100;
            if (usedSpacePercentage > 90)
            {
                message += $"Free up some space on your C drive. You have used {usedSpacePercentage:F2}% of your disk space.\n\n";
            }
            // check if c drive is an ssd and if not recommend to upgrade
            if (cDrive.DriveType == DriveType.Fixed)
            {
                if (cDrive.DriveFormat != "NTFS")
                {
                    message += "Upgrade to an SSD for better performance.\n\n";
                }
            }
            // check if the device is overheating
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_TemperatureProbe");
            foreach (ManagementObject obj in searcher.Get())
            {
                double temperature = (double)obj["CurrentReading"];
                if (temperature > 80)
                {
                    message += "Your device is overheating. Make sure it is properly ventilated.\n\n";
                    break;
                }
            }




            textBox2.Text = message;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sd();
        }

        //main 

    }
}
