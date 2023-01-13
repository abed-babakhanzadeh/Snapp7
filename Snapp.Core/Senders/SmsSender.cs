using System.Net.Http.Json;

namespace Snapp.Core.Senders
{
	public static class SmsSender
	{
		public static void VerifySend(string to, string mytext)
		{
			var strTo = to;
			var strMytext = mytext;

			//Uri apiBaseAddress = new Uri("https://console.melipayamak.com");

			//using (HttpClient client = new HttpClient() { BaseAddress = apiBaseAddress })
			//{
			//	// You may need to Install-Package Microsoft.AspNet.WebApi.Client
			//	// ReSharper disable once AsyncApostle.AsyncWait
			//	var result = client.PostAsJsonAsync("api/send/simple/b385f2214d2d48e9aa85a715b77e60fa",
			//		new { from = "50004000251251", to = strTo, text = strMytext }).Result;
			//	// ReSharper disable once AsyncApostle.AsyncWait
			//	var response = result.Content.ReadAsStringAsync().Result;
			//}



            Uri apiBaseAddress = new Uri("https://console.melipayamak.com");
            using (HttpClient client = new HttpClient() { BaseAddress = apiBaseAddress })
            {
                // You may need to Install-Package Microsoft.AspNet.WebApi.Client
                // ReSharper disable once AsyncApostle.AsyncWait
                var result = client.PostAsJsonAsync("api/send/shared/b385f2214d2d48e9aa85a715b77e60fa", 
                    new { bodyId = 42147, to = strTo, args = new[] {strMytext}}).Result;
                // ReSharper disable once AsyncApostle.AsyncWait
                var response = result.Content.ReadAsStringAsync().Result;
            }
		}


	}
}
