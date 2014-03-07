using System;
using System.Drawing;
using System.Linq;
using Grasshopper.Kernel;
using JsonPath;
using Newtonsoft.Json.Linq;

namespace ru.Mathrioshka.ghJSON
{
    public class JPathComponent : GH_Component
    {
        private readonly JsonPathContext FParser = new JsonPathContext { ValueSystem = new JsonNetValueSystem() };
       
        public JPathComponent():base("JSON Path", "JPath", "Get data from JObject by JPath query", "Extra", "JSON") {}

        public override Guid ComponentGuid
        {
            get { return new Guid("82E4C254-1A3E-457F-AD8B-80A824E3A53E"); }
        }

        protected override Bitmap Icon { get { return Icons.JPath; } }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("JObject", "JO", "JSON Object", GH_ParamAccess.item);
            pManager.AddTextParameter("JSONPath Query", "JPQ", "JSONPath query for the needed data", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Data", "D", "Result Data", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            JObject jsonObject = null;
            string jpathQuery = null;

            if (!da.GetData(0, ref jsonObject) || !da.GetData(1, ref jpathQuery)) return;

            if (jsonObject == null || String.IsNullOrEmpty(jpathQuery)) return;

            var values = FParser.SelectNodes(jsonObject, jpathQuery).Select(node => node.Value.ToString()).ToList();

            da.SetDataList(0, values);
        }
    }
}
