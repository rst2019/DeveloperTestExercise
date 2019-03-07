using System;
using FileDetails;
using ThirdPartyTools;
namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            FileDatFetchRules fetch = new FileDatFetchRules();
             string result =  fetch.GetFileDetails(args[0], args[1]);
            Console.WriteLine(result);
            Console.Read();            
        }
    }
}
