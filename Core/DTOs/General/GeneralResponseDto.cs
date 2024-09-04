namespace CQRS_and_MediatR.Core.DTOs.General
{
    public class GeneralResponseDto
    {
        public bool IsSucceed { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }


    }
}
