using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMemo.ProjectMemoConsole
{
    public class Command
    {
        private string mCommandCallName = "";
        private List<string> mArgOverloads = new List<string>();
        private CustomConsole.CommandDelegate mCommandDelegate;

        public string CommandCallName
        {
            get { return mCommandCallName; }
        }

        public List<string> ArgOverloads
        {
            get { return mArgOverloads; }
        }

        public Command(string a_callName, CustomConsole.CommandDelegate a_delegate, List<string> a_argOverloads)
        {
            mCommandCallName = a_callName;
            mCommandDelegate = a_delegate;
            mArgOverloads = a_argOverloads;
        }

        public void Invoke(string[] a_args)
        {
            try
            {
                mCommandDelegate(a_args);
            }
            catch (Exception e)
            {
                CustomConsole.Log(e.Message);
            }
        }
    }
}
