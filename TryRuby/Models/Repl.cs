using IronRuby;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryRuby.Models
{
    public class Repl
    {
        private Repl()
        {
            _engine = Ruby.CreateEngine();
            _scope = _engine.CreateScope();

            Messages = new ObservableCollection<ReplMessage>();

            PostMessage("Hi, I'm Ruby. What expressions do you want me to evaluate?", ReplMessageKind.Received);
        }

        private static Repl _instance = new Repl();
        public static Repl Instance
        {
            get { return _instance; }
        }

        public ObservableCollection<ReplMessage> Messages { get; private set; }

        public async Task Send(string sourceCode, SourceCodeKind sourceCodeKind = SourceCodeKind.Expression)
        {
            PostMessage(sourceCode, ReplMessageKind.Sent);

            var result = await Task.Run<string>(() => Evaluate(sourceCode, sourceCodeKind));

            PostMessage(result, ReplMessageKind.Received);
        }

        private ScriptEngine _engine;
        private ScriptScope _scope;

        private void PostMessage(string text, ReplMessageKind kind)
        {
            Messages.Add(
                new ReplMessage
                {
                    Text = text,
                    Kind = kind
                });
        }

        private string Evaluate(string sourceCode, SourceCodeKind sourceCodeKind)
        {
            var source = _engine.CreateScriptSourceFromString(sourceCode, sourceCodeKind);
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
                        return "Hey, nothing returned.";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Oops! Syntax errors!";
            }
        }
    }
}
