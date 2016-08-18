namespace CACore.View
{
    public interface IToastMessage
    {
        string Message { get; set; }
        string Caption { get; set; }

        void Execute();

    }

    public class SimpleToastMessage : IToastMessage
    {
        public string Message { get; set; }
        public string Caption { get; set; }
        public void Execute()
        {
            
        }
    }
}
