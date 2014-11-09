using IronRuby;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryRuby.Utils
{
    public class Repl
    {
        private Repl()
        {
            _engine = Ruby.CreateEngine();
            _scope = _engine.CreateScope();

            SourceCodeKind = SourceCodeKind.Expression;
        }

        private static Repl _instance = new Repl();
        public static Repl Instance
        {
            get { return _instance; }
        }

        public string SourceCode { get; set; }

        public SourceCodeKind SourceCodeKind { get; set; }

        public string Evaluate()
        {
            var source = _engine.CreateScriptSourceFromString(SourceCode, SourceCodeKind);
            var props = source.GetCodeProperties();

            if (props == ScriptCodeParseResult.Complete)
            {
                try
                {
                    var result = source.Execute(_scope);

                    if (result != null)
                    {
                        return _engine.Operations.Format(result);
                    }
                    else
                    {
                        return "Hey, I've got nothing after evaluating your expression.";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Oops! Syntax error! Can you double check your code?";
            }
        }

        public async Task<string> EvaluateAsync()
        {
            return await Task.Factory.StartNew<string>(Evaluate);
        }

        private ScriptEngine _engine;
        private ScriptScope _scope;
    }
}
