namespace EasyRoomServiceApi.Request
{
    public class RegisterRequest
    {
        public int UserID { get; set; }
        public int PostID { get; set; }
        //sometimes
        public bool Status { get; set; }
    }
}
