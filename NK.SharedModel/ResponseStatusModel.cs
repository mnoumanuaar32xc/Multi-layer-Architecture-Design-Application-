using System;
using System.Collections.Generic;
using System.Text;

namespace NK.SharedModel
{

    public class ResponseStatusModel
    {
        public string Message { get; set; } = "";
        public bool IsSuccess { get; set; } = false;
        public bool IsMemory { get; set; }=false;   
        public List<string> references { get; set; } = new List<string>();
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();


        public Token Tokens { get; set; } = new Token();

        public class Token
        {

             public string TokenValue { get; set; }
        }

        public void SetAsSuccess()
        {
            IsSuccess = true;
        }
        public void SetAsSuccess(string message)
        {
            IsSuccess = true;
            Message = message;
        }
        public void SetAsSuccess(string message, string reference)
        {
            IsSuccess = true;
            Message = message;
            this.references = new List<string> { reference };
        }
        public void SetAsSuccess(string message, List<string> references)
        {
            IsSuccess = true;
            Message = message;
            this.references = references;
        }


        public void SetAsFailed(ErrorModel error)
        {
            IsSuccess = false;
            Errors.Add(error);
        }

        public void SetAsFailed(string message)
        {
            IsSuccess = false;
            Errors.Add(new ErrorModel { Message = message });
        }
        public void SetAsFailed(int code, string error)
        {
            IsSuccess = false;
            Errors.Add(new ErrorModel { Code = code.ToString(), Message = error });
        }

        public void SetAsFailed(List<ErrorModel> errors)
        {
            IsSuccess = false;
            Errors.AddRange(errors);
        }


    }
}
