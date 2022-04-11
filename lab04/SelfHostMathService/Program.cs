using CalcServiceLibrary;
using MathServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostMathService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceSelfHostMathLibrary = null, serviceSelfHostCalcLibrary = null;

            try
            {
                serviceSelfHostMathLibrary = new ServiceHost(typeof(MathService));
                serviceSelfHostCalcLibrary = new ServiceHost(typeof(CalcService));

                //serviceSelfHostMathLibrary.AddServiceEndpoint(
                //    typeof(IMathService),
                //    new BasicHttpBinding(),
                //    "http://localhost:4444/MathService");

                //serviceSelfHostCalcLibrary.AddServiceEndpoint(
                //    typeof(ICalcService),
                //    new BasicHttpBinding(),
                //    "http://localhost:5555/CalcService");

                serviceSelfHostMathLibrary.Open();
                serviceSelfHostCalcLibrary.Open();

                Console.WriteLine("Hosting został uruchomiony");
                Console.WriteLine("Serwisy nasłuchują żądań klientów na adresach:");
                Console.WriteLine();

                foreach (var serviceSelfHostEndpoint in serviceSelfHostMathLibrary.Description.Endpoints)
                {
                    Console.WriteLine($"Adres: {serviceSelfHostEndpoint.Address} Wiązanie: {serviceSelfHostEndpoint.Binding.Name}");
                }

                foreach (var serviceSelfHostEndpoint in serviceSelfHostCalcLibrary.Description.Endpoints)
                {
                    Console.WriteLine($"Adres: {serviceSelfHostEndpoint.Address} Wiązanie: {serviceSelfHostEndpoint.Binding.Name}");
                }

                Console.WriteLine();
                Console.WriteLine("Wciśnięcie dowolnego klawisza kończy pracę");
                Console.ReadKey();

                serviceSelfHostMathLibrary.Close();
                serviceSelfHostCalcLibrary.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            finally
            {
                if (serviceSelfHostMathLibrary != null && serviceSelfHostMathLibrary.State == CommunicationState.Opened) 
                    serviceSelfHostMathLibrary.Close();
                
                if (serviceSelfHostCalcLibrary != null && serviceSelfHostCalcLibrary.State == CommunicationState.Opened) 
                    serviceSelfHostCalcLibrary.Close();
            }
        }
    }
}
