using System.Globalization;
using OpenTK.Mathematics;
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

    // Pilot: try to read one float number (3D camera rotation around the y axis)
    if (args.Length > 0 &&
        double.TryParse(args[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double angle))
    {
      // 3D intersection demo.
      double xMin = -1.0;
      double xMax =  1.0;
      double yMin = -(double)hei / wid;
      double yMax = -yMin;
      double inner = Math.Min(xMax, yMax);

      // AA box.
      Vector3d boxCorner = new(-inner * 0.6, -inner * 0.6, -inner * 0.6);
      Vector3d boxSize   = new( inner * 1.2,  inner * 1.2,  inner * 1.2);

      // Triangle in xy plane.
      Vector3d A = new(inner * -0.4, 0.0, 0.0);
      Vector3d B = new(inner * 0.3, inner * -0.3, 0.0);
      Vector3d C = new(inner * 0.1, inner * 0.3, 0.0);

      // Image synthesis.
      Vector3d p1  = new(0.0, 0.0, 1.0);     // orthographic ray direction (basic orientation = z)
      Vector3d P00 = new(xMin, yMax, -5.0);
      Vector3d dx  = new((xMax - xMin) / wid, 0.0, 0.0);
      Vector3d dy  = new(0.0, (yMin - yMax) / hei, 0.0);

      // TODO: camera rotation

      float[] boxColor = { 0.0f, 0.2f, 0.2f };      // bounding box color

      for (int y = 0; y < hei; y++)
      for (int x = 0; x < wid; x++)
      {
        Vector3d P0 = P00 + x * dx + y * dy;
        float[]? color = null;

        // 1. bounding box.
        if (MathUtil.RayBoxIntersection(P0, p1, boxCorner, boxSize, out _))
          color = boxColor;

        // 2. triangle.
        if (!double.IsInfinity(MathUtil.RayTriangleIntersection(P0, p1, A, B, C, out var uv)))
        {
          // Intersection exists at (1 - uv.X - uv.Y) * A + uv.X * B + uv.Y * C).
          color = new[]
          {
            (float)(1.0 - uv.X - uv.Y),
            (float)uv.X,
            (float)uv.Y
          };
        }
        
        if (color != null)
          fi.PutPixel(x, y, color);
      }
    }
    else
    {
      // Example - putting one red pixel close to the upper left corner...
      float[] red = { 1.0f, 0.1f, 0.1f };   // R, G, B
      fi.PutPixel(1, 1, red);
    }

    // Save the HDR image.
    if (fileName.EndsWith(".hdr"))
      fi.SaveHDR(fileName);     // HDR format is still buggy
    else
      fi.SavePFM(fileName);     // PFM format works well

    Console.WriteLine($"HDR image '{fileName}' is finished.");
  }
}
