using System.Net;

namespace Models.Responses.Base
{
    public class GenericResponse<Model>
    {
        public Model Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public GenericResponse(Model data)
        {
            Data = data;
            StatusCode = HttpStatusCode.OK;
            ErrorMessage = null;
        }

        public GenericResponse()
        {
            Data = default(Model);
            StatusCode = HttpStatusCode.InternalServerError;
            ErrorMessage = null;
        }

        public GenericResponse<Model> CreatedWithSucess()
        {
            StatusCode = HttpStatusCode.Created;
            return this;
        }

        public GenericResponse<Model> Error(HttpStatusCode httpStatusCodeError, string errorMessage)
        {
            Data = default(Model);
            StatusCode = httpStatusCodeError;
            ErrorMessage = errorMessage;
            return this;
        }
    }
}
