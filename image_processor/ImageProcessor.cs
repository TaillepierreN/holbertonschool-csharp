using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

class ImageProcessor
{
    public static void Inverse(string[] filenames)
    {
        Parallel.ForEach(filenames, filename =>
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(filename))
                {
                    Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                    BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

                    int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                    int stride = bmpData.Stride;
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = Math.Abs(stride) * bitmap.Height;
                    byte[] pixelBuffer = new byte[bytes];

                    System.Runtime.InteropServices.Marshal.Copy(ptr, pixelBuffer, 0, bytes);

                    for (int i = 0; i < pixelBuffer.Length; i += bytesPerPixel)
                    {
                        pixelBuffer[i] = (byte)(255 - pixelBuffer[i]);
                        pixelBuffer[i + 1] = (byte)(255 - pixelBuffer[i + 1]);
                        pixelBuffer[i + 2] = (byte)(255 - pixelBuffer[i + 2]);
                    }

                    System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, ptr, bytes);
                    bitmap.UnlockBits(bmpData);

                    string directory = Path.GetDirectoryName(filename);
                    string originalFilename = Path.GetFileNameWithoutExtension(filename);
                    string extension = Path.GetExtension(filename);
                    string invertedFilename = Path.Combine(directory, originalFilename + "_inverted" + extension);

                    bitmap.Save(invertedFilename);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing {0}: {1}", filename, ex.Message);
            }
        });
    }

    public static void Grayscale(string[] filenames)
    {
        Parallel.ForEach(filenames, filename =>
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(filename))
                {
                    Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                    BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

                    int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                    int stride = bmpData.Stride;
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = Math.Abs(stride) * bitmap.Height;
                    byte[] pixelBuffer = new byte[bytes];

                    System.Runtime.InteropServices.Marshal.Copy(ptr, pixelBuffer, 0, bytes);

                    for (int i = 0; i < pixelBuffer.Length; i += bytesPerPixel)
                    {
                        // Calculate grayscale value using the weighted average method
                        byte blue = pixelBuffer[i];
                        byte green = pixelBuffer[i + 1];
                        byte red = pixelBuffer[i + 2];
                        byte gray = (byte)(0.3 * red + 0.59 * green + 0.11 * blue);

                        pixelBuffer[i] = gray;
                        pixelBuffer[i + 1] = gray;
                        pixelBuffer[i + 2] = gray;
                    }

                    System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, ptr, bytes);
                    bitmap.UnlockBits(bmpData);

                    string directory = Path.GetDirectoryName(filename);
                    string originalFilename = Path.GetFileNameWithoutExtension(filename);
                    string extension = Path.GetExtension(filename);
                    string grayscaleFilename = Path.Combine(directory, originalFilename + "_grayscale" + extension);

                    bitmap.Save(grayscaleFilename);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing {0}: {1}", filename, ex.Message);
            }
        });
    }
}
