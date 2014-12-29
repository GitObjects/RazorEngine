﻿using System;
using System.IO;
using System.Threading.Tasks;
namespace RazorEngine.Templating
{
    /// <summary>
    /// Defines the required contract for implementing a template.
    /// </summary>
    public interface ITemplate
    {
        #region Properties
        /// <summary>
        /// Sets the internal template service.
        /// </summary>
        IInternalTemplateService InternalTemplateService { set; }

        /// <summary>
        /// OBSOLETE: Sets the template service.
        /// </summary>
        [Obsolete("Only provided for backwards compatibility, use RazorEngine instead.")]
        ITemplateService TemplateService { set; }

        /// <summary>
        /// Sets the cached template service.
        /// </summary>
        IRazorEngineService RazorEngine { set; }

        #endregion

        #region Methods
        /// <summary>
        /// Set the model of the template (if applicable).
        /// </summary>
        /// <param name="model"></param>
        void SetModel(object model);

        /// <summary>
        /// Executes the compiled template.
        /// </summary>
#if RAZOR4
        Task Execute();
#else
        void Execute();
#endif

        /// <summary>
        /// Runs the template and returns the result.
        /// </summary>
        /// <param name="context">The current execution context.</param>
        /// <param name="writer"></param>
        /// <returns>The merged result of the template.</returns>
#if RAZOR4
        Task Run(ExecuteContext context, TextWriter writer);
#else
        void Run(ExecuteContext context, TextWriter writer);
#endif

        /// <summary>
        /// Writes the specified object to the result.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void Write(object value);

        /// <summary>
        /// Writes the specified string to the result.
        /// </summary>
        /// <param name="literal">The literal to write.</param>
        void WriteLiteral(string literal);
        #endregion
    }
}