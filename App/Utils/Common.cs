using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace SP.Utils
{
    class Common
    {
        // 将Image转换为二进制序列  
        public static byte[] ImageToBytes(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            byte[] bytes = new Byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }

        // 将二进制序列转换为Image  
        public static Image BytesToImage(byte[] bytes)
        {
            try
            {
                using (Stream fStream = new MemoryStream(bytes.Length))
                {
                    BinaryWriter bw = new BinaryWriter(fStream);
                    bw.Write(bytes);
                    bw.Flush();
                    Bitmap bitMap = new Bitmap(fStream);
                    bw.Close();
                    fStream.Close();
                    Image image = Image.FromHbitmap(bitMap.GetHbitmap());
                    return image;
                }
            }
            catch (IOException ex)
            {
                throw new Exception("读取图片失败：" + ex.Message);

            }
        }
    }
}
