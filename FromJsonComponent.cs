using System;
using Grasshopper.Kernel;
using Newtonsoft.Json.Linq;

namespace ru.Mathrioshka.ghJSON
{
    public class FromJsonComponent : GH_Component
    {

        public FromJsonComponent():base("FromJSON", "FromJSON", "Parse JSON string", "Data", "JSON"){}

        public override Guid ComponentGuid
        {
            get { return new Guid("475E86C2-41FA-4F8E-9C7C-07E1E0AE06A9"); }
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("JSON", "J", "JSON string", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("JObject", "JO", "JSON Object", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            string jsonString = null;

            if (!da.GetData(0, ref jsonString)) { return; }

            if(String.IsNullOrEmpty(jsonString)) return;

            var jsonObject = JObject.Parse(jsonString);

            da.SetData(0, jsonObject);
        }
    }
}
