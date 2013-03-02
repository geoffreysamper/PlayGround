using System;
using System.Globalization;
using System.IO;
using System.Web.Compilation;
using System.Web.Mvc;

namespace AspnetCompilationMode
{
    public abstract class MyBuildManagerView : IView
    {
        // Fields
        private ControllerContext _controllerContext;
        internal IViewPageActivator ViewPageActivator;

        // Methods
        protected MyBuildManagerView(ControllerContext controllerContext, string viewPath) : this(controllerContext, viewPath, null)
        {
        }

        protected MyBuildManagerView(ControllerContext controllerContext, string viewPath, IViewPageActivator viewPageActivator) : this(controllerContext, viewPath, viewPageActivator, null)
        {
        }

        internal MyBuildManagerView(ControllerContext controllerContext, string viewPath, IViewPageActivator viewPageActivator, IDependencyResolver dependencyResolver)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (string.IsNullOrEmpty(viewPath))
            {
                throw new ArgumentException("MvcResources.Common_NullOrEmpty", "viewPath");
            }
            this._controllerContext = controllerContext;
            this.ViewPath = viewPath;
            this.ViewPageActivator = viewPageActivator ?? new MyBuildManagerView.DefaultViewPageActivator(dependencyResolver);
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException("viewContext");
            }
            object instance = null;
            Type compiledType = BuildManager.GetCompiledType(this.ViewPath);
            if (compiledType != null)
            {
                instance = this.ViewPageActivator.Create(this._controllerContext, compiledType);
            }
            
             //follow code is added to so that we can support the CompilationMode="Never"
            else if (compiledType == null)
            {
                if (this.ViewPath.EndsWith(".ascx"))
                {
                 instance=   BuildManager.CreateInstanceFromVirtualPath(this.ViewPath, typeof(ViewUserControl));
                }
                else if (this.ViewPath.EndsWith(".aspx"))
                {
                  instance=  BuildManager.CreateInstanceFromVirtualPath(this.ViewPath, typeof(ViewPage));
                }

            }
            if (instance == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "MvcResources.CshtmlView_ViewCouldNotBeCreated", new object[] { this.ViewPath }));
            }
            this.RenderView(viewContext, writer, instance);
        }

        protected abstract void RenderView(ViewContext viewContext, TextWriter writer, object instance);

        public string ViewPath { get; protected set; }

        // Nested Types
        internal class DefaultViewPageActivator : IViewPageActivator
        {
            // Fields
            private Func<IDependencyResolver> _resolverThunk;

            // Methods
            public DefaultViewPageActivator() : this(null)
            {
            }

            public DefaultViewPageActivator(IDependencyResolver resolver)
            {
                Func<IDependencyResolver> func = null;
                if (resolver == null)
                {
                    this._resolverThunk = () => DependencyResolver.Current;
                }
                else
                {
                    if (func == null)
                    {
                        func = () => resolver;
                    }
                    this._resolverThunk = func;
                }
            }

            public object Create(ControllerContext controllerContext, Type type)
            {
                return (this._resolverThunk().GetService(type) ?? Activator.CreateInstance(type));
            }
        }
    }
}