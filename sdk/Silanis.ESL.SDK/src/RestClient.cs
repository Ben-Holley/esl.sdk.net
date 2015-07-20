using System;
using Silanis.ESL.SDK.Internal;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	public class RestClient
    {
        private string apiToken;
		private AuthHeaderGenerator headerGen;
        private Support support = new Support();

        private ProxyConfiguration proxyConfiguration;
        private readonly Boolean allowAllSSLCertificates;

        public RestClient(string apiToken) : this(apiToken, false){}

        public RestClient(string apiToken, Boolean allowAllSSLCertificates)
            : this(apiToken, allowAllSSLCertificates, null) {}

        public RestClient(string apiToken, ProxyConfiguration proxyConfiguration)
            : this(apiToken, false, proxyConfiguration){}

        public RestClient(string apiToken, Boolean allowAllSSLCertificates, ProxyConfiguration proxyConfiguration) {
            this.apiToken = apiToken;
            this.allowAllSSLCertificates = allowAllSSLCertificates;
            this.proxyConfiguration = proxyConfiguration;
        }

        public string Post(string path, string jsonPayload) {
            support.LogRequest("POST", path, jsonPayload);

			byte[] payloadBytes = null;
			if (jsonPayload != null)
			{
				payloadBytes = Converter.ToBytes(jsonPayload);
			}
			else
			{
				payloadBytes = new byte[0];
			}

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

			byte[] responseBytes = HttpMethods.PostHttp(apiToken, path, payloadBytes);
            
            String response = Converter.ToString(responseBytes);
            support.LogResponse(response);

            return response;
        }

        public string Put(string path, string jsonPayload) {
            support.LogRequest("PUT", path, jsonPayload);

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

            byte[] responseBytes = HttpMethods.PutHttp(apiToken, path, Converter.ToBytes(jsonPayload));
            string response = Converter.ToString(responseBytes);
            support.LogResponse(response);
            return response;
        }

        public string PostMultipartFile(string path, byte[] fileBytes, string boundary, string json) {
            support.LogRequest("POST", path, json);

            headerGen = new ApiTokenAuthHeaderGenerator(apiToken);

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

			byte[] responseBytes = HttpMethods.MultipartPostHttp(apiToken, path, fileBytes, boundary, headerGen);
            string response = Converter.ToString(responseBytes);
            support.LogResponse(response);

            return response;
        }

        public string PostMultipartFile(string path, byte[] fileBytes, string boundary, string sessionId, string json) {
            support.LogRequest("POST", path, json);

            headerGen = new SessionIdAuthHeaderGenerator(sessionId);

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

			byte[] responseBytes = HttpMethods.MultipartPostHttp(apiToken, path, fileBytes, boundary, headerGen);
            string response = Converter.ToString(responseBytes);
            support.LogResponse(response);

            return response;
		}

        public string PostMultipartPackage(string path, byte[] content, string boundary, string json) {
            support.LogRequest("POST", path, json);

            headerGen = new ApiTokenAuthHeaderGenerator(apiToken);

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

            byte[] responseBytes = HttpMethods.MultipartPostHttp(apiToken, path, content, boundary, headerGen);
            string response = Converter.ToString(responseBytes);
            support.LogResponse(response);

            return response;
        }

        public string Get(string path) {
            support.LogRequest("GET", path);

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

            DownloadedFile responseBytes = HttpMethods.GetHttpJson(apiToken, path, HttpMethods.ESL_ACCEPT_TYPE_APPLICATION_JSON);
            string response = Converter.ToString(responseBytes);
            support.LogResponse(response);

            return response;
        }
        
        public string Get(string path, string acceptType)
        {
            support.LogRequest("GET", path);

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

            DownloadedFile responseBytes = HttpMethods.GetHttpJson(apiToken, path, acceptType);
            return Converter.ToString(responseBytes);
        }

        public DownloadedFile GetBytes(string path) {
            support.LogRequest("GET", path);

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

            return HttpMethods.GetHttp(apiToken, path);
        }

        public DownloadedFile GetHttpAsOctetStream(string path) {
            support.LogRequest("GET", path);

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

            return HttpMethods.GetHttpAsOctetStream(apiToken, path);
        }

        public string Delete(string path) {
            support.LogRequest("DELETE", path);

            if (proxyConfiguration != null) 
                HttpMethods.proxyConfiguration = proxyConfiguration;

            byte[] responseBytes = HttpMethods.DeleteHttp(apiToken, path);
            string response = Converter.ToString(responseBytes);
            support.LogResponse(response);

            return response;
        }

    }
}

