namespace GeographyPortal.Container.Messages
{
    public record MessageToSend
    {
        public string EmailAdress { get; init; }

        public string TextOfEmail { get; init; }

        public string Subject { get; init; }


    }
}
