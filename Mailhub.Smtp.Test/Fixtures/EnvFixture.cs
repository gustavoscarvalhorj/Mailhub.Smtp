using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace Mailhub.Smtp.Test
{

    // FYI:
    // This class is adaptation from the link above:
    // https://stackoverflow.com/questions/43927955/should-getenvironmentvariable-work-in-xunit-test
    public class EnvFixture : IDisposable
    {
        public EnvFixture()
        {
            using (var file = File.OpenText("appsettings.json"))
            {
                var reader = new JsonTextReader(file);
                var jObject = JObject.Load(reader);
                foreach (var x in jObject)
                {
                    string name = x.Key;
                    JToken value = x.Value;
                    Environment.SetEnvironmentVariable(name, value.ToString());
                }
            }
        }

        public void Dispose()
        {
            // ... clean up
        }
    }
}
