namespace MonoPong
{
    internal class GameObjects
    {
        public AbstractPaddle2D PlayerPaddle { get; set; }
        public AbstractPaddle2D AiPaddle { get; set; }
        public Ball2D Ball { get; set; }

        public Score Score { get; set; }
    }
}