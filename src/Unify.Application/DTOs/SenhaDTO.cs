namespace Unify.Application.DTOs
{
    public class SenhaDTO
    {
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}

