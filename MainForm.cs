using System.Reflection;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

namespace Lethal_Company_Mod_Applier
{
    public partial class MainForm : Form
    {
        private bool hasDownloaded = false;

        public MainForm()
        {
            InitializeComponent();
            logEntry("Info: Welcome to the Lethal Company Mod Applier.");
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            logEntry("Info: Applying mods has started");
            logEntry("Step: Extracting mod pack.");

            string fileName = "Lethal-Company-Mod-List.zip";
            string? currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string gamePath = PathTextBox.Text;
            string gameBepInExPath = gamePath + "\\BepInEx";

            if (currentPath == null) return;

            ZipFile.ExtractToDirectory(fileName, currentPath);

            logEntry("Step: Applying the mods.");

            DeleteExistingMods();

            //Apply BepInExPack
            string fromPath = currentPath + "\\Lethal-Company-Mod-List\\BepInExPack";
            string copyToPath = gamePath;

            CopyFilesRecursively(fromPath, copyToPath);

            //Apply MoreCompany
            fromPath = currentPath + "\\Lethal-Company-Mod-List\\MoreCompany";
            copyToPath = gameBepInExPath;
            CopyFilesRecursively(fromPath, copyToPath);


            logEntry("Step: Cleaning up.");
            Directory.Delete(currentPath + "\\Lethal-Company-Mod-List", true);


            logEntry("Info: Applying mods completed.");
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            logEntry("Info: Download started.");
            logEntry("                  https://github.com/Andrew-Gray/Lethal-Company-Mod-List", false);
            logEntry("Info: Downloading mod pack from");

            string downloadLink = "https://github.com/Andrew-Gray/Lethal-Company-Mod-List/releases/download/Release/Lethal-Company-Mod-List.zip";
            string fileName = "Lethal-Company-Mod-List.zip";

            using var client = new HttpClient();
            using var s = client.GetStreamAsync(downloadLink);
            using var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            s.Result.CopyTo(fs);

            logEntry("Info: Download completed.");

            hasDownloaded = true;
            showHideApplyClear();
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            showHideApplyClear();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            logEntry("Info: Removing mods from folder");
            DeleteExistingMods();
            logEntry("Info: Mods have been removed");
        }


        private void showHideApplyClear()
        {
            string path = PathTextBox.Text;

            if (IsPathValid(path) && hasDownloaded)
            {
                ApplyBtn.Enabled = true;
                ClearBtn.Enabled = true;
            }
            else
            {
                ApplyBtn.Enabled = false;
                ClearBtn.Enabled = false;
            }
        }


        private static bool IsPathValid(string path)
        {
            if (path == null || path == "" || !Directory.Exists(path))
            {
                return false;
            }

            return true;
        }

        private void DeleteExistingMods()
        {
            string gamePath = PathTextBox.Text;
            string gameBepInExPath = gamePath + "\\BepInEx";
            string doorstopConfig = gamePath + "\\doorstop_config.ini";
            string winHttp = gamePath + "\\winhttp.dll";

            if (IsPathValid(gameBepInExPath))
            {
                Directory.Delete(gameBepInExPath, true);
            }

            if (File.Exists(doorstopConfig))
            {
                File.Delete(doorstopConfig);
            }

            if (File.Exists(winHttp))
            {
                File.Delete(winHttp);
            }
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private void logEntry(string log, bool timestamp = true)
        {
            string logString = "";

            if (timestamp)
            {
                string timestampString = DateTime.Now.ToString("HH:mm:ss");
                logString += $"[{timestampString}] ";
            }

            logString += log;

            LogList.Items.Insert(0, logString);
        }

        private void HelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Andrew-Gray/Lethal-Company-Mod-Applier/blob/main/README.md",
                UseShellExecute = true
            });
        }
    }
}
