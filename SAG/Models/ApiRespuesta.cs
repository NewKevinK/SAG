using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAG.Models
{
    public class ApiRespuesta
    {
        //atributos: Action, Result, Message, Data
        public string Action { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public List<string> DataList { get; set; }
        public ApiRespuesta() {
        }
        public ApiRespuesta(string action, string result, string message, object data, List<string> dataList)
        {
            Action = action;
            Result = result;
            Message = message;
            Data = data;
            DataList = dataList;
        }
    }
}