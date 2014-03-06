import Rhino
import System

gh = Rhino.RhinoApp.GetPlugInObject("Grasshopper")
gh.LoadEditor()
gh.ShowEditor()
gh.OpenDocument("D:/Dropbox/Mathrioshka Code/ghJSON/examples/JSON Example.ghx")