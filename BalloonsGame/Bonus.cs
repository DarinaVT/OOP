
namespace BalloonPoppingGame;

class Bonus
{
    private Random _random = new Random();
    private int _chanceForBonus = 20;
    public int AddBonus(int dartCoefficient)
    {
        if(_random.Next(100) < _chanceForBonus)
        {
            int bonusCoefficient = dartCoefficient + 10;
            Console.WriteLine("Bonus points added to the dart (prev. coeff. {0}, coeff. now is {1})", dartCoefficient, bonusCoefficient);
            return bonusCoefficient;
        }
        return dartCoefficient;
    }
}
