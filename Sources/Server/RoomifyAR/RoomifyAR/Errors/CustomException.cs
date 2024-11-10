namespace RoomifyAR.Errors
{
    public class CustomException : Exception
    {
        public CustomException(string msg) 
        {
            this.msg = msg;
        }

        private string msg;
        public override string Message => msg;
    }
}
