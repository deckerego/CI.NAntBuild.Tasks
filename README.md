NAnt Task for MSTest Code Coverage Reporting
============================================

A NAnt task for transforming MSTest's binary code coverage report to XML. The task outputs a serialized DataSet; you will probably need to run an XSL transform to get it into a useful format. See `MSTestCoverageToEmma.xsl` for an example of converting to the format used by Jenkin's Emma plugin.

This NAnt task is forked from Gareth Redman's CI.MSBuild.Tasks project, which adapted the code provided by http://archive.msdn.microsoft.com/vscoveragetoxmltask and http://wiki.hudson-ci.org/display/HUDSON/MSTest+Coverage+Reports to permit the use of Visual Studio 2010.

See `Example.build` for usage.

Building
--------

Building this task requires the following dependencies:
* NAnt Core libraries
* Visual Studio 2010 Code Coverage Test library

These assemblies are not included as part of this project. The Visual Studio Code Coverage library should be provided as part of Visual Studio Premium or Ultimate (or whatever) and will be auto-magically detected as a project reference. The NAnt Core libraries can be provided by NuGet or the like.

Installing
----------

To install this task, you need to ensure the following are dropped into your NAnt installation directory:
* This assembly (CI.NAntBuild.Tasks.dll)
* The Visual Studio 2010 Code Coverage Test library mentioned above (Microsoft.VisualStudio.Coverage.Analysis.dll)
* A runtime-only dependency on the Visual Studio 2010 Code Coverage Symbols library which ships with Visual Studio 2010 (Microsoft.VisualStudio.Coverage.Symbols.dll)

A runtime dependency of this task is the Microsoft.VisualStudio.Coverage.Symbols library, which ships with Visual Studio 2010. Ensure this is deployed alongside the CI.NAntBuild.Tasks assembly, else you may get "Unable to load DLL 'Microsoft.VisualStudio.Coverage.Symbols.dll'" exceptions at runtime.
