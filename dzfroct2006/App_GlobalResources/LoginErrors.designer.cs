//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LoginErrors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LoginErrors() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.LoginErrors", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cette adresse e-mail existe déjà. Merci de saisir une adresse différente..
        /// </summary>
        internal static string DuplicateEmail {
            get {
                return ResourceManager.GetString("DuplicateEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ce nom d&apos;utilisateur existe déjà. Merci d&apos;en choisir un autre..
        /// </summary>
        internal static string DuplicateUserName {
            get {
                return ResourceManager.GetString("DuplicateUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cette adresse e-mail existe déjà..
        /// </summary>
        internal static string EmailExisting {
            get {
                return ResourceManager.GetString("EmailExisting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password retrieval answer provided is invalid. Please check the value and try again..
        /// </summary>
        internal static string InvalidAnswer {
            get {
                return ResourceManager.GetString("InvalidAnswer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Merci de vérifier votre adresse e-mail..
        /// </summary>
        internal static string InvalidEmail {
            get {
                return ResourceManager.GetString("InvalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to l&apos;adresse e-mail est invalide. Merci de vérifier la valeur saisie..
        /// </summary>
        internal static string InvalidEmail1 {
            get {
                return ResourceManager.GetString("InvalidEmail1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Le mot de passe fourni est invalide..
        /// </summary>
        internal static string InvalidPassword {
            get {
                return ResourceManager.GetString("InvalidPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password retrieval question provided is invalid. Please check the value and try again..
        /// </summary>
        internal static string InvalidQuestion {
            get {
                return ResourceManager.GetString("InvalidQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Le nom d&apos;utilisateur est invalide. Merci de vérifier avant de réessayer..
        /// </summary>
        internal static string InvalidUserName {
            get {
                return ResourceManager.GetString("InvalidUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Le nom d&apos;utilisateur ou le mot de passe est incorrecte..
        /// </summary>
        internal static string LoginFailed {
            get {
                return ResourceManager.GetString("LoginFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Impossible de vous authentifier. Merci de réessayer plus tard. Si le problème pérsiste, contactez-nous..
        /// </summary>
        internal static string ProviderError {
            get {
                return ResourceManager.GetString("ProviderError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to s.
        /// </summary>
        internal static string String1 {
            get {
                return ResourceManager.GetString("String1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Une erreur inatendu s&apos;est produite . Verifiez vos entrées et réessayertry and try again. Si le problème persisre contactez-nous..
        /// </summary>
        internal static string UnknownError {
            get {
                return ResourceManager.GetString("UnknownError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Impossible de créer le compte. Merci de v&amp;rifier vos entrées et de réessayer. Si le problème persisre contactez-nous..
        /// </summary>
        internal static string UserRejected {
            get {
                return ResourceManager.GetString("UserRejected", resourceCulture);
            }
        }
    }
}