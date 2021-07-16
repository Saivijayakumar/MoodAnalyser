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
            catch (CustomMoodAnalyser ex)
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
            catch (CustomMoodAnalyser ex)
            {
                string expected = "Message should not be Empty";
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
    
}
