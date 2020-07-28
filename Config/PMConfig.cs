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
        private static Dictionary<string, Tuple<string, string>> s_configOptions = new Dictionary<string, Tuple<string, string>>();

        [ProjectMemoConsole.CommandAttributes.CommandMethod("config.printOptions", "")]
        public static void PrintAllConfigOptions(string[] args) {
            if (s_configOptions.Count == 0) {
                CustomConsole.Log("No config options loaded.");
                return;
            }

            foreach (KeyValuePair<string, Tuple<string, string>> pair in s_configOptions) {
                try {
                    CustomConsole.Log(string.Format("{0}:{1}={2}", pair.Value.Item1, pair.Key, pair.Value.Item2.ToString()), true);
                } catch (Exception) {
                    CustomConsole.Log("Failed to print config option. Key: " + pair.Key + ", Value Type: " + pair.Value.GetType().Name, true);
                }
            }
        }
        
        public static bool LoadFromFile(string path) {
            s_configOptions.Clear();
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

                        string[] nameSplit = splitString[0].Split(':');

                        Console.WriteLine(string.Format("[{0}:{1}={2}]", nameSplit[0], nameSplit[1], splitString[1]));

                        if (splitString.Length == 2) {
                            s_configOptions.Add(nameSplit[1], new Tuple<string, string>(nameSplit[0], splitString[1]));
                            lineNum++;
                        }
                    }
                }

                Console.WriteLine("read in all pmconfig");
                CustomConsole.Log("Successfully read in all preferences from '" + path + "'");
                return true;
            } catch (Exception e) {
                CustomConsole.Log("Failed to load preferences from '" + path + "'. Error in line: " + lineNum);
                CustomConsole.Log(e.Message);
                return false;
            }
        }

        public static bool DoesConfigValueExist(string configName) {
            return s_configOptions.ContainsKey(configName);
        }

        public static float GetConfigValueFloat(string configName) {
            if (DoesConfigValueExist(configName)) {
                try {
                    return float.Parse(s_configOptions[configName].Item2);
                } catch (Exception e) {
                    return 0;
                }
            } else {
                return 0;
            }
        }

        public static int GetConfigValueInt(string configName) {
            if (DoesConfigValueExist(configName)) {
                try {
                    return Convert.ToInt32(s_configOptions[configName].Item2);
                } catch (Exception e) {
                    return 0;
                }
            } else {
                return 0;
            }
        }

        public static string GetConfigValueString(string configName) {
            if (DoesConfigValueExist(configName)) {
                return s_configOptions[configName].Item2;
            } else {
                return "";
            }
        }

        public static void GenerateDefaultConfigFile(string path) {
            CustomConsole.Log("Generating a new, default, config file");

            s_configOptions = new Dictionary<string, Tuple<string, string>>();
            //s_configOptions.Add("mainnotedir", "");
            s_configOptions.Add("mainNoteDir", new Tuple<string, string>("s", ""));
            s_configOptions.Add("logDir", new Tuple<string, string>("s", "\\logs"));
            s_configOptions.Add("autoSaveDir", new Tuple<string, string>("s", "\\auto_saves"));
            s_configOptions.Add("languageThemesDir", new Tuple<string, string>("s", "\\language_themes"));
            s_configOptions.Add("autoSaveIntervalMs", new Tuple<string, string>("i", "5000"));
            s_configOptions.Add("filesListBoxRefreshIntervalMs", new Tuple<string, string>("i", "5000"));

            SaveToFile(path);
        }

        public static void SaveToFile(string path) {
            List<string> configAsText = new List<string>();

            foreach (KeyValuePair<string, Tuple<string, string>> pair in s_configOptions) {
                configAsText.Add(string.Format("{0}:{1}={2}", pair.Value.Item1, pair.Key, pair.Value.Item2.ToString()));
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
