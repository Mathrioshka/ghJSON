using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace ru.Mathrioshka.ghJSON.Helpers
{
    public class GetElementComponent : GH_Component
    {
        public GetElementComponent() : base("Get Element", "Element", "JSONPath helper. Get element from collection by index or range.", "Extra", "JSONPath") { }

        public override Guid ComponentGuid
        {
            get { return new Guid("0A17C4F3-A975-4045-90F2-D6E5FAAA197B"); }
        }

        protected override Bitmap Icon { get { return Icons.GetElement; } }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Collection", "C", "Objects collection", GH_ParamAccess.item);
            pManager.AddTextParameter("Collection", "I", "Index or index range like 0:2 or 0,1", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("JSONPath query", "JPQ", "JSONPath query for the needed data", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            string collection = null;
            string index = null;

            da.GetData(0, ref collection);
            da.GetData(1, ref index);

            if(String.IsNullOrEmpty(collection) || String.IsNullOrEmpty(index)) return;

            var jpq = String.Format(collection + "[{0}]", index);

            da.SetData(0, jpq);
        }
    }
}
