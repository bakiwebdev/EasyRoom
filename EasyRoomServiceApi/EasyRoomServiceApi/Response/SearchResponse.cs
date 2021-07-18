namespace EasyRoomServiceApi.Response
{
    public class SearchResponse
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool Status { get; set; }
    }
}
