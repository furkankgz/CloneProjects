using MyGrid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private NumberController _numberPrefab; // spawn edeceðimiz nesne

    private bool _isPressLeft => Input.GetKeyDown(KeyCode.A);
    private bool _isPressRight => Input.GetKeyDown(KeyCode.D);
    private bool _isPressUp => Input.GetKeyDown(KeyCode.W);
    private bool _isPressDown => Input.GetKeyDown(KeyCode.S);

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (_isPressLeft)
            Move(Direction.Left);

        if (_isPressRight)
            Move(Direction.Right);

        if(_isPressUp)
            Move(Direction.Up);

        if(_isPressDown)
            Move(Direction.Down);   
    }

    private void Move(Direction direction)
    {

        foreach (var tile in GridManager.Instance.listTile)
        {
            tile.isNew = false;
        }

        List<GameObject> listDestroy = new List<GameObject>();

        var result = GridManager.Instance.GetPriorityTile(direction);

        foreach (var listTile in result)
        {
            foreach (var tile in listTile)
            {
                if (tile._numberController) // hareket ettiðin yöndeki kutucuklar dolu ise oraya kadar hareket et
                {
                    bool isMerge = false;
                    TileController target = tile;
                    TileController next = tile;

                    for(int i = 0; i < 4; i++)
                    {
                        next = next.GetNeighbour(direction);
                        if (next == null) break;
                        if (next._numberController)
                        {

                            if (next._numberController.Number == tile._numberController.Number && !next.isNew)
                            {
                                isMerge = true;
                                target = next;
                            }

                            break;
                        } 
                        target = next;  
                    }

                    if (isMerge)
                    {
                        var value = tile._numberController.Number;
                        listDestroy.Add(tile._numberController.gameObject);
                        listDestroy.Add(target._numberController.gameObject);
                        tile._numberController = null;
                        target._numberController = null;
                        value++;
                        Spawn2(target, value);
                        continue;
                    }

                    if (target == tile) continue;

                    target._numberController = tile._numberController;
                    tile._numberController = null;
                    target._numberController.transform.position = target.transform.position;
                    
                }
            }
        }

        foreach (var item in listDestroy)
        {
            Destroy(item);
        }

        Spawn();
    }

    public void Spawn2(TileController tileController, int numberValue)
    {
        var number = Instantiate(_numberPrefab);
        number.Number = numberValue;

        number.transform.position = tileController.transform.position;
        tileController._numberController = number;
        tileController.isNew = true;
    }

    [ContextMenu(nameof(Spawn))] // bu sayede editörden direkt olarak bu fonksiyonu çaðýrabiliriz
    public void Spawn()
    {
        // number üret ve grid sisteminde random bir yerde spawn olsun
        var number = Instantiate(_numberPrefab);

        var isOne = Random.value < .75; // 4'te 1 ihtimalle 4 gelir
        number.Number = isOne ? 1 : 2;

        var listEmptyTile = GridManager.Instance.GetListEmptyTile();    // bana grid sisteminden boþ kutucuklarý ver

        if (listEmptyTile.Count != 0)
        {            
            var index = Random.Range(0, listEmptyTile.Count);
            var tile = listEmptyTile[index];
            tile._numberController = number;
            number.transform.position = tile.transform.position;
        }
        else
        {
            Debug.Log("Not found empty tile");
        }
        
    }
}
