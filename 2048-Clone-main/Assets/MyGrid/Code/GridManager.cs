using System.Collections.Generic;
using UnityEngine;

namespace MyGrid
{
	public class GridManager : MonoBehaviour
	{
		public static GridManager Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
		}

		public List<TileController> Tiles => listTile;
		public List<TileController> listTile;

		public List<List<TileController>> GetPriorityTile(Direction direction)
		{
			var result = new List<List<TileController>>();
			

			var isMax = direction == Direction.Up || direction == Direction.Right;
			var isVertical = direction == Direction.Up || direction == Direction.Down;

			int current = isMax ? 3 : 0;

			for (int i = 0; i < 4; i++)
			{
                var list = new List<TileController>();

                foreach (var tile in listTile)
				{
					var coordinate = isVertical ? tile.coordinate.y : tile.coordinate.x;
					if (coordinate == current)
					{ 
						list.Add(tile);
					}
						
				}
				result.Add(list);
				current += isMax ? -1 : 1;
			}

			return result;
		}

		public TileController GetTile(Vector2Int coordinate)
		{
			return listTile.Find(item => item.coordinate == coordinate);
		}

		public void SetTiles(List<TileController> tiles)
		{
			listTile = tiles;
		}

		public List<TileController> GetListEmptyTile()
		{
			var result = new List<TileController>();
			foreach (var tile in listTile)
			{
				if (!tile._numberController)
				{
					result.Add(tile);
				}
			}
			return result;
		}


	}
}