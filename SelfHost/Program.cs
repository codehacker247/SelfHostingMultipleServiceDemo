using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathServiceLibrary;
using System.ServiceModel;
using System.ServiceModel.Description;
using CalcServiceLibrary;

namespace SelfHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var servicehost2 = new ServiceHost(typeof(CalcService)); 
            var servicehost = new ServiceHost(typeof(MathService));
            
            ServiceEndpoint BasicHttpEndPoint1 = servicehost.AddServiceEndpoint(
            typeof(IMathService),
            new BasicHttpBinding(),
            "http://localhost:4444/MathService");

            ServiceEndpoint BasicHttpEndPoint2 = servicehost2.AddServiceEndpoint(
            typeof(ICalcService),
            new BasicHttpBinding(),
            "http://localhost:5555/CalcService");

            servicehost.Open();
            servicehost2.Open();

            Console.WriteLine("Your WCF Service is running");
            foreach(ServiceEndpoint endpoint in servicehost.Description.Endpoints)
            {
                Console.WriteLine("Host 1 Details:- Address : {0} Binding Name : {1}",endpoint.Address.ToString(),endpoint.Binding.Name);
            }
            foreach (ServiceEndpoint endpoint2 in servicehost.Description.Endpoints)
            {
                Console.WriteLine("Host 2 Details:- Address : {0} Binding Name : {1}", endpoint2.Address.ToString(), endpoint2.Binding.Name);
            }
            Console.WriteLine("Press any key to stop your WCF Math Service.");
            Console.ReadKey();  

            servicehost.Close();    
            servicehost2.Close();   
        }
    }
}