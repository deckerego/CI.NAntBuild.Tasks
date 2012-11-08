using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using CI.MSBuild.Tasks.Properties;
using NAnt.Core;
using NAnt.Core.Attributes;
using Microsoft.VisualStudio.Coverage.Analysis;

namespace CI.NAntBuild.Tasks
{
    [TaskName("convertvscoveragetoxml")]
    public class ConvertVSCoverageToXml : Task
    {
        [TaskAttribute("coveragefile", Required=true)]
        public string CoverageFile { get; set; }

		[TaskAttribute("symbolsdirectory", Required = true)]
        public string SymbolsDirectory { get; set; }

        [TaskAttribute("outputdirectory", Required = false)]
        public string OutputDirectory { get; set; }

        protected override void ExecuteTask()
        {
            try
            {
                if (File.Exists(CoverageFile))
                {
					Log(Level.Info, "Converting Visual Studio coverage file {0}", CoverageFile);

					string symbolsDir = SymbolsDirectory ?? Path.GetDirectoryName(CoverageFile);

                    using (CoverageInfo info = CoverageInfo.CreateFromFile(
                        CoverageFile, executablePaths: new [] { symbolsDir }, symbolPaths: new [] {symbolsDir}))
                    {
                        CoverageDS dataSet = info.BuildDataSet(null);
                        string outputFile = Path.ChangeExtension(CoverageFile, "xml");

                        // Unless an output dir is specified
                        // the converted files will be stored in the same dir
                        // as the source files, with the .XML extension
                        if (OutputDirectory != null)
                        {
                            outputFile = Path.Combine(OutputDirectory, Path.GetFileName(outputFile));
                        }

                        dataSet.WriteXml(outputFile);

						Log(Level.Info, "Written XML coverage file {0}", outputFile);
                    }
                }
                else
                {
					Log(Level.Error, "{0} does not exist, cannot generate code coverage file", CoverageFile);
                }
            }
            catch (Exception e)
            {
				Log(Level.Error, "Exception generating code coverage XML: {0}", e.Message);
            }
        }
    }
}
