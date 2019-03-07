using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FileDetails;

namespace FileDetails.Lib.Test
{
    [TestFixture]
    public class FileDetailsTest
    {
        [Test]
        public void Given_validVersion_Return_version([Values("-v", "--v", "/v", "--version")] string input)
        {
            FileDatFetchRules fetch = new FileDatFetchRules();
            string output = fetch.GetFileDetails(input, "filepath");
            bool result = output.Contains('.');
            Assert.AreEqual(true, result);
        }
        [Test]
        public void Given_validSize_Return_Size([Values("-s", "--s", "/s", "--size")] string input)
        {
            FileDatFetchRules fetch = new FileDatFetchRules();
            string output = fetch.GetFileDetails(input, "filepath");
            bool result = output.Contains('.');
            Assert.AreEqual(false, result);
        }
        [Test]
        public void Given_Empty_Return_Null()
        {
            FileDatFetchRules fetch = new FileDatFetchRules();
            string result = fetch.GetFileDetails("", "");
            Assert.AreEqual("", result);
        }
        [Test]
        public void Given_Input_OutOfRange_throw_Exception()
        {
            FileDatFetchRules fetch = new FileDatFetchRules();
            string Input = "q";
            string Filepath = "";
            var ex = Assert.Throws<Exception>(() => fetch.GetFileDetails(Input, Filepath));
            Assert.AreEqual("Entered string is not a valid parameter", ex.Message);

        }
    }
}
