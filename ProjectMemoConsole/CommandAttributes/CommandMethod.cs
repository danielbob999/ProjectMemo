using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMemo.ProjectMemoConsole.CommandAttributes
{
    public class CommandMethod : Attribute
    {
        private string mCommandCallName;
        private List<string> mArgOptions = new List<string>();

        public List<string> ArgOptions
        {
            get { return mArgOptions; }
        }

        public string CallString
        {
            get { return mCommandCallName; }
        }

        public CommandMethod(string a_commandName, string a_defaultArg, params string[] a_argOp)
        {
            mCommandCallName = a_commandName;
            mArgOptions.Add(a_defaultArg);
            mArgOptions.AddRange(a_argOp);
        }
    }
}
