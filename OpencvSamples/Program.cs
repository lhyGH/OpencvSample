using OpencvSamples.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpencvSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            ISample sample =
            //new DetectionImg();
            //new DetectionImg2();
            new DetectionImgDog();
            sample.Run();
        }
    }
}
