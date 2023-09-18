using Views;

namespace Services.GameField.Impl
{
    public class GameFieldProvider : IGameFieldProvider
    {
        public GameFieldProvider(GameFieldView field)
        {
            Field = field;
        }

        public GameFieldView Field { get; }
    }
}