using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;

namespace MoodAnalyserTestMethod
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodForMessageHappy()
        {
            //Arrange
            MoodAnalyse mood = new MoodAnalyse("I am Happy");
            string actual, expected = "happy";
            //Act
            actual = mood.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestMethodForMessageSad()
        {
            //Arrange
            MoodAnalyse mood = new MoodAnalyse("I am sad");
            string actual, expected = "sad";
            //Act
            actual = mood.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestMethodForMessageAnyMood()
        {
            //Arrange
            MoodAnalyse mood = new MoodAnalyse("I am in Any mood");
            string actual, expected = "happy";
            //Act
            actual = mood.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestMethodForMessageNull()
        {
            try
            {
                //Act
                string actual;
                //Arrange
                MoodAnalyse mood = new MoodAnalyse(null);
                actual = mood.CheckMood();
            }
            catch (CustomMoodAnalyserException ex)
            {
                string expected = "Message Should not be Null";
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void TestMethodForMessageEmpty()
        {
            try
            {
                //Act
                string actual;
                //Arrange
                MoodAnalyse mood = new MoodAnalyse(string.Empty);
                actual = mood.CheckMood();
            }
            catch (CustomMoodAnalyserException ex)
            {
                string expected = "Message should not be Empty";
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //-----------------------------------------------------------------------------
        /// <summary>
        /// TC 1 Class name and constructore name
        /// </summary>
        [TestMethod]
        [TestCategory("objectCreation")]
        public void ObjectCreationUsingReflection()
        {
            Object obj = null;
            MoodAnalyse mood = new MoodAnalyse();
            try
            {
                MoodAnalyserFactory moodAnalyse = new MoodAnalyserFactory();
                obj = moodAnalyse.CreateMoodAnalyserObject("MoodAnalyser.MoodAnalyse", "MoodAnalyse");
            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(mood);
        }
        /// <summary>
        /// TC 2 class not found
        /// </summary>
        [TestMethod]
        [TestCategory("objectCreationClassException")]
        public void ObjectCreationUsingReflectionClassException()
        {
            Object obj = null;
            MoodAnalyse mood = new MoodAnalyse();
            try
            {
                MoodAnalyserFactory moodAnalyse = new MoodAnalyserFactory();
                obj = moodAnalyse.CreateMoodAnalyserObject("MoodAnalyser.MoodAnalyse", "MoodAnalyse");
            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(mood);
        }
        /// <summary>
        /// TC3 constructor not found
        /// </summary>
        [TestMethod]
        [TestCategory("objectCreationConstructorException")]
        public void ObjectCreationUsingReflectionConstructorException()
        {
            Object obj = null;
            MoodAnalyse mood = new MoodAnalyse();
            try
            {
                MoodAnalyserFactory moodAnalyse = new MoodAnalyserFactory();
                obj = moodAnalyse.CreateMoodAnalyserObject("MoodAnalyser.MoodAnalyse", "MoodAnalyse");
            }
            catch (CustomMoodAnalyserException e)
            {
                throw new Exception(e.Message);
            }
            obj.Equals(mood);
        }
        //-----------------------------------UC5------------------------------------------
        /// <summary>
        /// TC1 - Object creation of parameterized constructor 
        /// </summary>
        [TestMethod]
        [TestCategory("ParameterizedConstructor")]
        public void ObjectCreationParameterizedConstructor()
        {
            Object obj;
            MoodAnalyse mood = new MoodAnalyse("I am in a happy mood");
            try
            {
                obj = MoodAnalyserFactory.CreateMoodAnalyserParameterizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyse", "I am in a happy mood");
            }
            catch (CustomMoodAnalyserException ex)
            {
                throw new Exception(ex.Message);
            }
            obj.Equals(mood);
        }
        /// <summary>
        /// TC2 - Object creation of parameterized constructor class not found exception
        /// </summary>
        [TestMethod]
        [TestCategory("ParameterizedConstructorClassException")]
        public void ObjectCreationParameterizedConstructorClassException()
        {
            Object obj;
            MoodAnalyse mood = new MoodAnalyse("I am in a happy mood");
            try
            {
                obj = MoodAnalyserFactory.CreateMoodAnalyserParameterizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyse", "I am in a happy mood");
            }
            catch (CustomMoodAnalyserException ex)
            {
                throw new Exception(ex.Message);
            }
            obj.Equals(mood);
        }
        /// <summary>
        /// TC3 - Object creation of parameterized constructor class not found exception
        /// </summary>
        [TestMethod]
        [TestCategory("ParameterizedConstructorClassException")]
        public void ObjectCreationParameterizedConstructorCOnstructorException()
        {
            Object obj;
            MoodAnalyse mood = new MoodAnalyse("I am in a happy mood");
            try
            {
                obj = MoodAnalyserFactory.CreateMoodAnalyserParameterizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyse", "I am in a happy mood");
            }
            catch (CustomMoodAnalyserException ex)
            {
                throw new Exception(ex.Message);
            }
            obj.Equals(mood);
        }
        //----------------------------------UC6-------------------------------------
        [TestMethod]
        [TestCategory("InvokeAnalyseMood")]
        public void InvokeAnalyseMoodReturnsHappy()
        {
            // TC 6.1
            string message = "HAPPY";
            string methodName = "CheckMood";
            string actual = MoodAnalyserFactory.InvokeAnalyseMood(message, methodName);
            Assert.AreEqual("happy", actual);
        }
        [TestMethod]
        [TestCategory("InvokeAnalyseMood")]
        public void InvokeAnalyseMoodReturnsNoSuchMethod()
        {
            try
            {
                // TC 6.2
                string message = "HAPPY";
                string methodName = "MethodName";
                string actual = MoodAnalyserFactory.InvokeAnalyseMood(message, methodName);
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual("wrong method name", ex.Message);
            }
        }
    }

}
