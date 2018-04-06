using Amazon.Lambda.Core;
using System;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AwsDotnetCsharp
{
    public class Handler
    {
       public Response Hello()
       {
         var items = new List<string>();
         for (var i = 0; i < 1000; i++){
           items.Add()
         }
           return new Response(Guid.NewGuid().ToString() + ' ' + DateTime.UtcNow.ToString());
       }
    }

    public class Response
    {
      public string Message {get; set;}

      public Response(string message){
        Message = message;
      }
    }
}
