namespace Universal.Common
{
	public class Response<T>
	{
		public Response() { }















		public T Data { get; set; } = default(T)!;
		public List<T> Collection { get; set; } = null!;
		public bool IsValidationError { get; set; }
		public int Success { get; set; } = 0;
		public string Message { get; set; } = null!;
	}
}