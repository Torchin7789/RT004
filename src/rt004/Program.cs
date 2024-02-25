using Util;

namespace rt004;

internal class Program
{
  static void Main(string[] args)
  {
    // Parameters.
    // TODO: parse command-line arguments and/or your config file.
    int wid = 600;
    int hei = 450;
    string fileName = "demo.pfm";

    // HDR image.
    FloatImage fi = new(wid, hei, 3);

    // TODO: put anything interesting into the image.

    // Example - putting one red pixel close to the upper left corner...
    float[] red = { 1.0f, 0.1f, 0.1f };   // R, G, B
    fi.PutPixel(1, 1, red);

    // Save the HDR image.
    if (fileName.EndsWith(".hdr"))
      fi.SaveHDR(fileName);     // HDR format is still buggy
    else
      fi.SavePFM(fileName);     // PFM format works well

    Console.WriteLine($"HDR image '{fileName}' is finished.");
  }
}
