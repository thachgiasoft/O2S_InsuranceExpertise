using Newtonsoft.Json;
using O2S_InsuranceExpertise.Common.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace O2S_InsuranceExpertise.Common.WebApiClient
{
    /// <summary>
    /// Class de goi cac API do server back-end cung cap
    /// </summary>
    public class ApiConsumer
    {
        private const string API_PARAM = "param";
        private const int TIME_OUT = 60000;//thoi gian timeout tinh theo miliseconds (1ph)
        private string baseUri = null;
        private string token = null;
        private string applicationCode = null;

        /// <summary>
        /// Khoi tao voi tham so truyen vao la base uri cua api do server back-end cung cap
        /// </summary>
        /// <param name="baseUri">BaseUri cua server back-end</param>
        public ApiConsumer(string baseUri, string applicationCode)
        {
            //Cau hinh JsonConvert
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            this.baseUri = baseUri;
            this.applicationCode = applicationCode;
        }

        /// <summary>
        /// Khoi tao voi tham so truyen vao la base uri cua api do server back-end cung cap va tokenCode cua front-end
        /// </summary>
        /// <param name="baseUri">BaseUri cua server back-end</param>
        public ApiConsumer(string baseUri, string tokenCode, string applicationCode)
        {
            //Cau hinh JsonConvert
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            this.baseUri = baseUri;
            this.token = tokenCode;
            this.applicationCode = applicationCode;
        }

        /// <summary>
        /// Cap nhat tokenCode
        /// </summary>
        /// <param name="tokenCode"></param>
        public void SetTokenCode(string tokenCode)
        {
            this.token = tokenCode;
        }

        /// <summary>
        /// Cap nhat tokenCode
        /// </summary>
        /// <param name="tokenCode"></param>
        public void SetBaseUri(string baseUri)
        {
            this.baseUri = baseUri;
        }

        /// <summary>
        /// Get du lieu
        /// </summary>
        /// <typeparam name="T">Kieu du lieu mong muon tra ve</typeparam>
        /// <param name="uri">Uri cua API can goi</param>
        /// <param name="commonParam">Doi tuong commonParam</param>
        /// <param name="filter">Du lieu Filter</param>
        /// <param name="listParam">Danh sach cac tham so bo sung. Kieu du lieu phai la primitive</param>
        /// <returns></returns>
        /// <exceptions>Exception, ArgumentException, ApiException</exceptions>
        public T Get<T>(string uri, object commonParam, object filter, params object[] listParam)
        {
            T result = default(T);

            using (var client = new HttpClient())
            {
                string requestedUrl = "";
                this.HttpRequestBuilder(client, uri, ref requestedUrl, listParam);
                if (filter != null || commonParam != null)
                {
                    ApiParam apiParam = new ApiParam();
                    apiParam.CommonParam = commonParam;
                    apiParam.ApiData = filter;
                    string param = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(apiParam)));
                    requestedUrl += string.Format("{0}={1}", API_PARAM, param);
                }
                HttpResponseMessage resp = client.GetAsync(requestedUrl).Result;
                
                if (!resp.IsSuccessStatusCode)
                {
                    LogSystem.Error(string.Format("Loi khi goi API: {0}{1}. StatusCode: {2}", client.BaseAddress.AbsoluteUri, uri, resp.StatusCode.GetHashCode()));
                    throw new ApiException(resp.StatusCode);
                }

                string responseData = resp.Content.ReadAsStringAsync().Result;
                LogSystem.Debug(string.Format("responseData: {0}", responseData));
                result = JsonConvert.DeserializeObject<T>(responseData);
            }
            return result;
        }

        /// <summary>
        /// Get du lieu
        /// </summary>
        /// <param name="uri">Uri cua API can goi</param>
        /// <param name="commonParam">Doi tuong commonParam</param>
        /// <param name="filter">Du lieu Filter</param>
        /// <param name="listParam">Danh sach cac tham so bo sung. Kieu du lieu phai la primitive</param>
        /// <returns></returns>
        /// <exceptions>Exception, ArgumentException, ApiException</exceptions>
        //public FileHolder GetFile(string uri, object commonParam, object filter, params object[] listParam)
        //{
        //    FileHolder result = null;
        //    using (var client = new HttpClient())
        //    {
        //        string requestedUrl = "";
        //        this.HttpRequestBuilder(client, uri, ref requestedUrl, listParam);
        //        if (filter != null || commonParam != null)
        //        {
        //            ApiParam apiParam = new ApiParam();
        //            apiParam.CommonParam = commonParam;
        //            apiParam.ApiData = filter;
        //            requestedUrl += string.Format("{0}={1}&", API_PARAM, Uri.EscapeDataString(JsonConvert.SerializeObject(apiParam)));
        //        }
        //        HttpResponseMessage resp = client.GetAsync(requestedUrl).Result;
        //        if (!resp.IsSuccessStatusCode)
        //        {
        //            LogSystem.Error(string.Format("Loi khi goi API: {0}{1}. StatusCode: {2}", this.baseUri, uri, resp.StatusCode.GetHashCode()));
        //            throw new ApiException(resp.StatusCode);
        //        }
        //        if (resp.Content != null && resp.Content.Headers != null && resp.Content.Headers.ContentDisposition != null)
        //        {
        //            result = new FileHolder();
        //            result.FileName = resp.Content.Headers.ContentDisposition.FileName;
        //            result.Content = new MemoryStream(resp.Content.ReadAsByteArrayAsync().Result);
        //        }

        //    }
        //    return result;
        //}

        /// <summary>
        /// Post du lieu
        /// </summary>
        /// <typeparam name="T">Kieu du lieu mong muon tra ve</typeparam>
        /// <param name="uri">Uri cua API can goi</param>
        /// <param name="commonParam">Doi tuong commonParam</param>
        /// <param name="data">Du lieu can post</param>
        /// <param name="listParam">Danh sach cac tham so bo sung. Kieu du lieu phai la primitive</param>
        /// <returns></returns>
        /// <exceptions>Exception, ArgumentException, ApiException</exceptions>
        //public T Post<T>(string uri, object commonParam, object data, params object[] listParam)
        //{
        //    T result = default(T);
        //    using (var client = new HttpClient())
        //    {
        //        string requestedUrl = "";
        //        this.HttpRequestBuilder(client, uri, ref requestedUrl, listParam);

        //        ApiParam apiParam = new ApiParam();
        //        if (data != null || commonParam != null)
        //        {
        //            apiParam.CommonParam = commonParam;
        //            apiParam.ApiData = data;
        //        }
        //        HttpResponseMessage resp = client.PostAsJsonAsync(requestedUrl, apiParam).Result;
        //        if (!resp.IsSuccessStatusCode)
        //        {
        //            LogSystem.Error(string.Format("Loi khi goi API: {0}{1}. StatusCode: {2}", this.baseUri, uri, resp.StatusCode.GetHashCode()));
        //            throw new ApiException(resp.StatusCode);
        //        }
        //        string responseData = resp.Content.ReadAsStringAsync().Result;
        //        LogSystem.Debug(string.Format("responseData: {0}", responseData));
        //        result = JsonConvert.DeserializeObject<T>(responseData);
        //    }
        //    return result;
        //}

        /// <summary>
        /// Post du lieu co kem file
        /// </summary>
        /// <typeparam name="T">Kieu du lieu mong muon tra ve</typeparam>
        /// <param name="uri">Uri cua API can goi</param>
        /// <param name="commonParam">Doi tuong commonParam</param>
        /// <param name="data">Du lieu can post</param>
        /// <param name="files">Danh sach file can post</param>
        /// <param name="listParam">Danh sach cac tham so bo sung. Kieu du lieu phai la primitive</param>
        /// <returns></returns>
        /// <exceptions>Exception, ArgumentException, ApiException</exceptions>
        //public T PostWithFile<T>(string uri, object commonParam, object data, List<FileHolder> files, params object[] listParam)
        //{
        //    T result = default(T);
        //    using (var client = new HttpClient())
        //    {
        //        string requestedUrl = "";
        //        this.HttpRequestBuilder(client, uri, ref requestedUrl, listParam);

        //        ApiParam apiParam = new ApiParam();
        //        if (data != null || commonParam != null)
        //        {
        //            apiParam.CommonParam = commonParam;
        //            apiParam.ApiData = data;
        //        }
        //        using (var content = new MultipartFormDataContent())
        //        {
        //            foreach (FileHolder file in files)
        //            {
        //                content.Add(new StreamContent(file.Content), "File", file.FileName);
        //            }
        //            HttpContent stringContent = new StringContent(JsonConvert.SerializeObject(apiParam));
        //            content.Add(stringContent, "Data", "Data");

        //            using (HttpResponseMessage resp = client.PostAsync(requestedUrl, content).Result)
        //            {
        //                if (!resp.IsSuccessStatusCode)
        //                {
        //                    LogSystem.Error(string.Format("Loi khi goi API: {0}{1}. StatusCode: {2}", this.baseUri, uri, resp.StatusCode.GetHashCode()));
        //                    throw new ApiException(resp.StatusCode);
        //                }
        //                string responseData = resp.Content.ReadAsStringAsync().Result;
        //                LogSystem.Debug(string.Format("responseData: {0}", responseData));
        //                result = JsonConvert.DeserializeObject<T>(responseData);
        //            }
        //        }
        //    }
        //    return result;
        //}

        /// <summary>
        /// Put du lieu
        /// Exception: Exception, ArgumentException, ApiException
        /// </summary>
        /// <typeparam name="T">Kieu du lieu mong muon tra ve</typeparam>
        /// <param name="uri">Uri cua API can goi</param>
        /// <param name="commonParam">Doi tuong commonParam</param>
        /// <param name="data">Du lieu can put</param>
        /// <param name="listParam">Danh sach cac tham so bo sung. Kieu du lieu phai la primitive</param>
        /// <returns></returns>
        //public T Put<T>(string uri, object commonParam, object data, params object[] listParam)
        //{
        //    T result = default(T);
        //    using (var client = new HttpClient())
        //    {
        //        string requestedUrl = "";
        //        this.HttpRequestBuilder(client, uri, ref requestedUrl, listParam);

        //        ApiParam apiParam = new ApiParam();
        //        if (data != null || commonParam != null)
        //        {
        //            apiParam.CommonParam = commonParam;
        //            apiParam.ApiData = data;
        //        }
        //        HttpResponseMessage resp = client.PutAsJsonAsync(requestedUrl, apiParam).Result;
        //        if (!resp.IsSuccessStatusCode)
        //        {
        //            LogSystem.Error(string.Format("Loi khi goi API: {0}{1}. StatusCode: {2}", this.baseUri, uri, resp.StatusCode.GetHashCode()));
        //            throw new ApiException(resp.StatusCode);
        //        }
        //        string responseData = resp.Content.ReadAsStringAsync().Result;
        //        LogSystem.Debug(string.Format("responseData: {0}", responseData));
        //        result = JsonConvert.DeserializeObject<T>(responseData);
        //    }
        //    return result;
        //}

        /// <summary>
        /// Tao HttpRequest voi cac tham so cho truoc
        /// </summary>
        /// <param name="client"></param>
        /// <param name="uri"></param>
        /// <param name="requestedUrl"></param>
        /// <param name="listParam"></param>
        private void HttpRequestBuilder(HttpClient client, string uri, ref string requestedUrl, params object[] listParam)
        {
            //client.DefaultRequestHeaders.Add(HeaderConstants.TOKEN_PARAM, this.token);
            //client.DefaultRequestHeaders.Add(HeaderConstants.APPLICATION_CODE_PARAM, this.applicationCode);
            client.DefaultRequestHeaders.Add("", this.token);
            client.DefaultRequestHeaders.Add("", this.applicationCode);
            client.BaseAddress = new Uri(this.baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.Timeout = new TimeSpan(0, 0, TIME_OUT);

            requestedUrl = string.Format("{0}?", uri);
            if (listParam != null && listParam.Length > 0)
            {
                if (listParam.Length % 2 != 0)
                {
                    throw new ArgumentException("Danh sach param khong hop le. So luong param phai la so chan");
                }
                for (int i = 0; i < listParam.Length;)
                {
                    requestedUrl += string.Format("{0}={1}&", HttpUtility.UrlEncode(listParam[i] + ""), HttpUtility.UrlEncode(listParam[i + 1] + ""));
                    i = i + 2;
                }
            }
        }
    }
}
