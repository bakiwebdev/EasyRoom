namespace EasyRoomServiceApi.Response
{
    public class PostResponse
    {
        //post data to show
        public int PostID { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        //user data to show
        public int UserID { get; set; }
        public string Gender { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
