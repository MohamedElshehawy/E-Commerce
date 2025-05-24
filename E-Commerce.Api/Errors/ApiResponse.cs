
namespace E_Commerce.Api.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        

        public ApiResponse(int statusCode, string? errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetErrorMessageForStatusCode(statusCode );
        }

        private string? GetErrorMessageForStatusCode(int statusCode)
          => statusCode switch
          {
              500 => "Internal Server Error" ,
              404 => "Not Found" ,
              401 => "Un Autharized " , 
              400 => "Bad Request" ,
              _ => ""

          };
    }
}
