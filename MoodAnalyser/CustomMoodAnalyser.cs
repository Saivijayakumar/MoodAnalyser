using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class CustomMoodAnalyser:Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            EMPTY_EXCEPTION,NULL_EXCEPTION
        }
        public CustomMoodAnalyser(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
