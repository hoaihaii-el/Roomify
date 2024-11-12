namespace RoomifyAR.Requests
{
    public class TaskCreateModelRequest
    {
        public int ProductId { get; set; }
        public List<string> Images { get; set; } = [];
    }
}
