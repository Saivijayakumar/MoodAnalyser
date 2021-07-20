using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        public Object CreateMoodAnalyserObject(string className, string constructorName)
        {
            //check class name and constructor name are same
            string pattern = constructorName + "$";
            Match res = Regex.Match(className, pattern);

            if (res.Success)
            {
                try
                {
                    //create assemblt object
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type classType = assembly.GetType(className);
                    //create object
                    var obj = Activator.CreateInstance(classType);
                    return obj;
                }
                catch (CustomMoodAnalyserException)
                {
                    //exception if class not found
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class Not found");
                }
            }
            else
            {
                //exception if constructor not found
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor Not found");
            }
        }
        public static Object CreateMoodAnalyserParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyse);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {

                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class Not Found");
                }
            }
            else
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not Found");
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                string className = "MoodAnalyser.MoodAnalyse";
                Type type = Type.GetType(className);
                //Creating object with parameter constructor
                object moodAnalyserObj = CreateMoodAnalyserParameterizedConstructor(className,"MoodAnalyse",message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyserObj, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyserException(CustomMoodAnalyserException.ExceptionType.METHOD_NOT_EXIST, "wrong method name");
            }
        }
    }
}
