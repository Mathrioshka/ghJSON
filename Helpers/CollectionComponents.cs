using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace ru.Mathrioshka.ghJSON.Helpers
{
    public abstract class CollectionComponent : GH_Component
    {
        protected CollectionComponent(string name, string nickname, string description, string category, string subCategory) : base(name, nickname, description, category, subCategory) { }

        protected abstract string Action { get; }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Collection", "C", "Objects collection", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("JSONPath query", "JPQ", "JSONPath query for the needed data", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            string collection = null;

            da.GetData(0, ref collection);

            if (String.IsNullOrEmpty(collection)) return;

            var jpq = String.Format(collection + "[{0}]", Action);

            da.SetData(0, jpq);
        }
    }

    public class AllElementsComponent : CollectionComponent
    {
        public AllElementsComponent() : base("All Elements", "All", "JSONPath helper. Get all elements from collection.", "Extra", "JSONPath"){}

        public override Guid ComponentGuid
        {
            get { return new Guid("1E2664AB-25FF-4A01-B5A3-09A4C89CC311"); }
        }

        protected override Bitmap Icon { get { return Icons.GetAllElements; } }

        protected override string Action
        {
            get { return "*"; }
        }
    }

    public class FirstElementComponent : CollectionComponent
    {
        public FirstElementComponent() : base("First Element", "First", "JSONPath helper. Get first element from collection.", "Extra", "JSONPath") { }

        public override Guid ComponentGuid
        {
            get { return new Guid("F017BC53-C63F-423D-9586-39DC40BB5293"); }
        }

        protected override Bitmap Icon { get { return Icons.GetFirstElement; } }

        protected override string Action
        {
            get { return "0"; }
        }
    }

    public class LastElementComponent : CollectionComponent
    {
        public LastElementComponent() : base("Last Element", "Last", "JSONPath helper. Get last element from collection.", "Extra", "JSONPath") { }

        public override Guid ComponentGuid
        {
            get { return new Guid("E572F4D1-ED02-4157-93C8-E8B7667212C5"); }
        }

        protected override Bitmap Icon { get { return Icons.GetLastElement; } }

        protected override string Action
        {
            get { return "-1:"; }
        }
    }
}
