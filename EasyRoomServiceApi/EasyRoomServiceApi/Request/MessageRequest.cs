namespace EasyRoomServiceApi.Request
{
    public class MessageRequest
    {
        public int FromID { get; set; }
        public int ToID { get; set; }
        public string Body { get; set; }
    }
}
