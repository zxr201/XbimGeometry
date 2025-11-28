using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Geometry.Abstractions;
using Xbim.Ifc;
using Xbim.ModelGeometry.Scene;

namespace XbimRegression
{
    class Program
    {
        private static void Main(string[] args)
        {

            // ContextTesting is a class that has been temporarily created to test multiple files
            // ContextTesting.Run();
            // return;

            //var arguments = new Params(args);
            //if (!arguments.IsValid)
            //    return;

            //var processor = new BatchProcessor(arguments);
            //processor.Run();

            var filePath = @"D:\project\32.xbimD6\chart\ifcTriangulatedFaceSet\3W住宅-建筑专业-参照多专业(上海ifc-建筑)\3W住宅-建筑专业-参照多专业(上海ifc-建筑).ifc";
            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .SetMinimumLevel(LogLevel.Trace)     // 控制最小输出级别
                    .AddConsole();                       // 输出到控制台
            });

            using (var m = IfcStore.Open(filePath))
            {
                var start = DateTime.Now;

                Xbim3DModelContext context = new Xbim3DModelContext(m, loggerFactory, engineVersion: XGeometryEngineVersion.V6);
                context.MaxThreads = 1;
                context.CreateContext(null);

                var end = DateTime.Now;
                var time = end - start;
                var s = time.TotalSeconds;
            }
        }

    }
}
