namespace EasyRoomServiceApi.Response
{
    public class FriendResponse
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int FriendID { get; set; }
        public bool FriendStatus { get; set; }
    }
}
