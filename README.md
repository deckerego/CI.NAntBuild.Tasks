MSBuild task for extracting coverage XML from MSTest runs.  Outputs a
serialized DataSet; you will probably need to run an XSL transform to get it
into a useful format (see `MSTestCoverageToEmma.xsl`).

Based off http://archive.msdn.microsoft.com/vscoveragetoxmltask and
http://wiki.hudson-ci.org/display/HUDSON/MSTest+Coverage+Reports, just updated
for VS2010.

See `Example.msbuild` for usage.
