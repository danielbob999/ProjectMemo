using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjectMemo.ProjectMemoConsole.CommandAttributes;

namespace ProjectMemo.ProjectMemoConsole
{
    public static class CustomConsole
    {
        public delegate void CommandDelegate(string[] a_args); // The delegate used for command logic

        private static List<string> msgQueue = new List<string>();
        private static List<Command> validCommands = new List<Command>();
        private static string mLogFilesDirectory;
        private static string mCurrentLogFileName;
        private static bool mLogFileIsActive = false;

        public static void Init()
        {
            mLogFilesDirectory = Directory.GetCurrentDirectory() + "\\logs\\";
            mCurrentLogFileName = string.Format("log_{0}_{1}_{2}.txt", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            if (!File.Exists(mLogFilesDirectory + mCurrentLogFileName)) {
                FileStream fs = File.Create(mLogFilesDirectory + mCurrentLogFileName);
                fs.Close();
                mLogFileIsActive = true;
            } else {
                mLogFileIsActive = true;
            }

            Log("Starting CustomConsole...");

            Log("Looking for CommandMethods in Assembly: " + typeof(CustomConsole).Assembly.GetName());
            int i = 0;

            foreach (Type classType in typeof(CustomConsole).Assembly.GetTypes()) {
                foreach (MethodInfo methodInfo in classType.GetMethods()) {
                    foreach (Attribute methodAttribute in methodInfo.GetCustomAttributes()) {
                        if (methodAttribute.GetType() == typeof(CommandAttributes.CommandMethod)) {
                            validCommands.Add(new Command(((CommandMethod)methodAttribute).CallString, (CommandDelegate)methodInfo.CreateDelegate(typeof(CommandDelegate)), ((CommandMethod)methodAttribute).ArgOptions));
                            i++;
                        }
                    }
                }
            }

            Log("Found " + i + " valid commands in Assembly: " + typeof(CustomConsole).Assembly.GetName());

            // Append all messages already in the message queue to the log file
            File.AppendAllLines(mLogFilesDirectory + mCurrentLogFileName, msgQueue);
        }

        public static void Close() {
            File.AppendAllText(mLogFilesDirectory + mCurrentLogFileName, string.Format("============ Shutdown: {0}:{1}:{2} ============", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
            File.AppendAllText(mLogFilesDirectory + mCurrentLogFileName, "\n\n");
        }

        public static void Log(string _msg, bool a_disableTrace = false)
        {
            if (_msg != "")
            {
                StackTrace trace = new StackTrace();
                string msgStr;

                if (a_disableTrace) {
                    msgStr = string.Format("[{0}] {1}", DateTime.Now.ToLongTimeString(), _msg);
                } else {
                    msgStr = string.Format("[{0}] {1} ({2}.{3})", DateTime.Now.ToLongTimeString(), _msg, trace.GetFrame(1).GetMethod().DeclaringType.Name, trace.GetFrame(1).GetMethod().Name);
                }

                msgQueue.Add(msgStr);

                // Append the message to the log file
                if (mLogFileIsActive)
                    File.AppendAllText(mLogFilesDirectory + mCurrentLogFileName, msgStr + "\n");
            }
        }

        public static void LogCommand(string _cmdStr)
        {
            if (_cmdStr != "")
            {
                string msgStr = string.Format("[{0}] > {1}", DateTime.Now.ToLongTimeString(), _cmdStr);
                msgQueue.Add(msgStr);

                // Append the message to the log file
                if (mLogFileIsActive)
                    File.AppendAllText(mLogFilesDirectory + mCurrentLogFileName, msgStr + "\n");
            }
        }

        public static string GetMessageQueueAsString()
        {
            string str = "";

            foreach (string s in msgQueue)
                str += (s + "\n");

            return str;
        }

        public static string[] GetMessageQueueAsArray()
        {
            return msgQueue.ToArray();
        }

        public static void ProcessCommand(string a_cmd)
        {
            string[] cmdSplitSpaces = SplitConsoleCommand(a_cmd);

            foreach (Command cmd in validCommands)
            {
                if (cmd.CommandCallName == cmdSplitSpaces[0])
                {
                    cmd.Invoke(cmdSplitSpaces);
                }
            }
        }

        private static string[] SplitConsoleCommand(string a_cmd)
        {
            List<string> argList = new List<string>();
            int i = 0;
            string nextString = "";
            bool lookingForEndQuotes = false;

            while (i < a_cmd.Length)
            {
                if (a_cmd[i] == '"' && lookingForEndQuotes)
                {
                    if (nextString != "")
                        argList.Add(nextString);
                    nextString = "";
                    lookingForEndQuotes = false;
                    i++;
                    continue;
                }

                if (a_cmd[i] == '"' && !lookingForEndQuotes)
                {
                    lookingForEndQuotes = true;
                    i++;
                    continue;
                }

                if (a_cmd[i] == ' ' && !lookingForEndQuotes)
                {
                    if (nextString != "")
                        argList.Add(nextString);
                    nextString = "";
                    i++;
                    continue;
                }

                nextString += a_cmd[i];
                i++;
            }

            if (i == a_cmd.Length)
                if (nextString != "")
                    argList.Add(nextString);

            return argList.ToArray();
        }

        [CommandMethod("console.help", "", "<string:commandName>")]
        public static void Help(string[] a_args)
        {
            if (a_args.Length == 1)
            {
                foreach (Command cmd in validCommands)
                {
                    Log(cmd.CommandCallName + " " + cmd.ArgOverloads[0], true);
                }

                return;
            }

            foreach (Command cmd in validCommands)
            {
                Log(cmd.CommandCallName + ":", true);

                foreach (string argOverload in cmd.ArgOverloads)
                {
                    if (argOverload == "")
                    {
                        Log("      0 args", true);
                        continue;
                    }

                    Log("      " + argOverload, true);
                }
            }
        }

        [CommandMethod("console.autoscroll", "", "<bool:Value>")]
        public static void SetAutoScrollCommand(string[] args) {
            if (args.Length == 1) {
                Log("console.autoscroll: " + Forms.ConsoleForm.CaretAutoScroll.ToString());
            } else if (args.Length == 2) {
                if (bool.TryParse(args[1], out bool res)) {
                    Forms.ConsoleForm.CaretAutoScroll = res;
                } else {
                    Log("Cannot convert '" + args[1] + "' to bool");
                }
            } else {
                Log("Incorrect number of arguments for command console.autoscroll");
            }
        }
    }
}
