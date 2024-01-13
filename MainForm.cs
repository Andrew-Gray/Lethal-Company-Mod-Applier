using System.Reflection;
using System.IO.Compression;
using System.Diagnostics;

namespace Lethal_Company_Mod_Applier
{
    public partial class MainForm : Form
    {
        private readonly string repoLink = "https://github.com/Andrew-Gray/Lethal-Company-Mod-List";
        private readonly string helpLink = "https://github.com/Andrew-Gray/Lethal-Company-Mod-Applier/blob/main/README.md";
        private readonly string downloadLink = "https://github.com/Andrew-Gray/Lethal-Company-Mod-List/releases/latest/download/Lethal-Company-Mod-List.zip";
        private readonly string fileName = "Lethal-Company-Mod-List.zip";
        private readonly string folderName = "\\Lethal-Company-Mod-List";

        private string currentPath = "";
        private bool hasDownloaded = false;

        public MainForm()
        {
            InitializeComponent();

            currentPath = Directory.GetCurrentDirectory();

            LogEntry("Info: Welcome to the Lethal Company Mod Applier.");
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            LogEntry("Info: Applying mods has started");

            LogEntry("Step: Clearing all old mods.");
            DeleteExistingMods();

            LogEntry("Step: Applying the mods.");
            CopySelectedMods();

            //LogEntry("Step: Cleaning up.");
            //CleanUpDownloadedResources();

            LogEntry("Info: Applying mods completed.");
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            LogEntry("Info: Download started.");
            LogEntry(repoLink, false, true);
            LogEntry("Info: Downloading mod pack from");

            DownloadMods();
            ExtractMods();
            ListMods();

            LogEntry("Info: Download completed.");

            hasDownloaded = true;
            ShowHideApplyClear();
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowHideApplyClear();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            LogEntry("Info: Removing mods from folder");
            DeleteExistingMods();
            LogEntry("Info: Mods have been removed");
        }

        private void HelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = helpLink,
                UseShellExecute = true
            });
        }

        private void OpenCloseBtn_Click(object sender, EventArgs e)
        {
            ModsListPanel.Visible = !ModsListPanel.Visible;

            if (ModsListPanel.Visible)
            {
                this.Height = 513;
                LogLabel.Location = new Point(12, 332);
                LogList.Location = new Point(12, 350);
            }
            else
            {
                this.Height = 315;
                LogLabel.Location = new Point(12, 123);
                LogList.Location = new Point(12, 141);
            }
        }

        private void SelectedModsCheckListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int itemCount = SelectedModsCheckListBox.Items.Count + 1;
            int selectdCount = SelectedModsCheckListBox.CheckedItems.Count + 1;

            if (e.NewValue == CheckState.Unchecked)
            {
                selectdCount--;
            }
            else
            {
                selectdCount++;
            }

            if (selectdCount == 1)
            {
                ApplyBtn.Text = "Apply (Base)";
            }
            else if (itemCount == selectdCount)
            {
                ApplyBtn.Text = "Apply (All)";
            }
            else
            {
                ApplyBtn.Text = $"Apply ({selectdCount})";
            }
        }

        private void SelectedModsCheckListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
        }





        private void ShowHideApplyClear()
        {
            string path = PathTextBox.Text;

            if (IsPathValid(path) && hasDownloaded)
            {
                ApplyBtn.Enabled = true;
                ApplyBtn.Text = "Apply (All)";

                ClearBtn.Enabled = true;
                OpenCloseBtn.Enabled = true;
            }
            else
            {
                ApplyBtn.Enabled = false;
                ApplyBtn.Text = "Apply";

                ClearBtn.Enabled = false;
                OpenCloseBtn.Enabled = false;
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
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private void LogEntry(string log, bool timestamp = true, bool spacer = false)
        {
            string logString = "";

            if (timestamp)
            {
                string timestampString = DateTime.Now.ToString("HH:mm:ss");
                logString += $"[{timestampString}] ";
            }

            if (spacer)
            {
                logString += "                  ";
            }

            logString += log;

            LogList.Items.Insert(0, logString);
        }

        private void DownloadMods()
        {
            if (File.Exists(currentPath + fileName))
            {
                File.Delete(currentPath + fileName);
            }

            using var client = new HttpClient();
            using var s = client.GetStreamAsync(downloadLink);
            using var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            s.Result.CopyTo(fs);
        }

        private void ExtractMods()
        {
            if (IsPathValid(currentPath + folderName))
            {
                Directory.Delete(currentPath + folderName, true);
            }

            ZipFile.ExtractToDirectory(fileName, currentPath);
        }

        private void CleanUpDownloadedResources()
        {
            if (IsPathValid(currentPath + folderName))
            {
                Directory.Delete(currentPath + folderName, true);
            }

            if (File.Exists(currentPath + "\\" + fileName))
            {
                File.Delete(currentPath + "\\" + fileName);
            }
        }

        private void ListMods()
        {
            SelectedModsCheckListBox.Items.Clear();

            var dirs = Directory.GetDirectories(currentPath + folderName, "*", SearchOption.TopDirectoryOnly);

            foreach (var dir in dirs)
            {
                string modName = Path.GetFileName(dir);

                if (modName == "BepInExPack")
                {
                    continue;
                }

                SelectedModsCheckListBox.Items.Add(modName, true);
            }
        }

        private void CopySelectedMods()
        {
            string gamePath = PathTextBox.Text;

            //Apply BepInExPack
            CopyFilesRecursively(currentPath + folderName + "\\BepInExPack", gamePath);

            //Apply All Other Selected Mods
            var dirs = Directory.GetDirectories(currentPath + folderName, "*", SearchOption.TopDirectoryOnly);

            foreach (var dir in dirs)
            {
                string modName = Path.GetFileName(dir);

                if (modName == "BepInExPack" || SelectedModsCheckListBox.CheckedItems.IndexOf(modName) < 0)
                {
                    continue;
                }

                string fromPath = currentPath + folderName + "\\" + modName;
                string copyToPath = gamePath + "\\BepInEx";
                CopyFilesRecursively(fromPath, copyToPath);
            }
        }
    }
}
