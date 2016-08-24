namespace Contract
{
    public class ContractRecord : Record
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Object { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}