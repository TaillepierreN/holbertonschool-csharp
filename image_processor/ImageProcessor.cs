using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


/// <summary>
/// Processes images.
/// </summary>
class ImageProcessor
{
    /// <summary>
    /// Inverts the colors of the images.
    /// </summary>
    /// <param name="filenames"></param>
    public static void Inverse(string[] filenames)
    {
        foreach (string filename in filenames)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(filename);

                byte[] invertedData = InvertColors(imageData);

                string outputFilename = $"{Path.GetFileNameWithoutExtension(filename)}_inverse{Path.GetExtension(filename)}";
                File.WriteAllBytes(outputFilename, invertedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Inverts the colors of the images asynchronously.
    /// </summary>
    private static byte[] InvertColors(byte[] imageData)
    {
        byte[] invertedData = new byte[imageData.Length];
        for (int i = 0; i < imageData.Length / 4; i++)
        {
            int x = i * 4;
            invertedData[x] ^= 0xFF;
            invertedData[x + 1] ^= 0xFF;
            invertedData[x + 2] ^= 0xFF;
            invertedData[x + 3] ^= 0xFF;
        }
        return invertedData;
    }

    /// <summary>
    /// Converts each image to grayscale.
    /// </summary>
    /// <param name="filenames">Array of image filenames to process.</param>
    public static void Grayscale(string[] filenames)
    {
        foreach (string filename in filenames)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(filename);

                byte[] grayedData = GrayscaleColors(imageData);

                string outputFilename = $"{Path.GetFileNameWithoutExtension(filename)}_grayscale{Path.GetExtension(filename)}";
                File.WriteAllBytes(outputFilename, grayedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Converts the colors of the image to grayscale.
    /// </summary>
    /// <param name="imageData"></param>
    private static byte[] GrayscaleColors(byte[] imageData)
    {
        byte[] grayedData = new byte[imageData.Length];
        for (int i = 0; i < imageData.Length / 4; i++)
        {
            int x = i * 4;
            int grayValue = (int)(0.3 * imageData[x] + 0.59 * imageData[x + 1] + 0.11 * imageData[x + 2]);

            grayedData[x] = (byte)grayValue;
            grayedData[x + 1] = (byte)grayValue;
            grayedData[x + 2] = (byte)grayValue;
            grayedData[x + 3] = imageData[x + 3];
        }

        return grayedData;
    } 

    /// <summary>
    /// Converts each image to black and white.
    /// </summary>
    /// <param name="filenames"></param>
    /// <param name="threshold"></param>
    public static void BlackWhite(string[] filenames, double threshold)
    {
        foreach (string filename in filenames)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(filename);

                byte[] blackAndWhiteData = BlackWhiteColors(imageData, threshold);

                string outputFilename = $"{Path.GetFileNameWithoutExtension(filename)}_bw{Path.GetExtension(filename)}";
                File.WriteAllBytes(outputFilename, blackAndWhiteData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {filename}: {ex.Message}");
            }
        }
    }
    private static byte[] BlackWhiteColors(byte[] imageData, double threshold)  
    {
        byte[] blackAndWhiteData = new byte[imageData.Length];
        for (int i = 0; i < imageData.Length / 4; i++)
        {
            int x = i * 4;
            double luminance = (double)(imageData[x] * 65536 + imageData[x + 1] * 256 + imageData[x + 2]);  
            double modifiedColor = (luminance >= threshold) ? 255 : 0;

            blackAndWhiteData[x] = (byte)modifiedColor;
            blackAndWhiteData[x + 1] = (byte)modifiedColor;
            blackAndWhiteData[x + 2] = (byte)modifiedColor;
            blackAndWhiteData[x + 3] = imageData[x + 3];
        }

        return blackAndWhiteData;
    }
}
