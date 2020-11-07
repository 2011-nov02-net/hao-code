using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RPS
{
    public class JsonFilePersistence
    {
        // besides JSON, also use XML to store data
        // XML more complicated than JSON
        // in .NET use DataContractSerializer, also supports JSON
        // XmlSerializer, old do not support generics


        // where do we write a file to
        private readonly string filePathField;
        public JsonFilePersistence(string filePath)
        {
            filePathField = filePath;
        }

        // add async if there is a async operation
        public async Task<Score> ReadAsync()
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
                // async method change return type to Task<>
                Task<string> jsonTask = File.ReadAllTextAsync(filePathField);
                json = await jsonTask;
            }
            catch (IOException e)
            {
                return new Score();
            }
            // deserialize to a specific class
            Score data = JsonSerializer.Deserialize<Score>(json);
            return data;

            // steps to go async:
            // 1. look for a version of the method you want to call that ends in the "Async" prefix that returns a Task. call that instead.
            // 2. now you have a Task instead of the thing you wanted. either await it right away, or, if you can do something useful in the meantime,
            //        do that first.
            // 3. compile error: method must be async. add "async" to method. change return type: void becomes Task, any T becomes Task<T>.
            //        also, by convention, add the "Async" suffix to your own method.
            // 4. any code that calls this method: start from step 1.
        }

        public async Task WriteAsync(Score data)
        {
            // ways to work with JSON in .net
            // -DataContractSerializer builtin semiold
            // System.Text.Json builtin new fast
            // Newtonsoft.Json, aka JSON.NET , popular

            // options, more human readable
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true} );

            // helper 
            // File.WriteAllText(filePathField, json);

            // expand

            // version 1. does not handle exception
            /*
            var fileWriter = new StreamWriter(filePathField);
            fileWriter.Write(json);
            fileWriter.Close(); 
            */
            // need to call Close or Dispose on any object that contacts stuff outside of CLR, disk or calls

            // version 2 exception handling
            /*
            StreamWriter fileWriter = null;
            try
            {
                fileWriter = new StreamWriter(filePathField);
                fileWriter.Write(json);

            }
            
            finally
            {
                // cleaning up resources regardless of success or failure
                fileWriter?.Close();
            }
            */
            // try code that might throw an exception
            // catch 1 exception we can handle, handle them 2 exception we cannot handle, log them, or re-throw "throw"
            // finally runs if there was an exception. if there was an uncaught exception, or if there was a caught exception
            // always every time

            // version 3
            // call Dispose when the variable goes out of scope
            // does not catch exception
            /*
            using (var fileWriter = new StreamWriter(filePathField))
            {
                fileWriter.Write(json);
            }
            */

            // version 4
            // does not catch exception
            // newer form of the using statement
            // call Dispose when the variable goes out of scope
            using var fileWriter = new StreamWriter(filePathField);
            await fileWriter.WriteAsync(json);
            

            // when you instantiate any class that implements IDisposable interface, use a using statement to handle cleaning up
            // using 1 namespace 2 close unmanaged resource
   
        }
    }
}
