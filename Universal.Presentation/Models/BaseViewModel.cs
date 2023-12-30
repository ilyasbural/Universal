namespace Universal.Presentation
{
    public class BaseViewModel<T>
    {
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}