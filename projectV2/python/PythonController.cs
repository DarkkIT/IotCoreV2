using IronPython.Hosting;
using System.Threading.Tasks;

namespace projectV2.python
{
    public class PythonController
    {
        public async Task Start()
        {
            var engine = Python.CreateEngine();

            var script = @"../../../python/examples/main.py";

            var source = engine.CreateScriptSourceFromFile(script);

            //var argv = new List<string>();
            //argv.Add("");
            //argv.Add("2022-7-18");
            //argv.Add("2022-7-20");

            //engine.GetSysModule().SetVariable("argv", argv);

            //var eIO = engine.Runtime.IO;

            //var error = new MemoryStream();
            //eIO.SetErrorOutput(error, Encoding.Default);

            //var result = new MemoryStream();
            //eIO.SetErrorOutput(result, Encoding.Default);

            source.Execute();
        }
    }
}
