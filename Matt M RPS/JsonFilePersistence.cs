using System;
using System.Collections.Generic;
using System.IO;
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

            // when file doesn't exist
            string json;
            try
            {
                json = File.ReadAllText(filePathField);
            }
            catch (IOException e)
            {
                return new Score();
            }
            // deserialize to a specific class
            Score data = JsonSerializer.Deserialize<Score>(json);
            return data;
        }

        public void Write(Score data)
        {
            // ways to work with JSON in .net
            // -DataContractSerializer builtin semiold
            // System.Text.Json builtin new fast
            // Newtonsoft.Json, aka JSON.NET , popular

            string json = JsonSerializer.Serialize(data);

            File.WriteAllText(filePathField, json);
        }
    }
}
