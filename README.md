NAnt Task for MSTest Code Coverage Reporting
============================================

A NAnt task for transforming MSTest's binary code coverage report to XML. The task outputs a serialized DataSet; you will probably need to run an XSL transform to get it into a useful format. See `MSTestCoverageToEmma.xsl` for an example of converting to the format used by Jenkin's Emma plugin.

This NAnt task is forked from Gareth Redman's CI.MSBuild.Tasks project, which adapted the code provided by http://archive.msdn.microsoft.com/vscoveragetoxmltask and http://wiki.hudson-ci.org/display/HUDSON/MSTest+Coverage+Reports to permit the use of Visual Studio 2010.

See `Example.build` for usage.
