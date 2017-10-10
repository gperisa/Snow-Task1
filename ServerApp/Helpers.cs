using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace ServerApp
{
    public class Helpers
    {
        public static List<ResponseData> ParseFileToResponse(string str)
        {

            List<ResponseData> response = new List<ResponseData>();

            try
            {
                var rows = str.Split('#').ToList();
                rows.RemoveAt(0);

                foreach (var item in rows)
                {
                    ResponseData data = new ResponseData();
                    var temp = item.Replace("\r\n", "").Replace("#", "");
                    var elements = temp.Split(':').ToList();
                    data.Name = elements[0];
                    data.Color = elements[1];
                    data.Value = Convert.ToInt32(elements[2]);

                    response.Add(data);
                }
            }
            catch (Exception)
            {
                throw new CustomException(ExceptionType.ParsingError, 222, "Parsing error occured!");
            }

            return response;
        }


        public static void SaveFileToDisk(string path, string str)
        {
            try
            {
                File.WriteAllText(path, str);
            }
            catch (Exception ex)
            {
                throw new CustomException(ExceptionType.FileWriteError, 111, "Error while saving to disk!");
            }
        }

        public static List<ResponseData> GenerateRandomData()
        {
            List<ResponseData> list = new List<ResponseData>();

            try
            {
                string[] names = new string[] { "A", "B", "C", "D", "E" };
                string[] colors = new string[] { "Red", "Blue", "Green", "Yellow", "Orange" };
                Random r = new Random();
                for (int i = 0; i < 5; i++)
                {
                    list.Add(new ResponseData { Name = names[i], Color = colors[i], Value = r.Next(0, 100) });
                }
            }
            catch (Exception)
            {

            }

            return list;

        }

        public static string ResolveRelativePath()
        {
            var path = HostingEnvironment.MapPath("~/content");

            try
            {
                if (path == null)
                {
                    var uriPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    path = new Uri(uriPath).LocalPath.Replace("bin\\Debug", "Uploads");
                }
            }
            catch (Exception)
            {

            }

            return path;
        }

    }
}
