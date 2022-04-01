using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantums_adventure.model
{
    public class Player : MovingGameObject

    {

        public Player(GameField field, CellLocation location, Facing facing) : base(field, location, facing)

        {

        }

    }
}
