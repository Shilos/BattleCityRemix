using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plan
{
		interface IGamerStat
		{
			string id_name { get; set; }
			int lives { get; set; }
			Position position { get; set; }
			Direction direction { get; set; }
			Teem teem { get; set; }
			Position bullet_position { get; set; }
		}

		interface IroomStat
		{
			string id { get; set; }
			int players_count { get; set; }
			string creator_player_name { get; set; }
		}

		interface ISender { }

		interface IMesegeQueue { }

		struct Position { float x; float y; }

		enum Direction { Left, Right, Up, Down }

		enum Teem { Red, Green }
}
