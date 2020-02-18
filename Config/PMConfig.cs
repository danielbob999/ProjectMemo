using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMemo.ProjectMemoConsole;

namespace ProjectMemo.Config
{
    class PMConfig
    {
        private static Dictionary<string, object> mConfigOptions = new Dictionary<string, object>();

        [ProjectMemoConsole.CommandAttributes.CommandMethod("config.printOptions", "")]
        public static void PrintAllConfigOptions(string[] args) {
            if (mConfigOptions.Count == 0) {
                CustomConsole.Log("No config options loaded.");
                return;
            }

            foreach (KeyValuePair<string, object> pair in mConfigOptions) {
                try {
                    CustomConsole.Log(string.Format("{0}={1}", pair.Key, pair.Value.ToString()), true);
                } catch (Exception) {
                    CustomConsole.Log("Failed to print config option. Key: " + pair.Key + ", Value Type: " + pair.Value.GetType().Name, true);
                }
            }
        }
        
        public static bool LoadFromFile(string path) {
            mConfigOptions.Clear();
            int lineNum = 1;

            if (!File.Exists(path)) {
                CustomConsole.Log("No config file present at: " + path);
                return false;
            }

            try {
                using (StreamReader reader = new StreamReader(path)) {
                    while (!reader.EndOfStream) {
                        string line = reader.ReadLine();
                        string[] splitString = line.Split('=');

                        if (splitString.Length == 2) {
                            mConfigOptions.Add(splitString[0], splitString[1]);
                            lineNum++;
                        }
                    }
                }

                CustomConsole.Log("Successfully read in all preferences from '" + path + "'");
                return true;
            } catch (Exception e) {
                CustomConsole.Log("Failed to load preferences from '" + path + "'. Error in line: " + lineNum);
                CustomConsole.Log(e.Message);
                return false;
            }
        }

        public static bool GetConfigValue<T>(string configName, out T value) {
            if (mConfigOptions.ContainsKey(configName)) {
                if (mConfigOptions[configName] is T) {
                    value = (T)mConfigOptions[configName];
                    return true;
                }

                try {
                    value = (T)Convert.ChangeType(mConfigOptions[configName], typeof(T));
                    return true;
                } catch (InvalidCastException) {
                    value = default(T);
                    return false;
                }
            }

            value = default(T);
            return false;
        }

        public static void GenerateDefaultConfigFile(string path) {
            CustomConsole.Log("Generating a new, default, config file");

            mConfigOptions = new Dictionary<string, object>();
            mConfigOptions.Add("mainnotedir", "");

            SaveToFile(path);
        }

        public static void SaveToFile(string path) {
            List<string> configAsText = new List<string>();

            foreach (KeyValuePair<string, object> pair in mConfigOptions) {
                configAsText.Add(string.Format("{0}={1}", pair.Key, pair.Value.ToString()));
            }

            try {
                if (File.Exists(path)) {
                    File.Delete(path);
                }

                File.WriteAllLines(path, configAsText.ToArray());
            } catch (Exception e) {
                CustomConsole.Log("Error when saving the config file.");
                CustomConsole.Log(e.Message);
            }
        }
    }
}
