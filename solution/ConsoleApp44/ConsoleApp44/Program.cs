using System;
using System.Globalization;
using System.IO;
using System.CommandLine;
using Newtonsoft.Json;
using OpenTK.Mathematics;
using System.Text;

namespace rt004;

internal class Program
{
    class Config
    {
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 450;
        public string OutputFile { get; set; } = "demo.pfm";
    }

    static void Main(string[] args)
    {
        var widthOption = new Option<int>("--width", () => 600, "Image width.");
        var heightOption = new Option<int>("--height", () => 450, "Image height.");
        var outputFileOption = new Option<string>("--output", () => "demo.pfm", "Output file name.");
        var configFileOption = new Option<string?>("--config", "Path to JSON config file.");

        var rootCommand = new RootCommand
        {
            widthOption,
            heightOption,
            outputFileOption,
            configFileOption
        };

        rootCommand.SetHandler((width, height, outputFile, configFile) =>
        {
            RunProgram(width, height, outputFile, configFile);
        }, widthOption, heightOption, outputFileOption, configFileOption);

        rootCommand.Invoke(args);
    }

    static void RunProgram(int width, int height, string outputFile, string? configFile)
    {
        Config config = new();

        if (!string.IsNullOrEmpty(configFile) && File.Exists(configFile))
        {
            string json = File.ReadAllText(configFile);
            config = JsonConvert.DeserializeObject<Config>(json) ?? new Config();
        }

        int wid = width != 600 ? width : config.Width;
        int hei = height != 450 ? height : config.Height;
        string fileName = outputFile != "demo.pfm" ? outputFile : config.OutputFile;

        Console.WriteLine($"Width: {wid}, Height: {hei}, Output: {fileName}");

        FloatImage fi = new(wid, hei, 3);

        for (int y = 0; y < hei; y++)
            for (int x = 0; x < wid; x++)
            {
                float r = (float)(0.5 + 0.5 * Math.Sin(x * 0.1));
                float g = (float)(0.5 + 0.5 * Math.Sin(y * 0.1));
                float b = (float)(0);
                fi.PutPixel(x, y, new[] { r, g, b });
            }

        if (fileName.EndsWith(".hdr"))
            fi.SaveHDR(fileName);
        else
            fi.SavePFM(fileName);


        Console.WriteLine($"HDR image '{fileName}' is finished.");
    }

    public class FloatImage
    {
        public int Width { get; }
        public int Height { get; }
        public int Channels { get; }
        private readonly float[] _data;

        public FloatImage(int width, int height, int channels)
        {
            Width = width;
            Height = height;
            Channels = channels;
            _data = new float[width * height * channels];
        }

        public void PutPixel(int x, int y, float[] color)
        {
            if (color.Length != Channels)
                throw new ArgumentException("Color array length must match the number of channels.");

            int index = (y * Width + x) * Channels;
            Array.Copy(color, 0, _data, index, Channels);
        }

        public void SavePFM(string filePath)
        {
            using var stream = new FileStream(filePath, FileMode.Create);
            using var writer = new StreamWriter(stream, Encoding.ASCII);

            writer.WriteLine("PF");
            writer.WriteLine($"{Width} {Height}");
            writer.WriteLine("-1.0"); 
            writer.Flush();

            byte[] byteArray = new byte[_data.Length * sizeof(float)];
            Buffer.BlockCopy(_data, 0, byteArray, 0, byteArray.Length);
            stream.Write(byteArray, 0, byteArray.Length);
        }

        public void SaveHDR(string filePath)
        {

        }

    }
}
