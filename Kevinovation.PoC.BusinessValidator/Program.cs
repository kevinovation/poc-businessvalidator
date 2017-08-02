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
            
            var loClient = new Client();
            loClient.Name = string.Empty;
            loClient.Contacts.Add(new Contact());

            ValiderCreation(loClient);
            ValiderModification(loClient);

            Thread.CurrentThread.Join(10000);
        }

        static void ValiderCreation(Client poClient)
        {
            ValidatorResult result;

            Console.WriteLine("CREATION");
            using (var loValidator = new ClientValidator())
            {
                result = loValidator.Validate(poClient, ENUMContexteValidation.Creation);
            }

            Console.WriteLine(result.ToString());
        }

        static void ValiderModification(Client poClient)
        {
            ValidatorResult result;

            Console.WriteLine("MODIFICATION");
            using (var loValidator = new ClientValidator())
            {
                result = loValidator.Validate(poClient, ENUMContexteValidation.Modification);
            }

            Console.WriteLine(result.ToString());
        }

        static private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IValidator<Client>, ClientValidator>();
        }
    }
}