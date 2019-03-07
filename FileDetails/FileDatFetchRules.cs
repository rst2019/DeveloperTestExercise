using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ThirdPartyTools;


namespace FileDetails
{
    public class FileDatFetchRules
    {
        ThirdPartyTools.FileDetails fd = new ThirdPartyTools.FileDetails();
        public string GetFileDetails(string input, string Filepath)
        {
            
            if (!string.IsNullOrEmpty(input) || !string.IsNullOrEmpty(Filepath))
            {
                List<string> _listVersion = ConfigurationManager.AppSettings["Versionpattern"].Split(',').ToList<string>();
                List<string> _ListSize = ConfigurationManager.AppSettings["Sizepattern"].Split(',').ToList<string>();

                //string Versionpattern = @"([-/Vv])";
                //string Sizepattern = @"([-/Ss])";
                //string VersionFullpattern = @"(version)";
                //string SizeFullpattern = @"(size
                //string FilePathpattern = @"(?:[\w]\:|\\)(\\[a-z_\-\s0-9\.]+)+\.(txt|gif|pdf|doc|docx|xls|xlsx)";         


                if (_listVersion.Count == 0)
                    throw new Exception("No valid version paramters specified in config setings");

                if (_ListSize.Count == 0)
                    throw new Exception("No valid size paramters specified in config setings");

                if (_listVersion.Contains(input))
                    return fd.Version(Filepath);

                if (_ListSize.Contains(input))
                    return fd.Size(Filepath).ToString();

                if (!_listVersion.Contains(input) || !_ListSize.Contains(input))
                    throw new Exception("Entered string is not a valid parameter");

            }
            return string.Empty;
        }
    }
}
