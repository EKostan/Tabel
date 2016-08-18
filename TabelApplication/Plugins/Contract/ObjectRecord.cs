namespace Contract
{
    public class ObjectRecord : Record
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}