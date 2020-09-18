using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBase;
namespace OpencvSamples.Samples
{
    public class DetectionImg2 : ISample
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
         
                        Cv2.Rectangle(result, new Point(face.X, face.Y), new Point(face.X + face.Width, face.Y + face.Height), new Scalar(0, 255, 0), 2,LineTypes.Link4);
                    }
                }
                return result;
            }
        }
    }
}
