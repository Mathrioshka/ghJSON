import Rhino
import System

gh = Rhino.RhinoApp.GetPlugInObject("Grasshopper")
gh.LoadEditor()
gh.ShowEditor()
gh.OpenDocument("D:/test.gh")