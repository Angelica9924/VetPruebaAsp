using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using Vet.Models;

namespace Vet.Controllers.Mail
{
    public class MailController
    {
        public async void SendEmailAsync()
        {
            try
            {
                //URL destino del POST
                string url= "https://api.mailersend.com/v1/email";

                //Token de autorización
                string jwtToken = "mlsn.770d8d984da913d51fc275047d93c229dfec51f7c352617dabf1662d4d84161a";

                //Objeto para contener los datos del msj del mail
                var emailMessage = new Email
                {
                    from = new From {email = "newquote@trial-z3m5jgryyno4dpyo.mlsender.net"},
                    to =new[]
                    {
                        new To {email = "angelicamartinez.c@outlook.com"}
                    },
                    subject = "New quote",
                    text = "your appointment has been scheduled",
                    html = "your appointment has been scheduled"
                };
            

                //Serializar el objeto en formato JSON
                string jsonBody = JsonSerializer.Serialize(emailMessage);
                //Crear el objeto HttpClient para realizar la solicitud HTTP
                using (HttpClient client = new HttpClient())
                {
                    //Configurar el encabezado Content-Type para indicar que el cuerpo es JSON
                    client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                    //Configurar el encabezado Authorization para indicar el token de autorización
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");
                    //Crear el contenido de la solicitud POST como StringContent
                    StringContent content= new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    //Realizar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    //Verificar si la solicitud fue exitosa (200-299)
                    if(response.IsSuccessStatusCode)
                    {
                        //Leer la respuesta como una cadena
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor:");
                        Console.WriteLine(responseBody);
                    }else{
                        Console.WriteLine($"La solicitud falló con el codigo de estado:{response.StatusCode}");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}