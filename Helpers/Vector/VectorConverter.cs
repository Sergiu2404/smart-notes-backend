namespace smart_notes_backend.Helpers.Vector
{
    public class VectorConverter
    {
        public static byte[] ToByteArray(float[] floats)
        {
            var bytes = new byte[floats.Length * sizeof(float)];
            Buffer.BlockCopy(floats, 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static float[] FromByteArray(byte[] bytes)
        {
            var floats = new float[bytes.Length / sizeof(float)];
            Buffer.BlockCopy(bytes, 0, floats, 0, bytes.Length);
            return floats;
        }
    }
}
