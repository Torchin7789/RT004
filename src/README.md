# Pilot source code
You can use the files in this directory as a starting point for your
own solution.

## The `src` directory
Includes the `rt004` project - a command-line program that can create
HDR files. This is a good starting point for your future raytracer.

Used platform is `.NET 8.0 Command line` with simple helpers:
* `FloatImage.cs` - HDR raster image stored in memory, able to export to
  the `.pfm` format.
* `Util.cs` - math and geometric support (intersections).
* Mathematics package `OpenTK.Mathematics` for simple types
  (vectors, matrices...) based on the `double` floating point type.

## The `shared` directory
The `FloatImage.cs` and `Util.cs` file are the only support files so far.
