using Newtonsoft.Json;

namespace AdidasModels.Solution
{
    /// <summary>
    /// Api returns the result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>: IApiResult<T>
    {
        /// <summary>
        /// Is it successful?
        /// </summary>
        [JsonIgnore]
        public bool Success {get; private set;}

        /// <summary>
        /// status code
        /// </summary>
        public int Code => Success? 1: 0;

        /// <summary>
        /// news
        /// </summary>
        public string Msg {get; private set;}

        /// <summary>
        /// data
        /// </summary>
        public T Data {get; private set;}

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="msg">Message</param>
        public ApiResult<T> Ok(T data, string msg = null)
        {
            Success = true;
            Data = data;
            Msg = msg;
            return this;
        }

        /// <summary>
        /// failed
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="data">data</param>
        /// <returns></returns>
        public ApiResult<T> NotOk(string msg = null, T data = default(T))
        {
            Success = false;
            Msg = msg;
            Data = data;
            return this;
        }
    }


    /// <summary>
    /// Return result
    /// </summary>
    public static partial class ApiResult
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="msg">Message</param>
        /// <returns></returns>
        public static IApiResult Ok<T>(T data = default(T), string msg = null)
        {
            return new ApiResult<T>().Ok(data, msg);
        }

        /// <summary>
        /// Success
        /// </summary>
        /// <returns></returns>
        public static IApiResult Ok()
        {
            return Ok<string>();
        }

        /// <summary>
        /// failed
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="data">data</param>
        /// <returns></returns>
        public static IApiResult NotOk<T>(string msg = null, T data = default(T))
        {
            return new ApiResult<T>().NotOk(msg, data);
        }

        /// <summary>
        /// failed
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns></returns>
        public static IApiResult NotOk(string msg = null)
        {
            return new ApiResult<string>().NotOk(msg);
        }

        /// <summary>
        /// Return the result according to the boolean value
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        public static IApiResult Result<T>(bool success)
        {
            return success? Ok<T>(): NotOk<T>();
        }

        /// <summary>
        /// Return the result according to the boolean value
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        public static IApiResult Result(bool success)
        {
            return success? Ok(): NotOk();
        }
    }
}
