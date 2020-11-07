using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RPS
{
    public class JsonFilePersistence
    {

        // where do we write a file to
        private readonly string filePathField;
        public JsonFilePersistence(string filePath)
        {
            filePathField = filePath;
        }

        public Score Read()
        {
            // property initialization syntax
            // Score() zero argument constructor

            /*
            var score = new Score
            {
                winCount = 0,
                tieCount = 0,
                lossCount = 0
            };
            */

            return new Score();
        }

        public void Write(Score data)
        {
            // ways to work with JSON in .net
            // -DataContractSerializer builtin semiold
            // System.Text.Json builtin new fast
            // Newtonsoft.Json, aka JSON.NET , popular

            string Json = JsonSerializer.Serialize(data);

            File.WriteAllText(filePathField, Json);
        }
    }
}
