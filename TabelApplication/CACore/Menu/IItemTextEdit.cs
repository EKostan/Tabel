namespace CACore.Menu
{
    public enum ButtonEdit
    {
        None,
        Search
    }

    public interface IItemTextEdit : IItem
    {
        ButtonEdit ButtonEdit { get; set; }
        string Text { get; set; }
    }
}