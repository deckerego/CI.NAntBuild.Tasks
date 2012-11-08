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
        [TaskAttribute("coveragefiles", Required=true)]
        public string[] CoverageFiles { get; set; }

		[TaskAttribute("symbolsdirectory", Required = true)]
        public string SymbolsDirectory { get; set; }

        [TaskAttribute("outputdirectory", Required = true)]
        public string OutputDirectory { get; set; }

        protected override void ExecuteTask()
        {
            foreach (string sourceFile in CoverageFiles)
            {
                try
                {
                    if (File.Exists(sourceFile))
                    {
						string symbolsDir = SymbolsDirectory ?? Path.GetDirectoryName(sourceFile);

                        using (CoverageInfo info = CoverageInfo.CreateFromFile(
                            sourceFile, executablePaths: new [] { symbolsDir }, symbolPaths: new [] {symbolsDir}))
                        {
                            CoverageDS dataSet = info.BuildDataSet(null);
                            string outputFile = Path.ChangeExtension(sourceFile, "xml");

                            // Unless an output dir is specified
                            // the converted files will be stored in the same dir
                            // as the source files, with the .XML extension
                            if (OutputDirectory != null)
                            {
                                outputFile = Path.Combine(OutputDirectory, Path.GetFileName(outputFile));
                            }

                            dataSet.WriteXml(outputFile);
                        }
                    }
                    else
                    {
						Console.WriteLine(string.Format("{0} does not exist, cannot generate code coverage file", sourceFile));
                    }
                }
                catch (Exception e)
                {
					Console.WriteLine(string.Format("Exception generating code coverage XML: {0}", e.Message));
                }
            }
        }
    }
}
