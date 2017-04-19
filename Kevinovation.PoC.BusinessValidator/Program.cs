using Kevinovation.PoC.BusinessValidator.Entity;
using Kevinovation.PoC.BusinessValidator.Library;
using Kevinovation.PoC.BusinessValidator.Validator;
using Kevinovation.PoC.BusinessValidator.Validator.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Kevinovation.PoC.BusinessValidator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            ValidatorResult result;
            var loClient = new Client();
            loClient.Name = string.Empty;
            loClient.Contacts.Add(new Contact());

            using (var loValidator = new ClientValidator())
            {
                result = loValidator.Validate(loClient);
            }

            Console.WriteLine(result.ToString());

            Thread.CurrentThread.Join(10000);
        }

        static private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IValidator, ClientValidator>();
        }
    }
}