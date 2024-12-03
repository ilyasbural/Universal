namespace Universal.Core
{
    public class EmojiRegisterDto
    {

    }

    public class EmojiUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class EmojiDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class EmojiSelectDto
    {
        public Guid Id { get; set; }
    }
}