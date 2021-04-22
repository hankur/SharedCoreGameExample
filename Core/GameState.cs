using System.Collections.Generic;

namespace Core
{
    public class GameState
    {
        public List<Player> Players { get; set; } = new();
        public Player NextPlayer { get; set; }
        public int Goal { get; set; }
    }
}