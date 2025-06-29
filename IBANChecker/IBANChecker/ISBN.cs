namespace ISBNChecker;

public class ISBN : IISBN
{
    public string ISBNCode { get; set; }
    public ISBN(string code)
    {
        ISBNCode = code;
    }

    public List<int> GetDigits()
    {
        List<int> digits = new List<int>();
        foreach(char c in ISBNCode)
        {
            if(c == '-')
            {
                continue;
            }
            else if(c == 'X' || c == 'x')
            {
                digits.Add(10);
            }
            else
            {
                int digit = int.Parse(c.ToString());
                digits.Add(digit);
            }
        }
        return digits;
    }

    public bool IsISBNValid()
    {
        List<int> isbn = GetDigits();
        int sum = 0;
        int multiplier = 10;
        for (int i = 0; i < isbn.Count; i++)
        {
            sum += isbn[i] *  multiplier;
            multiplier--;
        }
        if(sum % 11 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void PublisherRecords()
    {
        PublishingHouse publishingHouse = new PublishingHouse(ISBNCode);
    }
}