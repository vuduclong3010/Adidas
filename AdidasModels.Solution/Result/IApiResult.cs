using Newtonsoft.Json;

namespace AdidasModels.Solution
{
     /// <summary>
     /// Return result interface
     /// </summary>
     public interface IApiResult
     {
         /// <summary>
         /// whether succeed
         /// </summary>
         [JsonIgnore]
         bool Success {get;}

         /// <summary>
         /// news
         /// </summary>
         public string Msg {get;}
     }

     /// <summary>
     /// Return result generic interface
     /// </summary>
     /// <typeparam name="T"></typeparam>
     public interface IApiResult<T>: IApiResult
     {
         /// <summary>
         /// Returned data
         /// </summary>
         T Data {get;}
     }
}
