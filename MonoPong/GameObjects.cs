namespace MonoPong
{
    internal class GameObjects
    {
        public AbstractPaddle2D PlayerPaddle { get; set; }
        public AbstractPaddle2D AiPaddle { get; set; }
        public Ball2D Ball { get; set; }
        public Score Score { get; set; }
        public TouchInput TouchInput { get; set; }
    }

    public class TouchInput
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Tapped { get; set; }
    }
}