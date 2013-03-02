using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AspnetCompilationMode
{
    public class RecompilationsControl: Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
           var type =  Type.GetType(
                "System.Web.Compilation.DiskBuildResultCache,System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
           
            int recompilations =(int) type.GetField("s_recompilations", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetValue(null);
            int recompilationsBeforeRestart = (int)type.GetField("s_maxRecompilations", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetValue(null);

            writer.Write("<div style='color:red;font-weight:bold'>recompilations: {0}</div>", recompilations);
            writer.Write("<div style='color:red;font-weight:bold'>max recompilations before restart: {0}</div>", recompilationsBeforeRestart);
            
            base.Render(writer);
        }
    }
}