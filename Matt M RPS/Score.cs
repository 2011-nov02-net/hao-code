using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RPS
{
    public class Score
    {
        // tracks win, loss, and ties
        public event Action WinHappened;

        [JsonPropertyName("wins")]
        public int winCount { get; set; } = 0;

        [JsonPropertyName("losses")]

        public int lossCount { get;  set; } = 0;

        [JsonIgnore]

        public int tieCount { get; set; } = 0;

        // methods to increment scores
        public void winSet()
        {
            winCount++;
            // fire event like this, call it like a function
            // call every subscribed delegate with the provided parameters
            // ?. is like . if the left is not null, if it is null, does nothing
            WinHappened?.Invoke();

            // WinHappened(2); pass on 2 to its subscribers

            // if there are no subscribers, event is null -> nullexception 
        }        
        public void loseSet()
        {
            lossCount++;
        }       
        public void tieSet()
        {
            tieCount++;
        }
    }
}
