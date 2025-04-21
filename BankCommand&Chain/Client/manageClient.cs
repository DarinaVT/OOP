public abstract class ManageClient
{
    protected ManageClient _next;
    public void SetNext(ManageClient next)
    {
        _next = next;
    }
    public virtual void Manage(Client client, decimal balance)
    {
        if (_next != null)
        {
            _next.Manage(client, balance);
        }
    }
}
