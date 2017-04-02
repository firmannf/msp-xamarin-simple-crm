using CRM_Apps.Helper;
using CRM_Apps.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Apps.Service
{
    public class DataService
    {
        public async Task<List<Sale>> GetListSales()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var builder = new UriBuilder(new Uri(UrlHelper.SALES_URL));
                    var response = await client.GetAsync(builder.Uri);
                    if (!response.IsSuccessStatusCode)
                        return null;
                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);
                    var modelResult = JsonConvert.DeserializeObject<List<Sale>>(result);
                    return modelResult;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<List<Customer>> GetListCustomers()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var builder = new UriBuilder(new Uri(UrlHelper.CUSTOMERS_URL));
                    var response = await client.GetAsync(builder.Uri);
                    if (!response.IsSuccessStatusCode)
                        return null;
                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);
                    var modelResult = JsonConvert.DeserializeObject<List<Customer>>(result);
                    return modelResult;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<bool> Login(string username, string password)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    var loginDict = new Dictionary<string, string> { { "username", username }, { "password", password } };
                    var postData = JsonConvert.SerializeObject(loginDict);
                    HttpContent stringContent = new StringContent(postData);
                    stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var builder = new UriBuilder(new Uri(UrlHelper.LOGIN_URL));
                    var response = await client.PostAsync(builder.Uri, stringContent);
                    if (!response.IsSuccessStatusCode)
                        return false;
                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);
                    if (!result.Equals("true", StringComparison.OrdinalIgnoreCase))
                        return false;
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<bool> PostNewSale(Sale sale)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    var postData = JsonConvert.SerializeObject(sale);
                    HttpContent stringContent = new StringContent(postData);
                    stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var builder = new UriBuilder(new Uri(UrlHelper.SALES_URL));
                    var response = await client.PostAsync(builder.Uri, stringContent);
                    if (!response.IsSuccessStatusCode)
                        return false;
                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);
                    var modelResult = JsonConvert.DeserializeObject<Sale>(result);
                    if (modelResult == null)
                        return false;
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<bool> PostNewCustomer(Customer customer)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    var postData = JsonConvert.SerializeObject(customer);
                    HttpContent stringContent = new StringContent(postData);
                    stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var builder = new UriBuilder(new Uri(UrlHelper.CUSTOMERS_URL));
                    var response = await client.PostAsync(builder.Uri, stringContent);
                    if (!response.IsSuccessStatusCode)
                        return false;
                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);
                    var modelResult = JsonConvert.DeserializeObject<Customer>(result);
                    if (modelResult == null)
                        return false;
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


    }

}
