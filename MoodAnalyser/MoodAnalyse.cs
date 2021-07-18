using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyse
    {
        string message;
        //defualt constructor
        public MoodAnalyse()
        {
            Console.WriteLine("Default Constructor for reflection");
        }
        //parameterized constructor
        public MoodAnalyse(string message)
        {
            this.message = message;
        }
        public string CheckMood()
        {
            try
            {
                if (message.Equals(string.Empty))
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.EMPTY_EXCEPTION, "Message should not be Empty");
                }
                else if (this.message.ToLower().Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Message Should not be Null");
            }

        }
    }
}
