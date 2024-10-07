namespace ClassLibrary;

public class UpdatedEventArgs : EventArgs
{
    public DateTime TimeChanged { get; set; }

    public UpdatedEventArgs(DateTime timeChanged)
    {
        TimeChanged = timeChanged;
    }
}