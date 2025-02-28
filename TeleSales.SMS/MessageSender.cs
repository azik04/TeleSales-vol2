using RestSharp;
using System.Text.Json;
using TeleSales.Core.Response;

namespace TeleSales.SMS
{
    public class MessageSender : IMessageService
    {
        private const string ApiKey = "73bac02c65287c292bdc6fde6f2b17aa-31a3c95b-789e-46d2-8bd0-40200d32d0be";

        public async Task<BaseResponse<bool>> WpSender(long fromNumber, long toNumber)
        {
            try
            {
                string number = toNumber.ToString();
                var client = new RestClient("https://api.infobip.com/whatsapp/1/message/text");
                var request = new RestRequest("", Method.Post);

                request.AddHeader("Authorization", $"App {ApiKey}");
                request.AddHeader("Content-Type", "application/json");

                var body = new
                {
                    messages = new[]
                    {
                        new
                        {
                            to = number,
                            from = "447491163443",
                            content = new
                            {
                                text = "Test TeleSales v1" // The actual text message you're sending
                            }
                        }
                   }
                };

                var jsonBody = JsonSerializer.Serialize(body);

                request.AddJsonBody(jsonBody);

                var response = await client.ExecuteAsync(request);

                if (!response.IsSuccessful)
                {
                    return new BaseResponse<bool>(false, false, $"Xəta: {response.Content}");
                }

                return new BaseResponse<bool>(true, true, "Wp Message sent successfully");
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(false, false, ex.Message);
            }
        }

        public async Task<BaseResponse<bool>> SmsSender(long fromNumber, long toNumber)
        {
            try
            {
                var client = new RestClient("https://api.infobip.com/sms/2/text/advanced");
                var request = new RestRequest("", Method.Post);

                request.AddHeader("Authorization", $"App {ApiKey}");
                request.AddHeader("Content-Type", "application/json");

                var body = new
                {
                    messages = new[]
                    {
                        new
                        {
                            destinations = new[] { new { to = $"+{toNumber}" } },
                            from = $"+{fromNumber}",
                            text = "Test TeleSales v1"
                        }
                    }
                };

                request.AddJsonBody(JsonSerializer.Serialize(body));
                var response = await client.ExecuteAsync(request);

                return new BaseResponse<bool>(true, true, "Sms Message sents successfully");

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(false, false, ex.Message);
            }
        }
    }
}
