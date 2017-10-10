using System;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerApp
{
    public class FileController : ApiController
    {
        public async Task<Response> Post()
        {
            List<ResponseData> responseData = new List<ResponseData>();

            try
            {
                // Server app is OWIN self-hosted so getting relative path to save file must be done like this?
                string path = Helpers.ResolveRelativePath()+"\\sample.txt";

                   var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                    foreach (var stream in filesReadToProvider.Contents)
                    {
                        var fileBytes = await stream.ReadAsByteArrayAsync();
                        var str = System.Text.Encoding.Default.GetString(fileBytes);
                        Helpers.SaveFileToDisk(path, str);
                        responseData = Helpers.ParseFileToResponse(str);
                    }

            }
            
            catch (CustomException cex)
            {
                 return new Response { Status = cex.ErrorCode, Message = cex.ErrorMessage };
            }
            catch (Exception ex)
            {
                 return new Response { Status = 500, Message = "File is invalid" };
            }

            return new Response { Status = 200, Message = "OK", Data=responseData};

    }


        [HttpGet]
        public Response Random()
        {
            var response = new List<ResponseData>();

            try
            {
                response = Helpers.GenerateRandomData();
            }
            catch (Exception)
            {

                throw;
            }

            return new Response { Status = 200, Message = "OK", Data = response };
        }
  
    }
}
