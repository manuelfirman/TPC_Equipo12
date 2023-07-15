using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Negocio
{

    public class PaypalOrden
    {
        public string intent { get; set; }
        public List<PurchaseUnit> purchase_units { get; set; }
        public PaymentSource payment_source { get; set; }
    }

    public class Amount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public class ExperienceContext
    {
        public string payment_method_preference { get; set; }
        public string payment_method_selected { get; set; }
        public string brand_name { get; set; }
        public string locale { get; set; }
        public string landing_page { get; set; }
        public string shipping_preference { get; set; }
        public string user_action { get; set; }
        public string return_url { get; set; }
        public string cancel_url { get; set; }
    }

    public class PaymentSource
    {
        public Paypal paypal { get; set; }
    }

    public class Paypal
    {
        public ExperienceContext experience_context { get; set; }
    }

    public class PurchaseUnit
    {
        public string reference_id { get; set; }
        public Amount amount { get; set; }
    }

    public class PaypalNegocio
    {
        public async Task<JObject> Paypalfunction(string precio, string IDVenta)
        {
            bool status = false;
            string respuesta = string.Empty;

            using (var client = new HttpClient())
            {
                string userName = "AW-ETAb71gWsR6uAAazGjddGNuzJF5az3eKZ7o0QTvYe0jwvUZcNHHI5Z9-x3GXxmcy-suRSdVWMG71X";
                string password = "EJXOgL9pLb1eR6MYOyccSePSBdjlawQDDOHzC80-rgrDVFNjzO7-OivRdqTkwi1DjWYg1I54IVGs-dEo";

                client.BaseAddress = new Uri("https://api-m.sandbox.paypal.com");
                var authToken = Encoding.ASCII.GetBytes($"{userName}:{password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var orden = new PaypalOrden()
                {
                    intent = "CAPTURE",
                    purchase_units = new List<PurchaseUnit>()
                {
                    new PurchaseUnit()
                    {
                        amount = new Amount()
                        {
                            currency_code = "USD",
                            value = precio
                        },
                        reference_id = IDVenta
                    }
                },
                    payment_source = new PaymentSource()
                    {
                        paypal = new Paypal()
                        {
                            experience_context = new ExperienceContext()
                            {
                                payment_method_selected = "PAYPAL",
                                brand_name = "E-COMMERCE12",
                                locale = "en-US",
                                landing_page = "LOGIN",
                                shipping_preference = "SET_PROVIDED_ADDRESS",
                                user_action = "PAY_NOW",
                                return_url = "https://localhost:44358/CompraRealizada.aspx",
                                cancel_url = "https://localhost:44358/Pago.aspx"
                            }
                        }
                    }
                };

                var json = JObject.FromObject(orden);
                var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/v2/checkout/orders", data);

                status = response.IsSuccessStatusCode;

                if (status) respuesta = response.Content.ReadAsStringAsync().Result;

            }

            return JObject.FromObject(new { status = status, respuesta = respuesta });

        }
    }


}
