﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Roger.ParseTheParcel.Domain.Models.Languages {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ShippingMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ShippingMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Roger.ParseTheParcel.Domain.Models.Languages.ShippingMessages", typeof(ShippingMessages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please, insert valid breadth..
        /// </summary>
        public static string InsertValidBreadth {
            get {
                return ResourceManager.GetString("InsertValidBreadth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please, insert valid height..
        /// </summary>
        public static string InsertValidHeight {
            get {
                return ResourceManager.GetString("InsertValidHeight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please, insert valid length..
        /// </summary>
        public static string InsertValidLength {
            get {
                return ResourceManager.GetString("InsertValidLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please, insert valid weight..
        /// </summary>
        public static string InsertValidWeight {
            get {
                return ResourceManager.GetString("InsertValidWeight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, your package are oversized. Please, insert valid dimensions..
        /// </summary>
        public static string PackageOversized {
            get {
                return ResourceManager.GetString("PackageOversized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your package was successfully calculated..
        /// </summary>
        public static string PackageSuccessfullyCalculated {
            get {
                return ResourceManager.GetString("PackageSuccessfullyCalculated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, your package are too heavy. Please, insert valid weight..
        /// </summary>
        public static string PackageTooHeavy {
            get {
                return ResourceManager.GetString("PackageTooHeavy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We were unable to identify the size of your package, please check the dimensions inserted..
        /// </summary>
        public static string UnableIdentifySize {
            get {
                return ResourceManager.GetString("UnableIdentifySize", resourceCulture);
            }
        }
    }
}
