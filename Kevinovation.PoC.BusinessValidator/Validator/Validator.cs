using Kevinovation.PoC.BusinessValidator.Library;
using Kevinovation.PoC.BusinessValidator.Validator.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kevinovation.PoC.BusinessValidator.Validator
{
    public abstract class Validator<T> : IValidator<T>, IDisposable where T : class
    {
        protected ValidatorResult validatorResult = new ValidatorResult();

        public ValidatorResult Validate(T entity, ENUMContexteValidation peContexteValidation)
        {
            //>Declaration
            object[] loParams = { entity };
            var lloResultExecutedMethods = new Dictionary<String, bool>();
            var blnIsResultValid = true;

            //>Check
            if (entity is null)
                throw new ArgumentNullException();

            //>Process
            var lloMethods = this.GetType().GetTypeInfo().DeclaredMethods.Where(poMethod => !poMethod.GetCustomAttributes().Any(poCustomAttribute => poCustomAttribute.GetType() == typeof(IsDisabledValidatorAttribute))).ToList();

            foreach (var loOrderFunction in lloMethods)
            {
                // on verifie la présence du contexte de validation
                if (loOrderFunction.GetCustomAttributes<ContexteValidationAttribute>().Any() 
                    && !loOrderFunction.GetCustomAttributes<ContexteValidationAttribute>().Any(poAttribut => ((ContexteValidationAttribute)poAttribut).ContexteValidation == peContexteValidation))
                    continue;

                // pour chacun des attributs de la fonction
                foreach (PredicatValidatorAttribute loAttribute in loOrderFunction.GetCustomAttributes(typeof(PredicatValidatorAttribute)))
                {
                    // verifie si la fonction devant être executé avant a déjà été traitée
                    if (lloResultExecutedMethods.TryGetValue(loAttribute.MethodName, out blnIsResultValid))
                    {
                        if (!blnIsResultValid)
                            break;
                    }
                    // sinon on la traite
                    else
                    {
                        this.GetType().GetMethod(loAttribute.MethodName).Invoke(this, loParams);
                        lloResultExecutedMethods.Add(loAttribute.MethodName, validatorResult.IsValid);
                    }
                }
                // si un des predicats n'est pas valide on ne traite pas la fonction
                if (blnIsResultValid)
                {
                    loOrderFunction.Invoke(this, loParams);
                    lloResultExecutedMethods.Add(loOrderFunction.Name, validatorResult.IsValid);
                }
            }

            //>Return
            return this.validatorResult;
        }

        #region IDisposable Support

        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés).
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~Validator() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        void IDisposable.Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}