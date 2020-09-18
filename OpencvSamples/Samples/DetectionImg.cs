using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBase;
namespace OpencvSamples.Samples
{
    public class DetectionImg : ISample
    {
        public void Run()
        {
            var haarCascade = new CascadeClassifier(FilePath.Text.HaarCascade);
            Mat haarResult = DetectFace(haarCascade);
            Cv2.ImShow("Faces by Haar", haarResult);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
        private Mat DetectFace(CascadeClassifier cascade)
        {
            Mat result;
            using (var src = new Mat(FilePath.Image.Yalta, ImreadModes.Color))
            {
                using (var gray = new Mat())
                {
                    result = src.Clone();
                    Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
                    Rect[] fasces = cascade.DetectMultiScale(gray, 1.08, 2, HaarDetectionType.ScaleImage, new Size(30, 30));
                    foreach(Rect face in fasces)
                    {
                        var center = new Point
                        {
                            X = (int)(face.X + face.Width * 0.5),
                            Y = (int)(face.Y + face.Height * 0.5)
                        };
                        var axes = new Size
                        {
                            Width = (int)(face.Width * 0.5),
                            Height = (int)(face.Height * 0.5)
                        };
                        Cv2.Ellipse(result, center, axes, 0, 0, 360, new Scalar(255, 0, 255), 4);
                    }
                }
                return result;
            }
        }
    }
}
