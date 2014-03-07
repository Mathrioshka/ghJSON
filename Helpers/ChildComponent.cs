using System;
using Grasshopper.Kernel;

namespace ru.Mathrioshka.ghJSON.Helpers
{
    public class ChildComponent : GH_Component
    {
        public ChildComponent() : base("Get Child", "Child", "JSONPath helper. Get child from object by name.", "Extra", "JSONPath") { }

        public override Guid ComponentGuid
        {
            get { return new Guid("7E57C608-E095-4F38-AFD5-41C84AA9A6F3"); }
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Parent", "P", "Parent object", GH_ParamAccess.item, "$");
            pManager.AddTextParameter("Object Name", "O", "Child object name", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("JSONPath query", "JPQ", "JSONPath query for the needed data", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            string parent = null;
            string oName = null;

            da.GetData(0, ref parent);
            da.GetData(1, ref oName);

            if (String.IsNullOrEmpty(parent) || String.IsNullOrEmpty(oName)) return;

            da.SetData(0, parent + "." + oName);
        }
    }
}
