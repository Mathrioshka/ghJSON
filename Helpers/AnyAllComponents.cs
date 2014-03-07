using System;
using Grasshopper.Kernel;

namespace ru.Mathrioshka.ghJSON.Helpers
{

    public abstract class AbstractAnyAllComponent : GH_Component
    {
        protected AbstractAnyAllComponent(string name, string nickname, string description, string category, string subCategory) : base(name, nickname, description, category, subCategory) { }

        protected abstract string Action { get; }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Parent", "P", "Parent object", GH_ParamAccess.item, "$");
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("JSONPath query", "JPQ", "JSONPath query for the needed data", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            string parent = null;

            da.GetData(0, ref parent);

            if (String.IsNullOrEmpty(parent)) return;

            da.SetData(0, parent + "." + Action);
        }
    }

    public class AnyParentComponent : AbstractAnyAllComponent
    {
        public AnyParentComponent() : base("Any Parent", "AnyPrnt", "JSONPath helper. Insert into the path as any parent object.", "Extra", "JSONPath") { }

        public override Guid ComponentGuid
        {
            get { return new Guid("6C72158C-203E-44B2-A54C-E5617D0A8462"); }
        }

        protected override string Action
        {
            get { return ""; }
        }
    }

    public class AllComponent : AbstractAnyAllComponent
    {
        public AllComponent() : base("All Children", "AllChldrn", "JSONPath helper. Get all children from the parent object.", "Extra", "JSONPath") { }

        public override Guid ComponentGuid
        {
            get { return new Guid("30ECA708-4ACC-4113-BCFA-E75949FABEF1"); }
        }

        protected override string Action
        {
            get { return "*"; }
        }
    }
}
