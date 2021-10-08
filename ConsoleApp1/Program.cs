using System;
using System.IO;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //to run every 1000 s
            //windows application
            while (true)
            {

                delete();
                Thread.Sleep(100000);
            }
            
        }
        public static void delete()
        {
            //get all files from folder and insert it to array of string
            //string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Files/");
            string[] files = Directory.GetFiles(Path.GetDirectoryName(@"C:\Users\DELL\Downloads\Documents\"));
            //to get all element in files 
            foreach (var file in files)
            {
                //to get file info s fileinfo object
                FileInfo fileInfo = new FileInfo(file);
                //to get end of country index
                int _Index = fileInfo.Name.IndexOf('_') > -1 ? fileInfo.Name.IndexOf('_') : 0;
                //to get date form name
                int dotIndex = fileInfo.Name.IndexOf('.');
                var date = fileInfo.Name.Substring((_Index + 1), (dotIndex - _Index) - 1);
                //to get country name from file name
                var country = fileInfo.Name.Substring(0, _Index);
                //for loop in files
                foreach (var fileL in files)
                {
                    FileInfo fileInfoL = new FileInfo(fileL);
                    int _IndexL = fileInfoL.Name.IndexOf('_') > -1 ? fileInfoL.Name.IndexOf('_') : 0;
                    var countryL = fileInfoL.Name.Substring(0, _IndexL);
                    //to get date form name
                    int dotIndexL = fileInfoL.Name.IndexOf('.');
                    var dateL = fileInfoL.Name.Substring((_IndexL + 1), (dotIndexL - _IndexL) - 1);
                    //to check country name same or not
                    if (country.ToLower() == countryL.ToLower() && country != "" && countryL != "")
                    {
                        if (double.Parse(date) > double.Parse(dateL))
                           fileInfoL.Delete();
                    }

                }

            }
            Console.WriteLine("successfully deleted old files");
        }
    }
}
