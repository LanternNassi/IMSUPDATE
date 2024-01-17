using System.Diagnostics;

namespace IMSUpdate
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            string installation_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string installer = Path.Combine(installation_location, "IMS.exe");



            if (File.Exists(installer))
            {
                //Starting the installation process after the 5 seconds
                //string arguments = "/VERYSILENT /SUPPRESSMSGBOXES";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = installer,
                    //Verb = "runas", // Run as administrator
                    UseShellExecute = true,
                    Arguments = "/SILENT", // Use silent mode for Inno Setup
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit(); // Wait for the installer to finish
                }

                //MessageBox.Show("The update process is done . You might consider restarting your application for the update to take effect");
                // Optionally, you may want to restart your application after the update
                //Process.Start("Abbey Trading Store.exe");

                MessageBox.Show("The update was completed successfully . Restart the application for the changes to take effect.");

                //ApplicationConfiguration.Initialize();
                //Application.Run(new Form1());



            }
            else
            {
                MessageBox.Show("File does not exist");
            }
        }
    }
}