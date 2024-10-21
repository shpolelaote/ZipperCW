using System;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics.Tracing;

namespace ZipperCW
{
    public partial class ZipperForm : Form
    {
        string newLineDelimiter = " #NewLine# ";
        public ZipperForm()
        {
            InitializeComponent();
        }

        private void ZipperForm_Load(object sender, EventArgs e)
        {
            archiveChooseDirectoryTextBox.Text = @"C:\Users\TUF Gaming\OneDrive - НИТУ МИСиС\Документы\Учеба\3 семестр\Технологии программирования\Курсовая (2)\Маша Гл\6";
            archiveChooseFileTextBox.Text = @"C:\Users\TUF Gaming\OneDrive - НИТУ МИСиС\Документы\Учеба\3 семестр\Технологии программирования\Курсовая (2)\Маша Гл\6\test.txt";

            unarchiveChooseFileTextBox.Text = @"C:\Users\TUF Gaming\OneDrive - НИТУ МИСиС\Документы\Учеба\3 семестр\Технологии программирования\Курсовая (2)\Маша Гл\6\test.bin";
            unarchiveChooseDicTextBox.Text = @"C:\Users\TUF Gaming\OneDrive - НИТУ МИСиС\Документы\Учеба\3 семестр\Технологии программирования\Курсовая (2)\Маша Гл\6\test.dic";
            unarchiveChooseDirectoryTextBox.Text = archiveChooseDirectoryTextBox.Text;
        }
        // choose file to archive
        private void archiveChooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null)
            {
                archiveChooseFileTextBox.Text = openFileDialog.FileName;
            }
        }
        // choose directory to save an archived file
        private void archiveChooseDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath != null)
            {
                archiveChooseDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        // archive the file
        private void archiveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Replace 'filePath' with the path to your text file
                string filePath = archiveChooseFileTextBox.Text;

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    throw new Exception("The path doesn't refer to a file");
                }

                string directoryPath = archiveChooseDirectoryTextBox.Text;

                // Check if the directory exists and has write access
                if (Directory.Exists(directoryPath))
                {
                    // Check directory permissions for write access
                    DirectorySecurity directorySecurity = Directory.GetAccessControl(directoryPath);
                    AuthorizationRuleCollection rules = directorySecurity.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                    bool hasWriteAccess = false;

                    foreach (AuthorizationRule rule in rules)
                    {
                        FileSystemAccessRule fsAccessRule = rule as FileSystemAccessRule;
                        if (fsAccessRule != null && fsAccessRule.AccessControlType == AccessControlType.Allow && (fsAccessRule.FileSystemRights & FileSystemRights.Write) != 0)
                        {
                            hasWriteAccess = true;
                            break;
                        }
                    }

                    if (!hasWriteAccess)
                    {
                        throw new Exception("Directory doesn't have write access.");
                    }
                }
                else
                {
                    throw new Exception("The directory does not exist.");
                }

                // Read the entire contents of the file into a string
                string fileContent = File.ReadAllText(filePath).Trim();
                if (fileContent.Length == 0)
                {
                    throw new Exception("File is empty");
                }

                fileContent = fileContent.Replace("\r", "");
                fileContent = fileContent.Replace("\n", newLineDelimiter);

                var words = fileContent.Split(' ');
                words = words.Where(word => word.Length > 0).ToArray();

                var codes = HuffmanCoding.Encode(words);

                // archive
                foreach (var code in codes)
                {
                    fileContent = fileContent.Replace(code.Key, code.Value);
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] == code.Key)
                        {
                            words[i] = code.Value;
                        }
                    }
                }

                fileContent = String.Join("", words);
                // explained below
                int paddingZeros = 0;
                try
                {
                    // Calculate the number of padding zeros needed to make the string length divisible by 8
                    paddingZeros = 8 - (fileContent.Length % 8);

                    // Pad the binary string with zeros
                    fileContent = fileContent.PadRight(fileContent.Length + paddingZeros, '0');

                    // Convert the binary string to bytes
                    byte[] bytes = new byte[fileContent.Length / 8];
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        string byteString = fileContent.Substring(i * 8, 8);
                        bytes[i] = Convert.ToByte(byteString, 2);
                    }

                    // Replace 'filePath' with the path where you want to save the binary file
                    string pathToWrite = Path.Combine(directoryPath, Path.GetFileNameWithoutExtension(filePath) + ".bin");

                    // Write the bytes to a binary file
                    File.WriteAllBytes(pathToWrite, bytes);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                // write the code dictionary to a file so we could restore it
                var swappedCodes = new Dictionary<string, string>();
                foreach (var pair in codes)
                {
                    swappedCodes[pair.Value] = pair.Key;
                }
                swappedCodes["Pads"] = paddingZeros.ToString();
                // Serialize the dictionary to JSON and write to a file
                string json = JsonConvert.SerializeObject(swappedCodes, Formatting.Indented);
                string path = Path.Combine(directoryPath, Path.GetFileNameWithoutExtension(filePath) + ".dic");
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        // choose archived file
        private void unarchiveChooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null)
            {
                unarchiveChooseFileTextBox.Text = openFileDialog.FileName;
            }

        }
        // choose dictionary to unarchive
        private void unarchiveChooseDicButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null)
            {
                unarchiveChooseDicTextBox.Text = openFileDialog.FileName;
            }
        }
        // choose directory for writing restored file
        private void unarchiveChooseDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath != null)
            {
                unarchiveChooseDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        // unarchive the file
        private void unarchiveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = unarchiveChooseFileTextBox.Text;
                // path to a dictionary
                string dicPath = unarchiveChooseDicTextBox.Text;

                // Check if the file exists
                if (!File.Exists(filePath) || !File.Exists(dicPath))
                {
                    throw new Exception("The path doesn't refer to a file.");
                }

                string directoryPath = unarchiveChooseDirectoryTextBox.Text;

                // Check if the directory exists and has write access
                if (Directory.Exists(directoryPath))
                {
                    // Check directory permissions for write access
                    DirectorySecurity directorySecurity = Directory.GetAccessControl(directoryPath);
                    AuthorizationRuleCollection rules = directorySecurity.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                    bool hasWriteAccess = false;

                    foreach (AuthorizationRule rule in rules)
                    {
                        FileSystemAccessRule fsAccessRule = rule as FileSystemAccessRule;
                        if (fsAccessRule != null && fsAccessRule.AccessControlType == AccessControlType.Allow && (fsAccessRule.FileSystemRights & FileSystemRights.Write) != 0)
                        {
                            hasWriteAccess = true;
                            break;
                        }
                    }

                    if (!hasWriteAccess)
                    {
                        throw new Exception("Directory doesn't have write access.");
                    }
                }
                else
                {
                    throw new Exception("The directory does not exist.");
                }

                string dicContent = File.ReadAllText(dicPath);


                if (dicContent.Length == 0)
                {
                    throw new Exception("Dictionary file is empty");
                }

                // try to read as dictionary
                Dictionary<string, string> codes;
                try
                {
                    codes = JsonConvert.DeserializeObject<Dictionary<string, string>>(dicContent);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                // check if codes have only binary values
                foreach (var code in codes)
                {
                    if (code.Key == "Pads")
                    {
                        continue;
                    }
                    foreach (var c in code.Key)
                    {
                        if (c != '0' && c != '1')
                        {
                            throw new Exception("codes have non binary values");
                        }
                    }
                }

                // Read the entire contents of the file into a string
                byte[] bytes = File.ReadAllBytes(filePath);
                if (bytes.Length == 0)
                {
                    throw new Exception("Archived file is empty");
                }

                // Convert the bytes to a binary string
                string binaryString = "";
                foreach (byte b in bytes)
                {
                    binaryString += Convert.ToString(b, 2).PadLeft(8, '0');
                }

                int padding = Int32.Parse(codes["Pads"]);
                // Find the last index of '1' in the binary string to remove padding zeros
                if (padding != 0)
                {
                    // Remove the padding zeros
                    binaryString = binaryString.Substring(0, binaryString.Length - padding);
                }

                // restore data
                string fileContent = RestoreData(codes, binaryString);

                // write the restored file
                string pathToWrite = Path.Combine(directoryPath, Path.GetFileNameWithoutExtension(filePath) + "Restored.txt");
                File.WriteAllText(pathToWrite, fileContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
        // used to restore data by replacing codes with relative words
        public string RestoreData(Dictionary<string, string> codes, string data)
        {
            // used to check if the word is present in the list
            List<string> codeList = codes.Keys.ToList();
            string restoredData = "";

            // used for iteraton through the data
            int maxLength = codeList.Max(code => code.Length);
            int currentIndex = 0;

            while (currentIndex < data.Length)
            {
                for (int length = 1; length <= maxLength; length++)
                {
                    if (currentIndex + length <= data.Length)
                    {
                        string word = data.Substring(currentIndex, length);
                        if (codeList.Contains(word))
                        {
                            restoredData += codes[word] + " ";
                            currentIndex += length - 1;
                            break;
                        }
                    }
                }

                // If no code matches, move to the next character
                currentIndex++;
            }
            // add new lines
            restoredData = restoredData.Replace(newLineDelimiter.Trim(), "\n");

            // Remove trailing space
            return restoredData.Trim(); 
        }
    }
}
