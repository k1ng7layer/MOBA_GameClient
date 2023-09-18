using Views;

namespace Services.GameField
{
    public interface IGameFieldProvider
    {
        GameFieldView Field { get; }
    }
}