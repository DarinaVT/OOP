public abstract class LoanRequest
{
    protected LoanRequest _next;
    public void SetNext(LoanRequest next)
    {
        _next = next;
    }
    public abstract void Manage(decimal amount, Client client);
}
