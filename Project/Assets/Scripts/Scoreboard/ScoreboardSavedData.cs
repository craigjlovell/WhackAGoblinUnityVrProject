using System.Collections.Generic;
using System;

namespace Wack.Scoreboards
{
    [Serializable]
    public class ScoreboardSavedData 
    {
        public List<ScoreboardEntryData> highscores = new List<ScoreboardEntryData>();
    }

 
}
