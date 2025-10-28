namespace Core.Security.Hashing.Models
{
    public class HashResponse
    {
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
    }
}